using CEROK_STAJ_WEB.DAL.InterfaceUsers;
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
        private DoktorDAL _doktordal;
        public DoktorController(DoktorDAL doktordal)
        {
            _doktordal = doktordal;
        }

        // GET: api/<DoktorController>
        [HttpGet]
        public List<Doktor> Get()
        {
            return _doktordal.GetAll(); 
        }

        // GET api/<DoktorController>/5
        [HttpGet("{id}")]
        public Doktor GetDocByID(int id)
        {
            return _doktordal.Get(id);
        }



        // POST api/<DoktorController>
        [HttpPost]
        public void Post(Doktor doktor)
        {
            _doktordal.Add(doktor);
        }



        // PUT api/<DoktorController>/5
        [HttpPut("{id}")]
        public void Put(int id,Doktor doktor)
        {
            _doktordal.Update(id, doktor);
            
        }



        // DELETE api/<DoktorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Doktor doktor = _doktordal.Get(id);
            _doktordal.Delete(doktor);
        }
    }
}