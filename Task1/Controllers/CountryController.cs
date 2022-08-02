using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CountryController : ApiController
    {
        List<Countries> country = new List<Countries>()
        {
            new Countries() { countryId=1 , countryName = "India" , countryCapital = "Delhi"},
            new Countries() { countryId = 2 , countryName = "USA" , countryCapital = "Washington DC"},
            new Countries() { countryId=3 , countryName = "Nepal" , countryCapital = "Kathmandu"}

        };

        [HttpGet]
        public IHttpActionResult getCoutry() 
        {
            return Ok(country);
        }

        public IHttpActionResult getCountryById(int id) 
        {
            Countries obj = country.Find(item => item.countryId == id);

            if (obj != null)
            {
                return Ok(obj);
            }
            else { 
                return NotFound();
            }
        }

        [HttpPost]
        [Route("Deletecountry/{id}")]
        public IHttpActionResult addCountry(Countries obj) 
        {
            country.Add(obj);
            return Ok(country);
        }

        [HttpPut]
        public IHttpActionResult updateCountry(Countries obj) 
        {
            Countries upObj = country.Find(item => item.countryId == obj.countryId);
            if (upObj != null)
            {
                country.Remove(upObj);
                country.Add(obj);
                return Ok(country);

            }
            else 
            {
                return NotFound();
            }
           
        }

        [HttpDelete]
        public IHttpActionResult removeCountry(int id) 
        {
            Countries todelete = country.Find(item => item.countryId == id);

            if (todelete != null)
            {
                country.Remove(todelete);
                return Ok(country);
            }
            else {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("countryName")]

        public IHttpActionResult getCountryName(int id) 
        {
            Countries obj = country.Find(item => item.countryId == id);
            if (obj != null)
            {
                return Ok(obj.countryName);
            }
            else {
                return NotFound();
                 }
        }

    }
}
