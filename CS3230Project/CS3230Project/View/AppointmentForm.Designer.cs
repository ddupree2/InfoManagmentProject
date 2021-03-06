﻿namespace CS3230Project.View
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
            this.appointmentDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.appointmentLabel = new System.Windows.Forms.Label();
            this.doctorLabel = new System.Windows.Forms.Label();
            this.patientIDTextBox = new System.Windows.Forms.TextBox();
            this.patientLabel = new System.Windows.Forms.Label();
            this.reasonTextBox = new System.Windows.Forms.TextBox();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.addNewAppointmentButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.doctorIDComboBox = new System.Windows.Forms.ComboBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.appointmentDataGrid = new System.Windows.Forms.DataGridView();
            this.nameLabel = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.appointmentTimePassedLabel = new System.Windows.Forms.Label();
            this.timeComboBox = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.appointmentTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // appointmentDateTimePicker
            // 
            this.appointmentDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentDateTimePicker.Location = new System.Drawing.Point(191, 109);
            this.appointmentDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.appointmentDateTimePicker.Name = "appointmentDateTimePicker";
            this.appointmentDateTimePicker.Size = new System.Drawing.Size(353, 30);
            this.appointmentDateTimePicker.TabIndex = 0;
            this.appointmentDateTimePicker.Leave += new System.EventHandler(this.appointmentDateTimePicker_Leave);
            // 
            // appointmentLabel
            // 
            this.appointmentLabel.AutoSize = true;
            this.appointmentLabel.Location = new System.Drawing.Point(10, 109);
            this.appointmentLabel.Name = "appointmentLabel";
            this.appointmentLabel.Size = new System.Drawing.Size(174, 25);
            this.appointmentLabel.TabIndex = 1;
            this.appointmentLabel.Text = "Appointment Date:";
            // 
            // doctorLabel
            // 
            this.doctorLabel.AutoSize = true;
            this.doctorLabel.Location = new System.Drawing.Point(62, 53);
            this.doctorLabel.Name = "doctorLabel";
            this.doctorLabel.Size = new System.Drawing.Size(69, 25);
            this.doctorLabel.TabIndex = 2;
            this.doctorLabel.Text = "Doctor";
            // 
            // patientIDTextBox
            // 
            this.patientIDTextBox.Enabled = false;
            this.patientIDTextBox.Location = new System.Drawing.Point(186, 215);
            this.patientIDTextBox.MaxLength = 20;
            this.patientIDTextBox.Name = "patientIDTextBox";
            this.patientIDTextBox.Size = new System.Drawing.Size(282, 30);
            this.patientIDTextBox.TabIndex = 5;
            // 
            // patientLabel
            // 
            this.patientLabel.AutoSize = true;
            this.patientLabel.Location = new System.Drawing.Point(70, 215);
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
            // addNewAppointmentButton
            // 
            this.addNewAppointmentButton.Location = new System.Drawing.Point(407, 476);
            this.addNewAppointmentButton.Name = "addNewAppointmentButton";
            this.addNewAppointmentButton.Size = new System.Drawing.Size(100, 37);
            this.addNewAppointmentButton.TabIndex = 8;
            this.addNewAppointmentButton.Text = "Add New";
            this.addNewAppointmentButton.UseVisualStyleBackColor = true;
            this.addNewAppointmentButton.Click += new System.EventHandler(this.saveButton_Click);
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
            this.doctorIDComboBox.Location = new System.Drawing.Point(191, 50);
            this.doctorIDComboBox.MaxDropDownItems = 20;
            this.doctorIDComboBox.Name = "doctorIDComboBox";
            this.doctorIDComboBox.Size = new System.Drawing.Size(288, 33);
            this.doctorIDComboBox.TabIndex = 10;
            this.doctorIDComboBox.SelectedIndexChanged += new System.EventHandler(this.doctorIDComboBox_SelectedIndexChanged);
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
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(75, 161);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(56, 25);
            this.timeLabel.TabIndex = 12;
            this.timeLabel.Text = "Time";
            // 
            // appointmentDataGrid
            // 
            this.appointmentDataGrid.AllowUserToAddRows = false;
            this.appointmentDataGrid.AllowUserToDeleteRows = false;
            this.appointmentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appointmentTime});
            this.appointmentDataGrid.Location = new System.Drawing.Point(660, 50);
            this.appointmentDataGrid.MultiSelect = false;
            this.appointmentDataGrid.Name = "appointmentDataGrid";
            this.appointmentDataGrid.ReadOnly = true;
            this.appointmentDataGrid.RowHeadersWidth = 51;
            this.appointmentDataGrid.RowTemplate.Height = 24;
            this.appointmentDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentDataGrid.Size = new System.Drawing.Size(273, 480);
            this.appointmentDataGrid.TabIndex = 14;
            this.appointmentDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.appointmentDataGrid_CellClick);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(655, 13);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(0, 25);
            this.nameLabel.TabIndex = 15;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(407, 476);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(100, 37);
            this.updateButton.TabIndex = 16;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Visible = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // appointmentTimePassedLabel
            // 
            this.appointmentTimePassedLabel.AutoSize = true;
            this.appointmentTimePassedLabel.ForeColor = System.Drawing.Color.Red;
            this.appointmentTimePassedLabel.Location = new System.Drawing.Point(119, 482);
            this.appointmentTimePassedLabel.Name = "appointmentTimePassedLabel";
            this.appointmentTimePassedLabel.Size = new System.Drawing.Size(282, 25);
            this.appointmentTimePassedLabel.TabIndex = 17;
            this.appointmentTimePassedLabel.Text = "Appointment Time has passed.";
            this.appointmentTimePassedLabel.Visible = false;
            // 
            // timeComboBox
            // 
            this.timeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeComboBox.FormattingEnabled = true;
            this.timeComboBox.Location = new System.Drawing.Point(191, 158);
            this.timeComboBox.Name = "timeComboBox";
            this.timeComboBox.Size = new System.Drawing.Size(171, 33);
            this.timeComboBox.TabIndex = 18;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(12, 482);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(101, 31);
            this.deleteButton.TabIndex = 19;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Visible = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // appointmentTime
            // 
            this.appointmentTime.HeaderText = "Date";
            this.appointmentTime.MinimumWidth = 6;
            this.appointmentTime.Name = "appointmentTime";
            this.appointmentTime.ReadOnly = true;
            this.appointmentTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.appointmentTime.Width = 220;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(956, 546);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.timeComboBox);
            this.Controls.Add(this.appointmentTimePassedLabel);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.appointmentDataGrid);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.doctorIDComboBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addNewAppointmentButton);
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
            this.Load += new System.EventHandler(this.AppointmentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGrid)).EndInit();
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
        private System.Windows.Forms.Button addNewAppointmentButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox doctorIDComboBox;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.DataGridView appointmentDataGrid;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label appointmentTimePassedLabel;
        private System.Windows.Forms.ComboBox timeComboBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentTime;
    }
}