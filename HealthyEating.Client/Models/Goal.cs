using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthyEating.Client.Models
{
    public class Goal
    {
        public Goal()
        {

        }

       [Key,ForeignKey("User")]
        public int UserId { get; set; }
        
        [Required]
        [Range(0,int.MaxValue,ErrorMessage =("Max kcal must be between 0 and 2 billion"))]
        public int MaxKcal { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = ("Wanted weight must be between 0 and 2 billion"))]
        public int WantedWeight { get; set; }

        public bool isDeleted { get; set; }

        public virtual User User { get; set; }
    }
}
