using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2R_CLONEHUNTER
{

    public class D2R_IpAddressOccurenceEntity
    {
        private DateTime _CreatedOn;
        public DateTime CreatedOn { get { return this._CreatedOn; } set { this._CreatedOn = value; } }

        private String _IPAddress;
        public String IPAddress { get { return this._IPAddress; } set { this._IPAddress = value; } }

        public D2R_IpAddressOccurenceEntity()
        {
            _IPAddress = "";
            _CreatedOn = new DateTime();
        }
        public D2R_IpAddressOccurenceEntity(String lIPAddress, DateTime lCreatedOn)
        {
            _IPAddress = lIPAddress;
            _CreatedOn = lCreatedOn;
        }

    }

}
