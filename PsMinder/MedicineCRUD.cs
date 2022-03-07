using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsMinder
{
    interface MedicineCRUD
    {
        ICollection<MedicineTable> GetAllMedicineRecords();
        ICollection<UnitTable> GetAllUnits();
        MedicineTable FindMedicineRecord(int medicineID);
        int GetMaxMedicineID();
        void AddMedicineRecord(MedicineTable aNewMedicineRecord);
        void DeleteMedicineRecord(MedicineTable aMedicineRecordtoDelete);
        void UpdateMedicineRecord(int medicineID, MedicineTable aMedicineRecordtoUpdate);
    }
    public class MedicineRecords : MedicineCRUD
    {
        PsMinderEntities psMinderEntities=new PsMinderEntities();
        public void AddMedicineRecord(MedicineTable aNewMedicineRecord)
        {
            psMinderEntities.MedicineTables.Add(aNewMedicineRecord);
            psMinderEntities.SaveChanges();
        }

        public void DeleteMedicineRecord(MedicineTable aMedicineRecordtoDelete)
        {
            psMinderEntities.MedicineTables.Remove(aMedicineRecordtoDelete);
            psMinderEntities.SaveChanges();
        }

        public MedicineTable FindMedicineRecord(int medicineID)
        {
            MedicineTable foundMedicineRecord = new MedicineTable();
            foundMedicineRecord=psMinderEntities.MedicineTables.First(mdcntblrcrd => mdcntblrcrd.MedicineID==medicineID);
            if (foundMedicineRecord!=null) { return foundMedicineRecord; } else { return null; }
        }

        public ICollection<MedicineTable> GetAllMedicineRecords()
        {
            return psMinderEntities.MedicineTables.ToList();
        }

        public ICollection<UnitTable> GetAllUnits()
        {
            return psMinderEntities.UnitTables.ToList();
        }

        public int GetMaxMedicineID()
        {
            return psMinderEntities.MedicineTables.Max(mdcntblrcrdid => mdcntblrcrdid.MedicineID);
        }

        public void UpdateMedicineRecord(int medicineID, MedicineTable aMedicineRecordToUpdate)
        {
            MedicineTable aMedicineRecordUpdated = FindMedicineRecord(medicineID);
            aMedicineRecordUpdated.MedicineID=aMedicineRecordToUpdate.MedicineID;
            aMedicineRecordUpdated.MedicineName=aMedicineRecordToUpdate.MedicineName;
            aMedicineRecordUpdated.DailyConsumption=aMedicineRecordToUpdate.DailyConsumption;
            aMedicineRecordUpdated.CurrentStock=aMedicineRecordToUpdate.CurrentStock;
            aMedicineRecordUpdated.UnitID=aMedicineRecordToUpdate.UnitID;
            aMedicineRecordUpdated.Unit=aMedicineRecordToUpdate.Unit;
            aMedicineRecordUpdated.ProjectedRestockDate=aMedicineRecordToUpdate.ProjectedRestockDate;
            aMedicineRecordUpdated.Note=aMedicineRecordToUpdate.Note;
            psMinderEntities.SaveChanges();
        }
    }
}
