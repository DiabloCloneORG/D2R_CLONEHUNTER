using D2R_CLONEHUNTER.Properties;
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
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2R_CLONEHUNTER
{
    public partial class Form1 : Form
    {

        frmCidrSelector _frmCidrSelectorBlock; 
        frmCidrSelector _frmCidrSelectorAllow;

        frmIpRangeSelector _frmIpRangeSelectorBlock;
        frmIpRangeSelector _frmIpRangeSelectorAllow;

        /* SETTINGS SECTION */



        private D2R_IpAddressCountComparer _LoggedIPComparer;
        private List<D2R_IpAddressCountEntity> _LoggedIPAddressEntities;
        private List<D2R_IpAddressOccurenceEntity> _LoggedIPOccurences;

        private uint _CurrentVolume = 0;

        private int _TotalGamesJoined = 0;

        private bool _flagInGame = false;
        private string _lastInGameIPAddress = "";

        private DateTime _applicationStartedOn;
        private DateTime _lastGameJoinedOn;


        private Hashtable _loggedIPAddresses = new Hashtable();
        private Hashtable _excludedIPAddresses = new Hashtable();
        private Hashtable _activeIPAddresses = new Hashtable();

        private Hashtable _windowsFirewallBlockedCIDRs = new Hashtable();
        private Hashtable _windowsFirewallAllowedCIDRs = new Hashtable();

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

            if (!Settings.Default.SaveTotalGamesAndTotalTimeAcrossRestart)
            {
                _applicationStartedOn = DateTime.Now;
                Settings.Default.TotalTimeStartDateTime = _applicationStartedOn;
                Settings.Default.Save();
                Settings.Default.Reload();
            }
            else
            {
                if (Settings.Default.TotalTimeStartDateTime == (new DateTime(2000, 1, 1, 0, 0, 0)))
                {
                    _applicationStartedOn = DateTime.Now;
                    Settings.Default.TotalTimeStartDateTime = _applicationStartedOn;
                    Settings.Default.Save();
                    Settings.Default.Reload();
                }
                else
                {
                    _applicationStartedOn = Settings.Default.TotalTimeStartDateTime;
                }
                
                _TotalGamesJoined = Settings.Default.TotalGamesJoined;
            }






            trackVolumeChaching.ValueChanged -= trackVolumeChaching_ValueChanged;
            trackVolumeChaching.Scroll -= trackVolumeChaching_Scroll;
            _CurrentVolume = 0;
            waveOutGetVolume(IntPtr.Zero, out _CurrentVolume);

            ushort _CalcVol = (ushort)(_CurrentVolume & 0x0000ffff);
            // Get the volume on a scale of 1 to 10 (to fit the trackbar)
            trackVolumeChaching.Value = _CalcVol / (ushort.MaxValue / 100);

            trackVolumeChaching.ValueChanged += trackVolumeChaching_ValueChanged;
            trackVolumeChaching.Scroll += trackVolumeChaching_Scroll;


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
                    if (pid.RemoteAddress.ToString().StartsWith("34.117.122")) { continue; }
                    if (pid.RemoteAddress.ToString().StartsWith("24.105.29")) { continue; }
                    if (pid.RemoteAddress.ToString().StartsWith("37.244.28")) { continue; }
                    if (pid.RemoteAddress.ToString().StartsWith("37.244.54")) { continue; }
                    if (pid.RemoteAddress.ToString().StartsWith("117.52.35")) { continue; }
                    if (pid.RemoteAddress.ToString().StartsWith("137.221.105")) { continue; }
                    if (pid.RemoteAddress.ToString().StartsWith("137.221.106")) { continue; }

                    /* IP Addresses Connections Found While Being Outside of a Game (IE: while in lobby, or char select screen) */

                    /* North America */
                    if (pid.RemoteAddress.ToString()=="34.95.148.93") { continue; }
                    if (pid.RemoteAddress.ToString()=="35.224.190.107") { continue; }
                    if (pid.RemoteAddress.ToString()=="35.198.33.20") { continue; }
                    if (pid.RemoteAddress.ToString()=="34.125.178.230") { continue; }
                    if (pid.RemoteAddress.ToString()=="34.106.220.198") { continue; }
                    if (pid.RemoteAddress.ToString()=="35.198.9.161") { continue; }
                    if (pid.RemoteAddress.ToString()=="34.125.192.178") { continue; }
                    if (pid.RemoteAddress.ToString()=="35.203.90.248") { continue; }
                    if (pid.RemoteAddress.ToString()=="34.106.157.7") { continue; }
                    if (pid.RemoteAddress.ToString()=="35.184.165.43") { continue; }
                    if (pid.RemoteAddress.ToString()=="34.95.254.42") { continue; }
                    if (pid.RemoteAddress.ToString()=="35.236.78.59") { continue; }
                    if (pid.RemoteAddress.ToString()=="34.106.46.242") { continue; }
                    if (pid.RemoteAddress.ToString()=="34.125.187.42") { continue; }
                    if (pid.RemoteAddress.ToString()=="34.127.3.170") { continue; }
                    if (pid.RemoteAddress.ToString()=="34.83.221.205") { continue; }
                    if (pid.RemoteAddress.ToString()=="34.145.246.88") { continue; }
                    if (pid.RemoteAddress.ToString()=="34.106.138.112") { continue; }
                    if (pid.RemoteAddress.ToString()=="35.198.38.221") { continue; }
                    if (pid.RemoteAddress.ToString()=="34.150.253.5") { continue; }
                    if (pid.RemoteAddress.ToString()=="35.247.120.89") { continue; }
                    if (pid.RemoteAddress.ToString()=="158.115.222.213") { continue; }
                    if (pid.RemoteAddress.ToString()=="158.115.222.235") { continue; }
                    if (pid.RemoteAddress.ToString() == "35.203.49.62") { continue; }
                    if (pid.RemoteAddress.ToString() == "35.244.75.115") { continue; }
                    if (pid.RemoteAddress.ToString() == "158.115.222.192") { continue; }
                    if (pid.RemoteAddress.ToString() == "34.106.62.192") { continue; }
                    if (pid.RemoteAddress.ToString() == "34.83.204.197") { continue; }
                    if (pid.RemoteAddress.ToString() == "34.145.56.105") { continue; }

                    



                    if (pid.RemotePort.ToString() == "1119") { continue; }


                    if (_excludedIPAddresses.ContainsKey(pid.RemoteAddress.ToString())) { continue; }

                    if (!_activeIPAddresses.ContainsKey(pid.RemoteAddress.ToString()))
                    {
                        _activeIPAddresses.Add(pid.RemoteAddress.ToString(), 1);
                    }
                }
                catch
                {

                }
            }

            lstActiveIPs.Items.Clear();
            foreach (DictionaryEntry de in _activeIPAddresses) { lstActiveIPs.Items.Add(de.Key.ToString()); }

            if (_activeIPAddresses.Count < 1)
            {
                // lblCurrentIP.Text = "Not in a Game ?";

                if (_flagInGame == true)
                { // We were in a game, and we seem to have left that game ip.
                    _flagInGame = false;

                    if (_lastInGameIPAddress.Length > 0)
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
                if (_flagInGame == false || lstActiveIPs.Items[0].ToString() != _lastInGameIPAddress)
                { // This confirm we have just joined a game
                    _lastInGameIPAddress = lstActiveIPs.Items[0].ToString();
                    _flagInGame = true;

                    addLog("IP Address Detected: ");
                    addLog("-> " + _lastInGameIPAddress);

                    _lastGameJoinedOn = DateTime.Now;
                    _TotalGamesJoined++;

                    if (Settings.Default.SaveTotalGamesAndTotalTimeAcrossRestart)
                    {
                        Settings.Default.TotalGamesJoined = _TotalGamesJoined;
                        Settings.Default.Save();
                        Settings.Default.Reload();
                    }

                    _LoggedIPOccurences.Add(new D2R_IpAddressOccurenceEntity(_lastInGameIPAddress, DateTime.Now));

                    if (txtDesiredIPAddress.Text.ToLowerInvariant() == _lastInGameIPAddress.ToLowerInvariant())
                    {
                        try
                        {
                            System.Media.SoundPlayer my_wave_file = new System.Media.SoundPlayer(D2R_CLONEHUNTER.Properties.Resources.cash2);
                            my_wave_file.PlaySync();
                        }
                        catch { }

                        addLog(">>> >>> GAME HAS BEEN FOUND ON THE RIGHT IP <<< <<<");
                    }
                    else
                    {

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
                }

                lblCurrentIP.Text = lstActiveIPs.Items[0].ToString();
            }
            else if (_activeIPAddresses.Count > 1)
            {
                addLog("WARNING: Multiple IP Addresses Established Connections Detected: ");
                foreach (DictionaryEntry de in _activeIPAddresses)
                {
                    addLog("-> " + de.Key.ToString());
                }
            }

            if (p != null)
            {
                try
                {
                    p.Dispose();
                }
                catch { }
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

            if (_entities_copy.Count > 0)
            {
                lblStatisticsMostSeenIP.Text = _entities_copy[0].IPAddress;
            }
            else
            {
                lblStatisticsMostSeenIP.Text = "N/A";
            }
        }





        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (IsAdministrator() == false && 
                (Settings.Default.UseWindowsFirewallBlocking || Settings.Default.QuickRestartD2R) && !Debugger.IsAttached)
            {
                try
                {
                    // Restart program and run as admin
                    var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                    startInfo.Verb = "runas";
                    System.Diagnostics.Process.Start(startInfo);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(this, "The Application failed to restart in Administrator Mode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Application.Exit();
                return;
            }

            lblCurrentIP.Text = "Initializing";

            this.Text = "DiabloClone.ORG CLONEHUNTER v" + Application.ProductVersion + " - Discord Server @ https://discord.gg/FQrpzV8Smv";
            addLog("Application has Started.");
            addLog("Application version is : " + Application.ProductVersion);


            try { File.WriteAllText("runtime.txt", "0:00:00:00:000"); } catch { }

            if (!Settings.Default.SaveLoggedIPAddressesAcrossRestart)
            {
                try { File.WriteAllText("totaltime.txt", "0:00:00:00:000"); } catch { }
                try { File.WriteAllText("totalgames.txt", "0"); } catch { }
            }

            PingBlizzard();

            lblStatisticsTotalGames.Text = "N/A";
            lblStatisticsTotalUniqueIPs.Text = "N/A";
            lblStatisticsStartedOn.Text = "N/A";
            lblStatisticsMostSeenIP.Text = "N/A";
            lblStatisticsDuration.Text = "N/A";


            ReloadSettingsExclusionIPs();
            lstExcludedIPs.Items.Clear();
            foreach (DictionaryEntry de in _excludedIPAddresses) { lstExcludedIPs.Items.Add(de.Key.ToString()); }

            ReloadSettingsGenerals();

            ReloadSettingsStreamer();

            ReloadWindowsFirewallSettings();

            if (Settings.Default.UseWindowsFirewallBlocking)
            {
                ReloadSettingsWindowsFirewallAllowedCIDRs();
                lstFirewallAllowedSubnet.Items.Clear();
                foreach (DictionaryEntry de in _windowsFirewallAllowedCIDRs) { lstFirewallAllowedSubnet.Items.Add(de.Key.ToString()); }

                ReloadSettingsWindowsFirewallBlockedCIDRs();
                lstFirewallBlockedSubnets.Items.Clear();
                foreach (DictionaryEntry de in _windowsFirewallBlockedCIDRs) { lstFirewallBlockedSubnets.Items.Add(de.Key.ToString()); }
            }
        }

        private void ReloadSettingsStreamer()
        {
            try
            {
                chkWriteTxtGameTime.CheckedChanged -= chkWriteTxtGameTime_CheckedChanged;
                chkWriteTxtGameTime.Checked = Settings.Default.StreamerWriteGameTime;
                chkWriteTxtGameTime.CheckedChanged += chkWriteTxtGameTime_CheckedChanged;

                chkWriteTxtTotalGameJoined.CheckedChanged -= chkWriteTxtTotalGameJoined_CheckedChanged;
                chkWriteTxtTotalGameJoined.Checked = Settings.Default.StreamerWriteTotalGames;
                chkWriteTxtTotalGameJoined.CheckedChanged += chkWriteTxtTotalGameJoined_CheckedChanged;

                chkWriteTxtTotalTime.CheckedChanged -= chkWriteTxtTotalTime_CheckedChanged;
                chkWriteTxtTotalTime.Checked = Settings.Default.StreamerWriteTotalTime;
                chkWriteTxtTotalTime.CheckedChanged += chkWriteTxtTotalTime_CheckedChanged;

                ddStreamInfoTimerDelay.SelectedIndexChanged -= ddStreamInfoTimerDelay_SelectedIndexChanged;
                switch (Settings.Default.StreamerWriteDelayMS)
                {
                    case 50: { ddStreamInfoTimerDelay.SelectedIndex = 0; break; }
                    case 100: { ddStreamInfoTimerDelay.SelectedIndex = 1; break; }
                    case 150: { ddStreamInfoTimerDelay.SelectedIndex = 2; break; }
                    case 200: { ddStreamInfoTimerDelay.SelectedIndex = 3; break; }
                    case 250: { ddStreamInfoTimerDelay.SelectedIndex = 4; break; }
                    case 300: { ddStreamInfoTimerDelay.SelectedIndex = 5; break; }
                    case 350: { ddStreamInfoTimerDelay.SelectedIndex = 6; break; }
                    case 400: { ddStreamInfoTimerDelay.SelectedIndex = 7; break; }
                    case 450: { ddStreamInfoTimerDelay.SelectedIndex = 8; break; }
                    case 500: { ddStreamInfoTimerDelay.SelectedIndex = 9; break; }
                    default: { ddStreamInfoTimerDelay.SelectedIndex = 9; break; }
                }
                ddStreamInfoTimerDelay.SelectedIndexChanged += ddStreamInfoTimerDelay_SelectedIndexChanged;
            }
            catch
            {
                MessageBox.Show(this,
                    "An error occured while loading the configuration (Streamer Options section).\r\n\r\n" +
                        "Please make sure you have the latest version with all the necessary included files.",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SaveSettingsStreamer()
        {
            try
            {
                Settings.Default.StreamerWriteGameTime = chkWriteTxtGameTime.Checked;
                Settings.Default.StreamerWriteTotalGames = chkWriteTxtTotalGameJoined.Checked;
                Settings.Default.StreamerWriteTotalTime = chkWriteTxtTotalTime.Checked;
                switch (ddStreamInfoTimerDelay.SelectedIndex)
                {
                    case 0: { Settings.Default.StreamerWriteDelayMS = 50; break; }
                    case 1: { Settings.Default.StreamerWriteDelayMS = 100; break; }
                    case 2: { Settings.Default.StreamerWriteDelayMS = 150; break; }
                    case 3: { Settings.Default.StreamerWriteDelayMS = 200; break; }
                    case 4: { Settings.Default.StreamerWriteDelayMS = 250; break; }
                    case 5: { Settings.Default.StreamerWriteDelayMS = 300; break; }
                    case 6: { Settings.Default.StreamerWriteDelayMS = 350; break; }
                    case 7: { Settings.Default.StreamerWriteDelayMS = 400; break; }
                    case 8: { Settings.Default.StreamerWriteDelayMS = 450; break; }
                    case 9: { Settings.Default.StreamerWriteDelayMS = 500; break; }
                    default: { Settings.Default.StreamerWriteDelayMS = 500; break; }
                }
                Settings.Default.Save();
                Settings.Default.Reload();
            }
            catch
            {
                MessageBox.Show(this,
                    "An error occured while saving the configuration (General Options section).\r\n\r\n" +
                        "Please make sure you have the latest version with all the necessary included files.",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ReloadSettingsGenerals()
        {
            try
            {
                chkAutoTrimLogs.CheckedChanged -= chkAutoTrimLogs_CheckedChanged;
                chkAutoTrimLogs.Checked = Settings.Default.AutoTrimLogs;
                chkAutoTrimLogs.CheckedChanged += chkAutoTrimLogs_CheckedChanged;

                chkBlizzardPing.CheckedChanged -= chkBlizzardPing_CheckedChanged;
                chkBlizzardPing.Checked = Settings.Default.BlizzardPing;
                chkBlizzardPing.CheckedChanged += chkBlizzardPing_CheckedChanged;

                chkRingOnFound.CheckedChanged -= chkRingOnFound_CheckedChanged;
                chkRingOnFound.Checked = Settings.Default.RingOnFound;
                chkRingOnFound.CheckedChanged += chkRingOnFound_CheckedChanged;

                chkShowTicks.CheckedChanged -= chkShowTicks_CheckedChanged;
                chkShowTicks.Checked = Settings.Default.ShowTicks;
                chkShowTicks.CheckedChanged += chkShowTicks_CheckedChanged;

                chkSaveTotalGamesAndTotalTimeAcrossRestart.CheckedChanged -= chkSaveTotalGamesAndTotalTimeAcrossRestart_CheckedChanged;
                chkSaveTotalGamesAndTotalTimeAcrossRestart.Checked = Settings.Default.SaveTotalGamesAndTotalTimeAcrossRestart;
                chkSaveTotalGamesAndTotalTimeAcrossRestart.CheckedChanged += chkSaveTotalGamesAndTotalTimeAcrossRestart_CheckedChanged;

                chkSaveLoggedIPAddressesAccrossRestart.CheckedChanged -= chkSaveLoggedIPAddressesAccrossRestart_CheckedChanged;
                chkSaveLoggedIPAddressesAccrossRestart.Checked = Settings.Default.SaveLoggedIPAddressesAcrossRestart;
                chkSaveLoggedIPAddressesAccrossRestart.CheckedChanged += chkSaveLoggedIPAddressesAccrossRestart_CheckedChanged;

                trackVolumeChaching.ValueChanged -= trackVolumeChaching_ValueChanged;
                trackVolumeChaching.Value = Settings.Default.VolumeChaching;
                trackVolumeChaching.ValueChanged += trackVolumeChaching_ValueChanged;

                chkQuickRestartD2R.CheckedChanged -= chkQuickRestartD2R_CheckedChanged;
                chkQuickRestartD2R.Checked = Settings.Default.QuickRestartD2R;
                chkQuickRestartD2R.CheckedChanged += chkQuickRestartD2R_CheckedChanged;
                
                btnKillAndRestartD2R.Enabled = Settings.Default.QuickRestartD2R;


                txtD2RLauncherPath.TextChanged -= txtD2RLauncherPath_TextChanged;
                txtD2RLauncherPath.Text = Settings.Default.D2RLauncherPath;
                txtD2RLauncherPath.TextChanged += txtD2RLauncherPath_TextChanged;


                chkKeepOnTop.CheckedChanged -= chkKeepOnTop_CheckedChanged;
                chkKeepOnTop.Checked = Settings.Default.KeepOnTop;
                chkKeepOnTop.CheckedChanged += chkKeepOnTop_CheckedChanged;



                this.TopMost = Settings.Default.KeepOnTop;
            }
            catch
            {
                MessageBox.Show(this,
                    "An error occured while loading the configuration (General Options section).\r\n\r\n" +
                        "Please make sure you have the latest version with all the necessary included files.",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SaveSettingsGenerals()
        {
            try
            {
                Settings.Default.AutoTrimLogs = chkAutoTrimLogs.Checked;
                Settings.Default.BlizzardPing = chkBlizzardPing.Checked;
                Settings.Default.RingOnFound = chkRingOnFound.Checked;
                Settings.Default.ShowTicks = chkShowTicks.Checked;
                Settings.Default.VolumeChaching = trackVolumeChaching.Value;
                Settings.Default.SaveTotalGamesAndTotalTimeAcrossRestart = chkSaveTotalGamesAndTotalTimeAcrossRestart.Checked;
                Settings.Default.SaveLoggedIPAddressesAcrossRestart = chkSaveLoggedIPAddressesAccrossRestart.Checked;
                Settings.Default.QuickRestartD2R = chkQuickRestartD2R.Checked;
                Settings.Default.D2RLauncherPath = txtD2RLauncherPath.Text;
                Settings.Default.KeepOnTop = chkKeepOnTop.Checked;

                Settings.Default.Save();
                Settings.Default.Reload();
            }
            catch
            {
                MessageBox.Show(this,
                    "An error occured while saving the configuration (General Options section).\r\n\r\n" +
                        "Please make sure you have the latest version with all the necessary included files.",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ReloadWindowsFirewallSettings()
        {
            try
            {
                chkWindowsFirewallBlocking.CheckedChanged -= chkWindowsFirewallBlocking_CheckedChanged;
                chkWindowsFirewallBlocking.Checked = Settings.Default.UseWindowsFirewallBlocking;
                chkWindowsFirewallBlocking.CheckedChanged += chkWindowsFirewallBlocking_CheckedChanged;
            }
            catch
            {
                MessageBox.Show(this,
                    "An error occured while loading the configuration (Windows Firewall Blocking CIDRs).\r\n\r\n" +
                        "Please make sure you have the latest version with all the necessary included files.",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SaveWindowsFirewallSettings()
        {
            try
            {
                Settings.Default.UseWindowsFirewallBlocking = chkWindowsFirewallBlocking.Checked;

                Settings.Default.Save();
                Settings.Default.Reload();
            }
            catch
            {
                MessageBox.Show(this,
                    "An error occured while saving the configuration (Windows Firewall Blocking CIDRs).\r\n\r\n" +
                        "Please make sure you have the latest version with all the necessary included files.",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void ReloadSettingsWindowsFirewallBlockedCIDRs()
        {
            /* Attempt to Cleanup Old Blocked CIDRs if any are present */
            if (_windowsFirewallBlockedCIDRs != null)
            {
                if (_windowsFirewallBlockedCIDRs.Count > 0)
                {
                    foreach (DictionaryEntry de in _windowsFirewallBlockedCIDRs)
                    {
                        string cidr = (string)de.Key;
                        WindowsFirewallUnblock(cidr);
                    }
                }
            }

            _windowsFirewallBlockedCIDRs = new Hashtable();

            if (Settings.Default.BlockedCIDRs != null)
            {
                if (Settings.Default.BlockedCIDRs.Length > 0)
                {
                    /* Create an array with the (possible) ip addresses set in the setting file */
                    string[] lBlockedCIDRs = Settings.Default.BlockedCIDRs.Split(',');

                    /* Check if we got any element in our array. */
                    if (lBlockedCIDRs.Length > 0)
                    {
                        /* Iterate through each elements found to process em */
                        foreach (string lCIDRString in lBlockedCIDRs)
                        {
                            try
                            {
                                /* Try to parse the element string into an IP Address Object. */
                                string[] cidr = lCIDRString.Split('/');
                                if (cidr.Length == 2)
                                {
                                    IPAddress lIPAddress = null;
                                    if (System.Net.IPAddress.TryParse(cidr[0], out lIPAddress))
                                    {
                                        /* Make sure we are not adding a duplicate to our internal hashtable */
                                        if (!_windowsFirewallBlockedCIDRs.ContainsKey(lCIDRString))
                                        {
                                            _windowsFirewallBlockedCIDRs.Add(lCIDRString, 1);

                                            WindowsFirewallBlock(lCIDRString);
                                        }
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
        }
        private void ReloadSettingsWindowsFirewallAllowedCIDRs()
        {
            /* Attempt to Cleanup Old Blocked CIDRs if any are present */
            if (_windowsFirewallAllowedCIDRs!= null)
            {
                if (_windowsFirewallAllowedCIDRs.Count > 0)
                {
                    foreach (DictionaryEntry de in _windowsFirewallAllowedCIDRs)
                    {
                        string cidr = (string)de.Key;
                        WindowsFirewallUnallow(cidr);
                    }
                }
            }

            _windowsFirewallAllowedCIDRs = new Hashtable();

            if (Settings.Default.AllowedCIDRs != null)
            {
                if (Settings.Default.AllowedCIDRs.Length > 0)
                {
                    /* Create an array with the (possible) ip addresses set in the setting file */
                    string[] lAllowedCIDRs = Settings.Default.AllowedCIDRs.Split(',');

                    /* Check if we got any element in our array. */
                    if (lAllowedCIDRs.Length > 0)
                    {
                        /* Iterate through each elements found to process em */
                        foreach (string lCIDRString in lAllowedCIDRs)
                        {
                            try
                            {
                                /* Try to parse the element string into an IP Address Object. */
                                string[] cidr = lCIDRString.Split('/');
                                if (cidr.Length == 2)
                                {
                                    IPAddress lIPAddress = null;
                                    if (System.Net.IPAddress.TryParse(cidr[0], out lIPAddress))
                                    {
                                        /* Make sure we are not adding a duplicate to our internal hashtable */
                                        if (!_windowsFirewallAllowedCIDRs.ContainsKey(lCIDRString))
                                        {
                                            _windowsFirewallAllowedCIDRs.Add(lCIDRString, 1);

                                            WindowsFirewallAllow(lCIDRString);
                                        }
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
        }



        private void SaveSettingsWindowsFirewallBlockedCIDRs()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (DictionaryEntry de in _windowsFirewallBlockedCIDRs)
                {
                    string cidr = (string)de.Key;
                    sb.Append(cidr);
                    sb.Append(",");
                }

                String sbout = sb.ToString();
                if (sbout.EndsWith(",")) { sbout = sbout.TrimEnd(','); }

                Settings.Default.BlockedCIDRs = sbout;
                Settings.Default.Save();
                Settings.Default.Reload();

                sb.Clear();
                sbout = null;

            }
            catch
            {
                MessageBox.Show(this,
                    "An error occured while saving the configuration (Windows Firewall Blocked CIDRs section).\r\n\r\n" +
                        "Please make sure you have the latest version with all the necessary included files.",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            ReloadSettingsWindowsFirewallBlockedCIDRs();
        }
        private void SaveSettingsWindowsFirewallAllowedCIDRs()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (DictionaryEntry de in _windowsFirewallAllowedCIDRs)
                {
                    string cidr = (string)de.Key;
                    sb.Append(cidr);
                    sb.Append(",");
                }

                String sbout = sb.ToString();
                if (sbout.EndsWith(",")) { sbout = sbout.TrimEnd(','); }

                Settings.Default.AllowedCIDRs = sbout;
                Settings.Default.Save();
                Settings.Default.Reload();

                sb.Clear();
                sbout = null;

            }
            catch
            {
                MessageBox.Show(this,
                    "An error occured while saving the configuration (Windows Firewall Allowed CIDRs section).\r\n\r\n" +
                        "Please make sure you have the latest version with all the necessary included files.",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            ReloadSettingsWindowsFirewallBlockedCIDRs();
        }




        private void ReloadSettingsExclusionIPs()
        {
            if (Settings.Default.ExcludedIpAddresses != null)
            {
                if (Settings.Default.ExcludedIpAddresses.Length > 0)
                {
                    /* Create an array with the (possible) ip addresses set in the setting file */
                    string[] lExcludedIpAddresses = Settings.Default.ExcludedIpAddresses.Split(',');

                    /* Check if we got any element in our array. */
                    if (lExcludedIpAddresses.Length > 0)
                    {
                        /* Iterate through each elements found to process em */
                        foreach (string lIPAddressString in lExcludedIpAddresses)
                        {
                            try
                            {
                                /* Try to parse the element string into an IP Address Object. */
                                IPAddress lIPAddress = null;
                                if (System.Net.IPAddress.TryParse(lIPAddressString, out lIPAddress))
                                {
                                    /* Make sure we are not adding a duplicate to our internal hashtable */
                                    if (!_excludedIPAddresses.ContainsKey(lIPAddressString))
                                    {
                                        _excludedIPAddresses.Add(lIPAddressString, 1);
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        private void SaveSettingsExclusionIPs()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (DictionaryEntry de in _excludedIPAddresses)
                {
                    string ipaddress = (string)de.Key;
                    sb.Append(ipaddress);
                    sb.Append(",");
                }

                String sbout = sb.ToString();
                if (sbout.EndsWith(",")) { sbout = sbout.TrimEnd(','); }

                Settings.Default.ExcludedIpAddresses = sbout;
                Settings.Default.Save();
                Settings.Default.Reload();

                sb.Clear();
                sbout = null;

            }
            catch
            {
                MessageBox.Show(this,
                    "An error occured while saving the configuration (Excluded IP Address section).\r\n\r\n" +
                        "Please make sure you have the latest version with all the necessary included files.",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }


            if (Settings.Default.ExcludedIpAddresses != null)
            {
                if (Settings.Default.ExcludedIpAddresses.Length > 0)
                {
                    /* Create an array with the (possible) ip addresses set in the setting file */
                    string[] lExcludedIpAddresses = Settings.Default.ExcludedIpAddresses.Split(',');

                    /* Check if we got any element in our array. */
                    if (lExcludedIpAddresses.Length > 0)
                    {
                        /* Iterate through each elements found to process em */
                        foreach (string lIPAddressString in lExcludedIpAddresses)
                        {
                            try
                            {
                                /* Try to parse the element string into an IP Address Object. */
                                IPAddress lIPAddress = null;
                                if (System.Net.IPAddress.TryParse(lIPAddressString, out lIPAddress))
                                {
                                    /* Make sure we are not adding a duplicate to our internal hashtable */
                                    if (!_excludedIPAddresses.ContainsKey(lIPAddressString))
                                    {
                                        _excludedIPAddresses.Add(lIPAddressString, 1);
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        private void ddStreamInfoTimerDelay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddStreamInfoTimerDelay.SelectedIndex > -1)
            {
                if (tmrTextFileCreations.Enabled)
                {
                    tmrTextFileCreations.Enabled = false;
                }

                int newdelay = (ddStreamInfoTimerDelay.SelectedIndex + 1) * 50;
                tmrTextFileCreations.Interval = newdelay;
                tmrTextFileCreations.Enabled = true;
            }

            SaveSettingsStreamer();
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
            catch
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

                ReloadSettingsExclusionIPs();

                lstExcludedIPs.Items.Clear();
                foreach (DictionaryEntry de in _excludedIPAddresses) { lstExcludedIPs.Items.Add(de.Key.ToString()); }

                SaveSettingsExclusionIPs();
            }
            catch
            {

            }
        }


        private void addLog(string data)
        {

            int textlimit = 32768;

            txtApplicationLogs.Text = txtApplicationLogs.Text + "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "]  " + data + "\r\n";
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

            sb.AppendLine("Show Timer Ticks: " + (chkShowTicks.Checked ? "Yes" : "No"));
            sb.AppendLine("Auto Trim Logs: " + (chkAutoTrimLogs.Checked ? "Yes" : "No"));
            sb.AppendLine("");

            sb.AppendLine("Session Started On: " + _applicationStartedOn.ToString("yyyy-MM-dd HH:mm"));
            sb.AppendLine("Session Exported On: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            sb.AppendLine("");

            sb.AppendLine("Excluded IPs: ");
            foreach (DictionaryEntry de in _excludedIPAddresses) { sb.AppendLine(de.Key.ToString()); }
            sb.AppendLine("");

            sb.AppendLine("Logged IPs: ");
            foreach (DictionaryEntry de in _loggedIPAddresses) { sb.AppendLine(de.Key.ToString() + " --> " + de.Value.ToString() + " times."); }
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
            catch
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
            catch { }
        }

        private void gvLoggedIPs_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                gvLoggedIPs.DataSource = null;
                this.Invalidate(true);
            }
            catch { }

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
            catch
            {

            }
        }

        private void tmrBlizzardPing_Tick(object sender, EventArgs e)
        {
            PingBlizzard();
        }

        private void tabPageApplicationLogs_Click(object sender, EventArgs e)
        {

        }



        private void WriteTextFileTotalTime()
        {
            try
            {
                String text = "";

                if (_applicationStartedOn != null)
                {
                    TimeSpan timespan = DateTime.Now.Subtract(_applicationStartedOn);

                    text =
                        (timespan.Days > 0 ? timespan.Days.ToString() : "0") + ":" +
                        (timespan.Hours > 0 ? timespan.Hours.ToString().PadLeft(2, '0') : "00") + ":" +
                        (timespan.Minutes > 0 ? timespan.Minutes.ToString().PadLeft(2, '0') : "00") + ":" +
                        (timespan.Seconds > 0 ? timespan.Seconds.ToString().PadLeft(2, '0') : "00") + ":" +
                        (timespan.Milliseconds > 0 ? timespan.Milliseconds.ToString().PadLeft(3, '0') : "000");
                }
                else
                {
                    text = "";
                }

                File.WriteAllText("totaltime.txt", text);
            }
            catch
            {

            }
        }

        private void WriteTextFileTotalRuns()
        {
            try
            {
                File.WriteAllText("totalgames.txt", _TotalGamesJoined.ToString());
            }
            catch
            {

            }
        }


        private void WriteTextFileGameTime()
        {
            try
            {
                String text = "";

                if (_flagInGame && _lastGameJoinedOn != null)
                {
                    TimeSpan timespan = DateTime.Now.Subtract(_lastGameJoinedOn);

                    text =
                        (timespan.Days > 0 ? timespan.Days.ToString() : "0") + ":" +
                        (timespan.Hours > 0 ? timespan.Hours.ToString().PadLeft(2, '0') : "00") + ":" +
                        (timespan.Minutes > 0 ? timespan.Minutes.ToString().PadLeft(2, '0') : "00") + ":" +
                        (timespan.Seconds > 0 ? timespan.Seconds.ToString().PadLeft(2, '0') : "00") + ":" +
                        (timespan.Milliseconds > 0 ? timespan.Milliseconds.ToString().PadLeft(3, '0') : "000");
                }
                else
                {
                    text = "";
                }


                File.WriteAllText("runtime.txt", text);
            }
            catch
            {

            }
        }

        private void tmrTextFileCreations_Tick(object sender, EventArgs e)
        {

            if (chkWriteTxtTotalGameJoined.Checked)
            {
                WriteTextFileTotalRuns();
            }

            if (chkWriteTxtGameTime.Checked)
            {
                WriteTextFileGameTime();
            }

            if (chkWriteTxtTotalTime.Checked)
            {
                WriteTextFileTotalTime();
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { File.WriteAllText("runtime.txt", "0:00:00:00:000"); } catch { }

            if (!Settings.Default.SaveTotalGamesAndTotalTimeAcrossRestart)
            {
                try { File.WriteAllText("totaltime.txt", "0:00:00:00:000"); } catch { }
                try { File.WriteAllText("totalgames.txt", "0"); } catch { }
            }

            /* Attempt to Cleanup Old Blocked CIDRs if any are present */
            if (_windowsFirewallBlockedCIDRs != null)
            {
                if (_windowsFirewallBlockedCIDRs.Count > 0)
                {
                    foreach (DictionaryEntry de in _windowsFirewallBlockedCIDRs)
                    {
                        string cidr = (string)de.Key;
                        WindowsFirewallUnblock(cidr);
                    }
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { File.WriteAllText("runtime.txt", "0:00:00:00:000"); } catch { }

            if (!Settings.Default.SaveTotalGamesAndTotalTimeAcrossRestart)
            {
                try { File.WriteAllText("totaltime.txt", "0:00:00:00:000"); } catch { }
                try { File.WriteAllText("totalgames.txt", "0"); } catch { }
            }

            /* Attempt to Cleanup Old Blocked CIDRs if any are present */
            if (_windowsFirewallBlockedCIDRs != null)
            {
                if (_windowsFirewallBlockedCIDRs.Count > 0)
                {
                    foreach (DictionaryEntry de in _windowsFirewallBlockedCIDRs)
                    {
                        string cidr = (string)de.Key;
                        WindowsFirewallUnblock(cidr);
                    }
                }
            }
        }

        private void btnBuildExclusionHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,
                "You want to build the exclusion list, when you first start the game, after the initial queue if any, when you are in the lobby.\r\n\r\n" +
                "This is used to remove the Authentification Server from the current list of active ip address, so that we can only target the actual game ip.\r\n\r\n" +
                "If your d2r client game completly close and crash, simply rebuild the exclusion when you rejoin the lobby open re-opening to rebuild the exclusion list.", "Explaination", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkShowTicks_CheckedChanged_1(object sender, EventArgs e)
        {
            SaveSettingsGenerals();
        }

        private void chkAutoTrimLogs_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettingsGenerals();
        }

        private void chkRingOnFound_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettingsGenerals();
        }

        private void trackVolumeChaching_ValueChanged(object sender, EventArgs e)
        {
            SaveSettingsGenerals();
        }

        private void chkBlizzardPing_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettingsGenerals();
        }

        private void btnResetConfiguration_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "Are you sure you want to reset all configuration to default ?\r\n\r\nThis will restart the Application", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                List<string> directories = new List<string>(Directory.EnumerateDirectories(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\DiabloClone.ORG"));

                foreach (var dir in directories)
                {
                    try { Directory.Delete(dir, true); }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            Application.Restart();
        }

        private void chkWriteTxtTotalGameJoined_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettingsStreamer();
        }

        private void chkWriteTxtGameTime_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettingsStreamer();
        }

        private void chkWriteTxtTotalTime_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettingsStreamer();
        }


        private void chkSaveLoggedIPAddressesAccrossRestart_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettingsGenerals();
        }

        private void chkSaveTotalGamesAndTotalTimeAcrossRestart_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettingsGenerals();

            /* We need to save (or reset) our Total Games Joined 
             * Setting Variable for next Application Restart */

            if (Settings.Default.SaveTotalGamesAndTotalTimeAcrossRestart)
            {
                Settings.Default.TotalGamesJoined = _TotalGamesJoined;
                Settings.Default.Save();
                Settings.Default.Reload();
            }
            else
            {
                Settings.Default.TotalGamesJoined = 0;
                Settings.Default.Save();
                Settings.Default.Reload();
            }
        }



        private void txtD2RLauncherPath_TextChanged(object sender, EventArgs e)
        {
            SaveSettingsGenerals();
        }

        private void chkKeepOnTop_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettingsGenerals();

            this.TopMost = Settings.Default.KeepOnTop;
        }

        private void btnKillAndRestartD2R_Click(object sender, EventArgs e)
        {
            try
            {
                if (Settings.Default.QuickRestartD2R == true && IsAdministrator())
                {

                    Process[] processes = Process.GetProcessesByName("D2R");
                    if (processes.Length < 1)
                    {
                        addLog("ERROR: We can't find any D2R.exe running to restart ?!");
                    }
                    else if (processes.Length == 1)
                    {
                        addLog("OK, Killing D2R Client...");
                        processes[0].Kill();
                        processes[0].WaitForExit();

                        addLog("Killed! Waiting 6 seconds...");
                        Thread.Sleep(6000);

                        addLog("Starting new D2R Client !");
                        Process newprocess = Process.Start(Settings.Default.D2RLauncherPath, "--exec=\"launch OSI\"");
                    }
                    else
                    {
                        addLog("ERROR: There is more than one (1) D2R Client open, so to be safe, we are not going to restart all of em.");
                    }
                }
            }
            catch { }
        }

        private void chkQuickRestartD2R_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettingsGenerals();

            btnKillAndRestartD2R.Enabled = chkQuickRestartD2R.Checked;
        }




        /********************/
        /** FIREWALL : MISC */
        /********************/
        private void WindowsFirewallBlock(string cidr)
        {
            try
            {
                String arguments_in = "advfirewall firewall add rule name=\"DC_CLONEHUNTER IPs BLOCKING\" action=block remoteip=" + cidr + " dir=in";
                ProcessStartInfo psi_in = new ProcessStartInfo("netsh", arguments_in);
                psi_in.RedirectStandardOutput = true;
                psi_in.UseShellExecute = false;
                psi_in.CreateNoWindow = true;
                System.Diagnostics.Process.Start(psi_in);
            }
            catch (Exception ex)
            {
                addLog("Error while blocking (in) " + cidr + " from the Windows Firewall : " + ex.Message);
            }

            addLog("Firewall Blocking (in) " + cidr + " from the Windows Firewall : ");

            try
            {
                String arguments_out = "advfirewall firewall add rule name=\"DC_CLONEHUNTER IPs BLOCKING\" action=block remoteip=" + cidr + " dir=out";
                ProcessStartInfo psi_out = new ProcessStartInfo("netsh", arguments_out);
                psi_out.RedirectStandardOutput = true;
                psi_out.UseShellExecute = false;
                psi_out.CreateNoWindow = true;
                System.Diagnostics.Process.Start(psi_out);
            }
            catch (Exception ex)
            {
                addLog("Error while blocking (out) " + cidr + " from the Windows Firewall : " + ex.Message);
            }

            addLog("Firewall Blocking (out) " + cidr + " from the Windows Firewall : ");



        }

        private void WindowsFirewallUnblock(string cidr)
        {
            try
            {
                String arguments_in = "advfirewall firewall delete rule name=\"DC_CLONEHUNTER IPs BLOCKING\" remoteip=" + cidr + " dir=in";
                ProcessStartInfo psi_in = new ProcessStartInfo("netsh", arguments_in);
                psi_in.RedirectStandardOutput = true;
                psi_in.UseShellExecute = false;
                psi_in.CreateNoWindow = true;
                System.Diagnostics.Process.Start(psi_in);
            }
            catch (Exception ex)
            {
                addLog("Error while unblocking (in) " + cidr + " from the Windows Firewall : " + ex.Message);
            }

            addLog("Firewall Unblocking (in) " + cidr + " from the Windows Firewall : ");

            try
            {
                String arguments_out = "advfirewall firewall delete rule name=\"DC_CLONEHUNTER IPs BLOCKING\" remoteip=" + cidr + " dir=out";
                ProcessStartInfo psi_out = new ProcessStartInfo("netsh", arguments_out);
                psi_out.RedirectStandardOutput = true;
                psi_out.UseShellExecute = false;
                psi_out.CreateNoWindow = true;
                System.Diagnostics.Process.Start(psi_out);
            }
            catch (Exception ex)
            {
                addLog("Error while unblocking (out) " + cidr + " from the Windows Firewall : " + ex.Message);
            }

            addLog("Firewall Unblocking (out) " + cidr + " from the Windows Firewall : ");

        }

        private void WindowsFirewallAllow(string cidr)
        {
            try
            {
                String arguments_in = "advfirewall firewall add rule name=\"DC_CLONEHUNTER IPs ALLOWING\" enable=yes action=allow remoteip=" + cidr + " dir=in";
                ProcessStartInfo psi_in = new ProcessStartInfo("netsh", arguments_in);
                psi_in.RedirectStandardOutput = true;
                psi_in.UseShellExecute = false;
                psi_in.CreateNoWindow = true;
                System.Diagnostics.Process.Start(psi_in);
            }
            catch (Exception ex)
            {
                addLog("Error while allowing (in) " + cidr + " from the Windows Firewall : " + ex.Message);
            }

            addLog("Firewall Allowing (in) " + cidr + " from the Windows Firewall : ");

            try
            {
                String arguments_out = "advfirewall firewall add rule name=\"DC_CLONEHUNTER IPs ALLOWING\" enable=yes action=allow remoteip=" + cidr + " dir=out";
                ProcessStartInfo psi_out = new ProcessStartInfo("netsh", arguments_out);
                psi_out.RedirectStandardOutput = true;
                psi_out.UseShellExecute = false;
                psi_out.CreateNoWindow = true;
                System.Diagnostics.Process.Start(psi_out);
            }
            catch (Exception ex)
            {
                addLog("Error while allowing (out) " + cidr + " from the Windows Firewall : " + ex.Message);
            }

            addLog("Firewall Allowing (out) " + cidr + " from the Windows Firewall : ");
        }

        private void WindowsFirewallUnallow(string cidr)
        {
            try
            {
                String arguments_in = "advfirewall firewall delete rule name=\"DC_CLONEHUNTER IPs ALLOWING\" remoteip=" + cidr + " dir=in";
                ProcessStartInfo psi_in = new ProcessStartInfo("netsh", arguments_in);
                psi_in.RedirectStandardOutput = true;
                psi_in.UseShellExecute = false;
                psi_in.CreateNoWindow = true;
                System.Diagnostics.Process.Start(psi_in);
            }
            catch (Exception ex)
            {
                addLog("Error while unallowing (in) " + cidr + " from the Windows Firewall : " + ex.Message);
            }

            addLog("Firewall Unallowing (in) " + cidr + " from the Windows Firewall : ");

            try
            {
                String arguments_out = "advfirewall firewall delete rule name=\"DC_CLONEHUNTER IPs ALLOWING\" remoteip=" + cidr + " dir=out";
                ProcessStartInfo psi_out = new ProcessStartInfo("netsh", arguments_out);
                psi_out.RedirectStandardOutput = true;
                psi_out.UseShellExecute = false;
                psi_out.CreateNoWindow = true;
                System.Diagnostics.Process.Start(psi_out);
            }
            catch (Exception ex)
            {
                addLog("Error while unallowing (out) " + cidr + " from the Windows Firewall : " + ex.Message);
            }

            addLog("Firewall Unallowing (out) " + cidr + " from the Windows Firewall : ");

        }

        private void chkWindowsFirewallBlocking_CheckedChanged(object sender, EventArgs e)
        {
            SaveWindowsFirewallSettings();

            MessageBox.Show(this, "The Application will now quit. Please restart the application to apply this setting.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            this.Close();
        }

        private void linkCidrCalculator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://account.arin.net/public/cidrCalculator",
                UseShellExecute = true
            });

        }

        /********************************/
        /** FIREWALL : BLOCKED IP CIDR **/
        /********************************/
        private void btnFirewallBlockIPAddressCIDR_Click(object sender, EventArgs e)
        {
            if (_frmCidrSelectorBlock != null)
            {
                _frmCidrSelectorBlock.Dispose();
                _frmCidrSelectorBlock = null;
            }

            _frmCidrSelectorBlock = new frmCidrSelector();
            _frmCidrSelectorBlock.CidrSelectorOK += _frmCidrSelectorBlock_CidrSelectorOK;
            _frmCidrSelectorBlock.CidrSelectorCANCEL += _frmCidrSelectorBlock_CidrSelectorCANCEL;
            _frmCidrSelectorBlock.ShowDialog(this);
        }

        private void _frmCidrSelectorBlock_CidrSelectorOK(System.Net.IPAddress ipaddress, String cidrclass)
        {
            String cidr = ipaddress.ToString() + cidrclass;
            if (_windowsFirewallBlockedCIDRs.ContainsKey(cidr))
            {
                MessageBox.Show(this, "The provided IP Address Block (Subnet/CIDR) already exist in the blocked list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _windowsFirewallBlockedCIDRs.Add(cidr, 1);
            lstFirewallBlockedSubnets.Items.Add(cidr);

            WindowsFirewallBlock(cidr);

            SaveSettingsWindowsFirewallBlockedCIDRs();
        }

        private void _frmCidrSelectorBlock_CidrSelectorCANCEL()
        {
        }

        private void btnFirewallBlockIPAddressRange_Click(object sender, EventArgs e)
        {
            if (_frmIpRangeSelectorBlock != null)
            {
                _frmIpRangeSelectorBlock.Dispose();
                _frmIpRangeSelectorBlock = null;
            }

            _frmIpRangeSelectorBlock = new frmIpRangeSelector();
            _frmIpRangeSelectorBlock.IpAddressRangeSelectorOK += _frmIpRangeSelectorBlock_IpAddressRangeSelectorOK;
            _frmIpRangeSelectorBlock.IpAddressRangeSelectorCANCEL += _frmIpRangeSelectorBlock_IpAddressRangeSelectorCANCEL;
            _frmIpRangeSelectorBlock.ShowDialog(this);
        }

        private void _frmIpRangeSelectorBlock_IpAddressRangeSelectorOK(List<String> CIDRs)
        {
            foreach (String cidr in CIDRs)
            {
                if (_windowsFirewallBlockedCIDRs.ContainsKey(cidr))
                {
                    addLog("FIREWALL ERROR: " + cidr + " already exist in the firewall blocked list, ignoring...");
                    return;
                }

                _windowsFirewallBlockedCIDRs.Add(cidr, 1);
                lstFirewallBlockedSubnets.Items.Add(cidr);

                WindowsFirewallBlock(cidr);
            }

            SaveSettingsWindowsFirewallBlockedCIDRs();
        }

        private void _frmIpRangeSelectorBlock_IpAddressRangeSelectorCANCEL() 
        { }

        private void btnFirewallClearBlockedSubnets_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "Are you sure that you want to remove and unblock all subnet from this list that are currently blocked ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                for (int index = 0; index < lstFirewallBlockedSubnets.Items.Count; index++)
                {
                    String s = lstFirewallBlockedSubnets.Items[index].ToString();

                    WindowsFirewallUnblock(s);
                }

                _windowsFirewallBlockedCIDRs = new Hashtable();

                lstFirewallBlockedSubnets.Items.Clear();

                SaveSettingsWindowsFirewallBlockedCIDRs();
            }
        }

        private void btnFirewallClearBlockedSelectedSubnet_Click(object sender, EventArgs e)
        {
            if (lstFirewallBlockedSubnets.SelectedIndex < 0)
            {
                MessageBox.Show(this, "You need to select a blocked subnet in the list to unblock it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                String lSelectedListElement = (String)lstFirewallBlockedSubnets.Items[lstFirewallBlockedSubnets.SelectedIndex].ToString();

                WindowsFirewallUnblock(lSelectedListElement);

                lstFirewallBlockedSubnets.Items.RemoveAt(lstFirewallBlockedSubnets.SelectedIndex);

                _windowsFirewallBlockedCIDRs.Remove(lSelectedListElement);

                SaveSettingsWindowsFirewallBlockedCIDRs();

            }
        }



        /********************************/
        /** FIREWALL : ALLOWED IP CIDR **/
        /********************************/
        private void btnFirewallAllowIPAddressCIDR_Click(object sender, EventArgs e)
        {
            if (_frmCidrSelectorAllow != null)
            {
                _frmCidrSelectorAllow.Dispose();
                _frmCidrSelectorAllow = null;
            }

            _frmCidrSelectorAllow = new frmCidrSelector();
            _frmCidrSelectorAllow.CidrSelectorOK += _frmCidrSelectorAllow_CidrSelectorOK;
            _frmCidrSelectorAllow.CidrSelectorCANCEL += _frmCidrSelectorAllow_CidrSelectorCANCEL;
            _frmCidrSelectorAllow.ShowDialog(this);
        }

        private void _frmCidrSelectorAllow_CidrSelectorOK(System.Net.IPAddress ipaddress, String cidrclass)
        {
            String cidr = ipaddress.ToString() + cidrclass;
            if (_windowsFirewallAllowedCIDRs.ContainsKey(cidr))
            {
                MessageBox.Show(this, "The provided IP Address Block (Subnet/CIDR) already exist in the allowed list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _windowsFirewallAllowedCIDRs.Add(cidr, 1);
            lstFirewallAllowedSubnet.Items.Add(cidr);

            WindowsFirewallAllow(cidr);

            SaveSettingsWindowsFirewallAllowedCIDRs();
        }

        private void _frmCidrSelectorAllow_CidrSelectorCANCEL()
        {
        }

        private void btnFirewallAllowIPAddressRange_Click(object sender, EventArgs e)
        {
            if (_frmIpRangeSelectorAllow != null)
            {
                _frmIpRangeSelectorAllow.Dispose();
                _frmIpRangeSelectorAllow = null;
            }

            _frmIpRangeSelectorAllow = new frmIpRangeSelector();
            _frmIpRangeSelectorAllow.IpAddressRangeSelectorOK += _frmIpRangeSelectorAllow_IpAddressRangeSelectorOK;
            _frmIpRangeSelectorAllow.IpAddressRangeSelectorCANCEL += _frmIpRangeSelectorAllow_IpAddressRangeSelectorCANCEL;
            _frmIpRangeSelectorAllow.ShowDialog(this);
        }

        private void _frmIpRangeSelectorAllow_IpAddressRangeSelectorOK(List<String> CIDRs)
        {
            foreach (String cidr in CIDRs)
            {
                if (_windowsFirewallAllowedCIDRs.ContainsKey(cidr))
                {
                    addLog("FIREWALL ERROR: " + cidr + " already exist in the firewall allowed list, ignoring...");
                    return;
                }

                _windowsFirewallAllowedCIDRs.Add(cidr, 1);
                lstFirewallAllowedSubnet.Items.Add(cidr);

                WindowsFirewallAllow(cidr);
            }

            SaveSettingsWindowsFirewallAllowedCIDRs();
        }

        private void _frmIpRangeSelectorAllow_IpAddressRangeSelectorCANCEL()
        { }

        private void btnFirewallClearAllowedSubnets_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "Are you sure that you want to remove and unallow all subnet from this list that are currently allowed ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                for (int index = 0; index < lstFirewallAllowedSubnet.Items.Count; index++)
                {
                    String s = lstFirewallAllowedSubnet.Items[index].ToString();

                    WindowsFirewallUnallow(s);
                }

                _windowsFirewallAllowedCIDRs = new Hashtable();

                lstFirewallAllowedSubnet.Items.Clear();

                SaveSettingsWindowsFirewallAllowedCIDRs();
            }
        }

        private void btnFirewallClearAllowedSelectedSubnet_Click(object sender, EventArgs e)
        {
            if (lstFirewallAllowedSubnet.SelectedIndex < 0)
            {
                MessageBox.Show(this, "You need to select an allowed subnet in the list to unallow it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                String lSelectedListElement = (String)lstFirewallAllowedSubnet.Items[lstFirewallAllowedSubnet.SelectedIndex].ToString();

                WindowsFirewallUnallow(lSelectedListElement);

                lstFirewallAllowedSubnet.Items.RemoveAt(lstFirewallAllowedSubnet.SelectedIndex);

                _windowsFirewallAllowedCIDRs.Remove(lSelectedListElement);

                SaveSettingsWindowsFirewallAllowedCIDRs();

            }
        }


    }
}
