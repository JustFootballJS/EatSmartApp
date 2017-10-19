using Bytes2you.Validation;
using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthyEating.Client.Core.Providers
{
    public class FoodRecommender :IFoodRecomender
    {
        private readonly IDatabase database;

        public FoodRecommender(IDatabase database)
        {
            Guard.WhenArgument(database, "database").IsNull().Throw();

            this.database = database;
        }

        public ICollection<Recipe> RecommendFullPortions(decimal maxCalories, string nutrition)
        {
            var allRecipes = this.database.Recipes.ToList();

            int[][] matrix = new int[allRecipes.Count][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[(int)maxCalories+1];
            }

            if (nutrition == "protein")
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int a = 1; a < matrix[i].Length; a++)
                    {
                        if (i > 0)
                        {
                            if (a >= (int)(allRecipes[i].KCAL))
                            {
                                matrix[i][a] = Math.Max(matrix[i - 1][a], (int)allRecipes[i].Protein + matrix[i - 1][a - (int)(allRecipes[i].KCAL)]);
                            }
                            else
                            {
                                matrix[i][a] = matrix[i - 1][a];
                            }

                        }
                        else if (i == 0)
                        {
                            if (allRecipes[i].KCAL <= a)
                            {
                                matrix[i][a] = (int)allRecipes[i].Protein;
                            }
                        }
                    }
                }
            }
            else if (nutrition == "fat")
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int a = 1; a < matrix[i].Length; a++)
                    {
                        if (i > 0)
                        {
                            if (a >= (int)(allRecipes[i].KCAL))
                            {
                                matrix[i][a] = Math.Max(matrix[i - 1][a], (int)allRecipes[i].Fat + matrix[i - 1][a - (int)(allRecipes[i].KCAL)]);
                            }
                            else
                            {
                                matrix[i][a] = matrix[i - 1][a];
                            }

                        }
                        else if (i == 0)
                        {
                            if (allRecipes[i].KCAL <= a)
                            {
                                matrix[i][a] = (int)allRecipes[i].Fat;
                            }
                        }
                    }
                }
            }
            else if (nutrition == "carbohydrate")
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int a = 1; a < matrix[i].Length; a++)
                    {
                        if (i > 0)
                        {
                            if (a >= (int)(allRecipes[i].KCAL))
                            {
                                matrix[i][a] = Math.Max(matrix[i - 1][a], (int)allRecipes[i].Carbohydrate + matrix[i - 1][a - (int)(allRecipes[i].KCAL)]);
                            }
                            else
                            {
                                matrix[i][a] = matrix[i - 1][a];
                            }

                        }
                        else if (i == 0)
                        {
                            if (allRecipes[i].KCAL <= a)
                            {
                                matrix[i][a] = (int)allRecipes[i].Carbohydrate;
                            }
                        }
                    }
                }
            }
            else if (nutrition == "fibre")
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int a = 1; a < matrix[i].Length; a++)
                    {
                        if (i > 0)
                        {
                            if (a >= (int)(allRecipes[i].KCAL))
                            {
                                matrix[i][a] = Math.Max(matrix[i - 1][a], (int)allRecipes[i].Fibre + matrix[i - 1][a - (int)(allRecipes[i].KCAL)]);
                            }
                            else
                            {
                                matrix[i][a] = matrix[i - 1][a];
                            }

                        }
                        else if (i == 0)
                        {
                            if (allRecipes[i].KCAL <= a)
                            {
                                matrix[i][a] = (int)allRecipes[i].Fibre;
                            }
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("Wrong nutrition name!");
            }

            return FindItemsFromTable(matrix, allRecipes);
        }

        private ICollection<Recipe> FindItemsFromTable(int[][] matrix,List<Recipe> allRecipes)
        {
            var answer = new HashSet<Recipe>();
            var rows = matrix.Length - 1;
            var cols = matrix[rows].Length - 1;
            
            while (rows > 0 && cols > 0)
            {
                if (matrix[rows - 1][cols] != matrix[rows][cols])
                {
                    answer.Add(allRecipes[rows]);
                    cols -= (int)allRecipes[rows].KCAL;
                }
                rows--;
            }

            if (matrix[rows][cols] != 0)
            {
                answer.Add(allRecipes[rows]);
            }

            return answer;
        }

        public ICollection<Recipe> RecommendNotFullPortions(decimal maxCalories, string nutrition)
        {
            Recipe[] allFoods;
            if (nutrition == "protein")
            {
                allFoods = this.database.Recipes.OrderByDescending(x => x.Protein / x.KCAL).ToArray();
            }
            else if (nutrition == "fat")
            {
                allFoods = this.database.Recipes.OrderByDescending(x => x.Fat / x.KCAL).ToArray();
            }
            else if (nutrition == "carbohydrates")
            {
                allFoods = this.database.Recipes.OrderByDescending(x => x.Carbohydrate / x.KCAL).ToArray();
            }
            else if (nutrition == "fibre")
            {
                allFoods = this.database.Recipes.OrderByDescending(x => x.Fibre / x.KCAL).ToArray();
            }
            else
            {
                throw new ArgumentException("Invalid nutrition name!");
            }

            var answer = new List<Recipe>();
            var currentIndex = 0;

            while (maxCalories > 0 && currentIndex < allFoods.Length)
            {
                if (maxCalories < allFoods[currentIndex].KCAL)
                {
                    var ratio = maxCalories / allFoods[currentIndex].KCAL;

                    var newRecipe = new Recipe();
                    newRecipe.Name = allFoods[currentIndex].Name;
                    newRecipe.KCAL = allFoods[currentIndex].KCAL*ratio;
                    newRecipe.Protein = allFoods[currentIndex].Protein*ratio;
                    newRecipe.Fibre = allFoods[currentIndex].Fibre*ratio;
                    newRecipe.Fat = allFoods[currentIndex].Fat*ratio;
                    newRecipe.Carbohydrate = allFoods[currentIndex].Carbohydrate * ratio;
                    maxCalories = 0;
                    foreach (var ingredient in allFoods[currentIndex].Quantities)
                    {
                        var newQuantity = new Quantity();
                        newQuantity.Ingredient = ingredient.Ingredient;
                        newQuantity.QuantityValue = ingredient.QuantityValue * ratio;
                        newRecipe.Quantities.Add(newQuantity);
                    }
                    
                    answer.Add(newRecipe);
                }
                else
                {
                    answer.Add(allFoods[currentIndex]);
                    maxCalories -= allFoods[currentIndex].KCAL;
                }
                currentIndex++;
            }

            return answer;
        }
    }
}
