using System.ComponentModel.DataAnnotations;

namespace CatalogGames.Domain.Arguments.InputModel
{
    public class GameInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The game name must contain between 3 and 100 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "The producer name must contain between 1 and 100 characters.")]
        public string Producer { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "The price must be at least R$1.00 and at most R$1000.00.")]
        public double Price { get; set; }
    }
}