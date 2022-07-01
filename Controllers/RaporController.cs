using Microsoft.AspNetCore.Mvc;
using CEROK_STAJ_WEB.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEROK_STAJ_WEB.Controllers_ViewModels_
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
  
    public class RaporController : ControllerBase
    {
        // GET: api/<RaporController>
        [HttpGet]
        public List<Rapor> Get()
        {
            using (var context = new codbContext())
            {
                return (List<Rapor>)context.Rapors.ToList();
            }
        }



        // GET api/<RaporController>/5
        [HttpGet("{raporrID}")]
        public Rapor Get(int raporrID)
        {
            using (var context = new codbContext())
            {
                return context.Rapors.Where(u => u.raporID == raporrID).Select(x => x).FirstOrDefault()!;
            }
        }



        // POST api/<RaporController>
        [HttpPost]
        public void Post(DateTime gunsaattt, int gecerlilikgunuu)
        {
            using (var context = new codbContext())
            {
                var rapor = new Rapor()
                {
                    gunsaat = gunsaattt,
                    gecerlilikGunu = gecerlilikgunuu,
                    
                    
                };
                context.Rapors.Add(rapor);
                context.SaveChanges();
            }
        }



        // PUT api/<RaporController>/5
        [HttpPut("{raporrID}")]
        public void Put(int raporrID, DateTime gunsaattt, int gecerlilikgunuu, int taniiID)
        {
            using (var context = new codbContext())
            {
                Rapor rapor = (Rapor)context.Rapors.Where(u => u.raporID == raporrID).Select(rap => rap).FirstOrDefault()!;
                rapor.gunsaat = gunsaattt;
                rapor.gecerlilikGunu = gecerlilikgunuu;
                rapor.taniID = taniiID;
            }
        }



        // DELETE api/<RaporController>/5
        [HttpDelete("{raporID}")]
        public void Delete(int raporrID)
        {
            using (var context = new codbContext())
            {
                Rapor rap = (Rapor)context.Rapors.Where(u => u.raporID == raporrID).Select(rap => rap).FirstOrDefault()!;
                context.Rapors.Remove(rap);
                context.SaveChanges();
            }
        }
    }
}