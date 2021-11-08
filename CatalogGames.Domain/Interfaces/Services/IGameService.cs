using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogGames.Domain.Arguments.InputModel;
using CatalogGames.Domain.Arguments.ViewModel;

namespace CatalogGames.Domain.Interfaces.Services
{
    public interface IGameService
    {
        Task<List<GameViewModel>> GetAll(int page, int quantity);

        Task<GameViewModel> Get(Guid id);

        Task<GameViewModel> Insert(GameInputModel game);

        Task Update(Guid id, GameInputModel game);

        Task Update(Guid id, double price);

        Task Delete(Guid id);
        
    }
}