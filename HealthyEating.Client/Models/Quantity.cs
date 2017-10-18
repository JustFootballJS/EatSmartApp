using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Models
{
    public class Quantity
    {
        public int Id { get; set; }
        public int? IngredientId { get; set; }
        public int? RecipeId { get; set; }
        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
        public decimal QuantityValue { get; set; }
    }
}
