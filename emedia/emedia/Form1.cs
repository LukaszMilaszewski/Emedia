using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void loadButton_Click(object sender, EventArgs e) {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Files (wav)|*.wav";
            fileDialog.ShowDialog();
            loadTextBox.Text = fileDialog.FileName;
           
            FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            wav = new WAV(br);
            setListBox(wav);
        
            listBox.Visible = true;
            spectrumChart.Visible = true;
        }

        private void setListBox(WAV wav) {
            listBox.Items.Add("chunkID: " + wav.chunkID);
            listBox.Items.Add("chunkSize: " + wav.chunkSize);
            listBox.Items.Add("format: " + wav.format);
            listBox.Items.Add("subchunk1ID: " + wav.subchunk1ID);
            listBox.Items.Add("subchunk1Size: " + wav.subchunk1Size);
            listBox.Items.Add("audioFormat: " + wav.audioFormat);
            listBox.Items.Add("NumChannels: " + wav.numChanels);
            listBox.Items.Add("SampleRate: " + wav.sampleRate);
            listBox.Items.Add("ByteRate: " + wav.byteRate);
            listBox.Items.Add("BlockAlign: " + wav.blockAlign);
            listBox.Items.Add("BitsPerSample: " + wav.bitsPerSample);
            listBox.Items.Add("subchunk2ID: " + wav.subchunk2ID);
            listBox.Items.Add("subchunk2Size: " + wav.subchunk2Size);
        }
    }
}
