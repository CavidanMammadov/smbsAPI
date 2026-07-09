using Microsoft.AspNetCore.Mvc;
using Smbs.Application.DTOs.CorporateTraining;
using Smbs.Application.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateTrainingsController(ICorporateTrainingService _service) : ControllerBase
    {
        // GET: api/<CorporateTrainingsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var datas = await _service.GetAllAsync();
            return Ok(datas);
        }
        // GET api/<CorporateTrainingsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return Ok(data);
        }

        // POST api/<CorporateTrainingsController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CorporateTrainingCreateDto dto)
        {
           int id = await _service.CreateAsync(dto);
            return Ok(new {Id=id});
        }

        // PUT api/<CorporateTrainingsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CorporateTrainingUpdateDto dto)
        {await _service.UpdateAsync(id, dto);
            return Ok("Updated");
        }

        // DELETE api/<CorporateTrainingsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Removed");
        }
    }
}
