using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using HealthyEating.Client.Managers;
using HealthyEating.Client.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace HealthyEating.Tests.Managers.UserManagerTests
{
    [TestClass]
    public class Logout_Should
    {
        [TestMethod]
        public void MakeLoggedUserNull_WhenItIsInvoked()
        {
            //Arrange
            var databaseMock = new Mock<IDatabase>();
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var modelFactoryMock = new Mock<IModelFactory>();
           

            var userManager = new UserManager(passwordHasherMock.Object, databaseMock.Object, modelFactoryMock.Object);

            userManager.LoggedUser = new User();

            //Act
            userManager.Logout();

            //Assert
            Assert.IsNull(userManager.LoggedUser);
        }

        [TestMethod]
        public void ReturnLogoutMessage_WhenInvoked()
        {
            //Arrange
            var databaseMock = new Mock<IDatabase>();
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var modelFactoryMock = new Mock<IModelFactory>();
           

            var userManager = new UserManager(passwordHasherMock.Object, databaseMock.Object, modelFactoryMock.Object);
            var expected = "Log out successful";
            userManager.LoggedUser = new User();
            //Act
            var actual = userManager.Logout();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThrowException_WhenNoUserIsLogged()
        {
            //Arrange
            var databaseMock = new Mock<IDatabase>();
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var modelFactoryMock = new Mock<IModelFactory>();
         

            var userManager = new UserManager(passwordHasherMock.Object, databaseMock.Object, modelFactoryMock.Object);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => userManager.Logout());
        }
    }
}
