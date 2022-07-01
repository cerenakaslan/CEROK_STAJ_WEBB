using System;
using System.Collections.Generic;

namespace CEROK_STAJ_WEB.Models
{
    public partial class Hastane
    {
        public Hastane()
        {
            Hastane_polis = new HashSet<Hastane_poli>();
        }

        public int hastaneID { get; set; }
        public string? hastaneIsim { get; set; }
        public int? ilceID { get; set; }

        public virtual Ilce? ilce { get; set; }
        public virtual ICollection<Hastane_poli> Hastane_polis { get; set; }
    }
}
