using Microsoft.AspNetCore.Mvc;
using RestWineCooler.Manager;
using WineCoolerLib; 

namespace RestWineCooler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CoolerController : Controller
    {
        private CoolerManager _manager = new CoolerManager();

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<CoolerManager>> GetAll(int? coolerIdFilter)
        {
            IEnumerable<Cooler> cooler = _manager.GetAll(coolerIdFilter);
            if (cooler.Count() <= 0)
            {
                return NoContent();
            }     
            return Ok(cooler);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Cooler> GetById(int id)
        {
            Cooler cooler = _manager.GetById(id);
            if (cooler == null)
            {
                return NotFound("No such cooler found, id: " + id);
            }
            return Ok(cooler);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Cooler> Add([FromBody] Cooler newCooler)
        {
            Cooler cooler = new Cooler();

            if (newCooler.CapacityOfBottles == null || newCooler.BottlesInStorage <= 0)
            {
                return BadRequest(newCooler);
            }
            cooler = _manager.Add(newCooler);
            return Created("api/cooler/" + cooler.CoolerId, cooler);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpGet("{id}/AddWine")]
        public ActionResult<Cooler> AddWine([FromRoute]int id)
        {
            Cooler cooler = _manager.GetById(id);
            if (cooler.CoolerIsFull())
            {
                return Conflict();
            }
            int result = _manager.AddWine(id);
            return Ok("Bottles before: : " + (result - 1) + " bottles now : " + result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Cooler> Delete(int id)
        {
            Cooler cooler = _manager.GetById(id);
            if (cooler == null)
            {
                return NotFound("wine not found, id: " + id);
            }
            return Ok(_manager.Delete(id));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public Cooler Update(int id, [FromBody] Cooler value)
        {
            return _manager.Update(id, value);
        }
    }
}
