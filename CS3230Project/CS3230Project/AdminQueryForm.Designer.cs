namespace CS3230Project
{
    partial class AdminQueryForm
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
            this.queryButton = new System.Windows.Forms.Button();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.afterDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.beforeDatePicker = new System.Windows.Forms.DateTimePicker();
            this.customInstaller1 = new MySql.Data.MySqlClient.CustomInstaller();
            this.visitsButton = new System.Windows.Forms.Button();
            this.timeRangeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // queryButton
            // 
            this.queryButton.Location = new System.Drawing.Point(947, 104);
            this.queryButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(112, 31);
            this.queryButton.TabIndex = 0;
            this.queryButton.Text = "Query";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Enabled = false;
            this.resultsTextBox.Location = new System.Drawing.Point(30, 147);
            this.resultsTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.Size = new System.Drawing.Size(1029, 531);
            this.resultsTextBox.TabIndex = 1;
            // 
            // queryTextBox
            // 
            this.queryTextBox.Location = new System.Drawing.Point(93, 106);
            this.queryTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(829, 26);
            this.queryTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "End:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Search:";
            // 
            // afterDateTimePicker
            // 
            this.afterDateTimePicker.Location = new System.Drawing.Point(456, 52);
            this.afterDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.afterDateTimePicker.Name = "afterDateTimePicker";
            this.afterDateTimePicker.Size = new System.Drawing.Size(298, 26);
            this.afterDateTimePicker.TabIndex = 6;
            // 
            // beforeDatePicker
            // 
            this.beforeDatePicker.Location = new System.Drawing.Point(93, 52);
            this.beforeDatePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.beforeDatePicker.Name = "beforeDatePicker";
            this.beforeDatePicker.Size = new System.Drawing.Size(298, 26);
            this.beforeDatePicker.TabIndex = 7;
            // 
            // visitsButton
            // 
            this.visitsButton.Location = new System.Drawing.Point(947, 52);
            this.visitsButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.visitsButton.Name = "visitsButton";
            this.visitsButton.Size = new System.Drawing.Size(112, 31);
            this.visitsButton.TabIndex = 8;
            this.visitsButton.Text = "View Visits";
            this.visitsButton.UseVisualStyleBackColor = true;
            this.visitsButton.Click += new System.EventHandler(this.visitsButton_Click);
            // 
            // timeRangeCheckBox
            // 
            this.timeRangeCheckBox.AutoSize = true;
            this.timeRangeCheckBox.Location = new System.Drawing.Point(761, 54);
            this.timeRangeCheckBox.Name = "timeRangeCheckBox";
            this.timeRangeCheckBox.Size = new System.Drawing.Size(171, 24);
            this.timeRangeCheckBox.TabIndex = 9;
            this.timeRangeCheckBox.Text = "Disable Time Range";
            this.timeRangeCheckBox.UseVisualStyleBackColor = true;
            // 
            // AdminQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 692);
            this.Controls.Add(this.timeRangeCheckBox);
            this.Controls.Add(this.visitsButton);
            this.Controls.Add(this.beforeDatePicker);
            this.Controls.Add(this.afterDateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.queryTextBox);
            this.Controls.Add(this.resultsTextBox);
            this.Controls.Add(this.queryButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdminQueryForm";
            this.Text = "Admin Query";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.TextBox resultsTextBox;
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker afterDateTimePicker;
        private System.Windows.Forms.DateTimePicker beforeDatePicker;
        private MySql.Data.MySqlClient.CustomInstaller customInstaller1;
        private System.Windows.Forms.Button visitsButton;
        private System.Windows.Forms.CheckBox timeRangeCheckBox;
    }
}