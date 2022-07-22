using CEROK_STAJ_WEB.Models;
namespace CEROK_STAJ_WEB.DAL.Interfaces
{
    public interface IRandevuDAL:IRepository<RandevuKismi>
    {


        public List<RandevuKismi> GetHastaRandevus(int hastaid);
        public List<RandevuKismi> GetDoktorRandevus(int doktorid);


    }
}
