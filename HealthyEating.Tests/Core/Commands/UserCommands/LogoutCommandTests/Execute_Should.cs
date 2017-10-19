using HealthyEating.Client.Core.Commands.UserCommands;
using HealthyEating.Client.Core.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Tests.Core.Commands.UserCommands.LogoutCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void InvokeManagerCommand_WhenCalled()
        {

            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var userManagerMock = new Mock<IUserManager>();

            
            
            var command = new LogoutCommand(readerMock.Object, writerMock.Object, userManagerMock.Object);

            //Act
            command.Execute();

            //Assert
            userManagerMock.Verify(x => x.Logout(), Times.Once);

        }
    }
}
