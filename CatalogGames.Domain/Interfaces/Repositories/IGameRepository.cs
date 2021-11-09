using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogGames.Domain.Entities;

namespace CatalogGames.Domain.Interfaces.Repositories
{
    public interface IGameRepository
    {
        Task<List<Game>> GetAll(int page, int quantity);

        Task<Game> Get(Guid id);
        Task<List<Game>> Get(string name, string producer);

        Task<Game> Insert(Game game);
        
        Task Update(Game game);

        Task Delete(Guid id);
    }
}