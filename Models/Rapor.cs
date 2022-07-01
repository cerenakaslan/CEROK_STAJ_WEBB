using System;
using System.Collections.Generic;

namespace CEROK_STAJ_WEB.Models
{
    public partial class Rapor
    {
        public int raporID { get; set; }
        public DateTime gunsaat { get; set; }
        public int gecerlilikGunu { get; set; }
        public int taniID { get; set; }

        public virtual Tani tani { get; set; } = null!;
    }
}
