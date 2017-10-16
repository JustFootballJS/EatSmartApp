using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Contracts
{
    public interface IModelFactory 
    {
        Recipe CreateRecipe(string name, string ingredient);

        User CreateUser(string username, string password);
    }
}
