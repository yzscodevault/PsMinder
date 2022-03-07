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
    public partial class Reminder : Form
    {
        public Reminder()
        {
            InitializeComponent();
        }

        private void Reminder_Load(object sender, EventArgs e)
        {

        }

        private void lklblReminderPrescriptionInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible=false;
            MainPage prescriptionForm = new MainPage();
            prescriptionForm.Visible=true;
        }

        private void lklblReminderMedicineInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Medicine medicineInfoandRestock = new Medicine();
            medicineInfoandRestock.Visible=true;
            this.Visible=false;
        }

        private void lklblReminderPetInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Pet petinfo = new Pet();
            petinfo.Visible=true;
            this.Visible=false;
        }

        private void lklbReminderSignout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Visible=true;
            this.Visible=false;
        }

        private void btnReminderExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to exit?", "Exiting Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult==DialogResult.Yes)
            {
                MessageBox.Show("See you next time and have great day!", "Thank you for using PsMinder");
                Application.Exit();
            }
        }

        private void lklblReminderLinkedIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/yang-zhang-1318a6228/");
        }

        private void lklblReminderEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Mailto:zhangmssa@outlook.com");
        }
    }
}
