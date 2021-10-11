using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2R_CLONEHUNTER
{

    public class D2R_IpAddressCountComparer : IComparer<D2R_IpAddressCountEntity>
    {
        public enum D2RIpAddressCountComparisonType
        {
            IPAddress,
            OccurenceCount,
            NULL
        }
        public enum D2RIpAddressCountSortOrder
        {
            Ascending,
            Descending,
            Unspecified
        }

        private D2RIpAddressCountComparisonType _whichComparison;
        private D2RIpAddressCountSortOrder _sortDirection;

        public D2RIpAddressCountSortOrder SortDirection
        {
            get { return this._sortDirection; }
            set { this._sortDirection = value; }
        }
        public D2RIpAddressCountComparisonType WhichComparison
        {
            get { return this._whichComparison; }
            set { this._whichComparison = value; }
        }


        public int Compare(D2R_IpAddressCountEntity lhs, D2R_IpAddressCountEntity rhs)
        {
            if (SortDirection == D2RIpAddressCountSortOrder.Ascending)
                return lhs.CompareTo(rhs, WhichComparison);
            else
                return rhs.CompareTo(lhs, WhichComparison);
        }
        public bool Equals(D2R_IpAddressCountEntity lhs, D2R_IpAddressCountEntity rhs)
        {
            return this.Compare(lhs, rhs) == 0;
        }
        public int GetHashCode(D2R_IpAddressCountEntity e)
        {
            return e.GetHashCode();
        }

    }


}
