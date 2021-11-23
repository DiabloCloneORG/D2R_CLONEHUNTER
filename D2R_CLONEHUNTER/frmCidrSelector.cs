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
    public delegate void CidrSelectorOKEventHandler(System.Net.IPAddress ipaddress, String cidrclass);
    public delegate void CidrSelectorCancelEventHandler();

    public partial class frmCidrSelector : Form
    {

        public CidrSelectorOKEventHandler CidrSelectorOK;
        public CidrSelectorCancelEventHandler CidrSelectorCANCEL;

        System.Net.IPAddress _IpAddress;
        String _CidrClass;

        public frmCidrSelector()
        {
            InitializeComponent();
        }

        public frmCidrSelector(System.Net.IPAddress ipaddress, String CidrClass)
        {
            InitializeComponent();

            _IpAddress = ipaddress;
            _CidrClass = CidrClass;
        }

        private void frmCidrSelector_Load(object sender, EventArgs e)
        {
            txtIpAddress.Text = "";
            ddCidrClass.SelectedIndex = -1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!System.Net.IPAddress.TryParse(txtIpAddress.Text, out _IpAddress))
                {
                    MessageBox.Show(this, "The provided IP Address is invalid. Please enter a valid IP address in the textbox to block", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show(this, "The provided IP Address is invalid. Please enter a valid IP address in the textbox to block", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ddCidrClass.SelectedIndex < 0)
            {
                MessageBox.Show(this, "You need to select a subnet class to block an ip address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _CidrClass = "/" + ddCidrClass.SelectedIndex.ToString();
            }

            if (CidrSelectorOK!=null)
            {
                CidrSelectorOK(_IpAddress, _CidrClass);
            }

            this.Close();
        }

        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            if (CidrSelectorCANCEL != null)
            {
                CidrSelectorCANCEL();
            }

            this.Close();
        }
    }
}
