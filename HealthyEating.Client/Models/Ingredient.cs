using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            this.Quantities = new HashSet<Quantity>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(20,ErrorMessage ="Name is max 20")]
        public string Name { get; set; }

        public virtual ICollection<Quantity> Quantities { get; set; }

        [Required]
        [Range(0,2000000000,ErrorMessage = "KCAL is between 0 and 2 billion")]
        public decimal KCAL { get; set; }
        [Required]
        [Range(0, 2000000000, ErrorMessage = "Protein is between 0 and 2 billion")]
        public decimal Protein { get; set; }
        [Required]
        [Range(0, 2000000000, ErrorMessage = "Fat is between 0 and 2 billion")]
        public decimal Fat { get; set; }
        [Required]
        [Range(0, 2000000000, ErrorMessage = "Carbohydrate is between 0 and 2 billion")]
        public decimal Carbohydrate { get; set; }
        [Required]
        [Range(0, 2000000000, ErrorMessage = "Fibre is between 0 and 2 billion")]
        public decimal Fibre { get; set; }
    }
}
