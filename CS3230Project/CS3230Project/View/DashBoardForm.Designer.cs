namespace CS3230Project
{
    partial class DashBoardForm
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
            this.logOutButton = new System.Windows.Forms.Button();
            this.registerPatientButton = new System.Windows.Forms.Button();
            this.greetingsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainInfoDisplay = new System.Windows.Forms.ListBox();
            this.editPatientButton = new System.Windows.Forms.Button();
            this.patientLookUpButton = new System.Windows.Forms.Button();
            this.adminButton = new System.Windows.Forms.Button();
            this.appointmentBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logOutButton
            // 
            this.logOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutButton.Location = new System.Drawing.Point(91, 474);
            this.logOutButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(220, 48);
            this.logOutButton.TabIndex = 0;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // registerPatientButton
            // 
            this.registerPatientButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerPatientButton.Location = new System.Drawing.Point(91, 81);
            this.registerPatientButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.registerPatientButton.Name = "registerPatientButton";
            this.registerPatientButton.Size = new System.Drawing.Size(220, 48);
            this.registerPatientButton.TabIndex = 1;
            this.registerPatientButton.Text = "Register Patient";
            this.registerPatientButton.UseVisualStyleBackColor = true;
            this.registerPatientButton.Click += new System.EventHandler(this.registerPatientButton_Click);
            // 
            // greetingsLabel
            // 
            this.greetingsLabel.AutoSize = true;
            this.greetingsLabel.Location = new System.Drawing.Point(120, 43);
            this.greetingsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.greetingsLabel.Name = "greetingsLabel";
            this.greetingsLabel.Size = new System.Drawing.Size(61, 25);
            this.greetingsLabel.TabIndex = 2;
            this.greetingsLabel.Text = "Hello,";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(424, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Patients:";
            // 
            // mainInfoDisplay
            // 
            this.mainInfoDisplay.FormattingEnabled = true;
            this.mainInfoDisplay.ItemHeight = 25;
            this.mainInfoDisplay.Location = new System.Drawing.Point(428, 43);
            this.mainInfoDisplay.Name = "mainInfoDisplay";
            this.mainInfoDisplay.Size = new System.Drawing.Size(430, 479);
            this.mainInfoDisplay.TabIndex = 5;
            // 
            // editPatientButton
            // 
            this.editPatientButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPatientButton.Location = new System.Drawing.Point(91, 139);
            this.editPatientButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editPatientButton.Name = "editPatientButton";
            this.editPatientButton.Size = new System.Drawing.Size(220, 48);
            this.editPatientButton.TabIndex = 6;
            this.editPatientButton.Text = "Edit Patient";
            this.editPatientButton.UseVisualStyleBackColor = true;
            this.editPatientButton.Click += new System.EventHandler(this.editPatientButton_Click);
            // 
            // patientLookUpButton
            // 
            this.patientLookUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientLookUpButton.Location = new System.Drawing.Point(91, 362);
            this.patientLookUpButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.patientLookUpButton.Name = "patientLookUpButton";
            this.patientLookUpButton.Size = new System.Drawing.Size(220, 48);
            this.patientLookUpButton.TabIndex = 7;
            this.patientLookUpButton.Text = "Patient Lookup";
            this.patientLookUpButton.UseVisualStyleBackColor = true;
            this.patientLookUpButton.Click += new System.EventHandler(this.patientLookUpButton_Click);
            // 
            // adminButton
            // 
            this.adminButton.Enabled = false;
            this.adminButton.Location = new System.Drawing.Point(91, 418);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(220, 48);
            this.adminButton.TabIndex = 8;
            this.adminButton.Text = "Query";
            this.adminButton.UseVisualStyleBackColor = true;
            this.adminButton.Visible = false;
            this.adminButton.Click += new System.EventHandler(this.adminButton_Click);
            // 
            // appointmentBtn
            // 
            this.appointmentBtn.Location = new System.Drawing.Point(91, 195);
            this.appointmentBtn.Name = "appointmentBtn";
            this.appointmentBtn.Size = new System.Drawing.Size(220, 54);
            this.appointmentBtn.TabIndex = 9;
            this.appointmentBtn.Text = "Appointment";
            this.appointmentBtn.UseVisualStyleBackColor = true;
            this.appointmentBtn.Click += new System.EventHandler(this.appointmentBtn_Click);
            // 
            // DashBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 552);
            this.Controls.Add(this.appointmentBtn);
            this.Controls.Add(this.adminButton);
            this.Controls.Add(this.patientLookUpButton);
            this.Controls.Add(this.editPatientButton);
            this.Controls.Add(this.mainInfoDisplay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.greetingsLabel);
            this.Controls.Add(this.registerPatientButton);
            this.Controls.Add(this.logOutButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DashBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Activated += new System.EventHandler(this.DashBoardForm_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button registerPatientButton;
        private System.Windows.Forms.Label greetingsLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox mainInfoDisplay;
        private System.Windows.Forms.Button editPatientButton;
        private System.Windows.Forms.Button patientLookUpButton;
        private System.Windows.Forms.Button adminButton;
        private System.Windows.Forms.Button appointmentBtn;
    }
}