using System;
using System.Collections.Generic;

namespace CEROK_STAJ_WEB.Models
{
    public partial class Doktor_Poli
    {
        public int doktorID { get; set; }
        public int bolumID { get; set; }
        public int Id { get; set; }

        public virtual Poliklinik bolum { get; set; } = null!;
        public virtual Doktor doktor { get; set; } = null!;
    }
}
