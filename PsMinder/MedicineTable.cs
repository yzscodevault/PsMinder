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
    
    public partial class MedicineTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MedicineTable()
        {
            this.PrescriptionTables = new HashSet<PrescriptionTable>();
            this.ReminderTables = new HashSet<ReminderTable>();
        }
    
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public decimal DailyConsumption { get; set; }
        public decimal CurrentStock { get; set; }
        public int UnitID { get; set; }
        public string Unit { get; set; }
        public System.DateTime ProjectedRestockDate { get; set; }
        public string Note { get; set; }
    
        public virtual UnitTable UnitTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrescriptionTable> PrescriptionTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReminderTable> ReminderTables { get; set; }
    }
}
