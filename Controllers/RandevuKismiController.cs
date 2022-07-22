using Microsoft.AspNetCore.Mvc;
using CEROK_STAJ_WEB.Models;
using System.Text;
using CEROK_STAJ_WEB.DAL.InterfaceUsers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEROK_STAJ_WEB.Controllers_ViewModels_
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]

    public class RandevuKismiController : ControllerBase
    {
        private RandevuDAL _randevudal;
        public RandevuKismiController(RandevuDAL randevudal)
        {
            this._randevudal = randevudal;
        }
        /// GET: api/<RandevuKismiController>
        [HttpGet]
        public List<RandevuKismi> Get()
        {
            return _randevudal.GetAll();
        }
        [HttpGet]
        [Route("byDoc/{doktorid}")]
        public List<RandevuKismi> getRDVs(int doktorid)
        {
            return _randevudal.GetDoktorRandevus(doktorid);
        }

        // GET api/<RandevuKismiController>/5
        [HttpGet]
        [Route("byRDV/{randevuuID}")]
        public RandevuKismi Get(int randevuuID)
        {
            return _randevudal.Get(randevuuID);
        }
        [HttpGet]
        [Route("GetHastaRandevus/{HastaId}")]
        public List<RandevuKismi> GetHastaRandevus(int HastaId)
        {
            return _randevudal.GetHastaRandevus(HastaId);
        }

        // POST api/<RandevuKismiController>
        [HttpPost]
        public void Post(RandevuKismi randevu)
        {

            _randevudal.Add(randevu);
        }

        // PUT api/<RandevuKismiController>/5
        [HttpPut("{randevuuID}")]
        public void Put(int id,RandevuKismi randevu)
        {
            _randevudal.Update(id, randevu);
        }

        // DELETE api/<RandevuKismiController>/5
        [HttpDelete("{randevuuID}")]
        public void Delete(int randevuuID)
        {
            RandevuKismi randevu = this.Get(randevuuID);
            _randevudal.Delete(randevu);
        }
    }
}

