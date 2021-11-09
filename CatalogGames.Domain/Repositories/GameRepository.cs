using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogGames.Domain.Entities;
using CatalogGames.Domain.Interfaces.Repositories;

namespace CatalogGames.Domain.Repositories
{
    public class GameRepository : IGameRepository
    {
        private static Dictionary<Guid, Game> games = new Dictionary<Guid, Game>()
        {
            {
                Guid.Parse("26a1688f-d073-40a8-8f7a-364f937aaa1a"),
                new Game()
                {
                    Id = Guid.Parse("26a1688f-d073-40a8-8f7a-364f937aaa1a"), Name = "GTA IV", Price = 523.65,
                    Producer = "Rockseat"
                }
            },
            {
                Guid.Parse("ecfc85a9-8f77-47c1-80ad-e663de37f334"),
                new Game()
                {
                    Id = Guid.Parse("ecfc85a9-8f77-47c1-80ad-e663de37f334"), Name = "GTA IV", Price = 523.65,
                    Producer = "Rockseat"
                }
            },
            {
                Guid.Parse("f57b403d-644c-4e2e-870f-3ecbdd346029"),
                new Game()
                {
                    Id = Guid.Parse("f57b403d-644c-4e2e-870f-3ecbdd346029"), Name = "GTA IV", Price = 523.65,
                    Producer = "Rockseat"
                }
            },

            {
                Guid.Parse("acc4db82-be37-47f4-a7f2-98b27d3ed579"),
                new Game()
                {
                    Id = Guid.Parse("acc4db82-be37-47f4-a7f2-98b27d3ed579"), Name = "GTA IV", Price = 523.65,
                    Producer = "Rockseat"
                }
            },
            {
                Guid.Parse("4784f395-3c2c-4a4d-be69-b520dd50d472"),
                new Game()
                {
                    Id = Guid.Parse("4784f395-3c2c-4a4d-be69-b520dd50d472"), Name = "GTA IV", Price = 523.65,
                    Producer = "Rockseat"
                }
            },
            {
                Guid.Parse("1ac2113c-7391-4ea7-b90a-0a10b0ad7b91"),
                new Game()
                {
                    Id = Guid.Parse("1ac2113c-7391-4ea7-b90a-0a10b0ad7b91"), Name = "GTA IV", Price = 523.65,
                    Producer = "Rockseat"
                }
            },
            {
                Guid.Parse("c5646508-8c02-4d77-b410-bf68f73a3947"),
                new Game()
                {
                    Id = Guid.Parse("c5646508-8c02-4d77-b410-bf68f73a3947"), Name = "GTA IV", Price = 523.65,
                    Producer = "Rockseat"
                }
            },
            {
                Guid.Parse("1e1e9974-2dc6-4cc9-a79b-a1264cd1fc7e"),
                new Game()
                {
                    Id = Guid.Parse("1e1e9974-2dc6-4cc9-a79b-a1264cd1fc7e"), Name = "GTA IV", Price = 523.65,
                    Producer = "Rockseat"
                }
            }
        };

        public Task<List<Game>> GetAll(int page, int quantity)
        {
            return Task.FromResult(games.Values.Skip((page - 1) * quantity).Take(quantity).ToList());
        }

        public Task<Game> Get(Guid id)
        {
            if (!games.ContainsKey(id)) return null;

            return Task.FromResult(games[id]);
        }

        public Task<List<Game>> Get(string name, string producer)
        {
            return Task.FromResult(games.Values.Where(game => game.Name.Equals(name) && game.Producer.Equals(producer))
                .ToList());
        }

        public Task Insert(Game game)
        {
            games.Add(game.Id, game);
            return Task.CompletedTask;
        }

        public Task Update(Game game)
        {
            games[game.Id] = game;
            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            games.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}