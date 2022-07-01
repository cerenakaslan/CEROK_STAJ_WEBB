using Microsoft.AspNetCore.Mvc;
using CEROK_STAJ_WEB.Models;
using System.Collections;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEROK_STAJ_WEB.Controllers_ViewModels_
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]

    public class TetkikController : ControllerBase
    {
        // GET: api/<TetkikController>
        [HttpGet]
        public List<Tetkik> Get()
        {
            using (var context = new codbContext())
            {
                return (List<Tetkik>)context.Tetkiks.ToList();
            }
        }

        // GET api/<TetkikController>/5
        [HttpGet("{tetkikkID}")]
        public Tetkik Get(int tetkikkID)
        {
            using (var context = new codbContext())
            {
                return context.Tetkiks.Where(u => u.tetkikID == tetkikkID).Select(x => x).FirstOrDefault()!;
            }
        }
        [HttpGet]
        [Route("RandevuTetkiksByRandevuList/{RdvList}")]
        public List<RandevuTetkik> GetRandevuTetkiksByRandevuList(List<RandevuKismi> RdvList)
        {
            using (codbContext context =new codbContext())
            {
                List<RandevuTetkik> res = new List<RandevuTetkik>();
                foreach (RandevuKismi randevu in RdvList)
                {
                    res.Add(context.RandevuTetkiks.Where(x => x.RandevuID == randevu.randevuID).Select(x=>x).FirstOrDefault());
                }
                return res;

            }
        }
        [HttpGet]
        [Route("GetRandevuTetkiksOfRandevu/{randevuID}")]
        public List<RandevuTetkik> GetRandevuTetkiksOfRandevu(int randevuID)
        {
            using(codbContext context =new codbContext())
            {
                return context.RandevuTetkiks.Where(x => x.RandevuID == randevuID).Select(x => x).ToList();
            }
        }
        

        // POST api/<TetkikController>
        [HttpPost]
        [Route("PostTetkik/{rdvtelist}")]
        public void PostTetkik(List<RandevuTetkik> rdvtetList)
        {
            using (var context = new codbContext())
            {
                foreach (RandevuTetkik randevutetkik in rdvtetList)
                {
                    if (randevutetkik.IsChecked)
                    {
                        context.RandevuTetkiks.Add(randevutetkik);
                    }
                    

                }
                context.SaveChanges();
            }
        }
        

        //[HttpPost("{HastaID}/{DoktorID}/{RandevuID}")]
        //public void Post(int doktorID,int hastaID,string tetkikayrinti,int randevuID)
        //{
        //    using (codbContext context = new codbContext())
        //    {
        //        Tetkik tetkik = new Tetkik()
        //        {
        //            doktorID = doktorID,
        //            hastaID = hastaID,
        //            tetkikAyrinti=tetkikayrinti,
        //            randevuID=randevuID             
        //        };
        //        context.Tetkiks.Add(tetkik);
        //        context.Hastas.Where(x => x.hastaID == tetkik.hastaID).Select(x => x.Tetkiks).FirstOrDefault().Add(tetkik);
        //        context.SaveChanges();
        //    }
        //}


        // PUT api/<TetkikController>/5
        [HttpPut("{tetkikkID}")]
        public void Put(int tetkikkID, string tetkikayrinti)
        {
            using (var context = new codbContext())
            {
                Tetkik tetkik = (Tetkik)context.Tetkiks.Where(u => u.tetkikID == tetkikkID).Select(tet => tet).FirstOrDefault();
                tetkik.tetkikAyrinti = tetkikayrinti;
                

            }


        }


        // DELETE api/<TetkikController>/5
        [HttpDelete("{tetkikID}")]
        public void Delete(int tetkikkID)
        {
            using (var context = new codbContext())
            {
                Tetkik tet = (Tetkik)context.Tetkiks.Where(u => u.tetkikID == tetkikkID).Select(tet => tet.tetkikID == tetkikkID);              
                context.Tetkiks.Remove(tet);
                context.SaveChanges();
            }
                
        }
    }
}

