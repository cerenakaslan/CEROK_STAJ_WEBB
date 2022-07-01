using System;
using System.Collections.Generic;

namespace CEROK_STAJ_WEB.Models
{
    public partial class Il
    {
        public Il()
        {
            Ilces = new HashSet<Ilce>();
        }

        public int ilKodu { get; set; }
        public string? ilIsmi { get; set; }

        public virtual ICollection<Ilce> Ilces { get; set; }
    }
}
