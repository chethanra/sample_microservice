using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Sample.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class StatesController : Controller
    {
        private string _stateUrl = "http://localhost:8000/api/states";
        private string _cityUrl = "http://localhost:6001/api/";

        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<State>), 200)]
        public async Task<IActionResult> Get()
        {
            List<State> states = new List<State>();
            HttpResponseMessage responseMessage;
            using (var httpClient = new HttpClient())
            {
                responseMessage = await httpClient.GetAsync(new Uri(_stateUrl));
            }

            if (responseMessage.IsSuccessStatusCode)
            {
                states = JsonConvert.DeserializeObject<List<State>>(await responseMessage.Content.ReadAsStringAsync());
            }

            return (IActionResult)Ok(states);
        }

        [HttpGet("{stateCode}")]
        [ProducesResponseType(typeof(State), 200)]
        public async Task<IActionResult> Get([FromRoute]string stateCode)
        {
            State result = new State();
            
            HttpResponseMessage responseMessage;
            string uri = $"{_stateUrl}/{stateCode}";
            using (var httpClient = new HttpClient())
            {
                responseMessage = await httpClient.GetAsync(new Uri(uri));
            }

            if (responseMessage.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<State>(await responseMessage.Content.ReadAsStringAsync());
            }
            return (IActionResult)Ok(result);
        }

        [HttpGet("{stateCode}/cities")]
        [ProducesResponseType(typeof(IReadOnlyCollection<City>), 200)]
        public async Task<IActionResult> GetCities([FromRoute] string stateCode)
        {

            List<City> cities = new List<City>();
            string uri = $"{_cityUrl}states/{stateCode}/cities";
            HttpResponseMessage responseMessage;
            using (var httpClient = new HttpClient())
            {
                responseMessage = await httpClient.GetAsync(new Uri(uri));
            }

            if (responseMessage.IsSuccessStatusCode)
            {
                cities = JsonConvert.DeserializeObject<List<City>>(await responseMessage.Content.ReadAsStringAsync());
            }

            return (IActionResult)Ok(cities);
        }

        [HttpGet("{stateCode}/cities/{cityCode}")]
        [ProducesResponseType(typeof(City), 200)]
        public async Task<IActionResult> GetCity([FromRoute] string stateCode, [FromRoute] string cityCode)
        {
            City city = new City();
            HttpResponseMessage responseMessage;
            string uri = $"{_cityUrl}states/{stateCode}/cities/{cityCode}";
            using (var httpClient = new HttpClient())
            {
                responseMessage = await httpClient.GetAsync(new Uri(uri));
            }

            if (responseMessage.IsSuccessStatusCode)
            {
                city = JsonConvert.DeserializeObject<City>(await responseMessage.Content.ReadAsStringAsync());
            }

            return (IActionResult)Ok(city);
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

    public class State
    {
        public string StateCode { get; set; }
        public string StateName { get; set; }
    }
}
