using Microsoft.AspNetCore.Mvc;
using CEROK_STAJ_WEB.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEROK_STAJ_WEB.Controllers_ViewModels_
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    
    public class HastaneController : ControllerBase
    {
        // GET: api/<HastaneController>
        [HttpGet]
        public List<Hastane> Get()
        {
            using(var context =new codbContext())
            {
                return context.Hastanes.ToList();
            }
        }

        // GET api/<HastaneController>/5
        [HttpGet("{id}")]
        public Hastane Get(int id)
        {
            using (var context = new codbContext())
            {
                return context.Hastanes.Where(u => u.hastaneID == id).Select(x => x).FirstOrDefault();
            }
        }

        // POST api/<HastaneController>
        [HttpPost]
        public void Post(string isim, int ilceid)
        {
            using (var context = new codbContext())
            {
                Hastane hastane = new Hastane()
                {
                    hastaneIsim = isim,
                    ilceID = ilceid,
                    ilce = context.Ilces.Where(x => x.ilceID == ilceid).Select(y => y).FirstOrDefault()
                };
                                     
                
                context.Hastanes.Add(hastane);
                context.SaveChanges(); 
            }
        }

        // PUT api/<HastaneController>/5
        [HttpPut("{id}")]
        public void Put(int id, string isim, int ilceid)
        {
            using(var context=new codbContext())
            {
                Hastane hastane = (Hastane)context.Hastanes.Where(hastane => hastane.hastaneID == id).Select(x => x).FirstOrDefault();
                hastane.hastaneIsim = isim;
                hastane.ilceID = ilceid;
                context.SaveChanges();
            }
        }

        // DELETE api/<HastaneController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var context = new codbContext())
            {
                Hastane hastane = (Hastane)context.Hastanes.Where(hst => hst.hastaneID == id).Select(x => x).FirstOrDefault();
                context.Hastanes.Remove(hastane);
                context.SaveChanges();
            }

        }
    }
}
