using System.ComponentModel.DataAnnotations;

namespace HealthyEating.Client.Models
{
    public class Quantity
    {
        public int Id { get; set; }
        public int? IngredientId { get; set; }
        public int? RecipeId { get; set; }
        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
        [Required]
        [Range(0,1000000,ErrorMessage ="Quantity must be between 0 and 1mil")]
        public decimal QuantityValue { get; set; }
    }
}
