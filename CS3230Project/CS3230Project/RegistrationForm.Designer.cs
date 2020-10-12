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
            this.stateLabel = new System.Windows.Forms.Label();
            this.contactNumberLabel = new System.Windows.Forms.Label();
            this.contactNumberTextBox = new System.Windows.Forms.TextBox();
            this.sexComboBox = new System.Windows.Forms.ComboBox();
            this.sexLabel = new System.Windows.Forms.Label();
            this.requiredFieldLbl = new System.Windows.Forms.Label();
            this.stateComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.fNameWarnLabel = new System.Windows.Forms.Label();
            this.lNameWarnLabel = new System.Windows.Forms.Label();
            this.ssnWarnLabel = new System.Windows.Forms.Label();
            this.zipCodeWarnLabel = new System.Windows.Forms.Label();
            this.contactNumWarnLabel = new System.Windows.Forms.Label();
            this.stateWarnLabel = new System.Windows.Forms.Label();
            this.sexWarnLabel = new System.Windows.Forms.Label();
            this.addr1WarnLabel = new System.Windows.Forms.Label();
            this.cityWarnLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.firstNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameTextBox.Location = new System.Drawing.Point(109, 46);
            this.firstNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.firstNameTextBox.MaxLength = 45;
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(216, 22);
            this.firstNameTextBox.TabIndex = 1;
            this.firstNameTextBox.Enter += new System.EventHandler(this.firstNameTextBox_Enter);
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lastNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameTextBox.Location = new System.Drawing.Point(109, 90);
            this.lastNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.lastNameTextBox.MaxLength = 45;
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(216, 22);
            this.lastNameTextBox.TabIndex = 2;
            this.lastNameTextBox.Leave += new System.EventHandler(this.lastNameTextBox_Leave);
            // 
            // Addr1TextBox
            // 
            this.Addr1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Addr1TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addr1TextBox.Location = new System.Drawing.Point(109, 180);
            this.Addr1TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.Addr1TextBox.MaxLength = 45;
            this.Addr1TextBox.Name = "Addr1TextBox";
            this.Addr1TextBox.Size = new System.Drawing.Size(400, 22);
            this.Addr1TextBox.TabIndex = 4;
            this.Addr1TextBox.Leave += new System.EventHandler(this.addr1TextBox_Leave);
            // 
            // Addr2TextBox
            // 
            this.Addr2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Addr2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addr2TextBox.Location = new System.Drawing.Point(109, 230);
            this.Addr2TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.Addr2TextBox.MaxLength = 45;
            this.Addr2TextBox.Name = "Addr2TextBox";
            this.Addr2TextBox.Size = new System.Drawing.Size(400, 22);
            this.Addr2TextBox.TabIndex = 5;
            // 
            // cityTextBox
            // 
            this.cityTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityTextBox.Location = new System.Drawing.Point(109, 277);
            this.cityTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.cityTextBox.MaxLength = 45;
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(140, 22);
            this.cityTextBox.TabIndex = 6;
            this.cityTextBox.Leave += new System.EventHandler(this.cityTextBox_Leave);
            // 
            // zipCodeTextBox
            // 
            this.zipCodeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.zipCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipCodeTextBox.Location = new System.Drawing.Point(109, 323);
            this.zipCodeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.zipCodeTextBox.MaxLength = 6;
            this.zipCodeTextBox.Name = "zipCodeTextBox";
            this.zipCodeTextBox.Size = new System.Drawing.Size(140, 22);
            this.zipCodeTextBox.TabIndex = 8;
            this.zipCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zipCodeTextBox_KeyPress);
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLabel.Location = new System.Drawing.Point(26, 49);
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
            this.lastNameLabel.Location = new System.Drawing.Point(26, 93);
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
            this.addr1Label.Location = new System.Drawing.Point(30, 183);
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
            this.cityLabel.Location = new System.Drawing.Point(69, 280);
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
            this.addr2Label.Location = new System.Drawing.Point(30, 233);
            this.addr2Label.Name = "addr2Label";
            this.addr2Label.Size = new System.Drawing.Size(72, 16);
            this.addr2Label.TabIndex = 12;
            this.addr2Label.Text = "Address 2:";
            // 
            // zipCodeLabel
            // 
            this.zipCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.zipCodeLabel.AutoSize = true;
            this.zipCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipCodeLabel.Location = new System.Drawing.Point(36, 326);
            this.zipCodeLabel.Name = "zipCodeLabel";
            this.zipCodeLabel.Size = new System.Drawing.Size(66, 16);
            this.zipCodeLabel.TabIndex = 13;
            this.zipCodeLabel.Text = "Zip Code:";
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterButton.Location = new System.Drawing.Point(369, 381);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(140, 29);
            this.RegisterButton.TabIndex = 9;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // ssnTextBox
            // 
            this.ssnTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ssnTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssnTextBox.Location = new System.Drawing.Point(109, 135);
            this.ssnTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ssnTextBox.MaxLength = 9;
            this.ssnTextBox.Name = "ssnTextBox";
            this.ssnTextBox.Size = new System.Drawing.Size(216, 22);
            this.ssnTextBox.TabIndex = 3;
            this.ssnTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ssnTextBox_KeyPress);
            this.ssnTextBox.Leave += new System.EventHandler(this.ssnTextBox_Leave);
            // 
            // ssnLabel
            // 
            this.ssnLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ssnLabel.AutoSize = true;
            this.ssnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssnLabel.Location = new System.Drawing.Point(63, 138);
            this.ssnLabel.Name = "ssnLabel";
            this.ssnLabel.Size = new System.Drawing.Size(39, 16);
            this.ssnLabel.TabIndex = 16;
            this.ssnLabel.Text = "SSN:";
            // 
            // stateLabel
            // 
            this.stateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLabel.Location = new System.Drawing.Point(320, 280);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(42, 16);
            this.stateLabel.TabIndex = 18;
            this.stateLabel.Text = "State:";
            // 
            // contactNumberLabel
            // 
            this.contactNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.contactNumberLabel.AutoSize = true;
            this.contactNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactNumberLabel.Location = new System.Drawing.Point(296, 326);
            this.contactNumberLabel.Name = "contactNumberLabel";
            this.contactNumberLabel.Size = new System.Drawing.Size(66, 16);
            this.contactNumberLabel.TabIndex = 20;
            this.contactNumberLabel.Text = "Contact #:";
            // 
            // contactNumberTextBox
            // 
            this.contactNumberTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.contactNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactNumberTextBox.Location = new System.Drawing.Point(369, 323);
            this.contactNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.contactNumberTextBox.MaxLength = 10;
            this.contactNumberTextBox.Name = "contactNumberTextBox";
            this.contactNumberTextBox.Size = new System.Drawing.Size(140, 22);
            this.contactNumberTextBox.TabIndex = 19;
            this.contactNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.contactNumberTextBox_KeyPress);
            this.contactNumberTextBox.Leave += new System.EventHandler(this.contactNumberTextBox_Leave);
            // 
            // sexComboBox
            // 
            this.sexComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sexComboBox.FormattingEnabled = true;
            this.sexComboBox.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.sexComboBox.Location = new System.Drawing.Point(388, 90);
            this.sexComboBox.Name = "sexComboBox";
            this.sexComboBox.Size = new System.Drawing.Size(121, 24);
            this.sexComboBox.TabIndex = 21;
            this.sexComboBox.Leave += new System.EventHandler(this.sexComboBox_Leave);
            // 
            // sexLabel
            // 
            this.sexLabel.AutoSize = true;
            this.sexLabel.Location = new System.Drawing.Point(329, 93);
            this.sexLabel.Name = "sexLabel";
            this.sexLabel.Size = new System.Drawing.Size(56, 16);
            this.sexLabel.TabIndex = 22;
            this.sexLabel.Text = "Gender:";
            // 
            // requiredFieldLbl
            // 
            this.requiredFieldLbl.AutoSize = true;
            this.requiredFieldLbl.ForeColor = System.Drawing.Color.Red;
            this.requiredFieldLbl.Location = new System.Drawing.Point(19, 9);
            this.requiredFieldLbl.Name = "requiredFieldLbl";
            this.requiredFieldLbl.Size = new System.Drawing.Size(190, 16);
            this.requiredFieldLbl.TabIndex = 23;
            this.requiredFieldLbl.Text = "Fields with an * must be filled in";
            this.requiredFieldLbl.Visible = false;
            // 
            // stateComboBox
            // 
            this.stateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stateComboBox.FormattingEnabled = true;
            this.stateComboBox.Items.AddRange(new object[] {
            "AL",
            "AK",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "FL",
            "GA",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY"});
            this.stateComboBox.Location = new System.Drawing.Point(369, 275);
            this.stateComboBox.Name = "stateComboBox";
            this.stateComboBox.Size = new System.Drawing.Size(140, 24);
            this.stateComboBox.TabIndex = 24;
            this.stateComboBox.Leave += new System.EventHandler(this.stateComboBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(326, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(19, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(28, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(56, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(313, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(289, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 16);
            this.label6.TabIndex = 30;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(61, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(28, 321);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 16);
            this.label8.TabIndex = 32;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(18, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 16);
            this.label9.TabIndex = 33;
            this.label9.Text = "*";
            // 
            // fNameWarnLabel
            // 
            this.fNameWarnLabel.AutoSize = true;
            this.fNameWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.fNameWarnLabel.Location = new System.Drawing.Point(108, 29);
            this.fNameWarnLabel.Name = "fNameWarnLabel";
            this.fNameWarnLabel.Size = new System.Drawing.Size(175, 16);
            this.fNameWarnLabel.TabIndex = 34;
            this.fNameWarnLabel.Text = "First name cannot be empty.";
            this.fNameWarnLabel.Visible = false;
            // 
            // lNameWarnLabel
            // 
            this.lNameWarnLabel.AutoSize = true;
            this.lNameWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.lNameWarnLabel.Location = new System.Drawing.Point(108, 72);
            this.lNameWarnLabel.Name = "lNameWarnLabel";
            this.lNameWarnLabel.Size = new System.Drawing.Size(175, 16);
            this.lNameWarnLabel.TabIndex = 35;
            this.lNameWarnLabel.Text = "Last name cannot be empty.";
            this.lNameWarnLabel.Visible = false;
            // 
            // ssnWarnLabel
            // 
            this.ssnWarnLabel.AutoSize = true;
            this.ssnWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.ssnWarnLabel.Location = new System.Drawing.Point(108, 116);
            this.ssnWarnLabel.Name = "ssnWarnLabel";
            this.ssnWarnLabel.Size = new System.Drawing.Size(163, 16);
            this.ssnWarnLabel.TabIndex = 36;
            this.ssnWarnLabel.Text = "SSN must be 9 digits long.";
            this.ssnWarnLabel.Visible = false;
            // 
            // zipCodeWarnLabel
            // 
            this.zipCodeWarnLabel.AutoSize = true;
            this.zipCodeWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.zipCodeWarnLabel.Location = new System.Drawing.Point(69, 305);
            this.zipCodeWarnLabel.Name = "zipCodeWarnLabel";
            this.zipCodeWarnLabel.Size = new System.Drawing.Size(188, 16);
            this.zipCodeWarnLabel.TabIndex = 37;
            this.zipCodeWarnLabel.Text = "Zip code must be 6 digits long.";
            this.zipCodeWarnLabel.Visible = false;
            // 
            // contactNumWarnLabel
            // 
            this.contactNumWarnLabel.AutoSize = true;
            this.contactNumWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.contactNumWarnLabel.Location = new System.Drawing.Point(346, 303);
            this.contactNumWarnLabel.Name = "contactNumWarnLabel";
            this.contactNumWarnLabel.Size = new System.Drawing.Size(197, 16);
            this.contactNumWarnLabel.TabIndex = 38;
            this.contactNumWarnLabel.Text = "Contact # must be 10 digits long.";
            this.contactNumWarnLabel.Visible = false;
            // 
            // stateWarnLabel
            // 
            this.stateWarnLabel.AutoSize = true;
            this.stateWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.stateWarnLabel.Location = new System.Drawing.Point(371, 256);
            this.stateWarnLabel.Name = "stateWarnLabel";
            this.stateWarnLabel.Size = new System.Drawing.Size(110, 16);
            this.stateWarnLabel.TabIndex = 39;
            this.stateWarnLabel.Text = "Must select state.";
            this.stateWarnLabel.Visible = false;
            // 
            // sexWarnLabel
            // 
            this.sexWarnLabel.AutoSize = true;
            this.sexWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.sexWarnLabel.Location = new System.Drawing.Point(385, 71);
            this.sexWarnLabel.Name = "sexWarnLabel";
            this.sexWarnLabel.Size = new System.Drawing.Size(124, 16);
            this.sexWarnLabel.TabIndex = 40;
            this.sexWarnLabel.Text = "Must select gender.";
            this.sexWarnLabel.Visible = false;
            // 
            // addr1WarnLabel
            // 
            this.addr1WarnLabel.AutoSize = true;
            this.addr1WarnLabel.ForeColor = System.Drawing.Color.Red;
            this.addr1WarnLabel.Location = new System.Drawing.Point(110, 163);
            this.addr1WarnLabel.Name = "addr1WarnLabel";
            this.addr1WarnLabel.Size = new System.Drawing.Size(174, 16);
            this.addr1WarnLabel.TabIndex = 41;
            this.addr1WarnLabel.Text = "Address 1 cannot be empty.";
            this.addr1WarnLabel.Visible = false;
            // 
            // cityWarnLabel
            // 
            this.cityWarnLabel.AutoSize = true;
            this.cityWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.cityWarnLabel.Location = new System.Drawing.Point(110, 257);
            this.cityWarnLabel.Name = "cityWarnLabel";
            this.cityWarnLabel.Size = new System.Drawing.Size(135, 16);
            this.cityWarnLabel.TabIndex = 42;
            this.cityWarnLabel.Text = "City cannot be empty.";
            this.cityWarnLabel.Visible = false;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 421);
            this.Controls.Add(this.cityWarnLabel);
            this.Controls.Add(this.addr1WarnLabel);
            this.Controls.Add(this.sexWarnLabel);
            this.Controls.Add(this.stateWarnLabel);
            this.Controls.Add(this.contactNumWarnLabel);
            this.Controls.Add(this.zipCodeWarnLabel);
            this.Controls.Add(this.ssnWarnLabel);
            this.Controls.Add(this.lNameWarnLabel);
            this.Controls.Add(this.stateComboBox);
            this.Controls.Add(this.requiredFieldLbl);
            this.Controls.Add(this.sexLabel);
            this.Controls.Add(this.sexComboBox);
            this.Controls.Add(this.contactNumberLabel);
            this.Controls.Add(this.contactNumberTextBox);
            this.Controls.Add(this.stateLabel);
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fNameWarnLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(525, 460);
            this.Name = "RegistrationForm";
            this.Text = "Patient Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label contactNumberLabel;
        private System.Windows.Forms.TextBox contactNumberTextBox;
        private System.Windows.Forms.ComboBox sexComboBox;
        private System.Windows.Forms.Label sexLabel;
        private System.Windows.Forms.Label requiredFieldLbl;
        private System.Windows.Forms.ComboBox stateComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label fNameWarnLabel;
        private System.Windows.Forms.Label lNameWarnLabel;
        private System.Windows.Forms.Label ssnWarnLabel;
        private System.Windows.Forms.Label zipCodeWarnLabel;
        private System.Windows.Forms.Label contactNumWarnLabel;
        private System.Windows.Forms.Label stateWarnLabel;
        private System.Windows.Forms.Label sexWarnLabel;
        private System.Windows.Forms.Label addr1WarnLabel;
        private System.Windows.Forms.Label cityWarnLabel;
    }
}

