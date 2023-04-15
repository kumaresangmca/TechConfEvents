using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Net.Mime;
using System.Text;
using TechConf.Models.DTO;
using TechConf.Models.Enum;
using TechConf.Services.Contracts;
using TechConf.Web.Filters;

namespace TechConf.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey()]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class EventsController : ControllerBase
    {
        private readonly IEventService<EventDTO> service;
        [FromHeader]
        public string apiKey { get; set; } = string.Empty;
        public EventsController(IEventService<EventDTO> service)
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
        [Consumes(MediaTypeNames.Application.Json)]
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
            return CreatedAtAction(nameof(GetById), new { id = data.Id }, data);
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

        [HttpGet("download/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileStreamResult))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BadRequestResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DownloadEvents([FromRoute] int id)
        {
            StringBuilder builder = new StringBuilder();
            var eventDTO = await service.DownloadEventByIdAsync(id);
            if(eventDTO == null)
            {
                return BadRequest("Event not exist");
            }
            builder.Append("Speaker Name"); builder.Append(",");
            builder.Append("Event Title"); builder.Append(",");
            builder.Append("Event Description"); builder.Append(",");
            builder.Append("Event Date"); builder.Append(",");
            builder.Append("Event Type"); builder.Append(",");
            builder.Append("Session Name"); builder.Append(",");
            builder.Append("Session Start Time"); builder.Append(",");
            builder.Append("Session End Time");
            builder.AppendLine();
            if (eventDTO.Sessions.Any())
            {
                foreach (var session in eventDTO.Sessions)
                {
                    builder.Append(eventDTO.speaker?.Name); builder.Append(",");
                    builder.Append(eventDTO.Title); builder.Append(",");
                    builder.Append(eventDTO.Description); builder.Append(",");
                    builder.Append(eventDTO.EventDate); builder.Append(",");
                    builder.Append(eventDTO.Type == EventType.Offline ? "Offline" : "Online"); builder.Append(",");
                    builder.Append(session.Name); builder.Append(",");
                    builder.Append(session.StartTime); builder.Append(",");
                    builder.Append(session.EndTime);
                    builder.AppendLine();
                }
            }
            else
            {
                builder.Append(eventDTO.speaker?.Name); builder.Append(",");
                builder.Append(eventDTO.Title); builder.Append(",");
                builder.Append(eventDTO.Description); builder.Append(",");
                builder.Append(eventDTO.EventDate); builder.Append(",");
                builder.Append(eventDTO.Type == EventType.Offline ? "Offline" : "Online"); builder.Append(",");
                builder.AppendLine();
            }
            
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", eventDTO.Title+".csv");
        }
    }
}
