using Bytes2you.Validation;
using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Commands
{
    public class ListRecipesCommand : ICommand
    {
        private readonly IDatabase db;
        public ListRecipesCommand(IDatabase db)
        {
            Guard.WhenArgument(db, "db").IsNull().Throw();

            this.db = db;
        }
        public string Execute()
        {
            var recipes = db.Recipes;

            if (recipes.Count() == 0)
            {
                return "There are no created recipes.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, recipes);
        }
    }
}
