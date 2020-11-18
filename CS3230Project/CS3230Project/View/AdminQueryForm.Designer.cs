namespace CS3230Project.View
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
            this.queryButton = new System.Windows.Forms.Button();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.afterDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.beforeDatePicker = new System.Windows.Forms.DateTimePicker();
            this.customInstaller1 = new MySql.Data.MySqlClient.CustomInstaller();
            this.visitsButton = new System.Windows.Forms.Button();
            this.timeRangeCheckBox = new System.Windows.Forms.CheckBox();
            this.resultsGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridView)).BeginInit();
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
            // queryTextBox
            // 
            this.queryTextBox.Location = new System.Drawing.Point(93, 106);
            this.queryTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.queryTextBox.Multiline = true;
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(829, 160);
            this.queryTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "End:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Search:";
            // 
            // afterDateTimePicker
            // 
            this.afterDateTimePicker.Location = new System.Drawing.Point(456, 52);
            this.afterDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.afterDateTimePicker.Name = "afterDateTimePicker";
            this.afterDateTimePicker.Size = new System.Drawing.Size(298, 30);
            this.afterDateTimePicker.TabIndex = 6;
            // 
            // beforeDatePicker
            // 
            this.beforeDatePicker.Location = new System.Drawing.Point(93, 52);
            this.beforeDatePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.beforeDatePicker.Name = "beforeDatePicker";
            this.beforeDatePicker.Size = new System.Drawing.Size(298, 30);
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
            this.timeRangeCheckBox.Size = new System.Drawing.Size(210, 29);
            this.timeRangeCheckBox.TabIndex = 9;
            this.timeRangeCheckBox.Text = "Disable Time Range";
            this.timeRangeCheckBox.UseVisualStyleBackColor = true;
            // 
            // resultsGridView
            // 
            this.resultsGridView.AllowUserToAddRows = false;
            this.resultsGridView.AllowUserToDeleteRows = false;
            this.resultsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsGridView.Location = new System.Drawing.Point(30, 313);
            this.resultsGridView.Name = "resultsGridView";
            this.resultsGridView.ReadOnly = true;
            this.resultsGridView.RowHeadersWidth = 51;
            this.resultsGridView.Size = new System.Drawing.Size(1029, 355);
            this.resultsGridView.TabIndex = 10;
            // 
            // AdminQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 692);
            this.Controls.Add(this.resultsGridView);
            this.Controls.Add(this.timeRangeCheckBox);
            this.Controls.Add(this.visitsButton);
            this.Controls.Add(this.beforeDatePicker);
            this.Controls.Add(this.afterDateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.queryTextBox);
            this.Controls.Add(this.queryButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AdminQueryForm";
            this.Text = "Admin Query";
            ((System.ComponentModel.ISupportInitialize)(this.resultsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker afterDateTimePicker;
        private System.Windows.Forms.DateTimePicker beforeDatePicker;
        private MySql.Data.MySqlClient.CustomInstaller customInstaller1;
        private System.Windows.Forms.Button visitsButton;
        private System.Windows.Forms.CheckBox timeRangeCheckBox;
        private System.Windows.Forms.DataGridView resultsGridView;
    }
}