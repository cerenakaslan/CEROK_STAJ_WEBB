using System;
using System.Collections.Generic;

namespace CEROK_STAJ_WEB.Models
{
    public partial class Recete
    {
        public int doktorID { get; set; }
        public int hastaID { get; set; }
        public int receteID { get; set; }
        public DateTime gunsaat { get; set; }
        public int randevuID { get; set; }

        public virtual Doktor doktor { get; set; } = null!;
        public virtual Hasta hasta { get; set; } = null!;
        public virtual RandevuKismi randevu { get; set; } = null!;
    }
}
