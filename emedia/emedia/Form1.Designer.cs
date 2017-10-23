namespace emedia
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.listBox = new System.Windows.Forms.ListBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.spectrumChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.loadTextBox = new System.Windows.Forms.TextBox();
            this.SaveTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.spectrumChart)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(527, 334);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(259, 199);
            this.listBox.TabIndex = 1;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(431, 368);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(431, 430);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(56, 499);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(192, 23);
            this.encryptButton.TabIndex = 4;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(319, 499);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(187, 23);
            this.decryptButton.TabIndex = 5;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            // 
            // spectrumChart
            // 
            chartArea1.Name = "ChartArea1";
            this.spectrumChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.spectrumChart.Legends.Add(legend1);
            this.spectrumChart.Location = new System.Drawing.Point(56, -2);
            this.spectrumChart.Name = "spectrumChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Spectrum";
            this.spectrumChart.Series.Add(series1);
            this.spectrumChart.Size = new System.Drawing.Size(730, 302);
            this.spectrumChart.TabIndex = 6;
            this.spectrumChart.Text = "Spectrum Chart";
            title1.Name = "Title1";
            title1.Text = "FFT - 1000 samples";
            this.spectrumChart.Titles.Add(title1);
            // 
            // loadTextBox
            // 
            this.loadTextBox.Location = new System.Drawing.Point(56, 370);
            this.loadTextBox.Name = "loadTextBox";
            this.loadTextBox.Size = new System.Drawing.Size(369, 20);
            this.loadTextBox.TabIndex = 7;
            // 
            // SaveTextBox
            // 
            this.SaveTextBox.Location = new System.Drawing.Point(56, 430);
            this.SaveTextBox.Name = "SaveTextBox";
            this.SaveTextBox.Size = new System.Drawing.Size(369, 20);
            this.SaveTextBox.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 559);
            this.Controls.Add(this.SaveTextBox);
            this.Controls.Add(this.loadTextBox);
            this.Controls.Add(this.spectrumChart);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.listBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spectrumChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart spectrumChart;
        private System.Windows.Forms.TextBox loadTextBox;
        private System.Windows.Forms.TextBox SaveTextBox;
    }
}

