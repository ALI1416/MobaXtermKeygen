using System.IO;
using System.Text;

namespace MobaXtermKeygen
{

    /// <summary>
    /// 许可证
    /// <para>@createDate 2025/05/06 11:11:11</para>
    /// <para>@author ALI[ali-k@foxmail.com]</para>
    /// <para>@since 1.0.0</para>
    /// </summary>
    public class License
    {

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="type">类型</param>
        /// 1:Professional
        /// 3:Educational
        /// 4:Persional
        /// <param name="count">数量</param>
        /// <param name="username">用户名</param>
        /// <param name="majorVersion">主版本号</param>
        /// <param name="minorVersion">次版本号</param>
        public static void Generate(int type, int count, string username, int majorVersion, int minorVersion)
        {
            string licenseString = string.Format("{0}#{1}|{2}{3}#{4}#{5}3{6}6{7}#0#0#0#",
                type, username,
                majorVersion, minorVersion,
                count,
                majorVersion, minorVersion, minorVersion
                );
            //Console.WriteLine(licenseString);
            string encodedLicenseString = VariantBase64.Encode(VariantBase64.EncryptBytes(0x787, UTF8Encoding.UTF8.GetBytes(licenseString)));
            //Console.WriteLine(encodedLicenseString);
            //string decodedLicenseString = UTF8Encoding.UTF8.GetString(VariantBase64.DecryptBytes(0x787, UTF8Encoding.UTF8.GetBytes(VariantBase64.Decode(encodedLicenseString))));
            //Console.WriteLine(decodedLicenseString);

            /*非Stored类型，无效*/
            //FileStream fileStream = File.Open("./Custom.mxtpro", FileMode.Create);
            //ZipArchive zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create);
            //ZipArchiveEntry zipArchiveEntry = zipArchive.CreateEntry("Pro.key", CompressionLevel.NoCompression);
            //byte[] bytes = UTF8Encoding.UTF8.GetBytes(encodedLicenseString);
            //using (Stream stream = zipArchiveEntry.Open())
            //{
            //    stream.Write(bytes, 0, bytes.Length);
            //}
            //fileStream.Close();

            /*无效*/
            //FileStream fileStream = File.Open("./Custom.mxtpro", FileMode.Create);
            //ZipOutputStream zipOutputStream = new ZipOutputStream(fileStream);
            //ZipEntry zipEntry = new ZipEntry("Pro.key")
            //{
            //    CompressionMethod = CompressionMethod.Stored
            //};
            //zipOutputStream.PutNextEntry(zipEntry);
            //byte[] bytes = UTF8Encoding.UTF8.GetBytes(encodedLicenseString);
            //zipOutputStream.Write(bytes, 0, bytes.Length);
            //zipOutputStream.CloseEntry();
            //fileStream.Close();

            /*二进制写入(小端)*/
            //https://www.cnblogs.com/li-sx/p/17531186.html
            //文件头       4byte   04034B50
            //解压版本     2byte   0014     2.0版本 使用Deflate压缩来压缩文件
            //通用位标记   2byte   0000
            //压缩方式     2byte   0000     不压缩
            //修改时间     2byte   0000     00:00:00
            //修改日期     2byte   0021     1980-01-01
            //CRC32        4byte
            //压缩后大小   4byte
            //压缩前大小   4byte
            //文件名长度   2byte   0007      Pro.key
            //拓展区长度   2byte   0000
            //文件名               50726F2E6B6579  Pro.key
            //拓展区

            //文件头       4byte   02014B50
            //未知         4byte   00140014
            //未知         4byte   00000000
            //修改时间     2byte   0000     00:00:00
            //修改日期     2byte   0021     1980-01-01
            //CRC32        4byte
            //压缩后大小   4byte
            //压缩前大小   4byte
            //文件名长度   2byte   0007      Pro.key
            //未知         4byte   00000000
            //未知         4byte   00000000
            //未知         4byte   01800000
            //未知         4byte   00000000
            //文件名               50726F2E6B6579  Pro.key

            //文件头       4byte   06054B50
            //未知         4byte   00000000
            //未知         4byte   00010001
            //未知         4byte   00000035
            //大小         4byte   37+压缩前大小
            //未知         2byte   0000

            byte[] nameBytes = UTF8Encoding.UTF8.GetBytes("Pro.key");
            byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(encodedLicenseString);
            uint crc32 = Crc32.crc32(dataBytes);
            int length = dataBytes.Length;
            using (FileStream fileStream = File.Open("./Custom.mxtpro", FileMode.Create))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    binaryWriter.Write(0x04034B50);
                    binaryWriter.Write((short)0x0014);
                    binaryWriter.Write((short)0x0000);
                    binaryWriter.Write((short)0x0000);
                    binaryWriter.Write((short)0x0000);
                    binaryWriter.Write((short)0x0021);
                    binaryWriter.Write(crc32);
                    binaryWriter.Write(length);
                    binaryWriter.Write(length);
                    binaryWriter.Write((short)0x0007);
                    binaryWriter.Write((short)0x0000);
                    binaryWriter.Write(nameBytes);
                    binaryWriter.Write(dataBytes);

                    binaryWriter.Write(0x02014B50);
                    binaryWriter.Write(0x00140014);
                    binaryWriter.Write(0x00000000);
                    binaryWriter.Write((short)0x0000);
                    binaryWriter.Write((short)0x0021);
                    binaryWriter.Write(crc32);
                    binaryWriter.Write(length);
                    binaryWriter.Write(length);
                    binaryWriter.Write((short)0x0007);
                    binaryWriter.Write(0x00000000);
                    binaryWriter.Write(0x00000000);
                    binaryWriter.Write(0x01800000);
                    binaryWriter.Write(0x00000000);
                    binaryWriter.Write(nameBytes);

                    binaryWriter.Write(0x06054B50);
                    binaryWriter.Write(0x00000000);
                    binaryWriter.Write(0x00010001);
                    binaryWriter.Write(0x00000035);
                    binaryWriter.Write(37 + length);
                    binaryWriter.Write((short)0x0000);
                }
            }
        }

    }
}
