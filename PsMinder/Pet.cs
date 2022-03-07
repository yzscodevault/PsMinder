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
using System.IO;
using System.Drawing.Imaging;

namespace PsMinder
{
    public partial class Pet : Form
    {
        PetRecords petRecords;
        string ageFormatCheckString = @"\b([01]?[0-9][0-9]?|2[0-4][0-9]|25[0-5])";//0-255
        string weightFormatCheckString = @"^\d+(\.?\d+)?$";
        byte petAge=0;
        double petWeight=0;
        bool nonOptionalAreValid = false;

        public Pet()
        {
            InitializeComponent();
        }

        public void checknonOptionalsNullorOverflowandDatetimeInput()//if input is invalid, submit or update would not go through, error message will be shown, focus will be gained, data will be assigned as "0" or today.date
        {
            if (!string.IsNullOrWhiteSpace(txbxPetInfoPetName.Text))
            {
                if (Regex.IsMatch(txbxPetInfoPetAge.Text, ageFormatCheckString))
                {
                    try { petAge = Convert.ToByte(txbxPetInfoPetAge.Text); }
                    catch (OverflowException ex)
                    {
                        MessageBox.Show(ex.Message, "Input number for pet age is too large!");
                        txbxPetInfoPetAge.Text="0";
                        txbxPetInfoPetAge.Focus();
                    }
                    if (Regex.IsMatch(txbxPetInfoPetWeight.Text, weightFormatCheckString))
                    {
                        try { petWeight = Convert.ToDouble(txbxPetInfoPetWeight.Text); }
                        catch (OverflowException ex)
                        {
                            MessageBox.Show(ex.Message, "Input number for pet weight is too large!");
                            txbxPetInfoPetWeight.Text="0";
                            txbxPetInfoPetWeight.Focus();
                        }
                        if (!string.IsNullOrWhiteSpace(txbxPetInfoPetColor.Text))
                        {
                            if (!string.IsNullOrWhiteSpace(txbxPetInfoPetSpecies.Text))
                            {
                                if (!string.IsNullOrWhiteSpace(txbxPetInfoPetBreed.Text)) { nonOptionalAreValid=true; }
                                else
                                {
                                    MessageBox.Show("Pet Breed cannot be empty or white space!", "Pet Breed Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txbxPetInfoPetBreed.Text="Unspecified Breed";
                                    txbxPetInfoPetBreed.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Pet Species cannot be empty or white space!", "Pet Species Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txbxPetInfoPetSpecies.Text="Unspecified Species";
                                txbxPetInfoPetSpecies.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Pet Color cannot be empty or white space!", "Pet Name Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txbxPetInfoPetColor.Text="No Name";
                            txbxPetInfoPetColor.Focus();
                        }
                    } 
                    else
                    {
                        MessageBox.Show("Weight data should be double format!", "Weight Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txbxPetInfoPetWeight.Text="0";
                        txbxPetInfoPetWeight.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Age data should be between 0 and 255!", "Age Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txbxPetInfoPetAge.Text="0";
                    txbxPetInfoPetAge.Focus();
                }
            }
            else
            {
                MessageBox.Show("Pet Name cannot be empty or white space!", "Pet Name Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbxPetInfoPetName.Text="No Name";
                txbxPetInfoPetName.Focus();
            }
        }

        private void Pet_Load(object sender, EventArgs e)
        {
            petRecords=new PetRecords();
            dataGridPetInfo.DataSource=petRecords.GetAllPetRecords();
            dataGridPetInfo.Columns[11].Visible=false;
            dataGridPetInfo.Columns[12].Visible=false;
            grpbxPetPsMinder.Visible=true;
            grpbxPetInfo.Visible=true;
            grpbxPetAddorUpdate.Visible=false;
            btnPetSubmitNew.Enabled=false;
            btnPetUpdateRecord.Enabled=false;
            //dataGridPetInfo.Columns. here and refresh function
            /*for (int i = 0; i < dataGridPetInfo.Columns.Count; i++)
                if (dataGridPetInfo.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridPetInfo.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    break;
                }*/
        }
        public void ClearAllPetInfo()
        {
            pictureBoxPetImage.Image=null;
            txbxPetInfoPetID.Clear();
            txbxPetInfoPetName.Clear();
            txbxPetInfoPetAge.Clear();
            txbxPetInfoPetWeight.Clear();
            txbxPetInfoPetColor.Clear();
            txbxPetInfoPetSpecies.Clear();
            txbxPetInfoPetBreed.Clear();
            txbxPetInfoOwnerName.Clear();
            txbxPetInfoOwnerName.Text="optional";
            txbxPetInfoOwnerPhone.Clear();
            txbxPetInfoOwnerPhone.Text="optional";
            txbxPetInfoNotes.Clear();
            txbxPetInfoNotes.Text="optional";
            //txbxPetInfoNotes.Font.Italic=true;
        }
        public void RefreshPetGridViewandClearAll()
        {
            dataGridPetInfo.DataSource=null;
            dataGridPetInfo.DataSource=petRecords.GetAllPetRecords();
            dataGridPetInfo.Columns[11].Visible=false;
            dataGridPetInfo.Columns[12].Visible=false;
            ClearAllPetInfo();
        }
                

        private void btnPetAddNew_Click(object sender, EventArgs e)
        {
            grpbxPetAddorUpdate.Visible=true;
            RefreshPetGridViewandClearAll();
            txbxPetInfoPetID.ReadOnly=true;
            txbxPetInfoPetID.Text=Convert.ToString(petRecords.GetMaxPetID()+1);
            txbxPetInfoPetID.Enabled=false;
            btnPetSubmitNew.Enabled=true;
            btnPetUpdateRecord.Enabled=false;
            /*if (txbxPetInfoOwnerName.Text!=null|txbxPetInfoOwnerName.Text!="optional") { txbxPetInfoOwnerName.Text="optional"; }
            if (txbxPetInfoOwnerPhone.Text!=null|txbxPetInfoOwnerPhone.Text!="optional") { txbxPetInfoOwnerPhone.Text="optional"; }
            if (txbxPetInfoNotes.Text!=null|txbxPetInfoNotes.Text!="optional") { txbxPetInfoNotes.Text="optional"; }*/
        }

        private void btnPetCancel_Click(object sender, EventArgs e)
        {
            ClearAllPetInfo();
        }


        private void btnPetUploadPetImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog petOpenFileDialog = new OpenFileDialog();
            petOpenFileDialog.Filter="Image Files(*.jpg; *.jpeg; *.png; *.bmp; *ico; *tiff)|*.jpg; *.jpeg; *.png; *.bmp; *ico; *tiff";//first half is for displaying, second half is to check actual filetype
            petOpenFileDialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            petOpenFileDialog.ShowDialog();
            if (petOpenFileDialog.FileName != string.Empty/*&&petOpenFileDialog.ShowDialog() == DialogResult.OK*/) // if user clicked OK
            {
                pictureBoxPetImage.SizeMode=PictureBoxSizeMode.StretchImage;
                pictureBoxPetImage.SizeMode=PictureBoxSizeMode.CenterImage;
                pictureBoxPetImage.Image=new Bitmap(petOpenFileDialog.FileName);//both sides are image datatype
                //String path = petOpenFileDialog.FileName; // get name of file
            }
        }

        private void btnPetSubmitNew_Click(object sender, EventArgs e)
        {
            PetTable newPetRecordtoSubmit=new PetTable();
            MemoryStream memoryStream = new MemoryStream();//memoryStream read all as bytes
            pictureBoxPetImage.Image.Save(memoryStream, ImageFormat.Jpeg);//convert image to a memoryStream, bytes in memory
            byte[] photo = new byte[memoryStream.Length];
            memoryStream.Position=0;//start with position 0
            memoryStream.Read(photo, 0, photo.Length);//read from memoryStream(contains the image as bytes) and write it to a buffer(photo, the byte[]) is to convert image to byte array
            checknonOptionalsNullorOverflowandDatetimeInput();
            if (nonOptionalAreValid)
            {
                newPetRecordtoSubmit.PetID=Convert.ToInt32(txbxPetInfoPetID.Text);
                newPetRecordtoSubmit.PetName=txbxPetInfoPetName.Text;
                newPetRecordtoSubmit.PetImage=photo;
                newPetRecordtoSubmit.PetAge=petAge;
                newPetRecordtoSubmit.PetWeight=petWeight;
                newPetRecordtoSubmit.PetColor=txbxPetInfoPetColor.Text;
                newPetRecordtoSubmit.PetSpecies=txbxPetInfoPetSpecies.Text;
                newPetRecordtoSubmit.PetBreed=txbxPetInfoPetBreed.Text;
                if (txbxPetInfoNotes.Text=="optional"|string.IsNullOrWhiteSpace(txbxPetInfoNotes.Text)) { newPetRecordtoSubmit.Note=null; }
                else {newPetRecordtoSubmit.Note=txbxPetInfoNotes.Text; }
                if (txbxPetInfoOwnerName.Text=="optional"|string.IsNullOrWhiteSpace(txbxPetInfoOwnerName.Text)) { newPetRecordtoSubmit.Owner=null; }
                else { newPetRecordtoSubmit.Owner=txbxPetInfoOwnerName.Text; }
                if (txbxPetInfoOwnerPhone.Text=="optional"|string.IsNullOrWhiteSpace(txbxPetInfoOwnerPhone.Text)) { newPetRecordtoSubmit.OwnerContact=null; }
                else{ newPetRecordtoSubmit.OwnerContact=txbxPetInfoOwnerPhone.Text; }
                petRecords.AddPetRecord(newPetRecordtoSubmit);
                btnPetSubmitNew.Enabled=false;
                RefreshPetGridViewandClearAll();
            }
            else { MessageBox.Show("not submitting"); }
        }

        private void btnPetSelectToUpdate_Click(object sender, EventArgs e)
        {
            PetTable selectedPetRecord = new PetTable();
            int selectedPetID = Convert.ToInt32(dataGridPetInfo.CurrentRow.Cells[0].Value);
            selectedPetRecord=petRecords.FindPet(selectedPetID);
            //pictureBoxPetImage.Image=Image.FromStream(new MemoryStream(selectedPetRecord.PetImage));
            txbxPetInfoPetID.Text=selectedPetRecord.PetID.ToString();
            txbxPetInfoPetID.ReadOnly=true;
            txbxPetInfoPetID.Enabled=false;
            grpbxPetAddorUpdate.Visible=true;
            txbxPetInfoPetName.Text=selectedPetRecord.PetName;
            txbxPetInfoPetAge.Text=selectedPetRecord.PetAge.ToString();
            txbxPetInfoPetWeight.Text=selectedPetRecord.PetWeight.ToString();
            txbxPetInfoPetColor.Text=selectedPetRecord.PetColor;
            txbxPetInfoPetSpecies.Text=selectedPetRecord.PetSpecies;
            txbxPetInfoPetBreed.Text=selectedPetRecord.PetBreed;
            txbxPetInfoOwnerName.Text=selectedPetRecord.Owner;
            txbxPetInfoOwnerPhone.Text=selectedPetRecord.OwnerContact;
            txbxPetInfoNotes.Text=selectedPetRecord.Note;
            btnPetUpdateRecord.Enabled=true;
            if (txbxPetInfoOwnerName==null|string.IsNullOrWhiteSpace(txbxPetInfoOwnerName.Text)) { txbxPetInfoOwnerName.Text="optional"; }
            if (txbxPetInfoOwnerPhone==null|string.IsNullOrWhiteSpace(txbxPetInfoOwnerPhone.Text)) { txbxPetInfoOwnerPhone.Text="optional"; }
            if (txbxPetInfoNotes==null|string.IsNullOrWhiteSpace(txbxPetInfoNotes.Text)) { txbxPetInfoNotes.Text="optional"; }
        }
        private void btnPetUpdateRecord_Click(object sender, EventArgs e)
        {
            MemoryStream memoryStream = new MemoryStream();//memoryStream read all as bytes
            pictureBoxPetImage.Image.Save(memoryStream, ImageFormat.Jpeg);
            byte[] photo = new byte[memoryStream.Length];
            memoryStream.Position=0;//convert image to byte array
            memoryStream.Read(photo, 0, photo.Length);
            PetTable petRecordtoUpdate = new PetTable();
            petRecordtoUpdate.PetID=Int32.Parse(txbxPetInfoPetID.Text);
            txbxPetInfoPetID.ReadOnly=true;txbxPetInfoPetID.Enabled=false;
            checknonOptionalsNullorOverflowandDatetimeInput();
            if (nonOptionalAreValid)
            {

                petRecordtoUpdate.PetImage=photo;
                petRecordtoUpdate.PetName=txbxPetInfoPetName.Text;
                petRecordtoUpdate.PetAge=petAge;
                petRecordtoUpdate.PetWeight=petWeight;
                petRecordtoUpdate.PetColor=txbxPetInfoPetColor.Text;
                petRecordtoUpdate.PetSpecies=txbxPetInfoPetSpecies.Text;
                petRecordtoUpdate.PetBreed=txbxPetInfoPetBreed.Text;
                if (txbxPetInfoNotes.Text=="optional"|string.IsNullOrWhiteSpace(txbxPetInfoNotes.Text)) { petRecordtoUpdate.Note=null; txbxPetInfoNotes.Text="optional"; }
                else { petRecordtoUpdate.Note=txbxPetInfoNotes.Text; }
                if (txbxPetInfoOwnerName.Text=="optional"|string.IsNullOrWhiteSpace(txbxPetInfoOwnerName.Text)) { petRecordtoUpdate.Owner=null; txbxPetInfoOwnerName.Text="optional"; }
                else { petRecordtoUpdate.Owner=txbxPetInfoOwnerName.Text; }
                if (txbxPetInfoOwnerPhone.Text=="optional"|string.IsNullOrWhiteSpace(txbxPetInfoOwnerPhone.Text)) { petRecordtoUpdate.OwnerContact=null; txbxPetInfoOwnerPhone.Text="optional"; }
                else { petRecordtoUpdate.OwnerContact=txbxPetInfoOwnerPhone.Text; }

                //petRecordtoUpdate.PetImage=null;


                petRecords.UpdatePetRecord(petRecordtoUpdate.PetID, petRecordtoUpdate);
                RefreshPetGridViewandClearAll();
                btnPetUpdateRecord.Enabled=false;
            }
        }

        private void btnPetDelete_Click(object sender, EventArgs e)
        {
            int selectedPetID = Convert.ToInt32(dataGridPetInfo.CurrentRow.Cells[0].Value);
            DialogResult dialogResult = MessageBox.Show("Are you sure to delete this record?", "Confirm to delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult==DialogResult.Yes)
            {
                petRecords.DeletePetRecord(petRecords.FindPet(selectedPetID));
                RefreshPetGridViewandClearAll();
                MessageBox.Show("Record deleted");
            }
        }

        private void btnPetRefreshData_Click(object sender, EventArgs e)
        {
            RefreshPetGridViewandClearAll();
        }

        private void lklblPetReminder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible=false;
            Reminder reminderForm = new Reminder();
            reminderForm.Visible=true;
        }

        private void lklblPetPrescriptionInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible=false;
            MainPage prescriptionForm = new MainPage();
            prescriptionForm.Visible=true;
        }

        private void lklblPetMedicineInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible=false;
            Medicine medicineForm = new Medicine();
            medicineForm.Visible=true;
        }

        private void lklblPetSignout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible=false;
            LoginPage loginPageForm = new LoginPage();
            loginPageForm.Visible=true;
        }

        private void btnPetExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to exit?", "Exiting Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult==DialogResult.Yes)
            {
                MessageBox.Show("See you next time and have great day!", "Thank you for using PsMinder");
                Application.Exit();
            }
        }

        private void lklblPetLinkedIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/yang-zhang-1318a6228/");
        }

        private void lklblPetEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Mailto:zhangmssa@outlook.com");
        }

        private void txbxPetInfoOwnerName_Click(object sender, EventArgs e)
        {
            if (txbxPetInfoOwnerName.Text=="optional"|string.IsNullOrWhiteSpace(txbxPetInfoOwnerName.Text))
            {
                txbxPetInfoOwnerName.Text=null;
            }
        }

        private void txbxPetInfoOwnerPhone_Click(object sender, EventArgs e)
        {
            if (txbxPetInfoOwnerPhone.Text=="optional"|string.IsNullOrWhiteSpace(txbxPetInfoOwnerPhone.Text))
            {
                txbxPetInfoOwnerPhone.Text=null;
            }
        }

        private void txbxPetInfoNotes_Click(object sender, EventArgs e)
        {
            if (txbxPetInfoNotes.Text=="optional"|string.IsNullOrWhiteSpace(txbxPetInfoNotes.Text))
            {
                txbxPetInfoNotes.Text=null;
            }
        }

        
    }
}
