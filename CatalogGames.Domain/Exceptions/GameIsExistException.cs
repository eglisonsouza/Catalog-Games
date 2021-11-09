using System;

namespace CatalogGames.Domain.Exceptions
{
    public class GameIsExistException : Exception
    {
        public GameIsExistException() : base("There is already a registered game with this name for this producer.")
        {
        }
    }
}