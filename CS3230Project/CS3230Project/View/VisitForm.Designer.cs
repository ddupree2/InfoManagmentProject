namespace CS3230Project.View
{
    partial class VisitForm
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.systolicTextBox = new System.Windows.Forms.TextBox();
            this.diagnosisTextBox = new System.Windows.Forms.TextBox();
            this.otherTextBox = new System.Windows.Forms.TextBox();
            this.bodyTempTextBox = new System.Windows.Forms.TextBox();
            this.respirationRateTextBox = new System.Windows.Forms.TextBox();
            this.heartRateTextBox = new System.Windows.Forms.TextBox();
            this.diastolicTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.finalDiagnosisCheckBox = new System.Windows.Forms.CheckBox();
            this.testResultsGridView = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.patientIDTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nurseComboBox = new System.Windows.Forms.ComboBox();
            this.apppointmentComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.testResultsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(584, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Test Results:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Systolic #:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Diastolic #:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Heart Rate:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 440);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Respiration Rate:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 495);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Body Temp:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 553);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Other:";
            // 
            // systolicTextBox
            // 
            this.systolicTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.systolicTextBox.Location = new System.Drawing.Point(157, 267);
            this.systolicTextBox.Name = "systolicTextBox";
            this.systolicTextBox.Size = new System.Drawing.Size(274, 26);
            this.systolicTextBox.TabIndex = 8;
            // 
            // diagnosisTextBox
            // 
            this.diagnosisTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.diagnosisTextBox.Location = new System.Drawing.Point(157, 607);
            this.diagnosisTextBox.Multiline = true;
            this.diagnosisTextBox.Name = "diagnosisTextBox";
            this.diagnosisTextBox.Size = new System.Drawing.Size(274, 73);
            this.diagnosisTextBox.TabIndex = 9;
            // 
            // otherTextBox
            // 
            this.otherTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.otherTextBox.Location = new System.Drawing.Point(157, 550);
            this.otherTextBox.Name = "otherTextBox";
            this.otherTextBox.Size = new System.Drawing.Size(274, 26);
            this.otherTextBox.TabIndex = 13;
            // 
            // bodyTempTextBox
            // 
            this.bodyTempTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bodyTempTextBox.Location = new System.Drawing.Point(157, 492);
            this.bodyTempTextBox.Name = "bodyTempTextBox";
            this.bodyTempTextBox.Size = new System.Drawing.Size(274, 26);
            this.bodyTempTextBox.TabIndex = 14;
            // 
            // respirationRateTextBox
            // 
            this.respirationRateTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.respirationRateTextBox.Location = new System.Drawing.Point(157, 437);
            this.respirationRateTextBox.Name = "respirationRateTextBox";
            this.respirationRateTextBox.Size = new System.Drawing.Size(274, 26);
            this.respirationRateTextBox.TabIndex = 15;
            // 
            // heartRateTextBox
            // 
            this.heartRateTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.heartRateTextBox.Location = new System.Drawing.Point(157, 378);
            this.heartRateTextBox.Name = "heartRateTextBox";
            this.heartRateTextBox.Size = new System.Drawing.Size(274, 26);
            this.heartRateTextBox.TabIndex = 16;
            // 
            // diastolicTextBox
            // 
            this.diastolicTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.diastolicTextBox.Location = new System.Drawing.Point(157, 322);
            this.diastolicTextBox.Name = "diastolicTextBox";
            this.diastolicTextBox.Size = new System.Drawing.Size(274, 26);
            this.diastolicTextBox.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(68, 607);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Diagnosis:";
            // 
            // finalDiagnosisCheckBox
            // 
            this.finalDiagnosisCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.finalDiagnosisCheckBox.AutoSize = true;
            this.finalDiagnosisCheckBox.Location = new System.Drawing.Point(446, 656);
            this.finalDiagnosisCheckBox.Name = "finalDiagnosisCheckBox";
            this.finalDiagnosisCheckBox.Size = new System.Drawing.Size(136, 24);
            this.finalDiagnosisCheckBox.TabIndex = 22;
            this.finalDiagnosisCheckBox.Text = "Final Diagnosis";
            this.finalDiagnosisCheckBox.UseVisualStyleBackColor = true;
            // 
            // testResultsGridView
            // 
            this.testResultsGridView.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.testResultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.testResultsGridView.Location = new System.Drawing.Point(588, 77);
            this.testResultsGridView.Name = "testResultsGridView";
            this.testResultsGridView.Size = new System.Drawing.Size(637, 603);
            this.testResultsGridView.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(67, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 20);
            this.label11.TabIndex = 26;
            this.label11.Text = "Patient ID:";
            // 
            // patientIDTextBox
            // 
            this.patientIDTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.patientIDTextBox.Enabled = false;
            this.patientIDTextBox.Location = new System.Drawing.Point(157, 162);
            this.patientIDTextBox.Name = "patientIDTextBox";
            this.patientIDTextBox.Size = new System.Drawing.Size(274, 26);
            this.patientIDTextBox.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(96, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Nurse:";
            // 
            // nurseComboBox
            // 
            this.nurseComboBox.FormattingEnabled = true;
            this.nurseComboBox.Location = new System.Drawing.Point(157, 215);
            this.nurseComboBox.Name = "nurseComboBox";
            this.nurseComboBox.Size = new System.Drawing.Size(274, 28);
            this.nurseComboBox.TabIndex = 29;
            // 
            // apppointmentComboBox
            // 
            this.apppointmentComboBox.FormattingEnabled = true;
            this.apppointmentComboBox.Location = new System.Drawing.Point(157, 58);
            this.apppointmentComboBox.Name = "apppointmentComboBox";
            this.apppointmentComboBox.Size = new System.Drawing.Size(274, 28);
            this.apppointmentComboBox.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(96, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 20);
            this.label9.TabIndex = 32;
            this.label9.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Location = new System.Drawing.Point(157, 111);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(274, 26);
            this.nameTextBox.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(47, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 20);
            this.label12.TabIndex = 33;
            this.label12.Text = "Appointment:";
            // 
            // VisitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 747);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.apppointmentComboBox);
            this.Controls.Add(this.nurseComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.patientIDTextBox);
            this.Controls.Add(this.testResultsGridView);
            this.Controls.Add(this.finalDiagnosisCheckBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.diastolicTextBox);
            this.Controls.Add(this.heartRateTextBox);
            this.Controls.Add(this.respirationRateTextBox);
            this.Controls.Add(this.bodyTempTextBox);
            this.Controls.Add(this.otherTextBox);
            this.Controls.Add(this.diagnosisTextBox);
            this.Controls.Add(this.systolicTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VisitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visit Info";
            ((System.ComponentModel.ISupportInitialize)(this.testResultsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox systolicTextBox;
        private System.Windows.Forms.TextBox diagnosisTextBox;
        private System.Windows.Forms.TextBox otherTextBox;
        private System.Windows.Forms.TextBox bodyTempTextBox;
        private System.Windows.Forms.TextBox respirationRateTextBox;
        private System.Windows.Forms.TextBox heartRateTextBox;
        private System.Windows.Forms.TextBox diastolicTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox finalDiagnosisCheckBox;
        private System.Windows.Forms.DataGridView testResultsGridView;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox patientIDTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox nurseComboBox;
        private System.Windows.Forms.ComboBox apppointmentComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label12;
    }
}