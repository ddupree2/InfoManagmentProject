namespace CS3230Project.View
{
    partial class OrderTestsForm
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
            this.components = new System.ComponentModel.Container();
            this.removeSelectedButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addTestButton = new System.Windows.Forms.Button();
            this.addAllTestsButton = new System.Windows.Forms.Button();
            this.testsComboBox = new System.Windows.Forms.ComboBox();
            this.orderedTestsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.appointmentDateLabel = new System.Windows.Forms.DateTimePicker();
            this.orderTestViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.patientIDTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.orderTestViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // removeSelectedButton
            // 
            this.removeSelectedButton.Location = new System.Drawing.Point(270, 324);
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
            this.cancelButton.Location = new System.Drawing.Point(623, 540);
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
            this.addTestButton.Location = new System.Drawing.Point(93, 324);
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
            this.addAllTestsButton.Location = new System.Drawing.Point(446, 540);
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
            this.testsComboBox.Location = new System.Drawing.Point(112, 257);
            this.testsComboBox.Name = "testsComboBox";
            this.testsComboBox.Size = new System.Drawing.Size(290, 28);
            this.testsComboBox.TabIndex = 1;
            // 
            // orderedTestsListBox
            // 
            this.orderedTestsListBox.FormattingEnabled = true;
            this.orderedTestsListBox.ItemHeight = 20;
            this.orderedTestsListBox.Location = new System.Drawing.Point(446, 43);
            this.orderedTestsListBox.Name = "orderedTestsListBox";
            this.orderedTestsListBox.Size = new System.Drawing.Size(322, 484);
            this.orderedTestsListBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(442, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ordered Tests:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // appointmentDateLabel
            // 
            this.appointmentDateLabel.Enabled = false;
            this.appointmentDateLabel.Location = new System.Drawing.Point(112, 43);
            this.appointmentDateLabel.Name = "appointmentDateLabel";
            this.appointmentDateLabel.Size = new System.Drawing.Size(290, 26);
            this.appointmentDateLabel.TabIndex = 11;
            // 
            // orderTestViewModelBindingSource
            // 
            this.orderTestViewModelBindingSource.DataSource = typeof(CS3230Project.ViewModel.OrderTestViewModel);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 20);
            this.label9.TabIndex = 36;
            this.label9.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Location = new System.Drawing.Point(112, 117);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(290, 26);
            this.nameTextBox.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 20);
            this.label11.TabIndex = 35;
            this.label11.Text = "Patient ID:";
            // 
            // patientIDTextBox
            // 
            this.patientIDTextBox.Enabled = false;
            this.patientIDTextBox.Location = new System.Drawing.Point(112, 187);
            this.patientIDTextBox.Name = "patientIDTextBox";
            this.patientIDTextBox.Size = new System.Drawing.Size(290, 26);
            this.patientIDTextBox.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Tests:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "Appointment:";
            // 
            // OrderTestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 609);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.patientIDTextBox);
            this.Controls.Add(this.appointmentDateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.orderedTestsListBox);
            this.Controls.Add(this.testsComboBox);
            this.Controls.Add(this.addAllTestsButton);
            this.Controls.Add(this.addTestButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.removeSelectedButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OrderTestsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Tests";
            ((System.ComponentModel.ISupportInitialize)(this.orderTestViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button removeSelectedButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addTestButton;
        private System.Windows.Forms.Button addAllTestsButton;
        private System.Windows.Forms.ComboBox testsComboBox;
        private System.Windows.Forms.ListBox orderedTestsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource orderTestViewModelBindingSource;
        private System.Windows.Forms.DateTimePicker appointmentDateLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox patientIDTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}