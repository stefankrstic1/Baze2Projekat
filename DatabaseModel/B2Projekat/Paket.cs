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
    
    public partial class Paket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paket()
        {
            this.Proizvods = new HashSet<Proizvod>();
        }
    
        public int IdPaketa { get; set; }
        public int PakerIDMasina { get; set; }
        public int MagacinID { get; set; }
        public string Tezina { get; set; }
        public Nullable<int> DostavljacMBR { get; set; }
    
        public virtual Paker Paker { get; set; }
        public virtual Magacin Magacin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proizvod> Proizvods { get; set; }
        public virtual Dostavljac Dostavljac { get; set; }
    }
}
