using System;
using System.Collections.Generic;

namespace CEROK_STAJ_WEB.Models
{
    public partial class Doktor
    {
        public Doktor()
        {
            Doktor_Polis = new HashSet<Doktor_Poli>();
            RandevuKismis = new HashSet<RandevuKismi>();
            Recetes = new HashSet<Recete>();
            Tanis = new HashSet<Tani>();
            Tetkiks = new HashSet<Tetkik>();
        }

        public int doktorID { get; set; }
        public string doktorpassword { get; set; } = null!;
        public string doktorismi { get; set; } = null!;
        public string doktorsoyismi { get; set; } = null!;

        public virtual ICollection<Doktor_Poli> Doktor_Polis { get; set; }
        public virtual ICollection<RandevuKismi> RandevuKismis { get; set; }
        public virtual ICollection<Recete> Recetes { get; set; }
        public virtual ICollection<Tani> Tanis { get; set; }
        public virtual ICollection<Tetkik> Tetkiks { get; set; }
    }
}
