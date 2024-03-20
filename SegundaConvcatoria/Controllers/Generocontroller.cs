using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SegundaConvcatoria.Models;
using SegundaConvcatoria.Models.Dto;
using SegundaConvcatoria.RepostoryF.IRepositoryF;
using System.Data;

namespace SegundaConvcatoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Generocontroller : ControllerBase
    {

        private readonly IGenerosRepositoy _Repos;
        private readonly ILogger<Generocontroller> _logger;
        private readonly IMapper _mapper;

        public Generocontroller(ILogger<Generocontroller> logger, IGenerosRepositoy Repo, IMapper mapper)
        {
            _logger = logger;

            _mapper = mapper;
            _Repos = Repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GeneroDto>>> Get()
        {
            _logger.LogInformation("Obtener los generos");

            var Generos = await _Repos.GetAll();

            return Ok(_mapper.Map<IEnumerable<GeneroDto>>(Generos));
        }

        [HttpGet("{id:int}", Name = "GetGenero")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GeneroDto>> Get(int id)
        {
            if (id == 0)
            {
                _logger.LogError($"Error al traer genero con Id {id}");
                return BadRequest();
            }
            var genero = await _Repos.Get(s => s.ID == id);

            if (genero == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GeneroDto>(genero));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GeneroDto>> Add([FromBody] GeneroCreateDto CreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _Repos.Get(s => s.Nombre.ToLower() == CreateDto.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("Genero", "¡El genero con ese Nombre ya existe!");
                return BadRequest(ModelState);
            }

            if (CreateDto == null)
            {
                return BadRequest(CreateDto);
            }

            Genero modelo = _mapper.Map<Genero>(CreateDto);



            await _Repos.Add(modelo);

            return CreatedAtRoute("GeytGenero", new { id = modelo.ID }, modelo);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var genero = await _Repos.Get(s => s.ID == id);

            if (genero == null)
            {
                return NotFound();
            }

            await _Repos.Remove(genero);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] GeneroUpdateDto UpdateDto)
        {
            if (UpdateDto == null || id != UpdateDto.ID)
            {
                return BadRequest();
            }

            Genero modelo = _mapper.Map<Genero>(UpdateDto);



            await _Repos.Update(modelo);

            return NoContent();
        }

    }
}
