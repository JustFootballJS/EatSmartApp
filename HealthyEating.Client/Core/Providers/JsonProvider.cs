using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HealthyEating.Client.Core.Contracts;

namespace HealthyEating.Client.Core.Providers
{
    public class JsonProvider :IJsonProvider
    {
        public ICollection<Ingredient> SeedIngredients(string fileName)
        {
            ICollection<Ingredient> ingredients;
            using (StreamReader reader = new StreamReader($"../../IngredientsForSeeding/{fileName}"))
            {
                var wholeFile = reader.ReadToEnd();
                ingredients = JsonConvert.DeserializeObject<ICollection<Ingredient>>(wholeFile);
            }
            return ingredients;
        }
    }
}
