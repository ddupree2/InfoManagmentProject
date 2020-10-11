namespace CS3230Project
{
    partial class RegistrationForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.Addr1TextBox = new System.Windows.Forms.TextBox();
            this.Addr2TextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.zipCodeTextBox = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.addr1Label = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.addr2Label = new System.Windows.Forms.Label();
            this.zipCodeLabel = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.ssnTextBox = new System.Windows.Forms.TextBox();
            this.ssnLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(92, 362);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(445, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "This is a test button . if you press it you must delete \r\nthe data in the databas" +
    "e that was added to the address and patient tables.";
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.firstNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameTextBox.Location = new System.Drawing.Point(106, 26);
            this.firstNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(235, 22);
            this.firstNameTextBox.TabIndex = 1;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lastNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameTextBox.Location = new System.Drawing.Point(106, 70);
            this.lastNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(235, 22);
            this.lastNameTextBox.TabIndex = 2;
            // 
            // Addr1TextBox
            // 
            this.Addr1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Addr1TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addr1TextBox.Location = new System.Drawing.Point(106, 160);
            this.Addr1TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.Addr1TextBox.Name = "Addr1TextBox";
            this.Addr1TextBox.Size = new System.Drawing.Size(400, 22);
            this.Addr1TextBox.TabIndex = 4;
            // 
            // Addr2TextBox
            // 
            this.Addr2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Addr2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addr2TextBox.Location = new System.Drawing.Point(106, 210);
            this.Addr2TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.Addr2TextBox.Name = "Addr2TextBox";
            this.Addr2TextBox.Size = new System.Drawing.Size(400, 22);
            this.Addr2TextBox.TabIndex = 5;
            // 
            // cityTextBox
            // 
            this.cityTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityTextBox.Location = new System.Drawing.Point(106, 257);
            this.cityTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(140, 22);
            this.cityTextBox.TabIndex = 6;
            // 
            // zipCodeTextBox
            // 
            this.zipCodeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.zipCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipCodeTextBox.Location = new System.Drawing.Point(374, 257);
            this.zipCodeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.zipCodeTextBox.Name = "zipCodeTextBox";
            this.zipCodeTextBox.Size = new System.Drawing.Size(132, 22);
            this.zipCodeTextBox.TabIndex = 7;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLabel.Location = new System.Drawing.Point(23, 29);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(76, 16);
            this.firstNameLabel.TabIndex = 8;
            this.firstNameLabel.Text = "First Name:";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLabel.Location = new System.Drawing.Point(23, 73);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(76, 16);
            this.lastNameLabel.TabIndex = 9;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // addr1Label
            // 
            this.addr1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addr1Label.AutoSize = true;
            this.addr1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addr1Label.Location = new System.Drawing.Point(27, 163);
            this.addr1Label.Name = "addr1Label";
            this.addr1Label.Size = new System.Drawing.Size(72, 16);
            this.addr1Label.TabIndex = 10;
            this.addr1Label.Text = "Address 1:";
            // 
            // cityLabel
            // 
            this.cityLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cityLabel.AutoSize = true;
            this.cityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityLabel.Location = new System.Drawing.Point(66, 257);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(33, 16);
            this.cityLabel.TabIndex = 11;
            this.cityLabel.Text = "City:";
            // 
            // addr2Label
            // 
            this.addr2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addr2Label.AutoSize = true;
            this.addr2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addr2Label.Location = new System.Drawing.Point(27, 213);
            this.addr2Label.Name = "addr2Label";
            this.addr2Label.Size = new System.Drawing.Size(72, 16);
            this.addr2Label.TabIndex = 12;
            this.addr2Label.Text = "Address 2:";
            // 
            // zipCodeLabel
            // 
            this.zipCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.zipCodeLabel.AutoSize = true;
            this.zipCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipCodeLabel.Location = new System.Drawing.Point(301, 260);
            this.zipCodeLabel.Name = "zipCodeLabel";
            this.zipCodeLabel.Size = new System.Drawing.Size(66, 16);
            this.zipCodeLabel.TabIndex = 13;
            this.zipCodeLabel.Text = "Zip Code:";
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterButton.Location = new System.Drawing.Point(374, 299);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(132, 31);
            this.RegisterButton.TabIndex = 0;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            // 
            // ssnTextBox
            // 
            this.ssnTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ssnTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssnTextBox.Location = new System.Drawing.Point(106, 115);
            this.ssnTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ssnTextBox.MaxLength = 9;
            this.ssnTextBox.Name = "ssnTextBox";
            this.ssnTextBox.Size = new System.Drawing.Size(235, 22);
            this.ssnTextBox.TabIndex = 3;
            // 
            // ssnLabel
            // 
            this.ssnLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ssnLabel.AutoSize = true;
            this.ssnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssnLabel.Location = new System.Drawing.Point(60, 118);
            this.ssnLabel.Name = "ssnLabel";
            this.ssnLabel.Size = new System.Drawing.Size(39, 16);
            this.ssnLabel.TabIndex = 16;
            this.ssnLabel.Text = "SSN:";
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 436);
            this.Controls.Add(this.ssnLabel);
            this.Controls.Add(this.ssnTextBox);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.zipCodeLabel);
            this.Controls.Add(this.addr2Label);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.addr1Label);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.zipCodeTextBox);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.Addr2TextBox);
            this.Controls.Add(this.Addr1TextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(525, 460);
            this.Name = "RegistrationForm";
            this.Text = "Patient Registration";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox Addr1TextBox;
        private System.Windows.Forms.TextBox Addr2TextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox zipCodeTextBox;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label addr1Label;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label addr2Label;
        private System.Windows.Forms.Label zipCodeLabel;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.TextBox ssnTextBox;
        private System.Windows.Forms.Label ssnLabel;
    }
}

