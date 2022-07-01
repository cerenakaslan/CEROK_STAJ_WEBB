using Microsoft.AspNetCore.Mvc;
using CEROK_STAJ_WEB.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEROK_STAJ_WEB.Controllers_ViewModels_
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
   
    public class TaniController : ControllerBase
    {
        // GET: api/<TaniController>
        [HttpGet]
        public List<Tani> Get()
        {
            using (var context = new codbContext())
            {
                return (List<Tani>)context.Tanis.ToList();
            }
        }

        // GET api/<TaniController>/5
        [HttpGet("{taniiID}")]
        public Tani Get(int taniiID)
        {
            using (var context = new codbContext())
            {
                return context.Tanis.Where(u => u.taniID == taniiID).Select(x => x).FirstOrDefault()!;
            }
        }

        // POST api/<TetkikController>
        [HttpPost]
        public void Post(string taniaciklama, DateTime tarihh)
        {
            using (var context = new codbContext())
            {
                var tani = new Tani()
                {
                    taniAciklama = taniaciklama,
                    tarih = tarihh
                };
                context.Tanis.Add(tani);
                context.SaveChanges();
            }

        }

        // PUT api/<TaniController>/5
        [HttpPut("{taniiID}")]
        public void Put(int taniiID, string taniaciklama, DateTime tarihh, int doktorid, int hastaid, int randevuuID)
        {
            using (var context = new codbContext())
            {
                Tani tani = (Tani)context.Tanis.Where(u => u.taniID == taniiID).Select(tan => tan).FirstOrDefault()!;
                tani.taniAciklama = taniaciklama;
                tani.tarih = tarihh;
                tani.doktorID = doktorid;
                tani.hastaID = hastaid;
                tani.randevuID = randevuuID;


            }
        }


        // DELETE api/<DoktorController>/5
        [HttpDelete("{taniiID}")]
        public void Delete(int taniiID)
        {
            using (var context = new codbContext())
            {
                Tani tan = (Tani)context.Tanis.Where(u => u.taniID == taniiID).Select(tan => tan).FirstOrDefault()!;
                context.Tanis.Remove(tan);
                context.SaveChanges();
            }
        }
    }
}
