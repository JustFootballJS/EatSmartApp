using HealthyEating.Client.Core.Providers;
using HealthyEating.Client.Data;
using HealthyEating.Client.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Tests.Core.Providers.FoodRecomenderTests
{
    [TestClass]
   public class RecommendFullPortions_Should
    {
        [TestMethod]
        public void ThrowArgumentException_WhenNutritionisInvalid()
        {
            //Arrange
            var databaseMock = new Mock<IDatabase>();
            var recommender = new FoodRecommender(databaseMock.Object);
            var maxCalories = It.IsAny<decimal>();
            var nutrition = "invalid";
            IQueryable<Recipe> recipes = new List<Recipe>()
            {
                new Recipe()
            }.AsQueryable();
            var setMock = new Mock<DbSet<Recipe>>();
            setMock.As<IQueryable<Recipe>>().Setup(m => m.Provider).Returns(recipes.Provider);
            setMock.As<IQueryable<Recipe>>().Setup(m => m.Expression).Returns(recipes.Expression);
            setMock.As<IQueryable<Recipe>>().Setup(m => m.ElementType).Returns(recipes.ElementType);
            setMock.As<IQueryable<Recipe>>().Setup(m => m.GetEnumerator()).Returns(() => recipes.GetEnumerator());

            databaseMock.SetupGet(x => x.Recipes).Returns(setMock.Object);
            //Act&Assert
            Assert.ThrowsException<ArgumentException>(() => recommender.RecommendFullPortions(maxCalories, nutrition), "Wrong nutrition name!");
        }
    }
}
