using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emedia
{
    class WAV
    {
        public string chunkID { get; private set; }
        public int chunkSize { get; private set; }
        public string format { get; private set; }
        public string subchunk1ID { get; private set; }
        public int subchunk1Size { get; private set; }
        public int audioFormat { get; private set; }
        public int numChanels { get; private set; }
        public int sampleRate { get; private set; }
        public int byteRate { get; private set; }
        public int blockAlign { get; private set; }
        public int bitsPerSample { get; private set; }
        public string subchunk2ID { get; private set; }
        public int subchunk2Size { get; private set; }
        public float[,] data { get; private set; }
        public byte[] dataByte { get; set; }
        public byte[] headerByte { get; private set; }

        public WAV(BinaryReader br) {
            chunkID = Encoding.UTF8.GetString(br.ReadBytes(4));
            chunkSize = br.ReadInt32();
            format = Encoding.UTF8.GetString(br.ReadBytes(4));
            subchunk1ID = Encoding.UTF8.GetString(br.ReadBytes(4));
            subchunk1Size = br.ReadInt32();
            audioFormat = br.ReadInt16();
            numChanels = br.ReadInt16();
            sampleRate = br.ReadInt32();
            byteRate = br.ReadInt32();
            blockAlign = br.ReadInt16();
            bitsPerSample = br.ReadInt16();
            subchunk2ID = Encoding.UTF8.GetString(br.ReadBytes(4));
            subchunk2Size = br.ReadInt32();
            //dataByte = new byte[bytes.Length - 44];
            //headerByte = new byte[44];
            //Array.Copy(bytes, 44, dataByte, 0, bytes.Length - 44);
            //Array.Copy(bytes, 0, headerByte, 0, 44);
            //data = new float[numChanels, subchunk2Size / 2 / numChanels];
            //int index = 0;
            //int nr = 44;
            //while (nr < subchunk2Size + 42)
            //{
            //    for (var i = 0; i < numChanels; ++i)
            //    {
            //        data[i, index] = readFloat2(bytes, nr, nr + 2);
            //        nr += 2;
            //        if (nr >= subchunk2Size + 42)
            //            break;
            //        // Console.WriteLine(Data[i, index]);
            //    }
            //    index++;
            //}
        }
    }
}
