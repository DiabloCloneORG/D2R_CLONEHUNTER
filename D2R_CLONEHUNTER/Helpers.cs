using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace D2R_CLONEHUNTER
{
    class CidrHelpers
    {
        public struct CIDR
        {
            private IPAddress address;
            private uint network_length, bits;

            public CIDR(IPAddress address, uint network_length)
            {
                this.address = address;
                this.network_length = network_length;
                this.bits = AddressFamilyBits(address.AddressFamily);
                if (network_length > bits)
                {
                    throw new ArgumentException("Invalid network length " + network_length + " for " + address.AddressFamily);
                }
            }

            public IPAddress NetworkAddress
            {
                get { return address; }
            }
            public IPAddress LastAddress
            {
                get { return IPAddressAdd(address, (new BigInteger(1) << (int)HostLength) - 1); }
            }
            public uint NetworkLength
            {
                get { return network_length; }
            }
            public uint AddressBits
            {
                get { return bits; }
            }
            public uint HostLength
            {
                get { return bits - network_length; }
            }

            override public String ToString()
            {
                return address.ToString() + "/" + NetworkLength.ToString();
            }

            public String ToShortString()
            {
                if (network_length == bits) return address.ToString();
                return address.ToString() + "/" + NetworkLength.ToString();
            }

            /* static helpers */
            public static IPAddress IPAddressAdd(IPAddress address, BigInteger i)
            {
                return IPFromUnsigned(IPToUnsigned(address) + i, address.AddressFamily);
            }

            public static uint AddressFamilyBits(AddressFamily family)
            {
                switch (family)
                {
                    case AddressFamily.InterNetwork:
                        return 32;
                    case AddressFamily.InterNetworkV6:
                        return 128;
                    default:
                        throw new ArgumentException("Invalid address family " + family);
                }
            }

            private static BigInteger IPToUnsigned(IPAddress addr)
            {
                /* Need to reverse addr bytes for BigInteger; prefix with 0 byte to force unsigned BigInteger
                 * read BigInteger bytes as: bytes[n] bytes[n-1] ... bytes[0], address is bytes[0] bytes[1] .. bytes[n] */
                byte[] b = addr.GetAddressBytes();
                byte[] unsigned = new byte[b.Length + 1];
                for (int i = 0; i < b.Length; ++i)
                {
                    unsigned[i] = b[(b.Length - 1) - i];
                }
                unsigned[b.Length] = 0;
                return new BigInteger(unsigned);
            }

            private static byte[] GetUnsignedBytes(BigInteger unsigned, uint bytes)
            {
                /* reverse bytes again. check that now higher bytes are actually used */
                if (unsigned.Sign < 0) throw new ArgumentException("argument must be >= 0");
                byte[] data = unsigned.ToByteArray();
                byte[] result = new byte[bytes];
                for (int i = 0; i < bytes && i < data.Length; ++i)
                {
                    result[bytes - 1 - i] = data[i];
                }
                for (uint i = bytes; i < data.Length; ++i)
                {
                    if (data[i] != 0) throw new ArgumentException("argument doesn't fit in requested number of bytes");
                }
                return result;
            }

            private static IPAddress IPFromUnsigned(BigInteger unsigned, System.Net.Sockets.AddressFamily family)
            {
                /* IPAddress(byte[]) constructor picks family from array size */
                switch (family)
                {
                    case System.Net.Sockets.AddressFamily.InterNetwork:
                        return new IPAddress(GetUnsignedBytes(unsigned, 4));
                    case System.Net.Sockets.AddressFamily.InterNetworkV6:
                        return new IPAddress(GetUnsignedBytes(unsigned, 16));
                    default:
                        throw new ArgumentException("AddressFamily " + family.ToString() + " not supported");
                }
            }

            /* splits set [first..last] of unsigned integers into disjoint slices { x,..., x + 2^k - 1 | x mod 2^k == 0 }
             *  covering exaclty the given set.
             * yields the slices ordered by x as tuples (x, k)
             * This code relies on the fact that BigInteger can't overflow; temporary results may need more bits than last is using.
             */
            public static IEnumerable<Tuple<BigInteger, uint>> split(BigInteger first, BigInteger last)
            {
                if (first > last) yield break;
                if (first < 0) throw new ArgumentException();
                last += 1;
                /* mask == 1 << len */
                BigInteger mask = 1;
                uint len = 0;
                while (first + mask <= last)
                {
                    if ((first & mask) != 0)
                    {
                        yield return new Tuple<BigInteger, uint>(first, len);
                        first += mask;
                    }
                    mask <<= 1;
                    ++len;
                }
                while (first < last)
                {
                    mask >>= 1;
                    --len;
                    if ((last & mask) != 0)
                    {
                        yield return new Tuple<BigInteger, uint>(first, len);
                        first += mask;
                    }
                }
            }

            public static IEnumerable<CIDR> split(IPAddress first, IPAddress last)
            {
                if (first.AddressFamily != last.AddressFamily)
                {
                    throw new ArgumentException("AddressFamilies don't match");
                }
                AddressFamily family = first.AddressFamily;
                uint bits = AddressFamilyBits(family); /* split on numbers returns host length, CIDR takes network length */
                foreach (Tuple<BigInteger, uint> slice in split(IPToUnsigned(first), IPToUnsigned(last)))
                {
                    yield return new CIDR(IPFromUnsigned(slice.Item1, family), bits - slice.Item2);
                }
            }

        }
    }
}
