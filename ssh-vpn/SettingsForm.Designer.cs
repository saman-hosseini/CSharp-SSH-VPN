namespace ssh_vpn
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_port = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lst_profile = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_profile = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.lst_forwardedport = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_forwardportname = new System.Windows.Forms.TextBox();
            this.txt_boundport = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_remotehost = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_boundhost = new System.Windows.Forms.TextBox();
            this.txt_remoteport = new System.Windows.Forms.NumericUpDown();
            this.btn_forwardportsave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txt_port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_boundport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_remoteport)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(266, 35);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(187, 20);
            this.txt_ip.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Address : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username : ";
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(266, 88);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(187, 20);
            this.txt_username.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(183, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password : ";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(266, 114);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(187, 20);
            this.txt_password.TabIndex = 4;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(183, 140);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(222, 39);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(266, 61);
            this.txt_port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txt_port.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(187, 20);
            this.txt_port.TabIndex = 9;
            this.txt_port.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Server port :";
            // 
            // lst_profile
            // 
            this.lst_profile.FormattingEnabled = true;
            this.lst_profile.Location = new System.Drawing.Point(12, 12);
            this.lst_profile.Name = "lst_profile";
            this.lst_profile.Size = new System.Drawing.Size(165, 160);
            this.lst_profile.TabIndex = 10;
            this.lst_profile.SelectedIndexChanged += new System.EventHandler(this.lst_profile_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Profile : ";
            // 
            // txt_profile
            // 
            this.txt_profile.Location = new System.Drawing.Point(266, 9);
            this.txt_profile.Name = "txt_profile";
            this.txt_profile.Size = new System.Drawing.Size(187, 20);
            this.txt_profile.TabIndex = 11;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(411, 140);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(90, 39);
            this.btn_delete.TabIndex = 13;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // lst_forwardedport
            // 
            this.lst_forwardedport.FormattingEnabled = true;
            this.lst_forwardedport.Location = new System.Drawing.Point(9, 210);
            this.lst_forwardedport.Name = "lst_forwardedport";
            this.lst_forwardedport.Size = new System.Drawing.Size(165, 147);
            this.lst_forwardedport.TabIndex = 14;
            this.lst_forwardedport.SelectedIndexChanged += new System.EventHandler(this.lst_forwardedport_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Profile : ";
            // 
            // txt_forwardportname
            // 
            this.txt_forwardportname.Location = new System.Drawing.Point(266, 223);
            this.txt_forwardportname.Name = "txt_forwardportname";
            this.txt_forwardportname.Size = new System.Drawing.Size(187, 20);
            this.txt_forwardportname.TabIndex = 33;
            // 
            // txt_boundport
            // 
            this.txt_boundport.Location = new System.Drawing.Point(266, 275);
            this.txt_boundport.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txt_boundport.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_boundport.Name = "txt_boundport";
            this.txt_boundport.Size = new System.Drawing.Size(187, 20);
            this.txt_boundport.TabIndex = 32;
            this.txt_boundport.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 279);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Bound Port :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(180, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Remote Port : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(180, 305);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Remote Host : ";
            // 
            // txt_remotehost
            // 
            this.txt_remotehost.Location = new System.Drawing.Point(266, 302);
            this.txt_remotehost.Name = "txt_remotehost";
            this.txt_remotehost.Size = new System.Drawing.Size(187, 20);
            this.txt_remotehost.TabIndex = 27;
            this.txt_remotehost.Text = "127.0.0.1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(180, 252);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Bound Host : ";
            // 
            // txt_boundhost
            // 
            this.txt_boundhost.Location = new System.Drawing.Point(266, 249);
            this.txt_boundhost.Name = "txt_boundhost";
            this.txt_boundhost.Size = new System.Drawing.Size(187, 20);
            this.txt_boundhost.TabIndex = 25;
            this.txt_boundhost.Text = "127.0.0.1";
            // 
            // txt_remoteport
            // 
            this.txt_remoteport.Location = new System.Drawing.Point(266, 328);
            this.txt_remoteport.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txt_remoteport.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_remoteport.Name = "txt_remoteport";
            this.txt_remoteport.Size = new System.Drawing.Size(187, 20);
            this.txt_remoteport.TabIndex = 35;
            this.txt_remoteport.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // btn_forwardportsave
            // 
            this.btn_forwardportsave.Location = new System.Drawing.Point(183, 354);
            this.btn_forwardportsave.Name = "btn_forwardportsave";
            this.btn_forwardportsave.Size = new System.Drawing.Size(222, 39);
            this.btn_forwardportsave.TabIndex = 36;
            this.btn_forwardportsave.Text = "Save";
            this.btn_forwardportsave.UseVisualStyleBackColor = true;
            this.btn_forwardportsave.Click += new System.EventHandler(this.btn_forwardportsave_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btn_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(511, 398);
            this.Controls.Add(this.btn_forwardportsave);
            this.Controls.Add(this.txt_remoteport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_forwardportname);
            this.Controls.Add(this.txt_boundport);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_remotehost);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_boundhost);
            this.Controls.Add(this.lst_forwardedport);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_profile);
            this.Controls.Add(this.lst_profile);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.txt_port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_boundport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_remoteport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.NumericUpDown txt_port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lst_profile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_profile;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.ListBox lst_forwardedport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_forwardportname;
        private System.Windows.Forms.NumericUpDown txt_boundport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_remotehost;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_boundhost;
        private System.Windows.Forms.NumericUpDown txt_remoteport;
        private System.Windows.Forms.Button btn_forwardportsave;
    }
}