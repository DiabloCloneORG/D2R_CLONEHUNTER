using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2R_CLONEHUNTER
{
    public class D2R_IpAddressCountEntity : ICloneable
    {
        private String _IPAddress;
        public String IPAddress { get { return this._IPAddress; } set { this._IPAddress = value; } }

        private Int32 _OccurenceCount;
        public Int32 OccurenceCount { get { return this._OccurenceCount; } set { this._OccurenceCount = value; } }


        public D2R_IpAddressCountEntity()
        {
            _IPAddress = "";
            _OccurenceCount = 0;
        }

        public D2R_IpAddressCountEntity(D2R_IpAddressCountEntity entity)
        {
            _IPAddress = entity.IPAddress;
            _OccurenceCount = entity.OccurenceCount;
        }
        

        public int CompareTo(D2R_IpAddressCountEntity rhs, D2R_IpAddressCountComparer.D2RIpAddressCountComparisonType which)
        {
            switch (which)
            {
                case D2R_IpAddressCountComparer.D2RIpAddressCountComparisonType.IPAddress:
                    return this.IPAddress.CompareTo(rhs.IPAddress);
                case D2R_IpAddressCountComparer.D2RIpAddressCountComparisonType.OccurenceCount:
                    return this.OccurenceCount.CompareTo(rhs.OccurenceCount);
                default:
                    return 0;
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

}
