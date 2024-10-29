using BasicWebApi.Data;
using BasicWebApi.Entity;
using BasicWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroRepository _superHeroRepository;

        public SuperHeroController(ISuperHeroRepository superHeroRepository)
        {
            _superHeroRepository = superHeroRepository;
        }

        [HttpGet]
        public IActionResult GetAllSuperHeroes()
        {
            var superHeroes = _superHeroRepository.GetAllSuperHeroes();
            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public IActionResult GetSuperHero(int id)
        {
            var superHero = _superHeroRepository.GetSuperHero(id);
            if (superHero == null)
            {
                return NotFound();
            }
            return Ok(superHero);
        }

        [HttpPost]
        public IActionResult CreateSuperHero(SuperHEro superHero)
        {
            if (superHero == null)
            {
                return BadRequest();
            }
            _superHeroRepository.AddSuperHero(superHero);
            return CreatedAtAction(nameof(GetSuperHero), new {id = superHero.Id },superHero);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateSuperHero(int id, SuperHEro superHero)
        {
            if(superHero == null || id != superHero.Id)
            {
                return BadRequest();
            }
            var existingCharacter = _superHeroRepository.GetSuperHero(id);
            if(existingCharacter == null)
                return NotFound();

            _superHeroRepository.UpdateSuperHero(superHero);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSuperHero(int id)
        {
            var superHero = _superHeroRepository.GetSuperHero(id);
            if (superHero == null)
                return NotFound();

            _superHeroRepository.DeleteSuperHero(id);
            return NoContent();

        }

    }
}
