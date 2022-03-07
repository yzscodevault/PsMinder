
namespace PsMinder
{
    partial class LoginPage
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
            this.lblLoginPsMinder = new System.Windows.Forms.Label();
            this.lblLoginDefine = new System.Windows.Forms.Label();
            this.lblLoginUserName = new System.Windows.Forms.Label();
            this.txbxLoginUserName = new System.Windows.Forms.TextBox();
            this.lblLoginPassword = new System.Windows.Forms.Label();
            this.btnLoginEnter = new System.Windows.Forms.Button();
            this.btnLoginCancel = new System.Windows.Forms.Button();
            this.lklblLinkedIn = new System.Windows.Forms.LinkLabel();
            this.lklblEmail = new System.Windows.Forms.LinkLabel();
            this.btnLoginExit = new System.Windows.Forms.Button();
            this.grpbxLogin = new System.Windows.Forms.GroupBox();
            this.msktxbxLoginPassword = new System.Windows.Forms.TextBox();
            this.ckbxLoginPasswordShow = new System.Windows.Forms.CheckBox();
            this.grpbxLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLoginPsMinder
            // 
            this.lblLoginPsMinder.AutoSize = true;
            this.lblLoginPsMinder.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoginPsMinder.Location = new System.Drawing.Point(268, 89);
            this.lblLoginPsMinder.Name = "lblLoginPsMinder";
            this.lblLoginPsMinder.Size = new System.Drawing.Size(423, 46);
            this.lblLoginPsMinder.TabIndex = 10;
            this.lblLoginPsMinder.Text = "Welcome to Ps Minder";
            // 
            // lblLoginDefine
            // 
            this.lblLoginDefine.AutoSize = true;
            this.lblLoginDefine.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoginDefine.Location = new System.Drawing.Point(328, 151);
            this.lblLoginDefine.Name = "lblLoginDefine";
            this.lblLoginDefine.Size = new System.Drawing.Size(307, 25);
            this.lblLoginDefine.TabIndex = 11;
            this.lblLoginDefine.Text = "Pet Prescription Reminder System";
            // 
            // lblLoginUserName
            // 
            this.lblLoginUserName.AutoSize = true;
            this.lblLoginUserName.Location = new System.Drawing.Point(69, 58);
            this.lblLoginUserName.Name = "lblLoginUserName";
            this.lblLoginUserName.Size = new System.Drawing.Size(63, 13);
            this.lblLoginUserName.TabIndex = 12;
            this.lblLoginUserName.Text = "User Name:";
            // 
            // txbxLoginUserName
            // 
            this.txbxLoginUserName.Location = new System.Drawing.Point(162, 58);
            this.txbxLoginUserName.Name = "txbxLoginUserName";
            this.txbxLoginUserName.Size = new System.Drawing.Size(100, 20);
            this.txbxLoginUserName.TabIndex = 1;
            // 
            // lblLoginPassword
            // 
            this.lblLoginPassword.AutoSize = true;
            this.lblLoginPassword.Location = new System.Drawing.Point(69, 112);
            this.lblLoginPassword.Name = "lblLoginPassword";
            this.lblLoginPassword.Size = new System.Drawing.Size(53, 13);
            this.lblLoginPassword.TabIndex = 13;
            this.lblLoginPassword.Text = "Password";
            // 
            // btnLoginEnter
            // 
            this.btnLoginEnter.Location = new System.Drawing.Point(30, 175);
            this.btnLoginEnter.Name = "btnLoginEnter";
            this.btnLoginEnter.Size = new System.Drawing.Size(75, 23);
            this.btnLoginEnter.TabIndex = 4;
            this.btnLoginEnter.Text = "Enter";
            this.btnLoginEnter.UseVisualStyleBackColor = true;
            this.btnLoginEnter.Click += new System.EventHandler(this.btnLoginEnter_Click);
            // 
            // btnLoginCancel
            // 
            this.btnLoginCancel.Location = new System.Drawing.Point(297, 175);
            this.btnLoginCancel.Name = "btnLoginCancel";
            this.btnLoginCancel.Size = new System.Drawing.Size(75, 23);
            this.btnLoginCancel.TabIndex = 5;
            this.btnLoginCancel.Text = "Cancel";
            this.btnLoginCancel.UseVisualStyleBackColor = true;
            this.btnLoginCancel.Click += new System.EventHandler(this.btnLoginCancel_Click);
            // 
            // lklblLinkedIn
            // 
            this.lklblLinkedIn.AutoSize = true;
            this.lklblLinkedIn.Location = new System.Drawing.Point(42, 685);
            this.lklblLinkedIn.Name = "lklblLinkedIn";
            this.lklblLinkedIn.Size = new System.Drawing.Size(87, 13);
            this.lklblLinkedIn.TabIndex = 6;
            this.lklblLinkedIn.TabStop = true;
            this.lklblLinkedIn.Text = "Visit My LinkedIn";
            this.lklblLinkedIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklblLinkedIn_LinkClicked);
            // 
            // lklblEmail
            // 
            this.lklblEmail.AutoSize = true;
            this.lklblEmail.Location = new System.Drawing.Point(154, 685);
            this.lklblEmail.Name = "lklblEmail";
            this.lklblEmail.Size = new System.Drawing.Size(50, 13);
            this.lklblEmail.TabIndex = 7;
            this.lklblEmail.TabStop = true;
            this.lklblEmail.Text = "Email Me";
            this.lklblEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklblEmail_LinkClicked);
            // 
            // btnLoginExit
            // 
            this.btnLoginExit.Location = new System.Drawing.Point(907, 685);
            this.btnLoginExit.Name = "btnLoginExit";
            this.btnLoginExit.Size = new System.Drawing.Size(75, 23);
            this.btnLoginExit.TabIndex = 8;
            this.btnLoginExit.Text = "Exit Program";
            this.btnLoginExit.UseVisualStyleBackColor = true;
            this.btnLoginExit.Click += new System.EventHandler(this.btnLoginExit_Click);
            // 
            // grpbxLogin
            // 
            this.grpbxLogin.Controls.Add(this.ckbxLoginPasswordShow);
            this.grpbxLogin.Controls.Add(this.msktxbxLoginPassword);
            this.grpbxLogin.Controls.Add(this.txbxLoginUserName);
            this.grpbxLogin.Controls.Add(this.lblLoginUserName);
            this.grpbxLogin.Controls.Add(this.lblLoginPassword);
            this.grpbxLogin.Controls.Add(this.btnLoginCancel);
            this.grpbxLogin.Controls.Add(this.btnLoginEnter);
            this.grpbxLogin.Location = new System.Drawing.Point(261, 256);
            this.grpbxLogin.Name = "grpbxLogin";
            this.grpbxLogin.Size = new System.Drawing.Size(419, 226);
            this.grpbxLogin.TabIndex = 9;
            this.grpbxLogin.TabStop = false;
            this.grpbxLogin.Text = "Log In";
            // 
            // msktxbxLoginPassword
            // 
            this.msktxbxLoginPassword.Location = new System.Drawing.Point(162, 109);
            this.msktxbxLoginPassword.Name = "msktxbxLoginPassword";
            this.msktxbxLoginPassword.Size = new System.Drawing.Size(100, 20);
            this.msktxbxLoginPassword.TabIndex = 2;
            // 
            // ckbxLoginPasswordShow
            // 
            this.ckbxLoginPasswordShow.AutoSize = true;
            this.ckbxLoginPasswordShow.Location = new System.Drawing.Point(286, 111);
            this.ckbxLoginPasswordShow.Name = "ckbxLoginPasswordShow";
            this.ckbxLoginPasswordShow.Size = new System.Drawing.Size(102, 17);
            this.ckbxLoginPasswordShow.TabIndex = 3;
            this.ckbxLoginPasswordShow.Text = "Show Password";
            this.ckbxLoginPasswordShow.UseVisualStyleBackColor = true;
            this.ckbxLoginPasswordShow.CheckedChanged += new System.EventHandler(this.ckbxLoginPasswordShow_CheckedChanged);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 747);
            this.Controls.Add(this.grpbxLogin);
            this.Controls.Add(this.btnLoginExit);
            this.Controls.Add(this.lklblEmail);
            this.Controls.Add(this.lklblLinkedIn);
            this.Controls.Add(this.lblLoginDefine);
            this.Controls.Add(this.lblLoginPsMinder);
            this.Name = "LoginPage";
            this.Text = "Login Page";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.grpbxLogin.ResumeLayout(false);
            this.grpbxLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoginPsMinder;
        private System.Windows.Forms.Label lblLoginDefine;
        private System.Windows.Forms.Label lblLoginUserName;
        private System.Windows.Forms.TextBox txbxLoginUserName;
        private System.Windows.Forms.Label lblLoginPassword;
        private System.Windows.Forms.Button btnLoginEnter;
        private System.Windows.Forms.Button btnLoginCancel;
        private System.Windows.Forms.LinkLabel lklblLinkedIn;
        private System.Windows.Forms.LinkLabel lklblEmail;
        private System.Windows.Forms.Button btnLoginExit;
        private System.Windows.Forms.GroupBox grpbxLogin;
        private System.Windows.Forms.TextBox msktxbxLoginPassword;
        private System.Windows.Forms.CheckBox ckbxLoginPasswordShow;
    }
}