using System;
using System.Collections.Generic;

namespace CEROK_STAJ_WEB.Models
{
    public partial class Tetkik
    {
        public int tetkikID { get; set; }
        public string? tetkikAyrinti { get; set; }
        public int hastaID { get; set; }
        public int doktorID { get; set; }
        public int randevuID { get; set; }
        public string? tetkikSonuc { get; set; }
        public virtual Doktor doktor { get; set; } = null!;
        public virtual Hasta hasta { get; set; } = null!;
        public virtual RandevuKismi randevu { get; set; } = null!;
    }
}
