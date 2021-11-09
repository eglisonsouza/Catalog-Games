using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogGames.Domain.Arguments.InputModel;
using CatalogGames.Domain.Arguments.ViewModel;
using CatalogGames.Domain.Entities;
using CatalogGames.Domain.Exceptions;
using CatalogGames.Domain.Interfaces.Repositories;
using CatalogGames.Domain.Interfaces.Services;

namespace CatalogGames.Domain.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<List<GameViewModel>> GetAll(int page, int quantity)
        {
            return (await _gameRepository.GetAll(page, quantity))
                .Select(game =>
                    new GameViewModel()
                    {
                        Id = game.Id,
                        Name = game.Name,
                        Producer = game.Producer,
                        Price = game.Price
                    }
                ).ToList();
        }

        public async Task<GameViewModel> Get(Guid id)
        {
            var game = await _gameRepository.Get(id);

            if (game == null) return null;

            return new GameViewModel()
            {
                Id = game.Id,
                Name = game.Name,
                Producer = game.Producer,
                Price = game.Price
            };
        }

        public async Task<GameViewModel> Insert(GameInputModel game)
        {
            if ((await _gameRepository.Get(game.Name, game.Producer)).Any())
                throw new GameIsExistException();

            var gameIsert = new Game()
            {
                Id = Guid.NewGuid(),
                Name = game.Name,
                Producer = game.Producer,
                Price = game.Price
            };

            await _gameRepository.Insert(gameIsert);

            return new GameViewModel()
            {
                Id = gameIsert.Id,
                Name = gameIsert.Name,
                Producer = gameIsert.Producer,
                Price = gameIsert.Price
            };
        }

        public async Task Update(Guid id, GameInputModel game)
        {
            var entityGame = await _gameRepository.Get(id);
            if (entityGame == null)
                throw new GameIsNotExistException();
            entityGame.Name = game.Name;
            entityGame.Producer = game.Producer;
            entityGame.Price = game.Price;

            await _gameRepository.Update(entityGame);
        }

        public async Task Update(Guid id, double price)
        {
            var entityGame = await _gameRepository.Get(id);
            if (entityGame == null)
                throw new GameIsNotExistException();
            entityGame.Price = price;

            await _gameRepository.Update(entityGame);        }

        public async Task Delete(Guid id)
        {
            var entityGame = await _gameRepository.Get(id);
            if (entityGame == null)
                throw new GameIsNotExistException();
            await _gameRepository.Delete(id);
        }
    }
}