using System;
using System.Collections.Generic;

namespace CEROK_STAJ_WEB.Models
{
    public partial class Hasta
    {
        public Hasta()
        {
            RandevuKismis = new HashSet<RandevuKismi>();
            Recetes = new HashSet<Recete>();
            Tanis = new HashSet<Tani>();
            
        }

        public int hastaID { get; set; }
        public string tc { get; set; } = null!;
        public string sifre { get; set; } = null!;
        public string isim { get; set; } = null!;
        public string soyad { get; set; } = null!;
        public string cinsiyet { get; set; } = null!;
        public DateTime dogumTarihi { get; set; }
        public string telefonNo { get; set; } = null!;
        public string? email { get; set; }
        public string? kanGrubu { get; set; }
        public int? yas { get; set; }
        public int? boy { get; set; }
        public int? kilo { get; set; }

        public virtual ICollection<RandevuKismi> RandevuKismis { get; set; }
        public virtual ICollection<Recete> Recetes { get; set; }
        public virtual ICollection<Tani> Tanis { get; set; }
        
    }
}
