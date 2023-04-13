using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechConf.Models.DTO;
using TechConf.Services.Contracts;

namespace TechConf.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class EventController : ControllerBase
    {
        private readonly IService<EventDTO> service;
        public EventController(IService<EventDTO> service)
        {
            this.service = service;
        }

        //get: api/event
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDTO<List<EventDTO>>))]
        public async Task<ActionResult> Get()
        {
            var resultDTO = new ResultDTO<List<EventDTO>>();
            var data = await service.GetAllAsync(1, 100);
            resultDTO.Results = data;
            return Ok(resultDTO);
        }
        //get: api/event/1
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDTO<EventDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(int id)
        {
            var resultDTO = new ResultDTO<EventDTO>();
            var data = await service.GetByIdAsync(id);
            if (data == null)
            {
                resultDTO.ErrorsMessages = new List<string>() { $"Event not found with Id : {id}" };
                return NotFound(resultDTO);
            }
            resultDTO.Results = data;
            return Ok(resultDTO);

        }
        //post: api/event
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResultDTO<EventDTO?>))]
        public async Task<ActionResult> Post([FromBody] EventDTO speaker)
        {
            var resultDTO = new ResultDTO<EventDTO>();
            var data = await service.AddAsync(speaker);
            if (data == null)
            {
                resultDTO.ErrorsMessages = new List<string>() { $"Issue while creating new event" };
                return BadRequest(resultDTO);
            }
            resultDTO.Results = data;
            return Created(nameof(GetById), new { id = data.Id });
        }
        //put: api/event/1
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDTO<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] EventDTO speaker)
        {
            var resultDTO = new ResultDTO<bool>();
            var data = await service.EditAsync(id, speaker);
            if (!data)
            {
                resultDTO.ErrorsMessages = new List<string>() { $"event not found with Id: {id}" };
                return NotFound(resultDTO);
            }
            resultDTO.Results = data;
            return Ok(resultDTO);
        }
        //put: api/event/1
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDTO<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var resultDTO = new ResultDTO<bool>();
            var data = await service.DeleteAsync(id);
            if (!data)
            {
                resultDTO.ErrorsMessages = new List<string>() { $"event not found with Id: {id}" };
                return NotFound(resultDTO);
            }
            resultDTO.Results = data;
            return Ok(resultDTO);
        }
    }
}
