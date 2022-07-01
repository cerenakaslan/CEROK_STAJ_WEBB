using Microsoft.AspNetCore.Mvc;
using CEROK_STAJ_WEB.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEROK_STAJ_WEB.Controllers_ViewModels_
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    
    public class PoliklinikController : ControllerBase
    {
        // GET: api/<PoliklinikController>
        [HttpGet]
        public List<Poliklinik> Get()
        {
            using (var context = new codbContext())
            {
                return context.Polikliniks.ToList();
            }
        }

        // GET api/<PoliklinikController>/5
        [HttpGet("{id}")]
        public Poliklinik Get(int id)
        {
            using (var context = new codbContext())
            {
                return context.Polikliniks.Where(u => u.bolumID == id).Select(x => x).FirstOrDefault();
            }
        }

        // POST api/<PoliklinikController>
        [HttpPost]
        public void Post( string isimBolum, string isimHastane )
        {
            using (var context = new codbContext())
            {
                Poliklinik bolum = new Poliklinik()
                {
                    bolumIsmi = isimBolum
                    
                };
                context.Polikliniks.Add(bolum);
                context.SaveChanges();
            }
        }

        // PUT api/<PoliklinikController>/5
        [HttpPut("{id}")]
        public void Put(int id, string isim)
        {
            using (var context = new codbContext())
            {
                Poliklinik bolum = (Poliklinik)context.Polikliniks.Where(poli => poli.bolumID == id);
                bolum.bolumIsmi= isim;
                context.SaveChanges();
            }
        }

        // DELETE api/<PoliklinikController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using(var context= new codbContext())
            {
                Poliklinik poli = (Poliklinik)context.Polikliniks.Where(bolum => bolum.bolumID == id).Select(x => x).FirstOrDefault();
                context.Polikliniks.Remove(poli);
                context.SaveChanges();
            }
        }
    }
}
