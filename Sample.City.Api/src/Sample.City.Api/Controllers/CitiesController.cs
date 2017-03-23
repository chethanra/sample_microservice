using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sample.City.Api.Controllers
{
    [Route("api/")]
    public class CitiesController : Controller
    {
        private List<City> _cities = new List<City>();

        public CitiesController()
        {
            _cities.Add(new City() { CityCode = "1000", CityName = "Bangalore", StateCode = "100" });
            _cities.Add(new City() { CityCode = "1001", CityName = "Mysore", StateCode = "100" });
            _cities.Add(new City() { CityCode = "1002", CityName = "Mangalore", StateCode = "100" });
            _cities.Add(new City() { CityCode = "1003", CityName = "Hubballi", StateCode = "100" });

            _cities.Add(new City() { CityCode = "2000", CityName = "Chennai", StateCode = "101" });
            _cities.Add(new City() { CityCode = "2001", CityName = "Madurai", StateCode = "101" });
            _cities.Add(new City() { CityCode = "2002", CityName = "Rameshwara", StateCode = "101" });
            _cities.Add(new City() { CityCode = "2003", CityName = "Salem", StateCode = "101" });

            _cities.Add(new City() { CityCode = "3000", CityName = "Cochin", StateCode = "102" });
            _cities.Add(new City() { CityCode = "3001", CityName = "Travancore", StateCode = "102" });
            _cities.Add(new City() { CityCode = "3002", CityName = "Maye", StateCode = "102" });
            
            _cities.Add(new City() { CityCode = "4000", CityName = "Mumbai", StateCode = "103" });
            _cities.Add(new City() { CityCode = "4001", CityName = "Pune", StateCode = "103" });

            _cities.Add(new City() { CityCode = "5001", CityName = "Hydrabad", StateCode = "104" });
            _cities.Add(new City() { CityCode = "5003", CityName = "Vishakapatanam", StateCode = "104" });
        }

        [HttpGet("cities")]
        [ProducesResponseType(typeof(IReadOnlyCollection<City>), 200)]
        public async Task<IActionResult> Get()
        {
            return (IActionResult)Ok(_cities);
        }

        // GET api/values/5
        [HttpGet("cities/{code}")]
        [ProducesResponseType(typeof(City), 200)]
        public async Task<IActionResult> Get([FromRoute]string code)
        {
            City result = _cities.Find(s => s.CityCode.Equals(code, StringComparison.CurrentCultureIgnoreCase));
            return (IActionResult)Ok(result);
        }

        [HttpGet("states/{stateCode}/cities")]
        [ProducesResponseType(typeof(IReadOnlyCollection<City>), 200)]
        public async Task<IActionResult> GetCities([FromRoute]string stateCode)
        {
            List<City> result = _cities.FindAll(s => s.StateCode.Equals(stateCode, StringComparison.CurrentCultureIgnoreCase));
            return (IActionResult)Ok(result);
        }


        [HttpGet("states/{stateCode}/cities/{cityCode}")]
        [ProducesResponseType(typeof(City), 200)]
        public async Task<IActionResult> GetCities([FromRoute]string stateCode, [FromRoute]string cityCode)
        {
            List<City> result = _cities.FindAll(s => s.StateCode.Equals(stateCode, StringComparison.CurrentCultureIgnoreCase)
                                        && s.CityCode.Equals(cityCode, StringComparison.CurrentCultureIgnoreCase));
            if (result?.Count > 0)
                return (IActionResult)Ok(result[0]);

            return (IActionResult)Ok(new City());
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }

    public class City
    {
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string StateCode { get; set; }

    }
}
