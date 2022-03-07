using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsMinder
{
    interface PrescriptionCrud//Prescription CRUD
    {
        ICollection<PrescriptionTable> GetAllPrescriptionTableRecords();//return records of PrescriptionTable in PrescriptionTable datatype
        void AddPrescription(PrescriptionTable anewPrescriptionRecordtoadd);//get a prescription record(instance) from input, add to the list, and then reflect
        void DeletePrescription(PrescriptionTable aPrescriptionRecord);//locate a prescription record(instance), remove it from the list, then reflect
        void UpdatePrescription(int prescriptionID, PrescriptionTable anewPrescriptionRecordtoupdate);
        PrescriptionTable FindPrescription(int prescriptionID);//using the input as PrescriptionID to locate and return a prescription record(instance) 
        //MedicineTable FindMedicine(int medicineID);//using the input as PrescriptionID to locate and return a prescription record(instance) 
        int GetMaxPrescriptionID();
        ICollection<UnitTable> GetUnitTablesAllRecords();//return the records of UnitTable in UnitTable datatype
    }

    public class PrescriptionRecords : PrescriptionCrud //inherit from interface of PrescriptionCrud
    {
       public static PsMinderEntities PsMinderEntities = new PsMinderEntities();//initialize database adoEDM entities to interact with db tbls
        public ICollection<PrescriptionTable> GetAllPrescriptionTableRecords()
        {
            return PsMinderEntities.PrescriptionTables.ToList();//return databasename.tablename to a list, for datagridview to display, in PrescriptionTable datatype
        }

        public PrescriptionTable FindPrescription(int prescriptionID)
        {
            //var foundPrescriptionRecord = PsMinderEntities.PrescriptionTables.Find(prescriptionID);//1st way to locate a record from prescriptiontable by using passedin parameter
            var foundPrescriptionRecord = PsMinderEntities.PrescriptionTables.First(prstblrcrd => prstblrcrd.PrescriptionID == prescriptionID);//2nd way
            if (foundPrescriptionRecord != null)//check if the provided prescritionID is valid
            {
                return foundPrescriptionRecord;//if the prescriptionID is valid, look for record based on the provided ID and return the whole row/record
            }
            else
            {
                return null;//if the ID not matching any of the records in Prescription table, then return null
            }
        }

        public void AddPrescription(PrescriptionTable aPrescriptionRecordtoAdd)
        {
            PsMinderEntities.PrescriptionTables.Add(aPrescriptionRecordtoAdd);//add the provided/found Prescription record to database, but need dbEntities.SaveChanges(); function to achieve
            PsMinderEntities.SaveChanges();//save changes to database
        }

        public void DeletePrescription(PrescriptionTable aPrescriptionRecordtoDel)
        {
            PsMinderEntities.PrescriptionTables.Remove(aPrescriptionRecordtoDel);//first, need user to click at a row/cell to select that row/record, then remove the provided/found Prescription record from database, but need dbEntities.SaveChanges(); function to achieve
            PsMinderEntities.SaveChanges();//save changes to database
        }


        public void UpdatePrescription(int prescriptionID, PrescriptionTable aPrescriptionRecordfmIpt)
        {
            PrescriptionTable updatedPrescription = FindPrescription(prescriptionID);//find the record by provided prescription ID
            //following is to assign the data from the input to the affected/targeted record
            updatedPrescription.PrescriptionID = aPrescriptionRecordfmIpt.PrescriptionID;
            updatedPrescription.PrescriptionName = aPrescriptionRecordfmIpt.PrescriptionName;
            updatedPrescription.PetID = aPrescriptionRecordfmIpt.PetID;
            updatedPrescription.PetName = aPrescriptionRecordfmIpt.PetName;
            updatedPrescription.MedicineID = aPrescriptionRecordfmIpt.MedicineID;
            updatedPrescription.MedicineName = aPrescriptionRecordfmIpt.MedicineName;
            updatedPrescription.DosagePerDay = aPrescriptionRecordfmIpt.DosagePerDay;
            updatedPrescription.UnitID = aPrescriptionRecordfmIpt.UnitID;
            updatedPrescription.Unit = aPrescriptionRecordfmIpt.Unit;
            updatedPrescription.StartDate = aPrescriptionRecordfmIpt.StartDate;
            updatedPrescription.EndDate = aPrescriptionRecordfmIpt.EndDate;
            updatedPrescription.VeterinaryName = aPrescriptionRecordfmIpt.VeterinaryName;
            updatedPrescription.VeterinaryPhone = aPrescriptionRecordfmIpt.VeterinaryPhone;
            updatedPrescription.Notes = aPrescriptionRecordfmIpt.Notes;
            PsMinderEntities.SaveChanges();//save changes to database to achieve the update
        }

        public int GetMaxPrescriptionID()//used to find the current largest PrescriptionID, to auto generate next ID (increment by 1)
        {

            return PsMinderEntities.PrescriptionTables.Max(prstbl => prstbl.PrescriptionID);//return the current largest PrescriptionID #, dbEntities.tblName.Max( use ID )
        }

        public ICollection<UnitTable> GetUnitTablesAllRecords()
        {
            return PsMinderEntities.UnitTables.ToList();//return a list of all records of UnitTable
        }              

        //public MedicineTable FindMedicine(int medicineID)
        //{
        //    var foundMedicineRecord=PsMinderEntities.MedicineTables.First(mdcnrcrd=>mdcnrcrd.MedicineID == medicineID);
        //    if (foundMedicineRecord != null)
        //    {
        //        return foundMedicineRecord;
        //    }
        //    else
        //    {
        //        return null;//or //return newMedicineTable();
        //    }
        //}
    }
}
