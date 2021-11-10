using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogGames.Domain.Entities;
using CatalogGames.Domain.Interfaces.Repositories;
using CatalogGames.Infra.Persistence.EF;

namespace CatalogGames.Infra.Persistence.Repositories
{
    public class GameRepository: IGameRepository
    {
        private readonly GameDbContext _context;

        public GameRepository(GameDbContext context)
        {
            _context = context;
        }

        public Task<List<Game>> GetAll(int page, int quantity)
        {
            return Task.FromResult(_context.Games.Skip((page - 1) * quantity).Take(quantity).ToList());
        }

        public Task<Game> Get(Guid id)
        {
            return Task.FromResult(_context.Games.FirstOrDefault(x => x.Id.Equals(id)));
        }

        public Task<List<Game>> Get(string name, string producer)
        {
            return Task.FromResult(_context.Games.Where(x => x.Name.Equals(name) && x.Producer.Equals(producer)).ToList());
        }

        public Task Insert(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Update(Game game)
        {
            _context.Update(game);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            _context.Remove(_context.Games.Find(id));
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}