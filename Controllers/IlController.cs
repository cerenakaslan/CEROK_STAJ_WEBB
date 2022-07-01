using Microsoft.AspNetCore.Mvc;
using CEROK_STAJ_WEB.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEROK_STAJ_WEB.Controllers_ViewModels_
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    
    public class IlController : ControllerBase
    {
        // GET: api/<IlController>
        [HttpGet]
        public List<Il> Get()
        {
            using (var context = new codbContext())
            {
                return context.Ils.ToList();
            }
        }

        // GET api/<IlController>/5
        [HttpGet("{id}")]
        public Il Get(int id)
        {
            using (var context = new codbContext())
            {
                return context.Ils.Where(u => u.ilKodu == id).Select(x => x).FirstOrDefault();
            }
        }

        // POST api/<IlController>
        [HttpPost]
        public void Post( string isim)
        {
            using (var context = new codbContext())
            {
                Il il = new Il()
                {
                    ilIsmi = isim
                };
                context.Ils.Add(il);
                context.SaveChanges();
            }
        }

        // PUT api/<IlController>/5
        [HttpPut("{id}")]
        public void Put(int id,  string ilismi)
        {
            using (var context = new codbContext())
            {
                Il il = (Il)context.Ils.Where(mekan => mekan.ilKodu== id).Select(x => x).FirstOrDefault();
                il.ilIsmi = ilismi;
                context.SaveChanges();
            }
        }

        // DELETE api/<IlController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var context = new codbContext())
            {
                Il il = (Il)context.Ils.Where(i=> i.ilKodu== id).Select(x => x).FirstOrDefault();
                context.Ils.Remove(il);
                context.SaveChanges();
            }
        }
    }
}
