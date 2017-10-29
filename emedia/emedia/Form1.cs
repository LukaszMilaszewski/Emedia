using System;
using System.IO;
using System.Windows.Forms;
using AForge.Math;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace emedia {
    public partial class Form1 : Form {

        List<Point> pointsList = new List<Point>();
        WAV wav;

        public Form1() {
            InitializeComponent();
            loadTextBox.ReadOnly = true;
            SaveTextBox.ReadOnly = true;
            spectrumChart.Visible = false;
            listBox.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e) { }

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
            MessageBox.Show("File saved!");
        }

        private void loadButton_Click(object sender, EventArgs e) {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Files (wav)|*.wav";
            fileDialog.ShowDialog();
            loadTextBox.Text = fileDialog.FileName;
            listBox.Items.Clear();
            pointsList.Clear();
            FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            wav = new WAV(br, (int)fs.Length);
            setListBox(wav);
            br.Close();
            fs.Close();

            listBox.Visible = true;
            spectrumChart.Visible = true;
            spectrumChart.Series.Clear();
            spectrumChart.Update();
            spectrumChart.ResetAutoValues();

            var tabCom = new Complex[1024];
            float[] data = wav.getFloatData();
            for (int i = 0; i < 1024; i++) {
                tabCom[i] = new Complex(data[i], 0);
            }

            FourierTransform.FFT(tabCom, FourierTransform.Direction.Forward);

            for (int i = 0; i < 512; i++) {
                pointsList.Add(new Point() { x = (wav.header.sampleRate * i) / 511, y = tabCom[i].Magnitude * 1000 });
            }
            spectrumChart.Series.Clear();
            spectrumChart.Series.Add("Spectrum");

            foreach (var p in pointsList) {
                spectrumChart.Series["Spectrum"].Points.AddXY(p.x, p.y);
            }


            MessageBox.Show("File loaded!");
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

        private void encryptButton_Click(object sender, EventArgs e) {
            RSA.createKeys(233, 293);
            wav.data = RSA.getEncryptedData(wav.data);
            MessageBox.Show("Encrypted!");
        }

        private void decryptButton_Click(object sender, EventArgs e) {
            RSA.createKeys(233, 293);
            wav.data = RSA.getDecryptedData(wav.data);
            MessageBox.Show("Decrypted!");
        }
    }
}
