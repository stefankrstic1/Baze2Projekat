//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace B2Projekat
{
    using System;
    using System.Collections.Generic;
    
    public partial class Masina
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Masina()
        {
            this.UProizvodnjis = new HashSet<UProizvodnji>();
        }
    
        public int IDMasina { get; set; }
        public string Proizvodjac { get; set; }
        public string Model { get; set; }
        public int BrzinaRada { get; set; }
        public string Tip { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UProizvodnji> UProizvodnjis { get; set; }
    }
}
