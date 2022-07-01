using System;
using System.Collections.Generic;

namespace CEROK_STAJ_WEB.Models
{
    public partial class Tani
    {
        public Tani()
        {
            Rapors = new HashSet<Rapor>();
        }

        public int taniID { get; set; }
        public string? taniAciklama { get; set; }
        public DateTime tarih { get; set; }
        public int doktorID { get; set; }
        public int hastaID { get; set; }
        public int randevuID { get; set; }

        public virtual Doktor doktor { get; set; } = null!;
        public virtual Hasta hasta { get; set; } = null!;
        public virtual RandevuKismi randevu { get; set; } = null!;
        public virtual ICollection<Rapor> Rapors { get; set; }
    }
}
