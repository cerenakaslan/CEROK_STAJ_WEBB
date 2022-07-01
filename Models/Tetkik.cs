using System;
using System.Collections.Generic;

namespace CEROK_STAJ_WEB.Models
{
    public partial class Tetkik
    {
        public Tetkik()
        {
            RandevuTetkiks = new HashSet<RandevuTetkik>();
        }
        public int tetkikID { get; set; }
        public string? tetkikAyrinti { get; set; }

        public virtual ICollection<RandevuTetkik> RandevuTetkiks { get; set; }
        
        
        
        
        
    }
}
