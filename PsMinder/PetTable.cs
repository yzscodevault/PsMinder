//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PsMinder
{
    using System;
    using System.Collections.Generic;
    
    public partial class PetTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PetTable()
        {
            this.PrescriptionTables = new HashSet<PrescriptionTable>();
            this.ReminderTables = new HashSet<ReminderTable>();
        }
    
        public int PetID { get; set; }
        public byte[] PetImage { get; set; }
        public string PetName { get; set; }
        public Nullable<byte> PetAge { get; set; }
        public Nullable<double> PetWeight { get; set; }
        public string PetColor { get; set; }
        public string PetSpecies { get; set; }
        public string PetBreed { get; set; }
        public string Owner { get; set; }
        public string OwnerContact { get; set; }
        public string Note { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrescriptionTable> PrescriptionTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReminderTable> ReminderTables { get; set; }
    }
}
