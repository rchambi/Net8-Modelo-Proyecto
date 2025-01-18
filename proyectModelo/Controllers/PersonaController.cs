using Microsoft.AspNetCore.Mvc;
using proyectModelo.Modelos;
using proyectModelo.Services;

namespace proyectModelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonasController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cantidad =  _personaService.GetCantidadPersonas();
            var personas = await _personaService.GetAll();
            return Ok(personas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var persona = await _personaService.GetById(id);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Persona persona)
        {
            await _personaService.Add(persona);
            return CreatedAtAction(nameof(GetById), new { id = persona.Id }, persona);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Persona persona)
        {
            if (id != persona.Id)
            {
                return BadRequest();
            }
            await _personaService.Update(persona);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personaService.Delete(id);
            return NoContent();
        }
    }

}
