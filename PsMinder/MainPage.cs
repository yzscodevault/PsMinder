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
using System.Data.SqlClient;

//how to clear cmbx
//how to change font

namespace PsMinder
{
    public partial class MainPage : Form
    {
        #region CRUD
        PrescriptionTable prescriptionTable;
        PrescriptionRecords prescriptionRecords;
        PetTable petTable;
        PetRecords petRecords;
        MedicineTable medicineTable;
        MedicineRecords medicineRecords;
        string dosageFormatCheckString = @"^\d+(\.?\d+)?$";
        decimal dosage=0;
        bool nonOptionalAreValid = false;

        public MainPage()
        {
            InitializeComponent();
        }

        public void checknonOptionalsNullorOverflowandDatetimeInput()//if input is invalid, submit or update would not go through, error message will be shown, focus will be gained, data will be assigned as "0" or today.date
        {//check prescription name, dosage format/boundary, unit select/not, start/end date value compare
         //(prescription auto-generate, pet & med info are auto checked when tx/focus change)
            if (!string.IsNullOrWhiteSpace(txbxMainPrescriptionName.Text))
            {
                if (Regex.IsMatch(txbxMainDosage.Text, dosageFormatCheckString) /*| string.IsNullOrWhiteSpace(txbxMainDosage.Text)*/)
                {
                    try { dosage=Convert.ToDecimal(txbxMainDosage.Text); }// current stock is in decimal format, now check the boundary
                    catch (OverflowException ofex) { txbxMainDosage.Text="0"; txbxMainDosage.Focus(); MessageBox.Show(ofex.Message); }
                    if (cmbxMainUnit.SelectedIndex!=-1)
                    {
                        if (dateTimePickerMainStartDate.Value.Date<=dateTimePickerMainEndDate.Value.Date)
                        {
                            if (dateTimePickerMainEndDate.Value>=DateTime.Today.Date) { nonOptionalAreValid = true; }
                            else
                            {
                                MessageBox.Show("End Date should be today or later!", "End Date Selection Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dateTimePickerMainEndDate.Value=DateTime.Today.Date;
                                dateTimePickerMainEndDate.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("End Date should be same with or later than Start Date!", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dateTimePickerMainStartDate.Value=dateTimePickerMainEndDate.Value;
                            dateTimePickerMainEndDate.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please make a selection for Unit!", "Unit not Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbxMainUnit.SelectedIndex=0;
                        cmbxMainUnit.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Dosage data is decimal and cannot be empty or white space!", "Dosage Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbxMainDosage.Text="0";
                    txbxMainDosage.Focus();
                }
            }
            else
            {
                MessageBox.Show("Prescription Name cannot be empty or white space!", "Prescription Name Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbxMainPrescriptionName.Text="No Prescription Name Entered";
                txbxMainPrescriptionName.Focus();
            }
        }
            
        public void ResetAllPrescriptionInputArea()
        {
            txbxMainPrescriptionID.Clear();
            txbxMainPrescriptionName.Clear();
            txbxMainPetID.Clear();
            txbxMainPetName.Clear();
            txbxMainMedicineID.Clear();
            txbxMainMedicineName.Clear();
            txbxMainDosage.Clear();
            cmbxMainUnit.Items.Clear();
            foreach (UnitTable unitTableRecord in prescriptionRecords.GetUnitTablesAllRecords())
            {
                cmbxMainUnit.Items.Add(unitTableRecord.Unit);
            }
            cmbxMainUnit.SelectedIndex = -1;
            cmbxMainUnit.ResetText();
            dateTimePickerMainStartDate.ResetText();
            dateTimePickerMainEndDate.ResetText();
            txbxMainVeterinaryName.Clear();
            txbxMainVeterinaryName.Text="optional";
            txbxMainVeterinaryPhone.Clear();
            txbxMainVeterinaryPhone.Text="optional";
            txbxMainNotes.Clear();
            txbxMainNotes.Text="optional";
        }

        public void RefreshPrescriptionDataGridView()
        {
            dataGridMainPrescriptionInfo.DataSource=null;
            dataGridMainPrescriptionInfo.DataSource = prescriptionRecords.GetAllPrescriptionTableRecords();
            dataGridMainPrescriptionInfo.Columns[7].Visible=false;
            dataGridMainPrescriptionInfo.Columns[14].Visible=false;
            dataGridMainPrescriptionInfo.Columns[15].Visible=false;
            dataGridMainPrescriptionInfo.Columns[16].Visible=false;
            dataGridMainPrescriptionInfo.Columns[17].Visible=false;
        }

        private void btnMainCancel_Click(object sender, EventArgs e)
        {
            RefreshPrescriptionDataGridView(); ResetAllPrescriptionInputArea();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            prescriptionRecords = new PrescriptionRecords();
            dataGridMainPrescriptionInfo.DataSource = prescriptionRecords.GetAllPrescriptionTableRecords();
            dataGridMainPrescriptionInfo.Columns[7].Visible=false;
            dataGridMainPrescriptionInfo.Columns[14].Visible=false;
            dataGridMainPrescriptionInfo.Columns[15].Visible=false;
            dataGridMainPrescriptionInfo.Columns[16].Visible=false;
            dataGridMainPrescriptionInfo.Columns[17].Visible=false;
            dataGridMainPrescriptionInfo.Visible=true;
            btnMainSubmitNew.Enabled = false;//disable this button until after add new btn is clicked
            btnMainUpdateRecord.Enabled = false;//disable this button until after add new btn is clicked
            grpbxMainPsMinder.Visible=true;
            grpbxMainPrescriptionInfo.Visible = true;
            grpbxMainAddorUpdate.Visible=false;
            txbxMainPetName.Enabled=false;
            txbxMainPetName.ReadOnly=true;
            txbxMainMedicineName.Enabled=false;
            txbxMainMedicineName.ReadOnly=true;
        }

        private void btnMainAddNew_Click(object sender, EventArgs e)
        {
            grpbxMainAddorUpdate.Visible = true;
            btnMainUpdateRecord.Enabled=false;
            RefreshPrescriptionDataGridView(); ResetAllPrescriptionInputArea();
            txbxMainPrescriptionID.Text = Convert.ToString(prescriptionRecords.GetMaxPrescriptionID() + 1);//auto generate the PrescriptionID for this new prescription record
            txbxMainPrescriptionID.ReadOnly=true; txbxMainPrescriptionID.Enabled=false;//make the newly generated prescription ID read only to prevent user from tampering
            btnMainSubmitNew.Enabled = true;
        }

        private void txbxMainPetID_TextChanged(object sender, EventArgs e)
        {
            txbxMainPetID.LostFocus += TxbxMainPetID_LostFocus;
        }

        private void TxbxMainPetID_LostFocus(object sender, EventArgs e)
        {
            petRecords=new PetRecords();
            petTable=petRecords.FindPet(Convert.ToInt32(txbxMainPetID.Text)); // find pet //
            if (petTable.PetName!=null)
            {
                txbxMainPetName.Text=petTable.PetName;
                txbxMainMedicineID.Focus();
            }
            else
            {
                MessageBox.Show("Please first add NEW Pet using the \"PetInfo\" tab at top of this page", "No Exsiting Pet Record Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // then here add logic to verify if true return the pet name that is associate with the valid pet id
        }

        private void txbxMainMedicineID_TextChanged(object sender, EventArgs e)
        {
            txbxMainMedicineID.LostFocus+=TxbxMainMedicineID_LostFocus;
        }

        private void TxbxMainMedicineID_LostFocus(object sender, EventArgs e)
        {
            medicineRecords=new MedicineRecords();
            medicineTable=medicineRecords.FindMedicineRecord(Convert.ToInt32(txbxMainMedicineID.Text));// find medicine //
            if (medicineTable!=null)
            {
                txbxMainMedicineName.Text=medicineTable.MedicineName;
                txbxMainDosage.Focus();
            }
            else
            {
                MessageBox.Show("Please first add NEW Medicine using the \"Medicine Info and Restock\" tab at top of this page", "No Exsiting Pet Record Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMainSubmitNew_Click(object sender, EventArgs e)
        {
            prescriptionTable=new PrescriptionTable();
            prescriptionTable.PrescriptionID=Convert.ToInt32(txbxMainPrescriptionID.Text);
            checknonOptionalsNullorOverflowandDatetimeInput();
            if (nonOptionalAreValid)
            {
                prescriptionTable.PrescriptionName=txbxMainPrescriptionName.Text;
                prescriptionTable.PetID=Convert.ToInt32(txbxMainPetID.Text);
                prescriptionTable.PetName=txbxMainPetName.Text;
                prescriptionTable.MedicineID=Convert.ToInt32(txbxMainMedicineID.Text);
                prescriptionTable.MedicineName=txbxMainMedicineName.Text;
                prescriptionTable.DosagePerDay=Decimal.Round(dosage, 6);
                prescriptionTable.UnitID=cmbxMainUnit.SelectedIndex+1;
                prescriptionTable.Unit=cmbxMainUnit.SelectedItem.ToString();
                prescriptionTable.StartDate=dateTimePickerMainStartDate.Value.Date;
                prescriptionTable.EndDate=dateTimePickerMainEndDate.Value.Date;
                //prescriptionOptionalTextHandler();
                if (txbxMainNotes.Text=="optional"|string.IsNullOrWhiteSpace(txbxMainNotes.Text)) { prescriptionTable.Notes=null; }
                else { prescriptionTable.Notes=txbxMainNotes.Text; }
                if (txbxMainVeterinaryPhone.Text=="optional"|string.IsNullOrWhiteSpace(txbxMainVeterinaryPhone.Text)) { prescriptionTable.VeterinaryPhone=null; }
                else { prescriptionTable.VeterinaryPhone=txbxMainVeterinaryPhone.Text; }
                if (txbxMainVeterinaryName.Text=="optional"|string.IsNullOrWhiteSpace(txbxMainVeterinaryName.Text)) { prescriptionTable.VeterinaryName=null; }
                else { prescriptionTable.VeterinaryName=txbxMainVeterinaryName.Text; }
                prescriptionRecords.AddPrescription(prescriptionTable);
                btnMainSubmitNew.Enabled=false;
                RefreshPrescriptionDataGridView(); ResetAllPrescriptionInputArea();//or use refresh btn
            }
        }

        private void btnMainSelectToUpdate_Click(object sender, EventArgs e)
        {
            ResetAllPrescriptionInputArea();
            grpbxMainAddorUpdate.Visible = true;
            btnMainSubmitNew.Enabled=false;
            PrescriptionTable selectedPrscrcrd = prescriptionRecords.FindPrescription(Convert.ToInt32(dataGridMainPrescriptionInfo.CurrentRow.Cells[0].Value));
            //dateTimePickerMainEndDate.Value=new DateTime(3022, 12, 31);
            txbxMainPrescriptionID.ReadOnly=true;
            txbxMainPrescriptionID.Text=Convert.ToString(selectedPrscrcrd.PrescriptionID);
            txbxMainPrescriptionID.Enabled=false;
            txbxMainPrescriptionName.Text=selectedPrscrcrd.PrescriptionName;
            txbxMainPetID.Text=Convert.ToString(selectedPrscrcrd.PetID);
            txbxMainPetName.Text=selectedPrscrcrd.PetName;
            txbxMainMedicineID.Text=Convert.ToString(selectedPrscrcrd.MedicineID);
            txbxMainMedicineName.Text=selectedPrscrcrd.MedicineName;
            txbxMainDosage.Text=Convert.ToString(selectedPrscrcrd.DosagePerDay);
            foreach (UnitTable unitTable in prescriptionRecords.GetUnitTablesAllRecords())
            {
                if (unitTable.UnitID==selectedPrscrcrd.UnitID)
                {
                    cmbxMainUnit.SelectedItem=unitTable.Unit;
                }
            }
            dateTimePickerMainStartDate.Value=selectedPrscrcrd.StartDate;
            dateTimePickerMainEndDate.Value=selectedPrscrcrd.EndDate;
            txbxMainVeterinaryName.Text=selectedPrscrcrd.VeterinaryName;
            txbxMainVeterinaryPhone.Text=selectedPrscrcrd.VeterinaryPhone;
            txbxMainNotes.Text=selectedPrscrcrd.Notes;
            if (string.IsNullOrWhiteSpace(txbxMainVeterinaryName.Text)) { txbxMainVeterinaryName.Text="optional"; }
            if (string.IsNullOrWhiteSpace(txbxMainVeterinaryPhone.Text)) { txbxMainVeterinaryPhone.Text="optional"; }
            if (string.IsNullOrWhiteSpace(txbxMainNotes.Text)) { txbxMainNotes.Text="optional"; }
            btnMainUpdateRecord.Enabled=true;
        }

        private void btnMainUpdateRecord_Click(object sender, EventArgs e)
        {
            int newPrscrcrdID = Convert.ToInt32(txbxMainPrescriptionID.Text);
            PrescriptionTable prscRcrdtoUpdate=prescriptionRecords.FindPrescription(newPrscrcrdID);
            txbxMainPrescriptionID.ReadOnly=true;txbxMainPrescriptionID.Enabled=false;
            checknonOptionalsNullorOverflowandDatetimeInput();
            if (nonOptionalAreValid)
            {
                prscRcrdtoUpdate.PrescriptionName=txbxMainPrescriptionName.Text;
                prscRcrdtoUpdate.PetID=Convert.ToInt32(txbxMainPetID.Text);
                prscRcrdtoUpdate.PetName=txbxMainPetName.Text;
                prscRcrdtoUpdate.MedicineID=Convert.ToInt32(txbxMainMedicineID.Text);
                prscRcrdtoUpdate.MedicineName=txbxMainMedicineName.Text;
                prscRcrdtoUpdate.DosagePerDay=Decimal.Round(Convert.ToDecimal(txbxMainDosage.Text), 6);
                prscRcrdtoUpdate.UnitID=Convert.ToInt32(cmbxMainUnit.SelectedIndex+1);//cmbxMainUnit.SelectedIndex+1;
                prscRcrdtoUpdate.Unit=cmbxMainUnit.SelectedItem.ToString();
                prscRcrdtoUpdate.StartDate=dateTimePickerMainStartDate.Value.Date;
                prscRcrdtoUpdate.EndDate=dateTimePickerMainEndDate.Value.Date;
                //prescriptionOptionalTextHandler();
                if (txbxMainNotes.Text=="optional"|string.IsNullOrWhiteSpace(txbxMainNotes.Text)) { prscRcrdtoUpdate.Notes=null; }
                else { prscRcrdtoUpdate.Notes=txbxMainNotes.Text; }
                if (txbxMainVeterinaryPhone.Text=="optional"|string.IsNullOrWhiteSpace(txbxMainVeterinaryPhone.Text)) { prscRcrdtoUpdate.VeterinaryPhone=null; }
                else { prscRcrdtoUpdate.VeterinaryPhone=txbxMainVeterinaryPhone.Text; }
                if (txbxMainVeterinaryName.Text=="optional"|string.IsNullOrWhiteSpace(txbxMainVeterinaryName.Text)) { prscRcrdtoUpdate.VeterinaryName=null; }
                else { prscRcrdtoUpdate.VeterinaryName=txbxMainVeterinaryName.Text; }
                prescriptionRecords.UpdatePrescription(newPrscrcrdID, prscRcrdtoUpdate);
                btnMainUpdateRecord.Enabled=false;
                RefreshPrescriptionDataGridView(); ResetAllPrescriptionInputArea();//or use refresh btn
            }
        }

        private void btnMainDelete_Click(object sender, EventArgs e)
        {
            btnMainSubmitNew.Enabled=false; btnMainUpdateRecord.Enabled=false;
            int delPrscrcrdID =Convert.ToInt32(dataGridMainPrescriptionInfo.CurrentRow.Cells[0].Value);
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete this record?", "Confirm to delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult==DialogResult.Yes)
            {
                prescriptionRecords.DeletePrescription(prescriptionRecords.FindPrescription(delPrscrcrdID));
                RefreshPrescriptionDataGridView();
                MessageBox.Show("Record deleted");
            }
        }

        private void btnMainRefreshData_Click(object sender, EventArgs e)
        {
            btnMainSubmitNew.Enabled=false; btnMainUpdateRecord.Enabled=false;
            RefreshPrescriptionDataGridView(); ResetAllPrescriptionInputArea();
        }

        private void lklblMainReminder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reminder reminder = new Reminder();
            reminder.Visible=true;
            this.Visible=false;
        }

        private void lklblMainPrescriptionInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshPrescriptionDataGridView(); ResetAllPrescriptionInputArea();
        }

        private void lklblMainMedicineInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Medicine medicineInfoandRestock = new Medicine();
            medicineInfoandRestock.Visible=true;
            this.Visible=false;
        }

        private void lklblMainPetInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Pet petinfo = new Pet();
            petinfo.Visible=true;
            this.Visible=false;
        }

        private void lklblMainSignout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Visible=true;
            this.Visible=false;
        }

        private void btnMainExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to exit?", "Exiting Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult==DialogResult.Yes)
            {
                MessageBox.Show("See you next time and have great day!", "Thank you for using PsMinder");
                Application.Exit();
            }
        }

        private void lklblMainLinkedIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/yang-zhang-1318a6228/");
        }

        private void lklblMainEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Mailto:zhangmssa@outlook.com");
        }

        //click or get focus for optional ones will make it easier for user to modify
        private void TxbxMainVeterinaryPhone_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbxMainVeterinaryPhone.Text))
            {
                txbxMainVeterinaryPhone.Text="optional";
            }
        }

        private void TxbxMainVeterinaryName_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbxMainVeterinaryName.Text))
            {
                txbxMainVeterinaryName.Text="optional";
            }
        }

        private void TxbxMainNotes_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbxMainNotes.Text))
            {
                txbxMainNotes.Text="optional";
            }
        }

        private void txbxMainVeterinaryName_Click(object sender, EventArgs e)
        {
            if (txbxMainVeterinaryName.Text=="optional"|string.IsNullOrWhiteSpace(txbxMainVeterinaryName.Text))
            {
                txbxMainVeterinaryName.Text=null;
            }
        }

        private void txbxMainVeterinaryPhone_Click(object sender, EventArgs e)
        {
            if (txbxMainVeterinaryPhone.Text=="optional"|string.IsNullOrWhiteSpace(txbxMainVeterinaryPhone.Text))
            {
                txbxMainVeterinaryPhone.Text=null;
            }
        }

        private void txbxMainNotes_Click(object sender, EventArgs e)
        {
            if (txbxMainNotes.Text=="optional"|string.IsNullOrWhiteSpace(txbxMainNotes.Text))
            {
                txbxMainNotes.Text=null;
            }
        }
        #endregion


        //To be continued for SQL, join static tbls
        public void generatedailyconsumptiontoMedTbl()
        {
            PsMinderEntities psMinderEntities = new PsMinderEntities();


        }

        
    }
}
