using CEROK_STAJ_WEB.Models;


namespace CEROK_STAJ_WEB.DAL.Interfaces
{
    public interface IHastaDAL : IRepository<Hasta>
    {
        public Hasta GetHastaByTc(string tc);
    }
}
