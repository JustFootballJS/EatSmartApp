using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Quantities = new HashSet<Quantity>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        //public virtual ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Quantity> Quantities {get; set;}
        public decimal KCAL { get; set; }

        public decimal Protein { get; set; }

        public decimal Fat { get; set; }

        public decimal Carbohydrate { get; set; }

        public decimal Fibre { get; set; }
    }
}