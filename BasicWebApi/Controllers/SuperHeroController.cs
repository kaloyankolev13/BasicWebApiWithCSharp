using BasicWebApi.Data;
using BasicWebApi.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHEro>>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return Ok(heroes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHEro>> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null) return BadRequest("Hero not found");
            return Ok(hero);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHEro>>> AddHero(SuperHEro hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<SuperHEro>>> UpdateHero(SuperHEro updatedHero)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(updatedHero.Id);
            if (dbHero is null) return BadRequest("Hero not found");

            dbHero.Name = updatedHero.Name;
            dbHero.FirstName = updatedHero.FirstName;
            dbHero.LastName = updatedHero.LastName;
            dbHero.Place = updatedHero.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<SuperHEro>>> DeleteHero(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero is null) return BadRequest("Hero not found");
            _context.SuperHeroes.Remove(dbHero);

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

    }
}
