using CEROK_STAJ_WEB.DAL.Interfaces;
using CEROK_STAJ_WEB.Models;

namespace CEROK_STAJ_WEB.DAL.InterfaceUsers
{
    public class RandevuDAL : IRandevuDAL
    {
        private codbContext _context;
        public RandevuDAL(codbContext context)
        {
            _context = context;
        }

        public void Add(RandevuKismi entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(RandevuKismi entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public RandevuKismi Get(int id)
        {
            return _context.RandevuKismis.Where(x=>x.randevuID==id).FirstOrDefault();
        }

        public List<RandevuKismi> GetAll()
        {
            return _context.RandevuKismis.ToList<RandevuKismi>();
        }

        public List<RandevuKismi> GetDoktorRandevus(int doktorid)
        {
            //List<RandevuKismi> res= (from r in _context.RandevuKismis
            //      join h in _context.Hastas on r.hastaID equals h.hastaID
            //      join d in _context.Doktors on r.doktorID equals d.doktorID

            //      where r.doktorID == doktorid
            //      select new RandevuKismi()
            //      {
            //          doktor = d,
            //          hasta = h,                                      // sorun yaşanırsa sonradan bu denenebilir 
            //          doktorID = d.doktorID,
            //          hastaID=h.hastaID,
            //          gunsaat=r.gunsaat,
            //          randevuID=r.randevuID,
            //          RandevuTetkiks=r.RandevuTetkiks,
            //          Recetes=r.Recetes,
            //          Tanis=r.Tanis


            //      }).ToList<RandevuKismi>();
            return (from r in _context.RandevuKismis                                // return kısmına res yazılacak unutulmamalı
                    join h in _context.Hastas on r.hastaID equals h.hastaID
                    join d in _context.Doktors on r.doktorID equals d.doktorID

                    where r.doktorID == doktorid
                    select new RandevuKismi()
                    {
                        doktor = d,
                        hasta = h,
                        doktorID = d.doktorID,
                        hastaID = h.hastaID,
                        gunsaat = r.gunsaat,
                        randevuID = r.randevuID,
                        RandevuTetkiks = r.RandevuTetkiks,
                        Recetes = r.Recetes,
                        Tanis = r.Tanis


                    }).ToList<RandevuKismi>(); ;
        }

        public List<RandevuKismi> GetHastaRandevus(int hastaid)
        {
            List<RandevuKismi> res=null;
            res = (from r in _context.RandevuKismis
                   join h in _context.Hastas on r.hastaID equals h.hastaID
                   join d in _context.Doktors on r.doktorID equals d.doktorID
                   where r.hastaID == hastaid
                   select new RandevuKismi()
                   {
                       hasta = h,
                       doktor = d,
                       hastaID = h.hastaID,
                       doktorID = d.doktorID,
                       gunsaat=r.gunsaat,
                       randevuID=r.randevuID,
                       RandevuTetkiks=r.RandevuTetkiks,
                       Recetes=r.Recetes,
                       Tanis=r.Tanis

                   }).ToList<RandevuKismi>();
            return res;
        }

        public void Update(int id, RandevuKismi entity)
        {
            RandevuKismi randevu =this.Get(id);
            randevu.hastaID=entity.hastaID;
            randevu.hasta = entity.hasta;
            randevu.doktorID = entity.doktorID;
            randevu.doktor = entity.doktor;
            randevu.gunsaat = entity.gunsaat;
            _context.Update(randevu).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
