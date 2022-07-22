using CEROK_STAJ_WEB.DAL.Interfaces;
using CEROK_STAJ_WEB.Models;

namespace CEROK_STAJ_WEB.DAL.InterfaceUsers
{
    public class HastaDAL : IHastaDAL
    {
        private codbContext _context;
        public HastaDAL(codbContext context)
        {
            _context = context;
        }
    
        public void Add(Hasta entity)
        {
            _context.Hastas.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Hasta entity)
        {
            _context.Hastas.Remove(entity);
            _context.SaveChanges(); 
        }

        public Hasta Get(int id)
        {
            return _context.Hastas.Where(x=>x.hastaID==id).Select(x=>x).FirstOrDefault();
        }

        public List<Hasta> GetAll()
        {
            return _context.Hastas.ToList<Hasta>();
        }

        public void Update(int id,Hasta entity)
        {
            Hasta hasta=_context.Hastas.Where(x=>x.hastaID==id).Select(x=>x).FirstOrDefault();

            hasta.telefonNo = entity.telefonNo;
            hasta.email = entity.email;
            hasta.boy = entity.boy;
            hasta.kilo = entity.kilo;
            _context.Update(hasta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
        public Hasta GetHastaByTc(string tc)
        {
            return _context.Hastas.Where(x => x.tc == tc).FirstOrDefault();
        }
        
    }
}
