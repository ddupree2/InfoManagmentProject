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
            this.updateButton = new System.Windows.Forms.Button();
            this.dobLabel = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.firstNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameTextBox.Location = new System.Drawing.Point(109, 65);
            this.firstNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.firstNameTextBox.MaxLength = 45;
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(333, 26);
            this.firstNameTextBox.TabIndex = 1;
            this.firstNameTextBox.Enter += new System.EventHandler(this.firstNameTextBox_Enter);
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lastNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameTextBox.Location = new System.Drawing.Point(109, 128);
            this.lastNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.lastNameTextBox.MaxLength = 45;
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(333, 26);
            this.lastNameTextBox.TabIndex = 2;
            this.lastNameTextBox.Leave += new System.EventHandler(this.lastNameTextBox_Leave);
            // 
            // Addr1TextBox
            // 
            this.Addr1TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Addr1TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addr1TextBox.Location = new System.Drawing.Point(109, 250);
            this.Addr1TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.Addr1TextBox.MaxLength = 45;
            this.Addr1TextBox.Name = "Addr1TextBox";
            this.Addr1TextBox.Size = new System.Drawing.Size(333, 26);
            this.Addr1TextBox.TabIndex = 4;
            this.Addr1TextBox.Leave += new System.EventHandler(this.addr1TextBox_Leave);
            // 
            // Addr2TextBox
            // 
            this.Addr2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Addr2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addr2TextBox.Location = new System.Drawing.Point(109, 312);
            this.Addr2TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.Addr2TextBox.MaxLength = 45;
            this.Addr2TextBox.Name = "Addr2TextBox";
            this.Addr2TextBox.Size = new System.Drawing.Size(333, 26);
            this.Addr2TextBox.TabIndex = 5;
            // 
            // cityTextBox
            // 
            this.cityTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityTextBox.Location = new System.Drawing.Point(109, 372);
            this.cityTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.cityTextBox.MaxLength = 45;
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(198, 26);
            this.cityTextBox.TabIndex = 6;
            this.cityTextBox.Leave += new System.EventHandler(this.cityTextBox_Leave);
            // 
            // zipCodeTextBox
            // 
            this.zipCodeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.zipCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipCodeTextBox.Location = new System.Drawing.Point(109, 430);
            this.zipCodeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.zipCodeTextBox.MaxLength = 5;
            this.zipCodeTextBox.Name = "zipCodeTextBox";
            this.zipCodeTextBox.Size = new System.Drawing.Size(198, 26);
            this.zipCodeTextBox.TabIndex = 8;
            this.zipCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.zipCodeTextBox_KeyPress);
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLabel.Location = new System.Drawing.Point(14, 68);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(90, 20);
            this.firstNameLabel.TabIndex = 8;
            this.firstNameLabel.Text = "First Name:";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLabel.Location = new System.Drawing.Point(14, 131);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(90, 20);
            this.lastNameLabel.TabIndex = 9;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // addr1Label
            // 
            this.addr1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addr1Label.AutoSize = true;
            this.addr1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addr1Label.Location = new System.Drawing.Point(19, 253);
            this.addr1Label.Name = "addr1Label";
            this.addr1Label.Size = new System.Drawing.Size(85, 20);
            this.addr1Label.TabIndex = 10;
            this.addr1Label.Text = "Address 1:";
            // 
            // cityLabel
            // 
            this.cityLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cityLabel.AutoSize = true;
            this.cityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityLabel.Location = new System.Drawing.Point(65, 375);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(39, 20);
            this.cityLabel.TabIndex = 11;
            this.cityLabel.Text = "City:";
            // 
            // addr2Label
            // 
            this.addr2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addr2Label.AutoSize = true;
            this.addr2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addr2Label.Location = new System.Drawing.Point(19, 315);
            this.addr2Label.Name = "addr2Label";
            this.addr2Label.Size = new System.Drawing.Size(85, 20);
            this.addr2Label.TabIndex = 12;
            this.addr2Label.Text = "Address 2:";
            // 
            // zipCodeLabel
            // 
            this.zipCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.zipCodeLabel.AutoSize = true;
            this.zipCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipCodeLabel.Location = new System.Drawing.Point(27, 433);
            this.zipCodeLabel.Name = "zipCodeLabel";
            this.zipCodeLabel.Size = new System.Drawing.Size(77, 20);
            this.zipCodeLabel.TabIndex = 13;
            this.zipCodeLabel.Text = "Zip Code:";
            // 
            // RegisterButton
            // 
            this.RegisterButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterButton.Location = new System.Drawing.Point(634, 475);
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
            this.ssnTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssnTextBox.Location = new System.Drawing.Point(109, 190);
            this.ssnTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ssnTextBox.MaxLength = 9;
            this.ssnTextBox.Name = "ssnTextBox";
            this.ssnTextBox.Size = new System.Drawing.Size(333, 26);
            this.ssnTextBox.TabIndex = 3;
            this.ssnTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ssnTextBox_KeyPress);
            this.ssnTextBox.Leave += new System.EventHandler(this.ssnTextBox_Leave);
            // 
            // ssnLabel
            // 
            this.ssnLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ssnLabel.AutoSize = true;
            this.ssnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssnLabel.Location = new System.Drawing.Point(58, 193);
            this.ssnLabel.Name = "ssnLabel";
            this.ssnLabel.Size = new System.Drawing.Size(46, 20);
            this.ssnLabel.TabIndex = 16;
            this.ssnLabel.Text = "SSN:";
            // 
            // stateLabel
            // 
            this.stateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLabel.Location = new System.Drawing.Point(576, 315);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(52, 20);
            this.stateLabel.TabIndex = 18;
            this.stateLabel.Text = "State:";
            // 
            // contactNumberLabel
            // 
            this.contactNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.contactNumberLabel.AutoSize = true;
            this.contactNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactNumberLabel.Location = new System.Drawing.Point(443, 415);
            this.contactNumberLabel.Name = "contactNumberLabel";
            this.contactNumberLabel.Size = new System.Drawing.Size(82, 20);
            this.contactNumberLabel.TabIndex = 20;
            this.contactNumberLabel.Text = "Contact #:";
            // 
            // contactNumberTextBox
            // 
            this.contactNumberTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.contactNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactNumberTextBox.Location = new System.Drawing.Point(532, 416);
            this.contactNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.contactNumberTextBox.MaxLength = 10;
            this.contactNumberTextBox.Name = "contactNumberTextBox";
            this.contactNumberTextBox.Size = new System.Drawing.Size(242, 26);
            this.contactNumberTextBox.TabIndex = 19;
            this.contactNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.contactNumberTextBox_KeyPress);
            this.contactNumberTextBox.Leave += new System.EventHandler(this.contactNumberTextBox_Leave);
            // 
            // sexComboBox
            // 
            this.sexComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sexComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sexComboBox.FormattingEnabled = true;
            this.sexComboBox.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.sexComboBox.Location = new System.Drawing.Point(634, 68);
            this.sexComboBox.Name = "sexComboBox";
            this.sexComboBox.Size = new System.Drawing.Size(140, 28);
            this.sexComboBox.TabIndex = 21;
            this.sexComboBox.Leave += new System.EventHandler(this.sexComboBox_Leave);
            // 
            // sexLabel
            // 
            this.sexLabel.AutoSize = true;
            this.sexLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sexLabel.Location = new System.Drawing.Point(561, 71);
            this.sexLabel.Name = "sexLabel";
            this.sexLabel.Size = new System.Drawing.Size(67, 20);
            this.sexLabel.TabIndex = 22;
            this.sexLabel.Text = "Gender:";
            // 
            // requiredFieldLbl
            // 
            this.requiredFieldLbl.AutoSize = true;
            this.requiredFieldLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requiredFieldLbl.ForeColor = System.Drawing.Color.Red;
            this.requiredFieldLbl.Location = new System.Drawing.Point(19, 9);
            this.requiredFieldLbl.Name = "requiredFieldLbl";
            this.requiredFieldLbl.Size = new System.Drawing.Size(228, 20);
            this.requiredFieldLbl.TabIndex = 23;
            this.requiredFieldLbl.Text = "Fields with an * must be filled in";
            this.requiredFieldLbl.Visible = false;
            // 
            // stateComboBox
            // 
            this.stateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stateComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.stateComboBox.Location = new System.Drawing.Point(634, 312);
            this.stateComboBox.Name = "stateComboBox";
            this.stateComboBox.Size = new System.Drawing.Size(140, 28);
            this.stateComboBox.TabIndex = 24;
            this.stateComboBox.Leave += new System.EventHandler(this.stateComboBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(551, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(4, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(48, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(4, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(329, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(566, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(17, 427);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(9, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 20);
            this.label8.TabIndex = 32;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(432, 410);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 20);
            this.label9.TabIndex = 33;
            this.label9.Text = "*";
            // 
            // fNameWarnLabel
            // 
            this.fNameWarnLabel.AutoSize = true;
            this.fNameWarnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fNameWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.fNameWarnLabel.Location = new System.Drawing.Point(105, 41);
            this.fNameWarnLabel.Name = "fNameWarnLabel";
            this.fNameWarnLabel.Size = new System.Drawing.Size(210, 20);
            this.fNameWarnLabel.TabIndex = 34;
            this.fNameWarnLabel.Text = "First name cannot be empty.";
            this.fNameWarnLabel.Visible = false;
            // 
            // lNameWarnLabel
            // 
            this.lNameWarnLabel.AutoSize = true;
            this.lNameWarnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNameWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.lNameWarnLabel.Location = new System.Drawing.Point(105, 104);
            this.lNameWarnLabel.Name = "lNameWarnLabel";
            this.lNameWarnLabel.Size = new System.Drawing.Size(210, 20);
            this.lNameWarnLabel.TabIndex = 35;
            this.lNameWarnLabel.Text = "Last name cannot be empty.";
            this.lNameWarnLabel.Visible = false;
            // 
            // ssnWarnLabel
            // 
            this.ssnWarnLabel.AutoSize = true;
            this.ssnWarnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssnWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.ssnWarnLabel.Location = new System.Drawing.Point(105, 166);
            this.ssnWarnLabel.Name = "ssnWarnLabel";
            this.ssnWarnLabel.Size = new System.Drawing.Size(195, 20);
            this.ssnWarnLabel.TabIndex = 36;
            this.ssnWarnLabel.Text = "SSN must be 9 digits long.";
            this.ssnWarnLabel.Visible = false;
            // 
            // zipCodeWarnLabel
            // 
            this.zipCodeWarnLabel.AutoSize = true;
            this.zipCodeWarnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipCodeWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.zipCodeWarnLabel.Location = new System.Drawing.Point(84, 406);
            this.zipCodeWarnLabel.Name = "zipCodeWarnLabel";
            this.zipCodeWarnLabel.Size = new System.Drawing.Size(223, 20);
            this.zipCodeWarnLabel.TabIndex = 37;
            this.zipCodeWarnLabel.Text = "Zip code must be 5 digits long.";
            this.zipCodeWarnLabel.Visible = false;
            // 
            // contactNumWarnLabel
            // 
            this.contactNumWarnLabel.AutoSize = true;
            this.contactNumWarnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactNumWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.contactNumWarnLabel.Location = new System.Drawing.Point(534, 389);
            this.contactNumWarnLabel.Name = "contactNumWarnLabel";
            this.contactNumWarnLabel.Size = new System.Drawing.Size(240, 20);
            this.contactNumWarnLabel.TabIndex = 38;
            this.contactNumWarnLabel.Text = "Contact # must be 10 digits long.";
            this.contactNumWarnLabel.Visible = false;
            // 
            // stateWarnLabel
            // 
            this.stateWarnLabel.AutoSize = true;
            this.stateWarnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.stateWarnLabel.Location = new System.Drawing.Point(640, 279);
            this.stateWarnLabel.Name = "stateWarnLabel";
            this.stateWarnLabel.Size = new System.Drawing.Size(134, 20);
            this.stateWarnLabel.TabIndex = 39;
            this.stateWarnLabel.Text = "Must select state.";
            this.stateWarnLabel.Visible = false;
            // 
            // sexWarnLabel
            // 
            this.sexWarnLabel.AutoSize = true;
            this.sexWarnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sexWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.sexWarnLabel.Location = new System.Drawing.Point(626, 41);
            this.sexWarnLabel.Name = "sexWarnLabel";
            this.sexWarnLabel.Size = new System.Drawing.Size(148, 20);
            this.sexWarnLabel.TabIndex = 40;
            this.sexWarnLabel.Text = "Must select gender.";
            this.sexWarnLabel.Visible = false;
            // 
            // addr1WarnLabel
            // 
            this.addr1WarnLabel.AutoSize = true;
            this.addr1WarnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addr1WarnLabel.ForeColor = System.Drawing.Color.Red;
            this.addr1WarnLabel.Location = new System.Drawing.Point(105, 229);
            this.addr1WarnLabel.Name = "addr1WarnLabel";
            this.addr1WarnLabel.Size = new System.Drawing.Size(207, 20);
            this.addr1WarnLabel.TabIndex = 41;
            this.addr1WarnLabel.Text = "Address 1 cannot be empty.";
            this.addr1WarnLabel.Visible = false;
            // 
            // cityWarnLabel
            // 
            this.cityWarnLabel.AutoSize = true;
            this.cityWarnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityWarnLabel.ForeColor = System.Drawing.Color.Red;
            this.cityWarnLabel.Location = new System.Drawing.Point(146, 348);
            this.cityWarnLabel.Name = "cityWarnLabel";
            this.cityWarnLabel.Size = new System.Drawing.Size(161, 20);
            this.cityWarnLabel.TabIndex = 42;
            this.cityWarnLabel.Text = "City cannot be empty.";
            this.cityWarnLabel.Visible = false;
            // 
            // updateButton
            // 
            this.updateButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.updateButton.Enabled = false;
            this.updateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.Location = new System.Drawing.Point(466, 475);
            this.updateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(140, 29);
            this.updateButton.TabIndex = 43;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Visible = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // dobLabel
            // 
            this.dobLabel.AutoSize = true;
            this.dobLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dobLabel.Location = new System.Drawing.Point(452, 195);
            this.dobLabel.Name = "dobLabel";
            this.dobLabel.Size = new System.Drawing.Size(48, 20);
            this.dobLabel.TabIndex = 44;
            this.dobLabel.Text = "DOB:";
            // 
            // datePicker
            // 
            this.datePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePicker.Location = new System.Drawing.Point(506, 190);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(268, 26);
            this.datePicker.TabIndex = 45;
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(23, 475);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(117, 32);
            this.deleteButton.TabIndex = 46;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Visible = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(442, 190);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 20);
            this.label10.TabIndex = 47;
            this.label10.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(55, 371);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 20);
            this.label11.TabIndex = 48;
            this.label11.Text = "*";
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 531);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.dobLabel);
            this.Controls.Add(this.updateButton);
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
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
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
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label dobLabel;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

