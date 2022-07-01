using CEROK_STAJ_WEB.Models;
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
        // GET: api/<HastaController>
        [HttpGet]
        public List<Hasta> Get()
        {
            using (var context = new codbContext())
            {
                return context.Hastas.ToList();
            }
        }


        // GET api/<HastaController>/5
        [HttpGet("{id}")]
        public Hasta? Get(int id)
        {
            using (var context = new codbContext())
            {
                return context.Hastas.Where(u => u.hastaID == id).Select(x => x).FirstOrDefault()!;
            }
        }

        // POST api/<HastaController>
        [HttpPost]
        public void Post( string tc,string pass,string isim,string soyad,string cins,DateTime dogumTarihi, string telNo)
        {
            using(var context=new codbContext())                                               
            {
                //var hasta = new Hasta()
                //{
                //    isim = isim,
                //    tc = tc,
                //    sifre = pass,
                //    soyad = soyad,
                //    cinsiyet = cins,
                //    dogumTarihi = dogumTarihi,
                //    telefonNo = telNo
                //};
                context.Hastas.Add(new Hasta
                {
                    isim = isim,
                    tc = tc,
                    sifre = pass,
                    soyad = soyad,
                    cinsiyet = cins,
                    dogumTarihi = dogumTarihi,
                    telefonNo = telNo,
                    //boy = null,
                    //kilo= null,
                    //kanGrubu    =  DBNull.Value.ToString(),
                    //email    =  DBNull.Value.ToString(),
                    // yas   =  null
                }) ;
                context.SaveChanges();
            }
        }

        // PUT api/<HastaController>/5
        [HttpPut("{id}")]
        public void Put(int id, string tc, string pass, string isim, string soyad, string cins, DateTime dogumTarihi, string telNo
            ,string? email,string? kanGrubu, int? yas, int? boy, int? kilo)
        {
            using(var context=new codbContext())
            {// burayı conditionliycaz daha
                Hasta hasta = (Hasta)context.Hastas.Where(hst => hst.hastaID == id).Select(x => x).FirstOrDefault();
                hasta.isim = isim;
                hasta.tc = tc;
                hasta.dogumTarihi = dogumTarihi;
                hasta.email = email;
                hasta.sifre = pass;
                hasta.soyad = soyad;
                hasta.cinsiyet = cins;
                hasta.telefonNo = telNo;
                hasta.kilo = kilo;
                hasta.kanGrubu = kanGrubu;
                hasta.yas = yas;
                hasta.boy = boy;
                context.SaveChanges();
            }
        }

        // DELETE api/<HastaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using(var context=new codbContext())
            {
                Hasta hasta = context.Hastas.Where(hst => hst.hastaID == id).Select(x => x).FirstOrDefault();
                context.Hastas.Remove(hasta);
                context.SaveChanges();
            }
        }
    }
}
