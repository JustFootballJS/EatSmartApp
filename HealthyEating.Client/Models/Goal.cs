using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Models
{
    public class Goal
    {
        public Goal()
        {

        }

        public int Id { get; set; }
        
        public int MaxKcal { get; set; }

        public int WantedWeight { get; set; }

        public bool isDeleted { get; set; }


        public virtual User User { get; set; }
    }
}
