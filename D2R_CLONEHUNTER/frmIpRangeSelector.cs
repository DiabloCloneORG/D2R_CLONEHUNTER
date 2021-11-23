using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2R_CLONEHUNTER
{
    public delegate void IpAddressRangeSelectorOKEventHandler(List<String> cidrclasses);
    public delegate void IpAddressRangeSelectorCancelEventHandler();

    public partial class frmIpRangeSelector : Form
    {

        public IpAddressRangeSelectorOKEventHandler IpAddressRangeSelectorOK;
        public IpAddressRangeSelectorCancelEventHandler IpAddressRangeSelectorCANCEL;

        System.Net.IPAddress _IpAddress_Start;
        System.Net.IPAddress _IpAddress_End;
        List<String> _Cidrs;

        public frmIpRangeSelector()
        {
            InitializeComponent();

            _Cidrs = new List<string>();
        }

        private void frmCidrSelector_Load(object sender, EventArgs e)
        {
            txtIpAddressStart.Text = "";
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!System.Net.IPAddress.TryParse(txtIpAddressStart.Text, out _IpAddress_Start))
                {
                    MessageBox.Show(this, "The provided Start IP Address is invalid. Please enter a valid Start IP address in the textbox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show(this, "The provided Start IP Address is invalid. Please enter a valid Start IP address in the textbox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (!System.Net.IPAddress.TryParse(txtIpAddressEnd.Text, out _IpAddress_End))
                {
                    MessageBox.Show(this, "The provided End IP Address is invalid. Please enter a valid End IP address in the textbox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show(this, "The provided End IP Address is invalid. Please enter a valid End IP address in the textbox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var ip1long = BitConverter.ToUInt32(_IpAddress_Start.GetAddressBytes().Reverse().ToArray(), 0);
                var ip2long = BitConverter.ToUInt32(_IpAddress_End.GetAddressBytes().Reverse().ToArray(), 0);

                if (ip1long > ip2long)
                {
                    MessageBox.Show(this, "The IP Address Range is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show(this, "The IP Address Range is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Cidrs = new List<string>();
            foreach (CidrHelpers.CIDR c in CidrHelpers.CIDR.split(_IpAddress_Start, _IpAddress_End))
            {
                _Cidrs.Add(c.ToShortString());
            }

            if (IpAddressRangeSelectorOK != null)
            {
                IpAddressRangeSelectorOK(_Cidrs);
            }

            this.Close();
        }

        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            if (IpAddressRangeSelectorCANCEL != null)
            {
                IpAddressRangeSelectorCANCEL();
            }

            this.Close();
        }
    }
}
