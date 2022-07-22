using Microsoft.AspNetCore.Mvc;
using CEROK_STAJ_WEB.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEROK_STAJ_WEB.Controllers_ViewModels_
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    
    public class ReceteController : ControllerBase
    {
        codbContext _context;
        public ReceteController(codbContext context)
        {
            _context = context;
        }

    
        /// GET: api/<ReceteController>
        [HttpGet]
        public List<Recete> Get()
        {
            using (var context = new codbContext())
            {
                return (List<Recete>)context.Recetes.ToList();
            }
        }


        // GET api/<ReceteController>/5
        [HttpGet("{receteeID}")]
        public Recete Get(int receteeID)
        {
            using (var context = new codbContext())
            {
                return context.Recetes.Where(u => u.receteID == receteeID).Select(x => x).FirstOrDefault()!;
            }
        }
        [HttpGet]
        [Route("RecetesByHastaID/{hastaid}")]
        public List<Recete> GetRecetesyHastaID(int hastaid)
        {
            using (codbContext context =new codbContext())
            {
                return context.Recetes.Where(r=>r.hastaID == hastaid).Select(x => x).ToList();
            }
        }

        // POST api/<ReceteController>
        [HttpPost]
        public void Post(DateTime gunsaatt)
        {
            using (var context = new codbContext())
            {
                var recete = new Recete()
                {
                    gunsaat = gunsaatt
                };
                context.Recetes.Add(recete);
                context.SaveChanges();
            }

        }

        // PUT api/<ReceteController>/5
        [HttpPut("{receteeID}")]
        public void Put(int receteeID, DateTime gunsaatt, int doktorid, int hastaid, int randevuuID)
        {
            using (var context = new codbContext())
            {
                Recete recete = (Recete)context.Recetes.Where(u => u.receteID == receteeID).Select(rec => rec.receteID == receteeID);
                recete.gunsaat = gunsaatt;
                recete.doktorID = doktorid;
                recete.hastaID = hastaid;
                recete.randevuID = randevuuID;

            }
        }

        // DELETE api/<ReceteController>/5
        [HttpDelete("{receteeID}")]
        public void Delete(int receteeID)
        {
            using (var context = new codbContext())
            {
                Recete rec = (Recete)context.Recetes.Where(u => u.receteID == receteeID).Select(rec => rec.receteID == receteeID);              
                context.Recetes.Remove(rec);
                context.SaveChanges();
            }
        }
    }
}