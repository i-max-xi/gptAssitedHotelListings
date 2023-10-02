using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gptAssistedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly List<string> _values = new List<string>
        {
            "value1",
            "value2",
            "value3"
        };

        // GET: api/Values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _values;
        }

        // GET: api/Values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id >= 0 && id < _values.Count)
            {
                return _values[id];
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Values
        [HttpPost]
        public ActionResult<string> Post([FromBody] string value)
        {
            _values.Add(value);
            return CreatedAtAction(nameof(Get), new { id = _values.Count - 1 }, value);
        }

        // PUT: api/Values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id >= 0 && id < _values.Count)
            {
                _values[id] = value;
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id >= 0 && id < _values.Count)
            {
                _values.RemoveAt(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
