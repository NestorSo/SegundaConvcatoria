using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SegundaConvcatoria.Models;
using SegundaConvcatoria.Models.Dto;
using SegundaConvcatoria.RepostoryF.IRepositoryF;

namespace SegundaConvcatoria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeliculasController : ControllerBase
    {


        private readonly ILogger<PeliculasController> _logger;
        public readonly IMapper _mapper;
        public readonly IPeliculasRepository _Repos;

        public PeliculasController(ILogger<PeliculasController> logger, IMapper mapper, IPeliculasRepository Repos)
        {
            _logger = logger;
            _mapper = mapper;
            _Repos = Repos;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PeliculaDto>>> Get()
        {
            _logger.LogInformation("get All pelis");

            var clientesList = await _Repos.GetAll();

            return Ok(_mapper.Map<IEnumerable<PeliculaDto>>(clientesList));
        }

        [HttpGet("{id:int}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PeliculaDto>> Get(int id)
        {
            if (id == 0)
            {
                _logger.LogError($"Error al traer pelis con Id {id}");
                return BadRequest();
            }
            var pelis = await _Repos.Get(s => s.IdPelicula == id);

            if (pelis == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PeliculaDto>(pelis));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PeliculaDto>> AddR([FromBody] PeliculacreateDto  CreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (CreateDto == null)
            {
                return BadRequest(CreateDto);
            }

            Pelicula modelo = _mapper.Map<Pelicula>(CreateDto);

            await _Repos.Add(modelo);

            return CreatedAtRoute("Get", new { id = modelo.IdPelicula }, modelo);
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
            var pelis = await _Repos.Get(s => s.IdPelicula == id);

            if (pelis == null)
            {
                return NotFound();
            }

            _Repos.Remove(pelis);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] PeliculaUpdatedto UpdateDto)
        {
            if (UpdateDto == null || id != UpdateDto.IdPelicula)
            {
                return BadRequest();
            }

            Pelicula modelo = _mapper.Map<Pelicula>(UpdateDto);

            _Repos.Update(modelo);

            return NoContent();
        }



    }
}