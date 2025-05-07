using System.Collections.Generic;
using System.Text;

namespace MobaXtermKeygen
{

    /// <summary>
    /// 变种Base64
    /// <para>@createDate 2025/05/06 11:11:11</para>
    /// <para>@author ALI[ali-k@foxmail.com]</para>
    /// <para>@since 1.0.0</para>
    /// </summary>
    public class VariantBase64
    {

        private readonly static string VariantBase64Table = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
        private readonly static char[] VariantBase64Dict = VariantBase64Table.ToCharArray();
        private readonly static Dictionary<char, int> VariantBase64ReverseDict = new Dictionary<char, int>();

        static VariantBase64()
        {
            for (int i = 0; i < VariantBase64Dict.Length; i++)
            {
                VariantBase64ReverseDict.Add(VariantBase64Dict[i], i);
            }
        }

        /// <summary>
        /// 编码
        /// </summary>
        public static string Encode(byte[] bytes)
        {
            StringBuilder result = new StringBuilder();
            int blocksCount = bytes.Length / 3;
            int leftBytes = bytes.Length % 3;
            for (int i = 0; i < blocksCount; i++)
            {
                int codingInt = bytes[3 * i]
                    + (bytes[3 * i + 1] << 8)
                    + (bytes[3 * i + 2] << 16);
                result.Append(VariantBase64Dict[codingInt & 0x3F]);
                result.Append(VariantBase64Dict[(codingInt >> 6) & 0x3F]);
                result.Append(VariantBase64Dict[(codingInt >> 12) & 0x3F]);
                result.Append(VariantBase64Dict[(codingInt >> 18) & 0x3F]);
            }
            switch (leftBytes)
            {
                case 1:
                    {
                        int codingInt = bytes[3 * blocksCount];
                        result.Append(VariantBase64Dict[codingInt & 0x3F]);
                        result.Append(VariantBase64Dict[(codingInt >> 6) & 0x3F]);
                        break;
                    }
                case 2:
                    {
                        int codingInt = bytes[3 * blocksCount]
                            + (bytes[3 * blocksCount + 1] << 8);
                        result.Append(VariantBase64Dict[codingInt & 0x3F]);
                        result.Append(VariantBase64Dict[(codingInt >> 6) & 0x3F]);
                        result.Append(VariantBase64Dict[(codingInt >> 12) & 0x3F]);
                        break;
                    }
            }
            return result.ToString();
        }

        /// <summary>
        /// 解码
        /// </summary>
        public static string Decode(string strings)
        {
            StringBuilder result = new StringBuilder();
            int blocksCount = strings.Length / 4;
            int leftBytes = strings.Length % 4;
            for (int i = 0; i < blocksCount; i++)
            {
                int codingInt = VariantBase64ReverseDict[strings[4 * i]]
                    + (VariantBase64ReverseDict[strings[4 * i + 1]] << 6)
                    + (VariantBase64ReverseDict[strings[4 * i + 2]] << 12)
                    + (VariantBase64ReverseDict[strings[4 * i + 3]] << 18);
                result.Append((char)(codingInt & 0xFF));
                result.Append((char)((codingInt >> 8) & 0xFF));
                result.Append((char)(codingInt >> 16));
            }
            switch (leftBytes)
            {
                case 2:
                    {
                        int codingInt = VariantBase64ReverseDict[strings[4 * blocksCount]]
                            + (VariantBase64ReverseDict[strings[4 * blocksCount + 1]] << 6);
                        result.Append((char)codingInt);
                        break;
                    }
                case 3:
                    {
                        int codingInt = VariantBase64ReverseDict[strings[4 * blocksCount]]
                            + (VariantBase64ReverseDict[strings[4 * blocksCount + 1]] << 6)
                            + (VariantBase64ReverseDict[strings[4 * blocksCount + 2]] << 12);
                        result.Append((char)(codingInt & 0xFF));
                        result.Append((char)((codingInt >> 8) & 0xFF));
                        break;
                    }
            }
            return result.ToString();
        }

        /// <summary>
        /// 编码bytes
        /// </summary>
        public static byte[] EncryptBytes(int key, byte[] bytes)
        {
            byte[] result = new byte[bytes.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (byte)(bytes[i] ^ ((key >> 8) & 0xFF));
                key = result[i] & key | 0x482D;
            }
            return result;
        }

        /// <summary>
        /// 解码bytes
        /// </summary>
        public static byte[] DecryptBytes(int key, byte[] bytes)
        {
            byte[] result = new byte[bytes.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (byte)(bytes[i] ^ ((key >> 8) & 0xFF));
                key = bytes[i] & key | 0x482D;
            }
            return result;
        }

    }
}
