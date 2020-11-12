namespace CS3230Project.View
{
    partial class orderTestsForm
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
            this.removeSelectedButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addTestButton = new System.Windows.Forms.Button();
            this.addAllTestsButton = new System.Windows.Forms.Button();
            this.testsComboBox = new System.Windows.Forms.ComboBox();
            this.patientIdLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.orderedTestsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.appointmentDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // removeSelectedButton
            // 
            this.removeSelectedButton.Location = new System.Drawing.Point(203, 290);
            this.removeSelectedButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.removeSelectedButton.Name = "removeSelectedButton";
            this.removeSelectedButton.Size = new System.Drawing.Size(145, 55);
            this.removeSelectedButton.TabIndex = 4;
            this.removeSelectedButton.Text = "Remove Selected";
            this.removeSelectedButton.UseVisualStyleBackColor = true;
            this.removeSelectedButton.Click += new System.EventHandler(this.removeSelectedButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(600, 676);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(145, 55);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addTestButton
            // 
            this.addTestButton.Location = new System.Drawing.Point(26, 290);
            this.addTestButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addTestButton.Name = "addTestButton";
            this.addTestButton.Size = new System.Drawing.Size(145, 55);
            this.addTestButton.TabIndex = 2;
            this.addTestButton.Text = "Add Test";
            this.addTestButton.UseVisualStyleBackColor = true;
            this.addTestButton.Click += new System.EventHandler(this.addTestButton_Click);
            // 
            // addAllTestsButton
            // 
            this.addAllTestsButton.Location = new System.Drawing.Point(385, 676);
            this.addAllTestsButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addAllTestsButton.Name = "addAllTestsButton";
            this.addAllTestsButton.Size = new System.Drawing.Size(145, 55);
            this.addAllTestsButton.TabIndex = 5;
            this.addAllTestsButton.Text = "Add All Tests";
            this.addAllTestsButton.UseVisualStyleBackColor = true;
            this.addAllTestsButton.Click += new System.EventHandler(this.addAllTestsButton_Click);
            // 
            // testsComboBox
            // 
            this.testsComboBox.FormattingEnabled = true;
            this.testsComboBox.ItemHeight = 20;
            this.testsComboBox.Location = new System.Drawing.Point(26, 238);
            this.testsComboBox.Name = "testsComboBox";
            this.testsComboBox.Size = new System.Drawing.Size(322, 28);
            this.testsComboBox.TabIndex = 1;
            // 
            // patientIdLabel
            // 
            this.patientIdLabel.AutoSize = true;
            this.patientIdLabel.Location = new System.Drawing.Point(134, 168);
            this.patientIdLabel.Name = "patientIdLabel";
            this.patientIdLabel.Size = new System.Drawing.Size(104, 20);
            this.patientIdLabel.TabIndex = 7;
            this.patientIdLabel.Text = "No Patient ID";
            this.patientIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(134, 118);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(75, 20);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "No Name";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // orderedTestsListBox
            // 
            this.orderedTestsListBox.FormattingEnabled = true;
            this.orderedTestsListBox.ItemHeight = 20;
            this.orderedTestsListBox.Location = new System.Drawing.Point(385, 43);
            this.orderedTestsListBox.Name = "orderedTestsListBox";
            this.orderedTestsListBox.Size = new System.Drawing.Size(360, 604);
            this.orderedTestsListBox.TabIndex = 9;
            this.orderedTestsListBox.SelectedIndexChanged += new System.EventHandler(this.orderedTestsListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ordered Tests:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // appointmentDateTimePicker
            // 
            this.appointmentDateTimePicker.Location = new System.Drawing.Point(26, 43);
            this.appointmentDateTimePicker.Name = "appointmentDateTimePicker";
            this.appointmentDateTimePicker.Size = new System.Drawing.Size(322, 26);
            this.appointmentDateTimePicker.TabIndex = 11;
            // 
            // orderTestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 749);
            this.Controls.Add(this.appointmentDateTimePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.orderedTestsListBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.patientIdLabel);
            this.Controls.Add(this.testsComboBox);
            this.Controls.Add(this.addAllTestsButton);
            this.Controls.Add(this.addTestButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.removeSelectedButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "orderTestsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Tests";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button removeSelectedButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addTestButton;
        private System.Windows.Forms.Button addAllTestsButton;
        private System.Windows.Forms.ComboBox testsComboBox;
        private System.Windows.Forms.Label patientIdLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ListBox orderedTestsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker appointmentDateTimePicker;
    }
}