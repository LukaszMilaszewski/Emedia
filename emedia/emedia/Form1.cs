using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emedia
{
    public partial class Form1 : Form
    {

        WAV wav;

        public Form1()
        {
            InitializeComponent();
            loadTextBox.ReadOnly = true;
            SaveTextBox.ReadOnly = true;
            spectrumChart.Visible = false;
            listBox.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e) {
            var fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Files (wav)|*.wav";
            fileDialog.ShowDialog();
            SaveTextBox.Text = fileDialog.FileName;
            FileStream fs;
            fs = new FileStream(fileDialog.FileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            wav.convertToBytes(bw);
            bw.Close();
            fs.Close();
        }

        private void loadButton_Click(object sender, EventArgs e) {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Files (wav)|*.wav";
            fileDialog.ShowDialog();
            loadTextBox.Text = fileDialog.FileName;
            listBox.Items.Clear();

            FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            wav = new WAV(br);
            setListBox(wav);
            br.Close();
            fs.Close();
        
            listBox.Visible = true;
            spectrumChart.Visible = true;
        }

        private void setListBox(WAV wav) {
            listBox.Items.Add("chunkID: " + wav.header.chunkID);
            listBox.Items.Add("chunkSize: " + wav.header.chunkSize);
            listBox.Items.Add("format: " + wav.header.format);
            listBox.Items.Add("subchunk1ID: " + wav.header.subchunk1ID);
            listBox.Items.Add("subchunk1Size: " + wav.header.subchunk1Size);
            listBox.Items.Add("audioFormat: " + wav.header.audioFormat);
            listBox.Items.Add("NumChannels: " + wav.header.numChanels);
            listBox.Items.Add("SampleRate: " + wav.header.sampleRate);
            listBox.Items.Add("ByteRate: " + wav.header.byteRate);
            listBox.Items.Add("BlockAlign: " + wav.header.blockAlign);
            listBox.Items.Add("BitsPerSample: " + wav.header.bitsPerSample);
            listBox.Items.Add("subchunk2ID: " + wav.header.subchunk2ID);
            listBox.Items.Add("subchunk2Size: " + wav.header.subchunk2Size);
        }
    }

}
