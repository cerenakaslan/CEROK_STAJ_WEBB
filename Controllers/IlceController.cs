using Microsoft.AspNetCore.Mvc;
using CEROK_STAJ_WEB.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEROK_STAJ_WEB.Controllers_ViewModels_
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
   
    public class IlceController : ControllerBase
    {
        // GET: api/<IlceController>
        [HttpGet]
        public List<Ilce> Get()
        {
            using (var context = new codbContext())
            {
                return context.Ilces.ToList();
            }
        }

        // GET api/<IlceController>/5
        [HttpGet("{id}")]
        public Ilce Get(int id)
        {
            using (var context = new codbContext())
            {
                return context.Ilces.Where(u => u.ilceID == id).Select(x => x).FirstOrDefault();
            }
        }

        // POST api/<IlceController>
        [HttpPost]
        public void Post(string isim,int ilkodu)
        {
            using (var context = new codbContext())
            {
                Ilce ilce = new Ilce()
                {
                    ilceIsmi = isim,
                    ilKodu=ilkodu
                };
                context.Ilces.Add(ilce);
                context.SaveChanges();
            }
        }

        // PUT api/<IlceController>/5
        [HttpPut("{id}")]
        public void Put(int id, string ilceismi)
        {
            using (var context = new codbContext())
            {
                Ilce ilce = (Ilce)context.Ilces.Where(mekan => mekan.ilceID == id).Select(x => x).FirstOrDefault();
                ilce.ilceIsmi = ilceismi;
                context.SaveChanges();
            }
        }

        // DELETE api/<IlceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var context = new codbContext())
            {
                Ilce ilce = (Ilce)context.Ilces.Where(i => i.ilceID == id).Select(x => x).FirstOrDefault();
                context.Ilces.Remove(ilce);
                context.SaveChanges();
            }
        }
    }
}
