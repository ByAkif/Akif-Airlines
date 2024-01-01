using Microsoft.AspNetCore.Mvc;
using Web12412412.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebOdev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciApiController : ControllerBase
    {
        BiletContext k = new BiletContext();


        [HttpGet]
        public List<Kullanici> GetKullanici()
        {
            return k.Kullanicilar.ToList();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            var y = k.Kullanicilar.Find(id);
            return y.FirstName;
        }

        [HttpPost]

        public void PostKullanici(Kullanici kullanici)
        {
            k.Kullanicilar.Add(kullanici);
            k.SaveChanges();
        }

        [HttpPut("{id}")]
        public void PutKullanici(int id, Kullanici kullanici)
        {
            var x = k.Kullanicilar.Find(id);
            x.FirstName = kullanici.FirstName;
            x.LastName = kullanici.LastName;
            x.Email = kullanici.Email;
            x.Password = kullanici.Password;
            x.PhoneNumber = kullanici.PhoneNumber;
            k.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteKullanici(int id)
        {
            var x = k.Kullanicilar.Find(id);
            k.Kullanicilar.Remove(x);
            k.SaveChanges();
        }

        // GET api/<UcakApiController>/5


        // POST api/<UcakApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UcakApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UcakApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
