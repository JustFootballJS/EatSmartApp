using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using HealthyEating.Client.Managers;
using HealthyEating.Client.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HealthyEating.Tests.Managers.UserManagerTests
{
    [TestClass]
    public class RecoverAccount_Should
    {
        [TestMethod]
        public void ReturnSuccessMessage_WhenArgumentsAreCorrect()
        {
            //Arrange
            var databaseMock = new Mock<IDatabase>();
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var modelFactoryMock = new Mock<IModelFactory>();
            var userManager = new UserManager(passwordHasherMock.Object, databaseMock.Object, modelFactoryMock.Object);
            var username = "validUsername";
            var password = "validPassword";
            var answer = "yes";
            var expected = "Account successfully recovered!";
            IQueryable<User> users = new List<User>()
            {
                new User(){Username=username,Password=password, IsDeleted=true}
            }.AsQueryable();
            var setMock = new Mock<DbSet<User>>();
            setMock.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            setMock.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            setMock.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            setMock.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => users.GetEnumerator());

            databaseMock.SetupGet(x => x.Users).Returns(setMock.Object);
            passwordHasherMock.Setup(x => x.Verify(password, password)).Returns(true);
            //Act
            var result=userManager.RecoverAccount(username,password,answer);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RecoverUser_WhenParametersAreCorrect()
        {
            var databaseMock = new Mock<IDatabase>();
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var modelFactoryMock = new Mock<IModelFactory>();
            var userManager = new UserManager(passwordHasherMock.Object, databaseMock.Object, modelFactoryMock.Object);
            var username = "validUsername";
            var password = "validPassword";
            var answer = "yes";
           
            IQueryable<User> users = new List<User>()
            {
                new User(){Username=username,Password=password, IsDeleted=true}
            }.AsQueryable();

            var setMock = new Mock<DbSet<User>>();
            setMock.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            setMock.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            setMock.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            setMock.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => users.GetEnumerator());

            databaseMock.SetupGet(x => x.Users).Returns(setMock.Object);
            passwordHasherMock.Setup(x => x.Verify(password, password)).Returns(true);
            //Act
            userManager.RecoverAccount(username, password, answer);

            //Assert
            //Assert.AreSame(users.First(), userManager.LoggedUser);
            //Assert.AreEqual(false, userManager.LoggedUser.IsDeleted);
        }

        [TestMethod]
        public void ThrowArgumentExceptionWithCustomMessage_WhenAnswerIsNegative()
        {
            var databaseMock = new Mock<IDatabase>();
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var modelFactoryMock = new Mock<IModelFactory>();
            var userManager = new UserManager(passwordHasherMock.Object, databaseMock.Object, modelFactoryMock.Object);
            var username = "validUsername";
            var password = "validPassword";
            var answer = "no";

            IQueryable<User> users = new List<User>()
            {
                new User(){Username=username,Password=password, IsDeleted=true}
            }.AsQueryable();

            var setMock = new Mock<DbSet<User>>();
            setMock.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            setMock.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            setMock.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            setMock.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => users.GetEnumerator());

            databaseMock.SetupGet(x => x.Users).Returns(setMock.Object);
            passwordHasherMock.Setup(x => x.Verify(password, password)).Returns(true);
            //Act &Assert
            Assert.ThrowsException<ArgumentException>(()=>userManager.RecoverAccount(username, password, answer), "You cannot proceed without agreeing");          
        }

        [TestMethod]
        public void ThrowArgumentExceptionWithCustomMessage_WhenAccountIsNotDeleted()
        {
            var databaseMock = new Mock<IDatabase>();
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var modelFactoryMock = new Mock<IModelFactory>();
            var userManager = new UserManager(passwordHasherMock.Object, databaseMock.Object, modelFactoryMock.Object);
            var username = "validUsername";
            var password = "validPassword";
            var answer = "yes";

            IQueryable<User> users = new List<User>()
            {
                new User(){Username=username,Password=password, IsDeleted=false}
            }.AsQueryable();

            var setMock = new Mock<DbSet<User>>();
            setMock.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            setMock.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            setMock.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            setMock.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => users.GetEnumerator());

            databaseMock.SetupGet(x => x.Users).Returns(setMock.Object);
            passwordHasherMock.Setup(x => x.Verify(password, password)).Returns(true);
            //Act &Assert
            Assert.ThrowsException<ArgumentException>(() => userManager.RecoverAccount(username, password, answer), "Sorry but this account is active");
        }
        [TestMethod]
        [DataRow("FalseUsername",true)]
        [DataRow("validUsername", true)]
        public void ThrowArgumentExceptionWithCustomMessage_WhenCredentialsAreWrong(string username, bool isPasswordCorrect)
        {
            var databaseMock = new Mock<IDatabase>();
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var modelFactoryMock = new Mock<IModelFactory>();
            var userManager = new UserManager(passwordHasherMock.Object, databaseMock.Object, modelFactoryMock.Object);
           
            var password = "password";
            var answer = "yes";

            IQueryable<User> users = new List<User>()
            {
                new User(){Username="validUsername",Password=password, IsDeleted=false}
            }.AsQueryable();

            var setMock = new Mock<DbSet<User>>();
            setMock.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            setMock.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            setMock.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            setMock.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => users.GetEnumerator());

            databaseMock.SetupGet(x => x.Users).Returns(setMock.Object);
            passwordHasherMock.Setup(x => x.Verify(password, password)).Returns(isPasswordCorrect);
            //Act &Assert
            Assert.ThrowsException<ArgumentException>(() => userManager.RecoverAccount(username, password, answer), "Wrong username or password");
        }
    }
}
