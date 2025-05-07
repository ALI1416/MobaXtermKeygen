namespace MobaXtermKeygen
{

    /// <summary>
    /// CRC32
    /// <para>@createDate 2024/12/04 11:11:11</para>
    /// <para>@author ALI[ali-k@foxmail.com]</para>
    /// <para>@since 1.0.0</para>
    /// <see href="https://github.com/nodeca/pako/blob/master/lib/zlib/crc32.js"/>
    /// </summary>
    public class Crc32
    {

        /// <summary>
        /// 生成CRC表
        /// </summary>
        /// <returns>CRC表</returns>
        private static uint[] makeTable()
        {
            uint temp;
            uint[] table = new uint[256];
            for (uint i = 0; i < 256; i++)
            {
                temp = i;
                for (int j = 0; j < 8; j++)
                {
                    temp = ((temp & 1) == 1) ? (0xEDB88320 ^ (temp >> 1)) : (temp >> 1);
                }
                table[i] = temp;
            }
            return table;
        }

        /// <summary>
        /// CRC表
        /// </summary>
        private static uint[] crcTable = makeTable();

        /// <summary>
        /// 计算CRC32
        /// </summary>
        /// <param name="buffer">数据</param>
        /// <returns>CRC32</returns>
        public static uint crc32(byte[] buffer)
        {
            uint crc = 0xFFFFFFFF;
            for (int i = 0; i < buffer.Length; i++)
            {
                crc = (crc >> 8) ^ crcTable[(crc ^ buffer[i]) & 0xFF];
            }
            return crc ^ 0xFFFFFFFF;
        }

    }
}
