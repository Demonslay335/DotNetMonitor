using DotNetMonitor.Controls.HexBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotNetMonitor
{
    static class Extensions
    {
        // Byte array to hex string
        static public string ToHexString(this byte[] bytes, bool spaces = false, bool commas = false)
        {
            string replace = "";
            if (commas) replace = ",";
            if (spaces) replace += " ";
            return BitConverter.ToString(bytes).Replace("-", replace);
        }

        static public string ToHexString(this IEnumerable<byte> bytes, bool spaces = false, bool commas = false)
        {
            return bytes.ToArray().ToHexString(spaces, commas);
        }

        static public bool IsAscii(this char c)
        {
            return c >= 0x20 && c <= 0x7E;
        }

        static public bool IsHex(this char c)
        {
            return (c >= '0' && c <= '9')
                || (c >= 'A' && c <= 'F')
                || (c >= 'a' && c <= 'f');
        }

        static public string ToHexString(this char[] chars)
        {
            return BitConverter.ToString(System.Text.Encoding.UTF8.GetBytes(chars)).Replace("-", "");
        }

        static public string ToHexString(this IEnumerable<char> chars)
        {
            return chars.ToArray().ToHexString();
        }

        static public string ToArrayString(this IEnumerable<char> chars)
        {
            return new string(chars.ToArray());
        }

        // Hex string to byte array
        static public byte[] ToByteArrayHex(this string hex, bool strip = false)
        {
            // Strip whitespace, and common prefixes
            foreach (string r in new string[] { " ", "\n", "\r", "\t", "h", ",", "0x", "-", "[", "]", "{", "}", ":" })
            {
                hex = hex.Replace(r, string.Empty);
            }

            if (strip)
            {
                hex = hex.Where(c => c.IsHex()).ToArrayString();
                if (hex.Length % 2 != 0)
                {
                    hex = hex.Substring(0, hex.Length - 1);
                }
            }

            if (hex.Length % 2 != 0)
            {
                throw new InvalidOperationException("Invalid hex input");
            }
            return (from x in Enumerable.Range(0, hex.Length)
                    where x % 2 == 0
                    select Convert.ToByte(hex.Substring(x, 2), 16)).ToArray();
        }

        static public ParameterInfoWithValue[] WithValues(this ParameterInfo[] parameters)
        {
            return parameters.Select(p => new ParameterInfoWithValue(p, null)).ToArray();
        }

        static public ParameterInfoWithValue[] WithValues(this ParameterInfo[] parameters, CallLookup values)
        {
            return parameters.Select(p => {
                object val = null;
                if (values.ContainsKey(p?.Name))
                {
                    // We need to do a deep copy of some types, otherwise GC clears them
                    if (p.ParameterType == MainForm.Types.ByteArray || p.ParameterType == MainForm.Types.ByteArrayRef)
                    {
                        int len = ((byte[])values[p.Name]).Length;
                        val = new byte[len];
                        Buffer.BlockCopy((byte[])values[p.Name], 0, (byte[])val, 0, len);
                    }
                    else if (p.ParameterType.IsAssignableFrom(typeof(ICloneable)))
                    {
                        val = ((ICloneable)values[p.Name]).Clone();
                    }
                    else
                    {
                        val = values[p.Name];
                    }
                }

                return new ParameterInfoWithValue(p, val);
            }).ToArray();
        }

        static public IEnumerable<Type> GetTypesWithAttribute<A>(this Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(A), true).Length > 0)
                {
                    yield return type;
                }
            }
        }

        static public OverridableApi[] ToApiList(this IEnumerable<MethodBase> types)
        {
            return types.Select(m => new OverridableApi(m)).ToArray();
        }

        static public void DisplayBytes(this HexBox hexbox, byte[] bytes)
        {
            try
            {
                hexbox.ByteProvider = new DynamicByteProvider(bytes);
            }
            catch (Exception)
            {
                throw new Exception("Error displaying bytes");
            }
        }
    }
}
