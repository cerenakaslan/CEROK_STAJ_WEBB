using System;
using System.Collections.Generic;

namespace CEROK_STAJ_WEB.Models
{
    public partial class Poliklinik
    {
        public Poliklinik()
        {
            Doktor_Polis = new HashSet<Doktor_Poli>();
            Hastane_polis = new HashSet<Hastane_poli>();
        }

        public int bolumID { get; set; }
        public string bolumIsmi { get; set; } = null!;

        public virtual ICollection<Doktor_Poli> Doktor_Polis { get; set; }
        public virtual ICollection<Hastane_poli> Hastane_polis { get; set; }
    }
}
