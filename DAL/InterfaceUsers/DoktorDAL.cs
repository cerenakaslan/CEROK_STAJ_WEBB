using CEROK_STAJ_WEB.DAL.Interfaces;
using CEROK_STAJ_WEB.Models;

namespace CEROK_STAJ_WEB.DAL.InterfaceUsers
{
    public class DoktorDAL : IDoktorDAL
    {
        private codbContext _codbContext;
        public DoktorDAL(codbContext codbContext)
        {
            _codbContext = codbContext;
        }

        public void Add(Doktor entity)
        {
            _codbContext.Add(entity);
            _codbContext.SaveChanges();
        }

        public void Delete(Doktor entity)
        {
            _codbContext.Remove(entity);
            _codbContext.SaveChanges();
        }

        public Doktor Get(int id)
        {
            return _codbContext.Doktors.Where(x=>x.doktorID==id).FirstOrDefault();
        }

        public List<Doktor> GetAll()
        {
            return _codbContext.Doktors.ToList<Doktor>();
        }

        public void Update(int id, Doktor entity)
        {
            Doktor doktor=_codbContext.Doktors.Where(x=>x.doktorID==id).FirstOrDefault();
            doktor = entity;
            _codbContext.Update(doktor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _codbContext.SaveChanges();
        }
    }
}
