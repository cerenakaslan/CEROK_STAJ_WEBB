namespace CEROK_STAJ_WEB.Models
{
    public class RandevuTetkik
    {
        public int ID { get; set; } 
        public int TetkikID { get; set; }   
        public int RandevuID { get; set; }
        public string Sonuc { get; set; }
        public bool IsChecked { get; set; }

        public virtual Tetkik Tetkik { get; set; }
        public virtual RandevuKismi Randevu { get; set; }
    }
}
