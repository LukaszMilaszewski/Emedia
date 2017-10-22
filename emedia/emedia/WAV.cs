using System;
using System.Collections.Generic;
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
    }
}
