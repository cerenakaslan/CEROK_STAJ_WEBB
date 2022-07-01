using System;
using System.Collections.Generic;

namespace CEROK_STAJ_WEB.Models
{
    public partial class Ilce
    {
        public Ilce()
        {
            Hastanes = new HashSet<Hastane>();
        }

        public int ilceID { get; set; }
        public string? ilceIsmi { get; set; }
        public int ilKodu { get; set; }

        public virtual Il ilKoduNavigation { get; set; } = null!;
        public virtual ICollection<Hastane> Hastanes { get; set; }
    }
}
