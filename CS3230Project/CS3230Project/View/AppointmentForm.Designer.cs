namespace CS3230Project
{
    partial class AppointmentForm
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
            this.appointmentDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.appointmentLabel = new System.Windows.Forms.Label();
            this.doctorLabel = new System.Windows.Forms.Label();
            this.patientIDTextBox = new System.Windows.Forms.TextBox();
            this.patientLabel = new System.Windows.Forms.Label();
            this.reasonTextBox = new System.Windows.Forms.TextBox();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.doctorIDComboBox = new System.Windows.Forms.ComboBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // appointmentDateTimePicker
            // 
            this.appointmentDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentDateTimePicker.Location = new System.Drawing.Point(189, 50);
            this.appointmentDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.appointmentDateTimePicker.Name = "appointmentDateTimePicker";
            this.appointmentDateTimePicker.Size = new System.Drawing.Size(353, 30);
            this.appointmentDateTimePicker.TabIndex = 0;
            // 
            // appointmentLabel
            // 
            this.appointmentLabel.AutoSize = true;
            this.appointmentLabel.Location = new System.Drawing.Point(8, 50);
            this.appointmentLabel.Name = "appointmentLabel";
            this.appointmentLabel.Size = new System.Drawing.Size(174, 25);
            this.appointmentLabel.TabIndex = 1;
            this.appointmentLabel.Text = "Appointment Date:";
            // 
            // doctorLabel
            // 
            this.doctorLabel.AutoSize = true;
            this.doctorLabel.Location = new System.Drawing.Point(73, 120);
            this.doctorLabel.Name = "doctorLabel";
            this.doctorLabel.Size = new System.Drawing.Size(69, 25);
            this.doctorLabel.TabIndex = 2;
            this.doctorLabel.Text = "Doctor";
            // 
            // patientIDTextBox
            // 
            this.patientIDTextBox.Enabled = false;
            this.patientIDTextBox.Location = new System.Drawing.Point(154, 191);
            this.patientIDTextBox.MaxLength = 20;
            this.patientIDTextBox.Name = "patientIDTextBox";
            this.patientIDTextBox.Size = new System.Drawing.Size(282, 30);
            this.patientIDTextBox.TabIndex = 5;
            // 
            // patientLabel
            // 
            this.patientLabel.AutoSize = true;
            this.patientLabel.Location = new System.Drawing.Point(73, 194);
            this.patientLabel.Name = "patientLabel";
            this.patientLabel.Size = new System.Drawing.Size(72, 25);
            this.patientLabel.TabIndex = 4;
            this.patientLabel.Text = "Patient";
            // 
            // reasonTextBox
            // 
            this.reasonTextBox.Location = new System.Drawing.Point(12, 298);
            this.reasonTextBox.MaxLength = 300;
            this.reasonTextBox.Multiline = true;
            this.reasonTextBox.Name = "reasonTextBox";
            this.reasonTextBox.Size = new System.Drawing.Size(615, 168);
            this.reasonTextBox.TabIndex = 6;
            // 
            // reasonLabel
            // 
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Location = new System.Drawing.Point(10, 275);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(109, 25);
            this.reasonLabel.TabIndex = 7;
            this.reasonLabel.Text = "Reason(s):";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(407, 476);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 37);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(527, 476);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 37);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // doctorIDComboBox
            // 
            this.doctorIDComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.doctorIDComboBox.FormattingEnabled = true;
            this.doctorIDComboBox.Location = new System.Drawing.Point(148, 120);
            this.doctorIDComboBox.MaxDropDownItems = 20;
            this.doctorIDComboBox.Name = "doctorIDComboBox";
            this.doctorIDComboBox.Size = new System.Drawing.Size(288, 33);
            this.doctorIDComboBox.TabIndex = 10;
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(149, 9);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(269, 25);
            this.warningLabel.TabIndex = 11;
            this.warningLabel.Text = "Please fill in all required fields.";
            this.warningLabel.Visible = false;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(638, 521);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.doctorIDComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.reasonLabel);
            this.Controls.Add(this.reasonTextBox);
            this.Controls.Add(this.patientIDTextBox);
            this.Controls.Add(this.patientLabel);
            this.Controls.Add(this.doctorLabel);
            this.Controls.Add(this.appointmentLabel);
            this.Controls.Add(this.appointmentDateTimePicker);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AppointmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Appointment Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker appointmentDateTimePicker;
        private System.Windows.Forms.Label appointmentLabel;
        private System.Windows.Forms.Label doctorLabel;
        private System.Windows.Forms.TextBox patientIDTextBox;
        private System.Windows.Forms.Label patientLabel;
        private System.Windows.Forms.TextBox reasonTextBox;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox doctorIDComboBox;
        private System.Windows.Forms.Label warningLabel;
    }
}