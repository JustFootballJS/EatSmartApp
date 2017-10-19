using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Contracts
{
    public interface IRecipeManager
    {
        string CreateRecipe(string name, ICollection<Ingredient> ingredients);

        string DeleteRecipe(int id);

        string ReadRecipe(int id);

        //string ModifyRecipe(int id);
    }
}
