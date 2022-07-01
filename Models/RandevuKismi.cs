using System;
using System.Collections.Generic;

namespace CEROK_STAJ_WEB.Models
{
    public partial class RandevuKismi
    {
        public RandevuKismi()
        {
            Recetes = new HashSet<Recete>();
            Tanis = new HashSet<Tani>();
            RandevuTetkiks = new HashSet<RandevuTetkik>();
        }

        public int doktorID { get; set; }
        public int hastaID { get; set; }
        public int randevuID { get; set; }
        public DateTime gunsaat { get; set; }

        public virtual Doktor doktor { get; set; } = null!;
        public virtual Hasta hasta { get; set; } = null!;
        public virtual ICollection<Recete> Recetes { get; set; }
        public virtual ICollection<Tani> Tanis { get; set; }
        public virtual ICollection<RandevuTetkik> RandevuTetkiks { get; set; }

    }
}
