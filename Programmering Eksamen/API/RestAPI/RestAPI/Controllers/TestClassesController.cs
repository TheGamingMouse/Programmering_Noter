using CLassLib;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestClassesController : ControllerBase
    {
        private TestClassRepository _data;
        public TestClassesController(TestClassRepository repo)
        {
            _data = repo;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Get()
        {
            IEnumerable<TestClass> data = _data.Get();

            if (data.ToList().Count == 0)
            {
                return NoContent();
            }
            return Ok(data);
        }

        [HttpGet()]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetById(int id)
        {
            try
            {
                TestClass data = _data.GetById(id);
                return Ok(data);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet()]
        [Route("stock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult GetLowStock([FromQuery] Filter filter)
        {
            List<TestClass> data = _data.GetLowStock((int)filter.StockLevel).ToList();

            if (filter.StockLevel is not null)
            {
                data = data.FindAll(d => d.InStock <= filter.StockLevel);
            }

            if (data.ToList().Count() == 0)
            {
                return NoContent();
            }
            return Ok(data);
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] TestClass tClass)
        {
            TestClass data = _data.Add(tClass);
            return Created($"api/testclasses/{data.Id}", data);
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] TestClass tClass)
        {
            try
            {
                TestClass data = _data.Update(id, tClass);
                return Ok(data);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            try
            {
                TestClass data = _data.Delete(id);
                return Ok(data);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}