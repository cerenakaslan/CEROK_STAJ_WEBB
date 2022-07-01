using CEROK_STAJ_WEB.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEROK_STAJ_WEB.Controllers_ViewModels_
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]

    public class DoktorController : ControllerBase
    {
        // GET: api/<DoktorController>
        [HttpGet]
        public List<Doktor> Get()
        {
            using (var context = new codbContext())
            {
                return context.Doktors.ToList();
            }
        }

        // GET api/<DoktorController>/5
        [HttpGet("{id}")]
        public Doktor GetDocByID(int id)
        {
            using (var context = new codbContext())
            {
                return context.Doktors.Where(u => u.doktorID == id).Select(x => x).FirstOrDefault()!;
            }
        }



        // POST api/<DoktorController>
        [HttpPost]
        public void Post(string name, string lastname, string pass)
        {
            using (var context = new codbContext())
            {
                var doktor = new Doktor()
                {
                    doktorismi = name,
                    doktorsoyismi = lastname,
                    doktorpassword = pass
                };
                context.Doktors.Add(doktor);
                context.SaveChanges();
            }
        }



        // PUT api/<DoktorController>/5
        [HttpPut("{id}")]
        public void Put(int id, string isim, string soyisim, string pass)
        {
            using (var context = new codbContext())
            {
                Doktor doktor = (Doktor)context.Doktors.Where(doc => doc.doktorID == id).Select(x => x).FirstOrDefault();
                doktor.doktorismi = isim;
                doktor.doktorpassword = pass;
                doktor.doktorsoyismi = soyisim;
                context.SaveChanges();
            }
            
        }



        // DELETE api/<DoktorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var context = new codbContext())
            {
                Doktor doc = context.Doktors.Where(doc => doc.doktorID == id).Select(x=>x).FirstOrDefault();
                context.Doktors.Remove(doc);
                context.SaveChanges();
            }
        }
    }
}