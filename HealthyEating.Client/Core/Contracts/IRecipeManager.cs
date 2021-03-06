﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Contracts
{
    public interface IRecipeManager
    {
        string CreateRecipe(string name, string quanitites, string ingredients);

        string DeleteRecipe(string name);

        string RecipeAsString(string name);
    }
}
