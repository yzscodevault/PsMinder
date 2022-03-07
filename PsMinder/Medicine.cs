using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PsMinder
{
    public partial class Medicine : Form
    {
        MedicineRecords medicineRecords = new MedicineRecords();
        string decimalFormatCheckString = @"^\d+(\.?\d+)?$";
        decimal dailyConsumption = 0;
        decimal currentStock = 0;
        bool nonOptionalAreValid = false;

        public Medicine()
        {
            InitializeComponent();
        }

        public void RefreshMedicineDataGridView()
        {
            dataGridMedInfo.DataSource=null;
            dataGridMedInfo.DataSource=medicineRecords.GetAllMedicineRecords();
            //hide column 4,8-10
            dataGridMedInfo.Columns[4].Visible=false;
            dataGridMedInfo.Columns[8].Visible=false;
            dataGridMedInfo.Columns[9].Visible=false;
            dataGridMedInfo.Columns[10].Visible=false;
        }
        
        public void ResetAllMedicineInputAreas()
        {
            txbxMedInfoMedID.Clear();
            txbxMedInfoMedName.Clear();
            txbxMedInfoMedDailyConsumption.Clear();
            cmbxMedicineUnit.Items.Clear();
            foreach (UnitTable unitTableRecord in medicineRecords.GetAllUnits())
            { cmbxMedicineUnit.Items.Add(unitTableRecord.Unit); }
            cmbxMedicineUnit.ResetText();
            txbxMedInfoCurrentStock.Clear();
            dateTimePickerMedInfoProjectedRestockDate.ResetText();
            txbxMedInfoNotes.Clear();
            txbxMedInfoNotes.Text="optional";
        }

        public void checknonOptionalsNullorOverflowandDatetimeInput()//if input is invalid, submit or update would not go through, error message will be shown, focus will be gained, data will be assigned as "0" or today.date
        {
            if (!string.IsNullOrWhiteSpace(txbxMedInfoMedName.Text))
            {
                if (Regex.IsMatch(txbxMedInfoMedDailyConsumption.Text, decimalFormatCheckString) /*&& !string.IsNullOrWhiteSpace(txbxMedInfoMedDailyConsumption.Text)*/)
                {
                    if (cmbxMedicineUnit.SelectedIndex!=-1)
                    {
                        if (Regex.IsMatch(txbxMedInfoCurrentStock.Text, decimalFormatCheckString) /*&& !string.IsNullOrWhiteSpace(txbxMedInfoCurrentStock.Text)*/)
                        {
                            try { currentStock=Convert.ToDecimal(txbxMedInfoCurrentStock.Text); }// current stock is in decimal format, now check the boundary
                            catch (OverflowException ofex) { txbxMedInfoCurrentStock.Text="0"; txbxMedInfoCurrentStock.Focus(); MessageBox.Show(ofex.Message); }
                            
                            if (dateTimePickerMedInfoProjectedRestockDate.Value.Date>=DateTime.Today.Date) { nonOptionalAreValid=true; }
                            else
                            {
                                MessageBox.Show("Projected Restock Date should be today or later!", "Projected Restock Date Selection Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dateTimePickerMedInfoProjectedRestockDate.Value=DateTime.Today.Date;
                                dateTimePickerMedInfoProjectedRestockDate.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Current Stock data is decimal and cannot be empty or white space!", "Current Stock Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txbxMedInfoCurrentStock.Text="0";
                            txbxMedInfoCurrentStock.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please make a selection for Unit!", "Unit not Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbxMedicineUnit.SelectedIndex=0;
                        cmbxMedicineUnit.Focus();
                    }
                    try { dailyConsumption=Convert.ToDecimal(txbxMedInfoMedDailyConsumption.Text); }// daily consumption is in decimal format, now check the boundary
                    catch (OverflowException ofex) { txbxMedInfoMedDailyConsumption.Text="0"; txbxMedInfoMedDailyConsumption.Focus(); MessageBox.Show(ofex.Message); }
                }
                else
                {
                    MessageBox.Show("Daily Consumption data is decimal and cannot be empty or white space!", "Daily Consumption Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbxMedInfoMedDailyConsumption.Text="0";
                    txbxMedInfoMedDailyConsumption.Focus();
                }
            }
            else
            {
                MessageBox.Show("Medicine Name cannot be empty or white space!", "Medicine Name Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbxMedInfoMedName.Text="No Medicine Name Entered";
                txbxMedInfoMedName.Focus();
            }
        }

        private void Medicine_Load(object sender, EventArgs e)
        {
            grpbxMedPsMinder.Visible=true;
            grpbxMedInfo.Visible=true;
            grpbxMedicineAddorUpdate.Visible=false;
            dataGridMedInfo.DataSource=medicineRecords.GetAllMedicineRecords();
            //hide column 4,8-10
            dataGridMedInfo.Columns[4].Visible=false;
            dataGridMedInfo.Columns[8].Visible=false;
            dataGridMedInfo.Columns[9].Visible=false;
            dataGridMedInfo.Columns[10].Visible=false;
            btnMedSubmitNew.Enabled=false;
            btnMedUpdateRecord.Enabled=false;
            cmbxMedicineUnit.Items.Clear();
            foreach (UnitTable unit in medicineRecords.GetAllUnits())
            { cmbxMedicineUnit.Items.Add(unit); }
        }

        private void btnMedAddNew_Click(object sender, EventArgs e)
        {
            grpbxMedicineAddorUpdate.Visible=true;
            RefreshMedicineDataGridView(); ResetAllMedicineInputAreas();
            txbxMedInfoMedID.ReadOnly=true;
            txbxMedInfoMedID.Text=Convert.ToString(medicineRecords.GetMaxMedicineID()+1);
            txbxMedInfoMedID.Enabled=false;
            btnMedSubmitNew.Enabled=true;
        }

        private void btnMedSubmitNew_Click(object sender, EventArgs e)
        {
            MedicineTable newMedicineRecord=new MedicineTable();
            UnitTable unitTable=new UnitTable();
            newMedicineRecord.MedicineID=Convert.ToInt32(txbxMedInfoMedID.Text);
            checknonOptionalsNullorOverflowandDatetimeInput();
            if (nonOptionalAreValid)
            {
                newMedicineRecord.MedicineName=txbxMedInfoMedName.Text;
                newMedicineRecord.DailyConsumption=Decimal.Round(Convert.ToDecimal(txbxMedInfoMedDailyConsumption.Text), 6);
                newMedicineRecord.UnitID=cmbxMedicineUnit.SelectedIndex+1;
                newMedicineRecord.Unit=cmbxMedicineUnit.SelectedItem.ToString();
                newMedicineRecord.CurrentStock=Decimal.Round(Convert.ToDecimal(txbxMedInfoCurrentStock.Text), 6);
                newMedicineRecord.ProjectedRestockDate=dateTimePickerMedInfoProjectedRestockDate.Value.Date;
                if (txbxMedInfoNotes.Text=="optional"|string.IsNullOrWhiteSpace(txbxMedInfoNotes.Text))
                { newMedicineRecord.Note=null; }
                else { newMedicineRecord.Note=txbxMedInfoNotes.Text; }
                medicineRecords.AddMedicineRecord(newMedicineRecord);
                btnMedSubmitNew.Enabled=false;
                RefreshMedicineDataGridView(); ResetAllMedicineInputAreas();
            }
        }

        private void btnMedSelectToUpdate_Click(object sender, EventArgs e)
        {
            MedicineTable selectedMedicineRecord = new MedicineTable();
            grpbxMedicineAddorUpdate.Visible=true;
            btnMedSubmitNew.Enabled=false;
            ResetAllMedicineInputAreas();
            int selectedMedicineRecordID =Convert.ToInt32(dataGridMedInfo.CurrentRow.Cells[0].Value);
            selectedMedicineRecord=medicineRecords.FindMedicineRecord(selectedMedicineRecordID);
            txbxMedInfoMedID.Text=Convert.ToString(selectedMedicineRecordID);
            txbxMedInfoMedID.ReadOnly=true;txbxMedInfoMedID.Enabled=false;
            txbxMedInfoMedName.Text=selectedMedicineRecord.MedicineName;
            txbxMedInfoMedDailyConsumption.Text=Convert.ToString(selectedMedicineRecord.DailyConsumption);
            foreach (UnitTable unitTable in medicineRecords.GetAllUnits())
            {
                if (unitTable.UnitID==selectedMedicineRecord.UnitID)
                { cmbxMedicineUnit.SelectedItem=unitTable.Unit; }
            }
            txbxMedInfoCurrentStock.Text=Convert.ToString(selectedMedicineRecord.CurrentStock);
            dateTimePickerMedInfoProjectedRestockDate.Value=selectedMedicineRecord.ProjectedRestockDate;
            txbxMedInfoNotes.Text=selectedMedicineRecord.Note;
            if (string.IsNullOrWhiteSpace(txbxMedInfoNotes.Text))
            { txbxMedInfoNotes.Text="optional"; }
            btnMedUpdateRecord.Enabled=true;
        }

        private void btnMedUpdateRecord_Click(object sender, EventArgs e)
        {
            MedicineTable medicineRecordtoUpdate = new MedicineTable();
            medicineRecordtoUpdate.MedicineID=Convert.ToInt32(txbxMedInfoMedID.Text);
            checknonOptionalsNullorOverflowandDatetimeInput();
            if (nonOptionalAreValid)
            {
                medicineRecordtoUpdate.MedicineName=txbxMedInfoMedName.Text;
                medicineRecordtoUpdate.DailyConsumption=Decimal.Round(Convert.ToDecimal(txbxMedInfoMedDailyConsumption.Text), 6);
                medicineRecordtoUpdate.CurrentStock=Decimal.Round(Convert.ToDecimal(txbxMedInfoCurrentStock.Text), 6);
                medicineRecordtoUpdate.UnitID=cmbxMedicineUnit.SelectedIndex+1;
                medicineRecordtoUpdate.Unit=cmbxMedicineUnit.SelectedItem.ToString();
                medicineRecordtoUpdate.ProjectedRestockDate=dateTimePickerMedInfoProjectedRestockDate.Value.Date;
                if (txbxMedInfoNotes.Text=="optional"|string.IsNullOrWhiteSpace(txbxMedInfoNotes.Text))
                { medicineRecordtoUpdate.Note=null; }
                else { medicineRecordtoUpdate.Note=txbxMedInfoNotes.Text; }
                medicineRecords.UpdateMedicineRecord(medicineRecordtoUpdate.MedicineID, medicineRecordtoUpdate);
                btnMedUpdateRecord.Enabled=false;
                RefreshMedicineDataGridView(); ResetAllMedicineInputAreas();
            }
        }

        private void btnMedDelete_Click(object sender, EventArgs e)
        {
            btnMedSubmitNew.Enabled=false; btnMedUpdateRecord.Enabled=false;
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete this record?", "Confirm to delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult==DialogResult.Yes)
            {
                medicineRecords.DeleteMedicineRecord(medicineRecords.FindMedicineRecord(Convert.ToInt32(dataGridMedInfo.CurrentRow.Cells[0].Value)));
                RefreshMedicineDataGridView(); ResetAllMedicineInputAreas();
                MessageBox.Show("Record deleted!");
            }
            RefreshMedicineDataGridView(); ResetAllMedicineInputAreas();
        }

        private void btnMedRefreshData_Click(object sender, EventArgs e)
        {
            btnMedSubmitNew.Enabled=false; btnMedUpdateRecord.Enabled=false;
            ResetAllMedicineInputAreas(); RefreshMedicineDataGridView();
        }

        private void btnMedicineCancel_Click(object sender, EventArgs e)
        {
            ResetAllMedicineInputAreas(); RefreshMedicineDataGridView();
        }

        private void lklblMedReminder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible=false;
            Reminder reminderForm = new Reminder();
            reminderForm.Visible=true;
        }
       
        private void lklblMedPrescriptionInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible=false;
            MainPage prescriptionForm = new MainPage();
            prescriptionForm.Visible=true;
        }

        private void lklblMedMedicineInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetAllMedicineInputAreas(); RefreshMedicineDataGridView();
        }

        private void lklblMedPetInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible=false;
            Pet petInfoForm = new Pet();
            petInfoForm.Visible=true;
        }

        private void lklblMedSignout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible=false;
            LoginPage loginForm = new LoginPage();
            loginForm.Visible=true;
        }

        private void btnMedExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to exit?", "Exiting Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult==DialogResult.Yes)
            {
                MessageBox.Show("See you next time and have great day!", "Thank you for using PsMinder");
                Application.Exit();
            }
        }

        private void lklblMedLinkedIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/yang-zhang-1318a6228/");
        }

        private void lklblMedEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Mailto:zhangmssa@outlook.com");
        }

        //click or get focus for optional ones will make it easier for user to modify

        private void TxbxMedInfoNotes_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbxMedInfoNotes.Text))
            {
                txbxMedInfoNotes.Text="optional";
            }
        }

        private void txbxMedInfoNotes_Click(object sender, EventArgs e)
        {
            if (txbxMedInfoNotes.Text=="optional"|string.IsNullOrWhiteSpace(txbxMedInfoNotes.Text))
            {
                txbxMedInfoNotes.Text=null;
            }
        }

    }
}
