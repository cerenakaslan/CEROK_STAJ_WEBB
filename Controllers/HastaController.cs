using CEROK_STAJ_WEB.Models;
using CEROK_STAJ_WEB.DAL.InterfaceUsers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CEROK_STAJ_WEB.Controllers_ViewModels_
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
   
    public class HastaController : ControllerBase
    {
        private HastaDAL _hastadal;
        public HastaController(HastaDAL hastadal)
        {
            this._hastadal = hastadal;
        }

        // GET: api/<HastaController>
        [HttpGet]
        public List<Hasta> Get()
        {
             return _hastadal.GetAll();
        }


        // GET api/<HastaController>/5
        [HttpGet("{id}")]
        public Hasta Get(int id)
        {
            return _hastadal.Get(id);
        }
        [HttpGet("{id}/{pass}")]
        public bool GetHastaLoginCheck(int id,string pass)
        {
            Hasta hasta = _hastadal.Get(id);    
            return hasta!=null && id!=0 && hasta.sifre == pass;


            
        }
        
        [HttpGet]
        [Route("GetHastaByTc/{Tc}")]
        public Hasta GetHastasByTc(string Tc)
        {
            
            var count = 0;
            foreach (Hasta hasta in _hastadal.GetAll())
            {
                if (hasta.tc==Tc)
                {
                    count++;
                }
            }
            if (count>1)
            {
                return null;
            }
            return _hastadal.GetHastaByTc(Tc);
            
        }

        // POST api/<HastaController>
        [HttpPost]
        public void Post(Hasta hasta)
        {
            _hastadal.Add(hasta);
        }

        // PUT api/<HastaController>/5
        [HttpPut("{id}")]
        public void Put(int id,Hasta hasta)
        {
            _hastadal.Update(id, hasta);
        }

        // DELETE api/<HastaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Hasta hasta = _hastadal.Get(id);
            _hastadal.Delete(hasta);
        }
    }
}
