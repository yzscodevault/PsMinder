using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsMinder
{
    public partial class LoginPage : Form
    {
        PsMinderEntities psMinderEntities = new PsMinderEntities();
        int attempts = 0;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void ckbxLoginPasswordShow_CheckedChanged(object sender, EventArgs e)
        {
            msktxbxLoginPassword.PasswordChar=ckbxLoginPasswordShow.Checked ? '\0' : '*';
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            msktxbxLoginPassword.PasswordChar='*';
            ckbxLoginPasswordShow.Checked=false;
        }

        private void btnLoginEnter_Click(object sender, EventArgs e)
        {
            //CredentialTable usernameInputTable = psMinderEntities.CredentialTables.Find(txbxLoginUserName.Text);
            //string passwordInput = txbxLoginPassword.Text;
            StringBuilder passwordAnswer=new StringBuilder();
            CredentialTable credentialTable = new CredentialTable();
            credentialTable=psMinderEntities.CredentialTables.Find(txbxLoginUserName.Text);
            
            if (attempts<2)//user has one +3 attempts
            {
                if (psMinderEntities.CredentialTables.Find(txbxLoginUserName.Text)!=null&&psMinderEntities.CredentialTables.Find(txbxLoginUserName.Text).Password==msktxbxLoginPassword.Text)
                {
                    this.Visible=false;
                    MainPage prescriptionForm = new MainPage();
                    prescriptionForm.Visible=true;
                }
                else
                {
                    MessageBox.Show($"Please re-try or contact administrator! You have {3-attempts} more attempts left", "User Name or Password incorrect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (attempts==2)
            {
                if (psMinderEntities.CredentialTables.Find(txbxLoginUserName.Text)!=null&&psMinderEntities.CredentialTables.Find(txbxLoginUserName.Text).Password.ToString()==msktxbxLoginPassword.Text)
                {
                    this.Visible=false;
                    MainPage prescriptionForm = new MainPage();
                    prescriptionForm.Visible=true;
                }
                else
                {
                    MessageBox.Show($"Please re-try or contact administrator! You have 1 more attempt left", "User Name or Password incorrect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (attempts==3)
            {
                if (psMinderEntities.CredentialTables.Find(txbxLoginUserName.Text)!=null&&psMinderEntities.CredentialTables.Find(txbxLoginUserName.Text).Password.ToString()==msktxbxLoginPassword.Text)
                {
                    this.Visible=false;
                    MainPage prescriptionForm = new MainPage();
                    prescriptionForm.Visible=true;
                }
                else
                {
                    MessageBox.Show("Please contact administrator! You cannot login at this time", "User Name or Password incorrect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbxLoginUserName.Enabled=false;
                    msktxbxLoginPassword.Enabled=false;
                }
            }
            attempts++;
        }

        private void btnLoginCancel_Click(object sender, EventArgs e)
        {
            txbxLoginUserName.Clear();
            msktxbxLoginPassword.Clear();
            ckbxLoginPasswordShow.Checked=false;
        }

        private void btnLoginExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to exit?", "Exiting Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult==DialogResult.Yes)
            {
                MessageBox.Show("See you next time and have great day!", "Thank you for using PsMinder");
                Application.Exit();
            }
        }

        private void lklblLinkedIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/yang-zhang-1318a6228/");

        }

        private void lklblEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Mailto:zhangmssa@outlook.com");

        }
    }
}
