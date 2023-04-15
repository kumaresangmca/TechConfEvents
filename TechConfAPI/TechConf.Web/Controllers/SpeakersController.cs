using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using TechConf.Models.DTO;
using TechConf.Models.Models;
using TechConf.Services.Contracts;
using TechConf.Web.Filters;

namespace TechConf.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey()]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class SpeakersController : ControllerBase
    {
        private readonly IService<SpeakerDTO> service;
        [FromHeader]
        public string apiKey { get; set; } = string.Empty;
        public SpeakersController(IService<SpeakerDTO> service)
        {
            this.service = service;
        }

        //get: api/speaker
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDTO<List<SpeakerDTO>>))]
        public async Task<ActionResult> Get()
        {
            var resultDTO = new ResultDTO<List<SpeakerDTO>>();
            var data = await service.GetAllAsync(1, 100);
            resultDTO.Results = data;
            return Ok(resultDTO);
        }
        //get: api/speaker/1
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDTO<SpeakerDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(int id)
        {
            var resultDTO = new ResultDTO<SpeakerDTO>();
            var data = await service.GetByIdAsync(id);
            if (data == null)
            {
                resultDTO.ErrorsMessages = new List<string>() { $"Speaker not found with Id : {id}" };
                return NotFound(resultDTO);
            }
            resultDTO.Results = data;
            return Ok(resultDTO);

        }
        //post: api/speaker
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResultDTO<SpeakerDTO?>))]
        public async Task<ActionResult> Post([FromBody] SpeakerDTO speaker)
        {
            var resultDTO = new ResultDTO<SpeakerDTO>();
            var data = await service.AddAsync(speaker);
            if (data == null)
            {
                resultDTO.ErrorsMessages = new List<string>() { $"Issue while creating new speaker" };
                return BadRequest(resultDTO);
            }
            resultDTO.Results = data;
            return CreatedAtAction(nameof(GetById), new { id = data.Id }, data);
        }
        //put: api/speaker/1
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDTO<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] SpeakerDTO speaker)
        {
            var resultDTO = new ResultDTO<bool>();
            var data = await service.EditAsync(id, speaker);
            if (!data)
            {
                resultDTO.ErrorsMessages = new List<string>() { $"Speaker not found with Id: {id}" };
                return NotFound(resultDTO);
            }
            resultDTO.Results = data;
            return Ok(resultDTO);
        }
        //put: api/speaker/1
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultDTO<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var resultDTO = new ResultDTO<bool>();
            var data = await service.DeleteAsync(id);
            if (!data)
            {
                resultDTO.ErrorsMessages = new List<string>() { $"Speaker not found with Id: {id}" };
                return NotFound(resultDTO);
            }
            resultDTO.Results = data;
            return Ok(resultDTO);
        }

    }
}
