using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using HealthyEating.Client.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace HealthyEating.Tests.Managers.UserManagerTests
{
    [TestClass]
    public class SignUp_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenUsernameIsNull()
        {
            //Arrange
            var databaseMock = new Mock<IDatabase>();
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var modelFactoryMock = new Mock<IModelFactory>();
            var userManager = new UserManager(passwordHasherMock.Object, databaseMock.Object, modelFactoryMock.Object);
            var password = "somelegitpassword";
            string username = null;
            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => userManager.LogIn(username, password));
        }

        [TestMethod]
        [DataRow(" ")]
        [DataRow("")]
        public void ThrowArgumentException_WhenUsernameIsEmptyOrWhiteSpace(string username)
        {
            //Arrange
            var databaseMock = new Mock<IDatabase>();
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var modelFactoryMock = new Mock<IModelFactory>();
            var userManager = new UserManager(passwordHasherMock.Object, databaseMock.Object, modelFactoryMock.Object);
            var password = "somelegitpassword";
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => userManager.LogIn(username, password));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenPasswordIsNull()
        {
            //Arrange
            var databaseMock = new Mock<IDatabase>();
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var modelFactoryMock = new Mock<IModelFactory>();
            var userManager = new UserManager(passwordHasherMock.Object, databaseMock.Object, modelFactoryMock.Object);
            string password = null;
            string username = "somelegitusername";
            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => userManager.LogIn(username, password));
        }

        [TestMethod]
        [DataRow(" ")]
        [DataRow("")]
        public void ThrowArgumentException_WhenPasswordIsEmptyOrWhiteSpace(string password)
        {
            //Arrange
            var databaseMock = new Mock<IDatabase>();
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var modelFactoryMock = new Mock<IModelFactory>();
            var userManager = new UserManager(passwordHasherMock.Object, databaseMock.Object, modelFactoryMock.Object);
            var username = "somelegitusername";
            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => userManager.LogIn(username, password));
        }
    }
}
