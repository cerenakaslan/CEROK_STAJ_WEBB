using Microsoft.AspNetCore.Mvc;
using CEROK_STAJ_WEB.Models;
using System.Collections;

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
        [HttpGet("{tetkikID}")]
        public Tetkik Get(int tetkikID)
        {
            using (var context = new codbContext())
            {
                return context.Tetkiks.Where(u => u.tetkikID == tetkikID).Select(x => x).FirstOrDefault()!;
            }
        }
        // POST api/<TetkikController>
        [HttpPost]
        [Route("{hastaID}/{randevuID}/{doktorID}/{tetkikayrinti}")]
        public void Post(string tetkikayrinti,int randevuID,int hastaID,int doktorID)
        {

            using (var context = new codbContext())
            {
                var tetkik = new Tetkik()
                {
                    tetkikAyrinti = tetkikayrinti,
                    hastaID=hastaID,
                    randevuID=randevuID,
                    doktorID=doktorID,
                    doktor= context.Doktors.Where(u => u.doktorID == doktorID).Select(x => x).FirstOrDefault()!,
                    hasta= context.Hastas.Where(u => u.hastaID == hastaID).Select(x => x).FirstOrDefault()!,
                    randevu= context.RandevuKismis.Where(u => u.randevuID == randevuID).Select(x => x).FirstOrDefault()!

                };
                context.Tetkiks.Add(tetkik);
                context.Hastas.Where(x => x.hastaID == tetkik.hastaID).Select(x => x.Tetkiks).FirstOrDefault().Add(tetkik);
                context.SaveChanges();
            }
        }
       /* [HttpPost("{HastaID}/{DoktorID}/{RandevuID}")]
        public void Post(int doktorID,int hastaID,string tetkikayrinti,int randevuID)
        {
            using (var context = new codbContext())
            {
                var tetkik = new Tetkik()
                {
                    doktorID = doktorID,
                    hastaID = hastaID,
                    tetkikAyrinti = tetkikayrinti,
                    randevuID = randevuID                  
                };              
                context.Tetkiks.Add(tetkik);
                context.Hastas.Where(x => x.hastaID == tetkik.hastaID).Select(x => x.Tetkiks).FirstOrDefault().Add(tetkik);
                context.SaveChanges();
            }
        } */

        // PUT api/<TetkikController>/5
        [HttpPut("{tetkikID}/{tetkikayrinti}/{hastaID}/{doktorID}/{tetkikSonuc}")]
        public void Put(int tetkikID, string tetkikayrinti, int hastaID, int doktorID, string tetkikSonuc)
        {
            using (var context = new codbContext())
            {
                Tetkik tetkik = (Tetkik)context.Tetkiks.Where(u => u.tetkikID == tetkikID).Select(tet => tet).FirstOrDefault();
                //Tetkik tetkik = (Tetkik)context.Tetkiks.Where(u => u.tetkikID == tetkikID).Select(tet => tet.tetkikID == tetkikID).FirstOrDefault();
                tetkik.tetkikAyrinti = tetkikayrinti;
                tetkik.hastaID = hastaID;
                tetkik.doktorID = doktorID;
                tetkik.tetkikSonuc = tetkikSonuc;

            }
            }
        

        // DELETE api/<TetkikController>/5
        [HttpDelete("{tetkikID}")]
        public void Delete(int tetkikID)
        {
            using (var context = new codbContext())
            {
                Tetkik tet = (Tetkik)context.Tetkiks.Where(u => u.tetkikID == tetkikID).Select(tet => tet.tetkikID == tetkikID);              
                context.Tetkiks.Remove(tet);
                context.SaveChanges();
            }
                
        }
    }
}

