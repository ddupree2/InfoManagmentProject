namespace CS3230Project
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
            this.testResultsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.systolicTextBox = new System.Windows.Forms.TextBox();
            this.diagnosisTextBox = new System.Windows.Forms.TextBox();
            this.patientIDTextBox = new System.Windows.Forms.TextBox();
            this.nurseIDTextBox = new System.Windows.Forms.TextBox();
            this.otherTextBox = new System.Windows.Forms.TextBox();
            this.bodyTempTextBox = new System.Windows.Forms.TextBox();
            this.respirationRateTextBox = new System.Windows.Forms.TextBox();
            this.heartRateTextBox = new System.Windows.Forms.TextBox();
            this.diastolicTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.finalDiagnosisCheckBox = new System.Windows.Forms.CheckBox();
            this.AppointmentDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // testResultsListBox
            // 
            this.testResultsListBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.testResultsListBox.FormattingEnabled = true;
            this.testResultsListBox.ItemHeight = 20;
            this.testResultsListBox.Location = new System.Drawing.Point(588, 36);
            this.testResultsListBox.Name = "testResultsListBox";
            this.testResultsListBox.Size = new System.Drawing.Size(356, 644);
            this.testResultsListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(584, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Test Results:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Systolic #:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Diastolic #:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Heart Rate:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Respiration Rate:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Body Temp:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(98, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Other:";
            // 
            // systolicTextBox
            // 
            this.systolicTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.systolicTextBox.Location = new System.Drawing.Point(157, 50);
            this.systolicTextBox.Name = "systolicTextBox";
            this.systolicTextBox.Size = new System.Drawing.Size(274, 26);
            this.systolicTextBox.TabIndex = 8;
            // 
            // diagnosisTextBox
            // 
            this.diagnosisTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.diagnosisTextBox.Location = new System.Drawing.Point(157, 565);
            this.diagnosisTextBox.Multiline = true;
            this.diagnosisTextBox.Name = "diagnosisTextBox";
            this.diagnosisTextBox.Size = new System.Drawing.Size(274, 115);
            this.diagnosisTextBox.TabIndex = 9;
            // 
            // patientIDTextBox
            // 
            this.patientIDTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.patientIDTextBox.Location = new System.Drawing.Point(157, 447);
            this.patientIDTextBox.Name = "patientIDTextBox";
            this.patientIDTextBox.Size = new System.Drawing.Size(274, 26);
            this.patientIDTextBox.TabIndex = 11;
            // 
            // nurseIDTextBox
            // 
            this.nurseIDTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nurseIDTextBox.Location = new System.Drawing.Point(157, 390);
            this.nurseIDTextBox.Name = "nurseIDTextBox";
            this.nurseIDTextBox.Size = new System.Drawing.Size(274, 26);
            this.nurseIDTextBox.TabIndex = 12;
            // 
            // otherTextBox
            // 
            this.otherTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.otherTextBox.Location = new System.Drawing.Point(157, 333);
            this.otherTextBox.Name = "otherTextBox";
            this.otherTextBox.Size = new System.Drawing.Size(274, 26);
            this.otherTextBox.TabIndex = 13;
            // 
            // bodyTempTextBox
            // 
            this.bodyTempTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bodyTempTextBox.Location = new System.Drawing.Point(157, 275);
            this.bodyTempTextBox.Name = "bodyTempTextBox";
            this.bodyTempTextBox.Size = new System.Drawing.Size(274, 26);
            this.bodyTempTextBox.TabIndex = 14;
            // 
            // respirationRateTextBox
            // 
            this.respirationRateTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.respirationRateTextBox.Location = new System.Drawing.Point(157, 220);
            this.respirationRateTextBox.Name = "respirationRateTextBox";
            this.respirationRateTextBox.Size = new System.Drawing.Size(274, 26);
            this.respirationRateTextBox.TabIndex = 15;
            // 
            // heartRateTextBox
            // 
            this.heartRateTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.heartRateTextBox.Location = new System.Drawing.Point(157, 161);
            this.heartRateTextBox.Name = "heartRateTextBox";
            this.heartRateTextBox.Size = new System.Drawing.Size(274, 26);
            this.heartRateTextBox.TabIndex = 16;
            // 
            // diastolicTextBox
            // 
            this.diastolicTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.diastolicTextBox.Location = new System.Drawing.Point(157, 105);
            this.diastolicTextBox.Name = "diastolicTextBox";
            this.diastolicTextBox.Size = new System.Drawing.Size(274, 26);
            this.diastolicTextBox.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 393);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Nurse ID:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 508);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Appointment Date:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(68, 568);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Diagnosis:";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(67, 450);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "Patient ID:";
            // 
            // finalDiagnosisCheckBox
            // 
            this.finalDiagnosisCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.finalDiagnosisCheckBox.AutoSize = true;
            this.finalDiagnosisCheckBox.Location = new System.Drawing.Point(444, 656);
            this.finalDiagnosisCheckBox.Name = "finalDiagnosisCheckBox";
            this.finalDiagnosisCheckBox.Size = new System.Drawing.Size(136, 24);
            this.finalDiagnosisCheckBox.TabIndex = 22;
            this.finalDiagnosisCheckBox.Text = "Final Diagnosis";
            this.finalDiagnosisCheckBox.UseVisualStyleBackColor = true;
            // 
            // AppointmentDateTimePicker
            // 
            this.AppointmentDateTimePicker.Location = new System.Drawing.Point(157, 503);
            this.AppointmentDateTimePicker.Name = "AppointmentDateTimePicker";
            this.AppointmentDateTimePicker.Size = new System.Drawing.Size(274, 26);
            this.AppointmentDateTimePicker.TabIndex = 23;
            // 
            // VisitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 692);
            this.Controls.Add(this.AppointmentDateTimePicker);
            this.Controls.Add(this.finalDiagnosisCheckBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.diastolicTextBox);
            this.Controls.Add(this.heartRateTextBox);
            this.Controls.Add(this.respirationRateTextBox);
            this.Controls.Add(this.bodyTempTextBox);
            this.Controls.Add(this.otherTextBox);
            this.Controls.Add(this.nurseIDTextBox);
            this.Controls.Add(this.patientIDTextBox);
            this.Controls.Add(this.diagnosisTextBox);
            this.Controls.Add(this.systolicTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.testResultsListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VisitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visit Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox testResultsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox systolicTextBox;
        private System.Windows.Forms.TextBox diagnosisTextBox;
        private System.Windows.Forms.TextBox patientIDTextBox;
        private System.Windows.Forms.TextBox nurseIDTextBox;
        private System.Windows.Forms.TextBox otherTextBox;
        private System.Windows.Forms.TextBox bodyTempTextBox;
        private System.Windows.Forms.TextBox respirationRateTextBox;
        private System.Windows.Forms.TextBox heartRateTextBox;
        private System.Windows.Forms.TextBox diastolicTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox finalDiagnosisCheckBox;
        private System.Windows.Forms.DateTimePicker AppointmentDateTimePicker;
    }
}