using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace D2R_CLONEHUNTER
{
    public partial class Form1 : Form
    {


        private D2R_IpAddressCountComparer _LoggedIPComparer;
        private List<D2R_IpAddressCountEntity> _LoggedIPAddressEntities;
        private List<D2R_IpAddressOccurenceEntity> _LoggedIPOccurences;

        private uint _CurrentVolume = 0;

        private bool _flagInGame = false;
        private string _lastInGameIPAddress = "";

        private DateTime _applicationStartedOn;

        private Hashtable _loggedIPAddresses = new Hashtable();
        private Hashtable _excludedIPAddresses = new Hashtable();
        private Hashtable _activeIPAddresses = new Hashtable();


        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        [DllImport("iphlpapi.dll", SetLastError = true)]
        static extern uint GetExtendedTcpTable(IntPtr pTcpTable, ref int dwOutBufLen, bool sort, int ipVersion, TCP_TABLE_CLASS tblClass, uint reserved = 0);

        [StructLayout(LayoutKind.Sequential)]
        public struct MIB_TCPTABLE_OWNER_PID
        {
            public uint dwNumEntries;
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 1)]
            public MIB_TCPROW_OWNER_PID[] table;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MIB_TCP6ROW_OWNER_PID
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] localAddr;
            public uint localScopeId;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] localPort;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] remoteAddr;
            public uint remoteScopeId;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] remotePort;
            public uint state;
            public uint owningPid;

            public uint ProcessId
            {
                get { return owningPid; }
            }

            public long LocalScopeId
            {
                get { return localScopeId; }
            }

            public IPAddress LocalAddress
            {
                get { return new IPAddress(localAddr, LocalScopeId); }
            }

            public ushort LocalPort
            {
                get { return BitConverter.ToUInt16(localPort.Take(2).Reverse().ToArray(), 0); }
            }

            public long RemoteScopeId
            {
                get { return remoteScopeId; }
            }

            public IPAddress RemoteAddress
            {
                get { return new IPAddress(remoteAddr, RemoteScopeId); }
            }

            public ushort RemotePort
            {
                get { return BitConverter.ToUInt16(remotePort.Take(2).Reverse().ToArray(), 0); }
            }

            public MIB_TCP_STATE State
            {
                get { return (MIB_TCP_STATE)state; }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MIB_TCP6TABLE_OWNER_PID
        {
            public uint dwNumEntries;
            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 1)]
            public MIB_TCP6ROW_OWNER_PID[] table;
        }

        public const int AF_INET = 2;    // IP_v4 = System.Net.Sockets.AddressFamily.InterNetwork
        public const int AF_INET6 = 23;  // IP_v6 = System.Net.Sockets.AddressFamily.InterNetworkV6

        public enum TCP_TABLE_CLASS
        {
            TCP_TABLE_BASIC_LISTENER,
            TCP_TABLE_BASIC_CONNECTIONS,
            TCP_TABLE_BASIC_ALL,
            TCP_TABLE_OWNER_PID_LISTENER,
            TCP_TABLE_OWNER_PID_CONNECTIONS,
            TCP_TABLE_OWNER_PID_ALL,
            TCP_TABLE_OWNER_MODULE_LISTENER,
            TCP_TABLE_OWNER_MODULE_CONNECTIONS,
            TCP_TABLE_OWNER_MODULE_ALL
        }

        public enum MIB_TCP_STATE
        {
            MIB_TCP_STATE_CLOSED = 1,
            MIB_TCP_STATE_LISTEN = 2,
            MIB_TCP_STATE_SYN_SENT = 3,
            MIB_TCP_STATE_SYN_RCVD = 4,
            MIB_TCP_STATE_ESTAB = 5,
            MIB_TCP_STATE_FIN_WAIT1 = 6,
            MIB_TCP_STATE_FIN_WAIT2 = 7,
            MIB_TCP_STATE_CLOSE_WAIT = 8,
            MIB_TCP_STATE_CLOSING = 9,
            MIB_TCP_STATE_LAST_ACK = 10,
            MIB_TCP_STATE_TIME_WAIT = 11,
            MIB_TCP_STATE_DELETE_TCB = 12
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MIB_TCPROW_OWNER_PID
        {
            public uint state;
            public uint localAddr;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] localPort;
            public uint remoteAddr;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] remotePort;
            public uint owningPid;

            public uint ProcessId
            {
                get { return owningPid; }
            }

            public IPAddress LocalAddress
            {
                get { return new IPAddress(localAddr); }
            }

            public ushort LocalPort
            {
                get
                {
                    return BitConverter.ToUInt16(new byte[2] { localPort[1], localPort[0] }, 0);
                }
            }

            public IPAddress RemoteAddress
            {
                get { return new IPAddress(remoteAddr); }
            }

            public ushort RemotePort
            {
                get
                {
                    return BitConverter.ToUInt16(new byte[2] { remotePort[1], remotePort[0] }, 0);
                }
            }

            public MIB_TCP_STATE State
            {
                get { return (MIB_TCP_STATE)state; }
            }
        }

        

        public static List<MIB_TCPROW_OWNER_PID> GetAllTCPConnections()
        {
            return GetTCPConnections<MIB_TCPROW_OWNER_PID, MIB_TCPTABLE_OWNER_PID>(AF_INET);
        }

        public static List<MIB_TCP6ROW_OWNER_PID> GetAllTCPv6Connections()
        {
            return GetTCPConnections<MIB_TCP6ROW_OWNER_PID, MIB_TCP6TABLE_OWNER_PID>(AF_INET6);
        }

        private static List<IPR> GetTCPConnections<IPR, IPT>(int ipVersion)//IPR = Row Type, IPT = Table Type
        {
            IPR[] tableRows;
            int buffSize = 0;

            var dwNumEntriesField = typeof(IPT).GetField("dwNumEntries");

            // how much memory do we need?
            uint ret = GetExtendedTcpTable(IntPtr.Zero, ref buffSize, true, ipVersion, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
            IntPtr tcpTablePtr = Marshal.AllocHGlobal(buffSize);

            try
            {
                ret = GetExtendedTcpTable(tcpTablePtr, ref buffSize, true, ipVersion, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
                if (ret != 0)
                    return new List<IPR>();

                // get the number of entries in the table
                IPT table = (IPT)Marshal.PtrToStructure(tcpTablePtr, typeof(IPT));
                int rowStructSize = Marshal.SizeOf(typeof(IPR));
                uint numEntries = (uint)dwNumEntriesField.GetValue(table);

                // buffer we will be returning
                tableRows = new IPR[numEntries];

                IntPtr rowPtr = (IntPtr)((long)tcpTablePtr + 4);
                for (int i = 0; i < numEntries; i++)
                {
                    IPR tcpRow = (IPR)Marshal.PtrToStructure(rowPtr, typeof(IPR));
                    tableRows[i] = tcpRow;
                    rowPtr = (IntPtr)((long)rowPtr + rowStructSize);   // next entry
                }
            }
            finally
            {
                // Free the Memory
                Marshal.FreeHGlobal(tcpTablePtr);
            }
            return tableRows != null ? tableRows.ToList() : new List<IPR>();
        }


        public MIB_TCPROW_OWNER_PID[] GetAllTcpConnections()
        {
            MIB_TCPROW_OWNER_PID[] tTable;
            int AF_INET = 2;    // IP_v4
            int buffSize = 0;

            // how much memory do we need?
            uint ret = GetExtendedTcpTable(IntPtr.Zero, ref buffSize, true, AF_INET, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
            IntPtr buffTable = Marshal.AllocHGlobal(buffSize);

            try
            {
                ret = GetExtendedTcpTable(buffTable, ref buffSize, true, AF_INET, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
                if (ret != 0)
                {
                    return null;
                }

                // get the number of entries in the table
                MIB_TCPTABLE_OWNER_PID tab = (MIB_TCPTABLE_OWNER_PID)Marshal.PtrToStructure(buffTable, typeof(MIB_TCPTABLE_OWNER_PID));
                IntPtr rowPtr = (IntPtr)((long)buffTable + Marshal.SizeOf(tab.dwNumEntries));
                tTable = new MIB_TCPROW_OWNER_PID[tab.dwNumEntries];

                for (int i = 0; i < tab.dwNumEntries; i++)
                {
                    MIB_TCPROW_OWNER_PID tcpRow = (MIB_TCPROW_OWNER_PID)Marshal.PtrToStructure(rowPtr, typeof(MIB_TCPROW_OWNER_PID));
                    tTable[i] = tcpRow;
                    rowPtr = (IntPtr)((long)rowPtr + Marshal.SizeOf(tcpRow));   // next entry
                }
            }
            finally
            {
                // Free the Memory
                Marshal.FreeHGlobal(buffTable);
            }
            return tTable;
        }


        public MIB_TCPROW_OWNER_PID[] _TcpConnections;


        public Form1()
        {
            InitializeComponent();

            _applicationStartedOn = DateTime.Now;

            _CurrentVolume = 0;
            waveOutGetVolume(IntPtr.Zero, out _CurrentVolume);

            ushort _CalcVol = (ushort)(_CurrentVolume & 0x0000ffff);
            // Get the volume on a scale of 1 to 10 (to fit the trackbar)
            trackVolumeChaching.Value = _CalcVol / (ushort.MaxValue / 100);

            _LoggedIPComparer = new D2R_IpAddressCountComparer();
            _LoggedIPComparer.SortDirection = D2R_IpAddressCountComparer.D2RIpAddressCountSortOrder.Descending;
            _LoggedIPComparer.WhichComparison = D2R_IpAddressCountComparer.D2RIpAddressCountComparisonType.OccurenceCount;
            
            _LoggedIPAddressEntities = new List<D2R_IpAddressCountEntity>();
            _LoggedIPOccurences = new List<D2R_IpAddressOccurenceEntity>();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private bool isIpAddressExcluded(string needle_ipaddress)
        {
            return _excludedIPAddresses.ContainsKey(needle_ipaddress); 
        }

        private void refreshTable()
        {
            lblCurrentIP.Text = "Checking...";

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            Process p = null;
            _activeIPAddresses = new Hashtable();
            foreach (MIB_TCPROW_OWNER_PID pid in _TcpConnections)
            {
                try
                {
                    if (p != null) { if (pid.ProcessId != p.Id) { p = Process.GetProcessById(Convert.ToInt32(pid.ProcessId)); } }
                    else { p = Process.GetProcessById(Convert.ToInt32(pid.ProcessId)); }

                    if (p.ProcessName.ToLowerInvariant() != "d2r") { continue; }
                    if (pid.State != MIB_TCP_STATE.MIB_TCP_STATE_ESTAB) { continue; }
                    if (pid.RemoteAddress.ToString() == "127.0.0.1") { continue; }
                    if (pid.RemoteAddress.ToString() == "34.117.122.6") { continue; }

                    if (pid.RemoteAddress.ToString().StartsWith("24.105.")) { continue; }
                    if (pid.RemoteAddress.ToString().StartsWith("137.")) { continue; }
                    if (pid.RemotePort.ToString() == "1119") { continue; }
                    if (_excludedIPAddresses.ContainsKey(pid.RemoteAddress.ToString())) { continue; }

                    if (!_activeIPAddresses.ContainsKey(pid.RemoteAddress.ToString()))
                    {
                        _activeIPAddresses.Add(pid.RemoteAddress.ToString(), 1);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            
            lstActiveIPs.Items.Clear();
            foreach (DictionaryEntry de in _activeIPAddresses) { lstActiveIPs.Items.Add(de.Key.ToString()); }

            if (_activeIPAddresses.Count < 1)
            {
                lblCurrentIP.Text = "Not in a Game ?";

                if (_flagInGame==true)
                { // We were in a game, and we seem to have left that game ip.
                    _flagInGame = false;

                    if (_lastInGameIPAddress.Length>0) 
                    {
                        addLog("Game has been exited on " + _lastInGameIPAddress);
                        _lastInGameIPAddress = "";
                    }
                    else 
                    {
                        addLog("Game has been exited");
                    }
                    
                }
            }
            else if (_activeIPAddresses.Count == 1)
            { // We may have joined a game
                if (_flagInGame==false)
                { // This confirm we have just joined a game
                    _lastInGameIPAddress = lstActiveIPs.Items[0].ToString();
                    _flagInGame = true;

                    addLog("Game has been join on " + _lastInGameIPAddress);

                    _LoggedIPOccurences.Add(new D2R_IpAddressOccurenceEntity(_lastInGameIPAddress, DateTime.Now));

                    if (txtDesiredIPAddress.Text.ToLowerInvariant()==_lastInGameIPAddress.ToLowerInvariant())
                    {
                        try
                        {
                            System.Media.SoundPlayer my_wave_file = new System.Media.SoundPlayer(D2R_CLONEHUNTER.Properties.Resources.cash2);
                            my_wave_file.PlaySync();
                        }
                        catch (Exception ex) {  }

                        addLog(">>> >>> GAME HAS BEEN FOUND ON THE RIGHT IP <<< <<<");
                    }

                    if (_loggedIPAddresses.ContainsKey(_lastInGameIPAddress))
                    {
                        _loggedIPAddresses[_lastInGameIPAddress] = Int32.Parse(_loggedIPAddresses[_lastInGameIPAddress].ToString()) + 1;
                    }
                    else
                    {
                        _loggedIPAddresses.Add(_lastInGameIPAddress, 1);
                    }

                    gvLoggedIPs.DataSource = null;
                    _LoggedIPAddressEntities = new List<D2R_IpAddressCountEntity>();
                    foreach (DictionaryEntry de in _loggedIPAddresses) {
                        D2R_IpAddressCountEntity _entity = new D2R_IpAddressCountEntity() { IPAddress = de.Key.ToString(), OccurenceCount = Int32.Parse(de.Value.ToString()) };
                        _LoggedIPAddressEntities.Add(_entity);
                    }


                    if (_LoggedIPAddressEntities.Count > 0)
                    {
                        _LoggedIPAddressEntities.Sort(_LoggedIPComparer);
                        gvLoggedIPs.DataSource = _LoggedIPAddressEntities;
                    }
                }

                lblCurrentIP.Text = lstActiveIPs.Items[0].ToString();
            }
            else if (_activeIPAddresses.Count > 1)
            {
                lblCurrentIP.Text = "Exclusion ?";
            }

            if (p != null)
            {
                try
                {
                    p.Dispose();
                }
                catch (Exception ex) { }
            }


            lblStatisticsTotalGames.Text = _LoggedIPOccurences.Count.ToString();
            lblStatisticsTotalUniqueIPs.Text = _LoggedIPAddressEntities.Count.ToString();
            lblStatisticsStartedOn.Text = _applicationStartedOn.ToString("yyyy-MM-dd HH:mm:ss");
            TimeSpan ts = DateTime.Now - _applicationStartedOn;
            lblStatisticsDuration.Text = 
                Math.Round(ts.TotalMinutes, 0) + " minute" + ((Math.Round(ts.TotalMinutes, 0) > 1) ? "s" : "");

            List<D2R_IpAddressCountEntity> _entities_copy = new List<D2R_IpAddressCountEntity>();
            _LoggedIPAddressEntities.ForEach((item) => { _entities_copy.Add(new D2R_IpAddressCountEntity(item)); });
            D2R_IpAddressCountComparer _entities_copy_comparer = new D2R_IpAddressCountComparer()
            {
                SortDirection = D2R_IpAddressCountComparer.D2RIpAddressCountSortOrder.Descending,
                WhichComparison = D2R_IpAddressCountComparer.D2RIpAddressCountComparisonType.OccurenceCount
            };
            _entities_copy.Sort(_entities_copy_comparer);

            if (_entities_copy.Count>0)
            {
                lblStatisticsMostSeenIP.Text = _entities_copy[0].IPAddress;
            }
            else
            {
                lblStatisticsMostSeenIP.Text = "N/A";
            }
        }
            

        private void Form1_Load(object sender, EventArgs e)
        {
            lblCurrentIP.Text = "Initializing";

            this.Text = "DiabloClone.ORG Active D2R Connections Viewer v " + Application.ProductVersion  + " - Join Our Discord Server @ https://discord.gg/FQrpzV8Smv";
            addLog("Application has Started.");
            addLog("Application version is : " + Application.ProductVersion);

            PingBlizzard();

            lblStatisticsTotalGames.Text = "N/A";
            lblStatisticsTotalUniqueIPs.Text = "N/A";
            lblStatisticsStartedOn.Text = "N/A";
            lblStatisticsMostSeenIP .Text = "N/A";
            lblStatisticsDuration.Text = "N/A";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (chkShowTicks.Checked)
            {
                addLog("Timer Tick.");
            }

            _TcpConnections = GetAllTcpConnections();

            refreshTable();


            


        }


        private void PingBlizzard()
        {
            try
            {

                AutoResetEvent waiter = new AutoResetEvent(false);

                Ping pingSender = new Ping();
                pingSender.PingCompleted += PingSender_PingCompleted;

                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "abcdefghijklmnopqrstuvwxyzabcdef";
                byte[] buffer = Encoding.ASCII.GetBytes(data);

                // Wait 10 seconds for a reply.
                int timeout = 10000;

                // Set options for transmission:
                // The data can go through 64 gateways or routers
                // before it is destroyed, and the data packet
                // cannot be fragmented.
                PingOptions options = new PingOptions(64, true);

                Console.WriteLine("Time to live: {0}", options.Ttl);
                Console.WriteLine("Don't fragment: {0}", options.DontFragment);

                // Send the ping asynchronously.
                // Use the waiter as the user token.
                // When the callback completes, it can wake up this thread.
                pingSender.SendAsync("blizzard.com", timeout, buffer, options, waiter);
            }
            catch (Exception ex)
            {

            }
        }

        private void PingSender_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            // If the operation was canceled, display a message to the user.
            if (e.Cancelled)
            {
                Console.WriteLine("Ping canceled.");

                // Let the main thread resume.
                // UserToken is the AutoResetEvent object that the main thread
                // is waiting for.
                ((AutoResetEvent)e.UserState).Set();
            }

            // If an error occurred, display the exception to the user.
            if (e.Error != null)
            {
                Console.WriteLine("Ping failed:");
                Console.WriteLine(e.Error.ToString());

                // Let the main thread resume.
                ((AutoResetEvent)e.UserState).Set();
            }

            PingReply reply = e.Reply;

            DisplayPingReply(reply);

            // Let the main thread resume.
            ((AutoResetEvent)e.UserState).Set();
        }

        private void DisplayPingReply(PingReply reply)
        {
            if (lblBlizzardPingReply.InvokeRequired)
            {
                Action safeDisplayPingReply = delegate { DisplayPingReply(reply); };
                lblBlizzardPingReply.Invoke(safeDisplayPingReply);
            }
            else
            {
                if (reply != null)
                {
                    if (reply.Status == IPStatus.Success)
                    {
                        lblBlizzardPingReply.Text = reply.RoundtripTime.ToString() + "ms";
                    }
                    else
                    {
                        lblBlizzardPingReply.Text = "N/A";
                    }
                }
                else
                {
                    lblBlizzardPingReply.Text = "N/A";
                }
            }


            
        }

        private void btnBuildExclusion_Click(object sender, EventArgs e)
        {
            try
            {
                _excludedIPAddresses = new Hashtable();

                addLog("Copying active IPs connection into exclusion list and removing any logged instance of these IPs.");

                if (_activeIPAddresses != null && _activeIPAddresses.Count > 0)
                {
                    _excludedIPAddresses = (Hashtable)_activeIPAddresses.Clone();
                }

                foreach (DictionaryEntry de in _excludedIPAddresses)
                {
                    if (_loggedIPAddresses.ContainsKey(de.Key.ToString()))
                    {
                        _loggedIPAddresses.Remove(de.Key.ToString());
                    }
                }

                gvLoggedIPs.DataSource = null;
                _LoggedIPAddressEntities = new List<D2R_IpAddressCountEntity>();
                foreach (DictionaryEntry de in _loggedIPAddresses)
                {
                    D2R_IpAddressCountEntity _entity = new D2R_IpAddressCountEntity() { IPAddress = de.Key.ToString(), OccurenceCount = Int32.Parse(de.Value.ToString()) };
                    _LoggedIPAddressEntities.Add(_entity);
                }

                if (_LoggedIPAddressEntities.Count > 0)
                {
                    _LoggedIPAddressEntities.Sort(_LoggedIPComparer);
                    gvLoggedIPs.DataSource = _LoggedIPAddressEntities;
                }


                lstExcludedIPs.Items.Clear();
                foreach (DictionaryEntry de in _excludedIPAddresses) { lstExcludedIPs.Items.Add(de.Key.ToString()); }
            }
            catch (Exception ex)
            {

            }
        }


        private void addLog(string data)
        {

            int textlimit = 32768;

            txtApplicationLogs.Text = txtApplicationLogs.Text + "["+DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "]  " + data + "\r\n";
            txtApplicationLogs.Select(txtApplicationLogs.TextLength, 0);
            txtApplicationLogs.ScrollToCaret();


            if (chkAutoTrimLogs.Checked)
            {
                if (txtApplicationLogs.TextLength > textlimit)
                {
                    txtApplicationLogs.Text = txtApplicationLogs.Text.Substring(txtApplicationLogs.TextLength - textlimit, textlimit);
                    txtApplicationLogs.Select(txtApplicationLogs.TextLength, 0);
                    txtApplicationLogs.ScrollToCaret();
                }
            }

        }

        private void chkShowTicks_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveSessionToDisk_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Application Name: " + Application.ProductName);
            sb.AppendLine("Application Version: " + Application.ProductVersion);
            sb.AppendLine("");

            sb.AppendLine("Show Timer Ticks: " + (chkShowTicks.Checked?"Yes":"No"));
            sb.AppendLine("Auto Trim Logs: " + (chkAutoTrimLogs.Checked ? "Yes" : "No"));
            sb.AppendLine("");

            sb.AppendLine("Session Started On: " + _applicationStartedOn.ToString("yyyy-MM-dd HH:mm"));
            sb.AppendLine("Session Exported On: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            sb.AppendLine("");

            sb.AppendLine("Excluded IPs: ");
            foreach (DictionaryEntry de in _excludedIPAddresses) { sb.AppendLine(de.Key.ToString()); }
            sb.AppendLine("");

            sb.AppendLine("Logged IPs: ");
            foreach (DictionaryEntry de in _loggedIPAddresses) { sb.AppendLine(de.Key.ToString() +" --> "+de.Value.ToString() + " times."); }
            sb.AppendLine("");

            sb.AppendLine("Latest Application Logs: ");
            sb.Append(txtApplicationLogs.Text);
            sb.AppendLine("");

            try
            {
                DateTime now = DateTime.Now;
                String filename = "logs-" + now.ToString("yyyy-MM-dd-HH-mm") + ".txt";
                System.IO.TextWriter sw = new System.IO.StreamWriter(filename);

                sw.Write(sb.ToString());

                sw.Close();
                sw.Dispose();

                MessageBox.Show(this, "Exported to " + filename, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {

            }


        }


        private void btnTestChaching_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer my_wave_file = new System.Media.SoundPlayer(D2R_CLONEHUNTER.Properties.Resources.cash2);
            my_wave_file.PlaySync();
            
            
        }

        private void trackVolumeChaching_Scroll(object sender, EventArgs e)
        {
            try
            {
                int NewVolume = ((ushort.MaxValue / 100) * trackVolumeChaching.Value);
                // Set the same volume for both the left and the right channels
                uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
                // Set the volume
                waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
            }
            catch (Exception ex) {  }
        }

        private void gvLoggedIPs_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                gvLoggedIPs.DataSource = null;
                this.Invalidate(true);
            }
            catch (Exception ex) { }

            try
            {
                D2R_IpAddressCountComparer.D2RIpAddressCountComparisonType currentType = D2R_IpAddressCountComparer.D2RIpAddressCountComparisonType.NULL;
                switch (e.ColumnIndex)
                {
                    case 0: { currentType = D2R_IpAddressCountComparer.D2RIpAddressCountComparisonType.IPAddress; break; }
                    case 1: { currentType = D2R_IpAddressCountComparer.D2RIpAddressCountComparisonType.OccurenceCount; break; }
                    
                }


                if (currentType != _LoggedIPComparer.WhichComparison)
                {
                    _LoggedIPComparer.SortDirection = D2R_IpAddressCountComparer.D2RIpAddressCountSortOrder.Ascending;
                }
                else
                {
                    _LoggedIPComparer.SortDirection = (_LoggedIPComparer.SortDirection == D2R_IpAddressCountComparer.D2RIpAddressCountSortOrder.Ascending) ? D2R_IpAddressCountComparer.D2RIpAddressCountSortOrder.Descending : D2R_IpAddressCountComparer.D2RIpAddressCountSortOrder.Ascending;
                }
                _LoggedIPComparer.WhichComparison = currentType;

                _LoggedIPAddressEntities.Sort(_LoggedIPComparer);

                if (_LoggedIPAddressEntities.Count > 0)
                {
                    gvLoggedIPs.DataSource = _LoggedIPAddressEntities;
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void tmrBlizzardPing_Tick(object sender, EventArgs e)
        {
            PingBlizzard();
        }
    }
}
