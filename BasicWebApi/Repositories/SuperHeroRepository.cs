using BasicWebApi.Data;
using BasicWebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Repositories
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly DataContext _dataContext;
        public SuperHeroRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddSuperHero(SuperHEro superHero)
        {
            _dataContext.SuperHeroes.Add(superHero);
            _dataContext.SaveChangesAsync();
        }

        public void DeleteSuperHero(int id)
        {
            var heroToDelete = _dataContext.SuperHeroes.Find(id);
            if (heroToDelete != null)
            {
                _dataContext.SuperHeroes.Remove(heroToDelete);
                _dataContext.SaveChanges();
            }

        }

        public List<SuperHEro> GetAllSuperHeroes()
        {
            return _dataContext.SuperHeroes.ToList();
        }

        public SuperHEro? GetSuperHero(int id)
        {
            return _dataContext.SuperHeroes.Find(id);
        }

        public void UpdateSuperHero(SuperHEro superHero)
        {
            var heroToUpdate = _dataContext.SuperHeroes.FirstOrDefault(h => h.Id == superHero.Id);
            if (heroToUpdate is null)
            {
                return;
            }
            heroToUpdate.Name = superHero.Name;
            heroToUpdate.FirstName = superHero.FirstName;
            heroToUpdate.LastName = superHero.LastName;
            heroToUpdate.Place = superHero.Place;

            _dataContext.SaveChangesAsync();
        }
    }
}
