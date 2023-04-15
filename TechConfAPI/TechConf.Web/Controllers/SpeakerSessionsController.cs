using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using TechConf.Models.DTO;
using TechConf.Services.Contracts;
using TechConf.Web.Filters;

namespace TechConf.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [ApiKey()]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class SpeakerSessionsController : ControllerBase
    {
        private readonly ISpeakerSessionService<SpeakerSessionDTO> service;
        [FromHeader]
        public string apiKey { get; set; } = string.Empty;
        public SpeakerSessionsController(ISpeakerSessionService<SpeakerSessionDTO> service)
        {
            this.service = service;
        }

        //get: api/speakersession/1
        [HttpGet("{eventId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDTO<List<SpeakerSessionDTO>>))]
        public async Task<ActionResult> GetByEventId(int eventId)
        {
            var resultDTO = new ResultDTO<List<SpeakerSessionDTO>>();
            var data = await service.GetAllByEventIdAsync(eventId, 1, 100);
            resultDTO.Results = data;
            return Ok(resultDTO);
        }
        //get: api/speakersession/1
        [HttpGet("{eventId:int}/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDTO<SpeakerSessionDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(int eventId, int id)
        {
            var resultDTO = new ResultDTO<SpeakerSessionDTO>();
            var data = await service.GetByEventAndSessionIdAsync(eventId, id);
            if (data == null)
            {
                resultDTO.ErrorsMessages = new List<string>() { $"Speaker Session not found with Id : {id}" };
                return NotFound(resultDTO);
            }
            resultDTO.Results = data;
            return Ok(resultDTO);

        }
        //post: api/speakersession
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResultDTO<SpeakerSessionDTO?>))]
        public async Task<ActionResult> Post([FromBody] SpeakerSessionDTO speaker)
        {
            var resultDTO = new ResultDTO<SpeakerSessionDTO>();
            var data = await service.AddAsync(speaker);
            if (data == null)
            {
                resultDTO.ErrorsMessages = new List<string>() { $"Issue while creating new speaker session" };
                return BadRequest(resultDTO);
            }
            resultDTO.Results = data;
            return CreatedAtAction(nameof(GetById), new { eventId = data.EventId, id = data.Id }, data);
        }
        //put: api/speakersession/1
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDTO<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] SpeakerSessionDTO speaker)
        {
            var resultDTO = new ResultDTO<bool>();
            var data = await service.EditAsync(id, speaker);
            if (!data)
            {
                resultDTO.ErrorsMessages = new List<string>() { $"Speaker session not found with Id: {id}" };
                return NotFound(resultDTO);
            }
            resultDTO.Results = data;
            return Ok(resultDTO);
        }
        //put: api/speakersession/1
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDTO<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var resultDTO = new ResultDTO<bool>();
            var data = await service.DeleteAsync(id);
            if (!data)
            {
                resultDTO.ErrorsMessages = new List<string>() { $"Speaker Sesssion not found with Id: {id}" };
                return NotFound(resultDTO);
            }
            resultDTO.Results = data;
            return Ok(resultDTO);
        }
    }
}
