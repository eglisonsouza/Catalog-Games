using System;

namespace CatalogGames.Domain.Exceptions
{
    public class GameIsNotExistException : Exception
    {
        public GameIsNotExistException():base("Game is not exist.")
        {
        }
    }
}