using Microsoft.AspNetCore.Mvc;
using CEROK_STAJ_WEB.Models;
using System.Text;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEROK_STAJ_WEB.Controllers_ViewModels_
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]

    public class RandevuKismiController : ControllerBase
    {
        /// GET: api/<RandevuKismiController>
        [HttpGet]
        public List<RandevuKismi> Get()
        {
            using (var context = new codbContext())
            {
                return (List<RandevuKismi>)context.RandevuKismis.ToList();
            }
        }
        [HttpGet]
        [Route("byDoc/{doktorid}")]
        public List<RandevuKismi> getRDVs(int doktorid)
        {
            //codbContext context = new codbContext();
            //List<RandevuKismi> listrdv= context.RandevuKismis.Where(rdv => rdv.doktorID == doktorid).Select(x => x).ToList();
            //foreach (var itemHasta in listrdv)
            //{
            //    itemHasta.hasta = context.Hastas.Where(x => x.hastaID == itemHasta.hastaID).Select(y => y).FirstOrDefault();
            //}
            //return listrdv;

            //return context.RandevuKismis.Include(x=>x.hasta).Where(x=> x.hastaID == ).Select(y=> y).ToList();
            //return context.RandevuKismis.Include(x => x.hasta).Include(x => x.hasta.RandevuKismis).Include(x => x.hasta.RandevuKismis.Select(x => x.doktorID)).Where(x => x.doktorID == doktorid).ToList();
            //context.Dispose();
            List<RandevuKismi> randevuListesi = null;
            using (codbContext context = new codbContext())
            {
                randevuListesi = (from r in context.RandevuKismis
                                  join h in context.Hastas on r.hastaID equals h.hastaID
                                  join d in context.Doktors on r.doktorID equals d.doktorID

                                  where r.doktorID == doktorid //!//
                                  select new RandevuKismi()
                                  {
                                      hasta = h,
                                      doktor = d,
                                      doktorID = r.doktorID,
                                      gunsaat = r.gunsaat,
                                      hastaID = r.hastaID,
                                      randevuID = r.randevuID,
                                      Recetes = null,
                                      Tanis = null,
                                      Tetkiks = null

                                  }).ToList<RandevuKismi>();
            }
            return randevuListesi;
        }

        // GET api/<RandevuKismiController>/5
        [HttpGet]
        [Route("byRDV/{randevuuID}")]
        public RandevuKismi Get(int randevuuID)
        {
            using (var context = new codbContext())
            {
                return context.RandevuKismis.Where(u => u.randevuID == randevuuID).Select(x => x).FirstOrDefault()!;
            }
        }

        // POST api/<RandevuKismiController>
        [HttpPost]
        public void Post(DateTime gunsaatt, int hastaid, int doktorid)
        {
           
            using (var context = new codbContext())
            {
                var randevukismi = new RandevuKismi()
                {
                    
                    doktorID = doktorid,
                    hastaID = hastaid,
                    gunsaat = gunsaatt
                   
            };
                //randevukismi.hastaID = hastaid;
                //randevukismi.doktorID = doktorid;
                //randevukismi.gunsaat = gunsaatt;
                context.RandevuKismis.Add(randevukismi);
                context.SaveChanges();
            }
        }

        // PUT api/<RandevuKismiController>/5
        [HttpPut("{randevuuID}")]
        public void Put(int randevuuID, DateTime gunsaatt, int doktorid, int hastaid)
        {
            using (var context = new codbContext())
            {
                RandevuKismi randevukismi = (RandevuKismi)context.RandevuKismis.Where(u => u.randevuID == randevuuID).Select(ran => ran).FirstOrDefault();
               // randevukismi.gunsaat = Convert.ToDateTime(gunsaatttt);
                randevukismi.doktorID = doktorid;
                randevukismi.hastaID = hastaid;
                randevukismi.gunsaat = gunsaatt;

            }
        }

        // DELETE api/<RandevuKismiController>/5
        [HttpDelete("{randevuuID}")]
        public void Delete(int randevuuID)
        {
            using (var context = new codbContext())
            {
                RandevuKismi ran = (RandevuKismi)context.RandevuKismis.Where(u => u.randevuID == randevuuID).Select(ran => ran.randevuID == randevuuID);
                context.RandevuKismis.Remove(ran);
                context.SaveChanges();
            }
        }
    }
}

