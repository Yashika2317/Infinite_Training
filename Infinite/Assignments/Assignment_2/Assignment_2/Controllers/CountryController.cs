using Assignment_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment_2.Controllers
{
    public class CountryController : ApiController
    {
        static List<Country> countryList = new List<Country>()
        {
            new Country { ID = 1, CountryName = "USA", Capital = "Washington D.C." },
            new Country { ID = 2, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 3, CountryName = "UK", Capital = "London" }
        };

        [HttpGet]
        [Route("All")]
        public IEnumerable<Country> Get()
        {
            return countryList;
        }

        [HttpGet]
        [Route("ById")]
        public IHttpActionResult GetById(int id)
        {
            var country = countryList.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(Country country)
        {
            countryList.Add(country);
            return Ok(countryList);
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(int id, Country country)
        {
            var existingCountry = countryList.FirstOrDefault(c => c.ID == id);
            if (existingCountry == null)
            {
                return NotFound();
            }
            existingCountry.CountryName = country.CountryName;
            existingCountry.Capital = country.Capital;
            return Ok(countryList);
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(int id)
        {
            var country = countryList.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            countryList.Remove(country);
            return Ok(countryList);
        }
    }
}