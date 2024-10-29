using BasicWebApi.Entity;

namespace BasicWebApi.Repositories
{
    public interface ISuperHeroRepository
    {
        List<SuperHEro> GetAllSuperHeroes();
        SuperHEro? GetSuperHero(int id);
        void AddSuperHero(SuperHEro superHero);
        void UpdateSuperHero(SuperHEro superHero);
        void DeleteSuperHero(int id);
    }
}
