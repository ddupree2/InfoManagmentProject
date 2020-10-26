namespace CS3230Project.View
{
    partial class PatientLookupForm
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
            this.appointmentsLabel = new System.Windows.Forms.Label();
            this.visitsLabel = new System.Windows.Forms.Label();
            this.patientSearchButton = new System.Windows.Forms.Button();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.dobLabel = new System.Windows.Forms.Label();
            this.dobDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.appointmentsListBox = new System.Windows.Forms.ListBox();
            this.visitsListBox = new System.Windows.Forms.ListBox();
            this.enableDOBCeckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // appointmentsLabel
            // 
            this.appointmentsLabel.AutoSize = true;
            this.appointmentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentsLabel.Location = new System.Drawing.Point(12, 178);
            this.appointmentsLabel.Name = "appointmentsLabel";
            this.appointmentsLabel.Size = new System.Drawing.Size(112, 20);
            this.appointmentsLabel.TabIndex = 2;
            this.appointmentsLabel.Text = "Appointments:";
            // 
            // visitsLabel
            // 
            this.visitsLabel.AutoSize = true;
            this.visitsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visitsLabel.Location = new System.Drawing.Point(12, 472);
            this.visitsLabel.Name = "visitsLabel";
            this.visitsLabel.Size = new System.Drawing.Size(51, 20);
            this.visitsLabel.TabIndex = 3;
            this.visitsLabel.Text = "Visits:";
            // 
            // patientSearchButton
            // 
            this.patientSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientSearchButton.Location = new System.Drawing.Point(468, 57);
            this.patientSearchButton.Name = "patientSearchButton";
            this.patientSearchButton.Size = new System.Drawing.Size(136, 39);
            this.patientSearchButton.TabIndex = 3;
            this.patientSearchButton.Text = "Search Patient";
            this.patientSearchButton.UseVisualStyleBackColor = true;
            this.patientSearchButton.Click += new System.EventHandler(this.patientSearchButton_Click);
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameTextBox.Location = new System.Drawing.Point(106, 23);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(278, 26);
            this.firstNameTextBox.TabIndex = 1;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLabel.Location = new System.Drawing.Point(10, 26);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(90, 20);
            this.firstNameLabel.TabIndex = 6;
            this.firstNameLabel.Text = "First Name:";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLabel.Location = new System.Drawing.Point(8, 71);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(90, 20);
            this.lastNameLabel.TabIndex = 7;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameTextBox.Location = new System.Drawing.Point(106, 68);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(278, 26);
            this.lastNameTextBox.TabIndex = 2;
            // 
            // dobLabel
            // 
            this.dobLabel.AutoSize = true;
            this.dobLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dobLabel.Location = new System.Drawing.Point(50, 137);
            this.dobLabel.Name = "dobLabel";
            this.dobLabel.Size = new System.Drawing.Size(48, 20);
            this.dobLabel.TabIndex = 9;
            this.dobLabel.Text = "DOB:";
            // 
            // dobDateTimePicker
            // 
            this.dobDateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dobDateTimePicker.CustomFormat = "";
            this.dobDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dobDateTimePicker.Location = new System.Drawing.Point(106, 137);
            this.dobDateTimePicker.Name = "dobDateTimePicker";
            this.dobDateTimePicker.Size = new System.Drawing.Size(278, 26);
            this.dobDateTimePicker.TabIndex = 5;
            this.dobDateTimePicker.Value = new System.DateTime(2020, 10, 20, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "And/Or";
            // 
            // appointmentsListBox
            // 
            this.appointmentsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentsListBox.FormattingEnabled = true;
            this.appointmentsListBox.ItemHeight = 20;
            this.appointmentsListBox.Location = new System.Drawing.Point(12, 201);
            this.appointmentsListBox.Name = "appointmentsListBox";
            this.appointmentsListBox.Size = new System.Drawing.Size(668, 264);
            this.appointmentsListBox.TabIndex = 6;
            this.appointmentsListBox.SelectedIndexChanged += new System.EventHandler(this.appointmentsListBox_SelectedIndexChanged);
            // 
            // visitsListBox
            // 
            this.visitsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visitsListBox.FormattingEnabled = true;
            this.visitsListBox.ItemHeight = 20;
            this.visitsListBox.Location = new System.Drawing.Point(12, 495);
            this.visitsListBox.Name = "visitsListBox";
            this.visitsListBox.Size = new System.Drawing.Size(668, 264);
            this.visitsListBox.TabIndex = 7;
            this.visitsListBox.SelectedIndexChanged += new System.EventHandler(this.visitsListBox_SelectedIndexChanged);
            // 
            // enableDOBCeckBox
            // 
            this.enableDOBCeckBox.AutoSize = true;
            this.enableDOBCeckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableDOBCeckBox.Location = new System.Drawing.Point(408, 139);
            this.enableDOBCeckBox.Name = "enableDOBCeckBox";
            this.enableDOBCeckBox.Size = new System.Drawing.Size(172, 24);
            this.enableDOBCeckBox.TabIndex = 4;
            this.enableDOBCeckBox.Text = "Enable DOB Search";
            this.enableDOBCeckBox.UseVisualStyleBackColor = true;
            // 
            // PatientLookupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 774);
            this.Controls.Add(this.enableDOBCeckBox);
            this.Controls.Add(this.visitsListBox);
            this.Controls.Add(this.appointmentsListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dobDateTimePicker);
            this.Controls.Add(this.dobLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.patientSearchButton);
            this.Controls.Add(this.visitsLabel);
            this.Controls.Add(this.appointmentsLabel);
            this.Name = "PatientLookupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient Lookup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label appointmentsLabel;
        private System.Windows.Forms.Label visitsLabel;
        private System.Windows.Forms.Button patientSearchButton;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label dobLabel;
        private System.Windows.Forms.DateTimePicker dobDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox appointmentsListBox;
        private System.Windows.Forms.ListBox visitsListBox;
        private System.Windows.Forms.CheckBox enableDOBCeckBox;
    }
}