namespace Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.AlgorithmsComboBox = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DatasetListView = new System.Windows.Forms.ListView();
            this.Statistics = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.StartSamplingButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.SampleListView = new System.Windows.Forms.ListView();
            this.StatisticsSample = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValueSample = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RestartLabel = new System.Windows.Forms.Label();
            this.RestartUpDown = new System.Windows.Forms.NumericUpDown();
            this.SaveCsvButton = new System.Windows.Forms.Button();
            this.PrintReportButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestartUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Algorithm:";
            // 
            // AlgorithmsComboBox
            // 
            this.AlgorithmsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgorithmsComboBox.FormattingEnabled = true;
            this.AlgorithmsComboBox.Location = new System.Drawing.Point(65, 23);
            this.AlgorithmsComboBox.Name = "AlgorithmsComboBox";
            this.AlgorithmsComboBox.Size = new System.Drawing.Size(162, 21);
            this.AlgorithmsComboBox.TabIndex = 1;
            this.AlgorithmsComboBox.SelectedIndexChanged += new System.EventHandler(this.AlgorithmsComboBox_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Select Dataset";
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BrowseButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.BrowseButton.Location = new System.Drawing.Point(12, 12);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(106, 23);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Load Dataset";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DatasetListView);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 274);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network";
            // 
            // DatasetListView
            // 
            this.DatasetListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Statistics,
            this.Value});
            this.DatasetListView.Location = new System.Drawing.Point(7, 20);
            this.DatasetListView.Name = "DatasetListView";
            this.DatasetListView.Size = new System.Drawing.Size(217, 248);
            this.DatasetListView.TabIndex = 0;
            this.DatasetListView.UseCompatibleStateImageBehavior = false;
            this.DatasetListView.View = System.Windows.Forms.View.Details;
            // 
            // Statistics
            // 
            this.Statistics.Text = "Statistics";
            this.Statistics.Width = 88;
            // 
            // Value
            // 
            this.Value.Text = "Value";
            this.Value.Width = 124;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SampleListView);
            this.groupBox2.Location = new System.Drawing.Point(497, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 274);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sample";
            // 
            // StartSamplingButton
            // 
            this.StartSamplingButton.Enabled = false;
            this.StartSamplingButton.Location = new System.Drawing.Point(124, 12);
            this.StartSamplingButton.Name = "StartSamplingButton";
            this.StartSamplingButton.Size = new System.Drawing.Size(98, 23);
            this.StartSamplingButton.TabIndex = 5;
            this.StartSamplingButton.Text = "Start Sampling";
            this.StartSamplingButton.UseVisualStyleBackColor = true;
            this.StartSamplingButton.Click += new System.EventHandler(this.StartSamplingButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RestartUpDown);
            this.groupBox3.Controls.Add(this.RestartLabel);
            this.groupBox3.Controls.Add(this.SizeUpDown);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.AlgorithmsComboBox);
            this.groupBox3.Location = new System.Drawing.Point(248, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(243, 274);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sampling setting";
            // 
            // SizeUpDown
            // 
            this.SizeUpDown.DecimalPlaces = 2;
            this.SizeUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.SizeUpDown.Location = new System.Drawing.Point(65, 65);
            this.SizeUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SizeUpDown.Name = "SizeUpDown";
            this.SizeUpDown.Size = new System.Drawing.Size(162, 20);
            this.SizeUpDown.TabIndex = 3;
            this.SizeUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            131072});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Size:";
            // 
            // SampleListView
            // 
            this.SampleListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StatisticsSample,
            this.ValueSample});
            this.SampleListView.Location = new System.Drawing.Point(7, 20);
            this.SampleListView.Name = "SampleListView";
            this.SampleListView.Size = new System.Drawing.Size(232, 248);
            this.SampleListView.TabIndex = 0;
            this.SampleListView.UseCompatibleStateImageBehavior = false;
            this.SampleListView.View = System.Windows.Forms.View.Details;
            // 
            // StatisticsSample
            // 
            this.StatisticsSample.Text = "Statistics";
            this.StatisticsSample.Width = 127;
            // 
            // ValueSample
            // 
            this.ValueSample.Text = "Value";
            this.ValueSample.Width = 73;
            // 
            // RestartLabel
            // 
            this.RestartLabel.AutoSize = true;
            this.RestartLabel.Location = new System.Drawing.Point(7, 100);
            this.RestartLabel.Name = "RestartLabel";
            this.RestartLabel.Size = new System.Drawing.Size(44, 13);
            this.RestartLabel.TabIndex = 4;
            this.RestartLabel.Text = "Restart:";
            this.RestartLabel.Visible = false;
            // 
            // RestartUpDown
            // 
            this.RestartUpDown.DecimalPlaces = 2;
            this.RestartUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.RestartUpDown.Location = new System.Drawing.Point(65, 98);
            this.RestartUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RestartUpDown.Name = "RestartUpDown";
            this.RestartUpDown.Size = new System.Drawing.Size(162, 20);
            this.RestartUpDown.TabIndex = 5;
            this.RestartUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            131072});
            this.RestartUpDown.Visible = false;
            // 
            // SaveCsvButton
            // 
            this.SaveCsvButton.Enabled = false;
            this.SaveCsvButton.Location = new System.Drawing.Point(504, 12);
            this.SaveCsvButton.Name = "SaveCsvButton";
            this.SaveCsvButton.Size = new System.Drawing.Size(80, 23);
            this.SaveCsvButton.TabIndex = 7;
            this.SaveCsvButton.Text = "Save as CSV";
            this.SaveCsvButton.UseVisualStyleBackColor = true;
            this.SaveCsvButton.Click += new System.EventHandler(this.SaveCsvButton_Click);
            // 
            // PrintReportButton
            // 
            this.PrintReportButton.Enabled = false;
            this.PrintReportButton.Location = new System.Drawing.Point(590, 12);
            this.PrintReportButton.Name = "PrintReportButton";
            this.PrintReportButton.Size = new System.Drawing.Size(75, 23);
            this.PrintReportButton.TabIndex = 8;
            this.PrintReportButton.Text = "Print Report";
            this.PrintReportButton.UseMnemonic = false;
            this.PrintReportButton.UseVisualStyleBackColor = true;
            this.PrintReportButton.Click += new System.EventHandler(this.PrintReportButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 365);
            this.Controls.Add(this.PrintReportButton);
            this.Controls.Add(this.SaveCsvButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.StartSamplingButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Network Sampling";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RestartUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AlgorithmsComboBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView DatasetListView;
        private System.Windows.Forms.ColumnHeader Statistics;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button StartSamplingButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown SizeUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView SampleListView;
        private System.Windows.Forms.ColumnHeader StatisticsSample;
        private System.Windows.Forms.ColumnHeader ValueSample;
        private System.Windows.Forms.NumericUpDown RestartUpDown;
        private System.Windows.Forms.Label RestartLabel;
        private System.Windows.Forms.Button SaveCsvButton;
        private System.Windows.Forms.Button PrintReportButton;
    }
}

