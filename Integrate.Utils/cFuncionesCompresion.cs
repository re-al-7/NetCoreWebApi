namespace Integrate.Utils
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public static class cFuncionesCompresion
    {
        public static byte[] Compress(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream();
            GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true);
            zip.Write(buffer, 0, buffer.Length);
            zip.Close();
            ms.Position = 0;

            MemoryStream outStream = new MemoryStream();

            byte[] compressed = new byte[ms.Length];
            ms.Read(compressed, 0, compressed.Length);

            byte[] gzBuffer = new byte[compressed.Length + 4];
            Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
            return gzBuffer;
        }

        public static byte[] Decompress(byte[] gzBuffer)
        {
            MemoryStream ms = new MemoryStream();
            int msgLength = BitConverter.ToInt32(gzBuffer, 0);
            ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

            byte[] buffer = new byte[msgLength];

            ms.Position = 0;
            GZipStream zip = new GZipStream(ms, CompressionMode.Decompress);
            zip.Read(buffer, 0, buffer.Length);

            return buffer;
        }

        public static byte[] CompressTriDimensional(byte[,,] uncompressed)
        {
            if (uncompressed == null)
                throw new ArgumentNullException("uncompressed",
                                                "The given array is null!");
            if (uncompressed.LongLength > (long)int.MaxValue)
                throw new ArgumentException("The given array is to large!");

            using (MemoryStream ms = new MemoryStream())
            using (GZipStream gzs = new GZipStream(ms, CompressionMode.Compress))
            {
                // Save sizes of the dimensions
                for (int dim = 0; dim < 3; dim++)
                    gzs.Write(BitConverter.GetBytes(
                        uncompressed.GetLength(dim)), 0, sizeof(int));

                // Convert byte[,,] to byte[] by just blockcopying it
                // I know, some pointer-magic/unmanaged cast wouldnt 
                // have to copy it, but its cleaner this way...
                byte[] data = new byte[uncompressed.Length];
                Buffer.BlockCopy(uncompressed, 0, data, 0, uncompressed.Length);

                // Write the data to the stream to compress it
                gzs.Write(data, 0, data.Length);
                gzs.Close();

                // Get the compressed byte array back
                return ms.ToArray();
            }
        }

        public static byte[,,] DecompressTriDimensional(byte[] compressed)
        {
            if (compressed == null)
                throw new ArgumentNullException("compressed",
                                                "Data to decompress cant be null!");

            using (MemoryStream ms = new MemoryStream(compressed))
            using (GZipStream gzs = new GZipStream(ms, CompressionMode.Decompress))
            {
                // Read the header and restore sizes of dimensions
                byte[] dimheader = new byte[sizeof(int) * 3];
                gzs.Read(dimheader, 0, dimheader.Length);
                int[] dims = new int[3];
                for (int j = 0; j < 3; j++)
                    dims[j] = BitConverter.ToInt32(dimheader, sizeof(int) * j);

                // Read the data into a buffer
                byte[] data = new byte[dims[0] * dims[1] * dims[2]];
                gzs.Read(data, 0, data.Length);

                // Copy the buffer to the three-dimensional array
                byte[,,] uncompressed = new byte[dims[0], dims[1], dims[2]];
                Buffer.BlockCopy(data, 0, uncompressed, 0, data.Length);

                return uncompressed;
            }
        }
    }
}
