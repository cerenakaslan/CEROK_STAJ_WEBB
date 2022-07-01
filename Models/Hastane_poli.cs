using System;
using System.Collections.Generic;

namespace CEROK_STAJ_WEB.Models
{
    public partial class Hastane_poli
    {
        public int bolumID { get; set; }
        public int hastaneID { get; set; }
        public int id { get; set; }

        public virtual Poliklinik bolum { get; set; } = null!;
        public virtual Hastane hastane { get; set; } = null!;
    }
}
