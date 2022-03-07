using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsMinder
{
    interface PetCrud
    {
        ICollection<PetTable> GetAllPetRecords();
        PetTable FindPet(int petID);
        int GetMaxPetID();
        void AddPetRecord(PetTable aPetRecordtoAdd);
        void DeletePetRecord(PetTable aPetRecordtoDelete);
        void UpdatePetRecord(int petID, PetTable aNewPetRecord);

    }

    public class PetRecords : PetCrud
    {
        PsMinderEntities psMinderEntities=new PsMinderEntities();

        public void AddPetRecord(PetTable aPetRecordtoAdd)
        {
            psMinderEntities.PetTables.Add(aPetRecordtoAdd);
            psMinderEntities.SaveChanges();
        }

        public void DeletePetRecord(PetTable aPetRecordtoDelete)
        {
            psMinderEntities.PetTables.Remove(aPetRecordtoDelete);
            psMinderEntities.SaveChanges();
        }

        public PetTable FindPet(int petID)
        {
            PetTable foundPetRecord =psMinderEntities.PetTables.First(petblrcrd => petblrcrd.PetID== petID);
            if (foundPetRecord!=null)
            {
                return foundPetRecord;
            }
            else
            {
                return null;
            }
        }

        public ICollection<PetTable> GetAllPetRecords()
        {
            return psMinderEntities.PetTables.ToList();
        }

        public int GetMaxPetID()
        {
            return psMinderEntities.PetTables.Max(petblrcrd => petblrcrd.PetID);
        }

        public void UpdatePetRecord(int petID, PetTable petRecordfromInput)
        {
            PetTable aNewPetRecord = FindPet(petID);
            //aNewPetRecord=petRecordfromInput
            aNewPetRecord.PetName = petRecordfromInput.PetName;
            aNewPetRecord.PetImage=petRecordfromInput.PetImage;
            aNewPetRecord.PetAge=petRecordfromInput.PetAge;
            aNewPetRecord.PetColor=petRecordfromInput.PetColor;
            aNewPetRecord.PetWeight=petRecordfromInput.PetWeight;
            aNewPetRecord.PetSpecies=petRecordfromInput.PetSpecies;
            aNewPetRecord.PetBreed=petRecordfromInput.PetBreed;
            aNewPetRecord.Owner=petRecordfromInput.Owner;
            aNewPetRecord.OwnerContact=petRecordfromInput.OwnerContact;
            aNewPetRecord.Note=petRecordfromInput.Note;
            psMinderEntities.SaveChanges();
        }
    }
}
