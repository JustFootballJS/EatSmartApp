using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Contracts
{
    public interface IIngredientManager
    {
        string Create(string name, string kcal, string protein, string fat, string fibre, string carbs);

        string Delete(string name);
    }
}
