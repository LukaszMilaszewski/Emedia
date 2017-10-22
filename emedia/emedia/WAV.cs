using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace emedia {
    class Header {
        public string chunkID { get; set; }
        public int chunkSize { get; set; }
        public string format { get; set; }
        public string subchunk1ID { get; set; }
        public int subchunk1Size { get; set; }
        public short audioFormat { get; set; }
        public short numChanels { get; set; }
        public int sampleRate { get; set; }
        public int byteRate { get; set; }
        public short blockAlign { get; set; }
        public short bitsPerSample { get; set; }
        public string subchunk2ID { get; set; }
        public int subchunk2Size { get; set; }

        public void convertToBytes(BinaryWriter bw) {
            bw.Write(Encoding.ASCII.GetBytes(chunkID));
            bw.Write(BitConverter.GetBytes(chunkSize));
            bw.Write(Encoding.ASCII.GetBytes(format));
            bw.Write(Encoding.ASCII.GetBytes(subchunk1ID));
            bw.Write(BitConverter.GetBytes(subchunk1Size));
            bw.Write(BitConverter.GetBytes(audioFormat));
            bw.Write(BitConverter.GetBytes(numChanels));
            bw.Write(BitConverter.GetBytes(sampleRate));
            bw.Write(BitConverter.GetBytes(byteRate));
            bw.Write(BitConverter.GetBytes(blockAlign));
            bw.Write(BitConverter.GetBytes(bitsPerSample));
            bw.Write(Encoding.ASCII.GetBytes(subchunk2ID));
            bw.Write(BitConverter.GetBytes(subchunk2Size));
        }
    }

    class WAV {
        public Header header { get; private set; }
        public byte[] data { get; private set; }

        public WAV(BinaryReader br) {
            header = new Header();
            header.chunkID = Encoding.UTF8.GetString(br.ReadBytes(4));
            header.chunkSize = br.ReadInt32();
            header.format = Encoding.UTF8.GetString(br.ReadBytes(4));
            header.subchunk1ID = Encoding.UTF8.GetString(br.ReadBytes(4));
            header.subchunk1Size = br.ReadInt32();
            header.audioFormat = br.ReadInt16();
            header.numChanels = br.ReadInt16();
            header.sampleRate = br.ReadInt32();
            header.byteRate = br.ReadInt32();
            header.blockAlign = br.ReadInt16();
            header.bitsPerSample = br.ReadInt16();
            header.subchunk2ID = Encoding.UTF8.GetString(br.ReadBytes(4));
            header.subchunk2Size = br.ReadInt32();
            data = br.ReadBytes(header.subchunk2Size);
        }

        public void convertToBytes(BinaryWriter bw) {
            header.convertToBytes(bw);
            bw.Write(data);
        }
    }
}
