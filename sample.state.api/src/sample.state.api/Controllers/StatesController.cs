using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace sample.state.api.Controllers
{
    [Route("api/[controller]")]
    public class StatesController : Controller
    {
        private List<State> _stateTable = new List<State>();

        public StatesController()
        {
            _stateTable.Add(new State() { StateCode = "100", StateName = "Karnataka" });
            _stateTable.Add(new State() { StateCode = "101", StateName = "Tamilnadu" });
            _stateTable.Add(new State() { StateCode = "102", StateName = "Kerala" });
            _stateTable.Add(new State() { StateCode = "103", StateName = "Maharasthra" });
            _stateTable.Add(new State() { StateCode = "104", StateName = "Andrapradesh" });
        }



        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<State>), 200)]
        public async Task<IActionResult> Get()
        {
            return (IActionResult)Ok(_stateTable);
        }


        [HttpGet("{code}")]
        [ProducesResponseType(typeof(State), 200)]
        public async Task<IActionResult> Get([FromRoute]string code)
        {
            State result = _stateTable.Find(s => s.StateCode.Equals(code, StringComparison.CurrentCultureIgnoreCase));
            return (IActionResult)Ok(result);
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

    public class State
    {
        public string StateCode { get; set; }
        public string StateName { get; set; }
    }
}
