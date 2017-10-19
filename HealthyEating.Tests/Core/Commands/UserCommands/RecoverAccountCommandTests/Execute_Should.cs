using HealthyEating.Client.Core.Commands;
using HealthyEating.Client.Core.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace HealthyEating.Tests.Core.Commands.UserCommands.RecoverAccountCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void InvokeRecoverAccountFromManager_WhenCalled()
        {
            //Arrange 
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var userManagerMock = new Mock<IUserManager>();

           
            var command = new RecoverAccountCommand(readerMock.Object,writerMock.Object, userManagerMock.Object);

            readerMock.SetupSequence(x => x.Read()).Returns("ValidUsername").Returns("ValidPassword").Returns("ValidAnswer");

            //Act
            command.Execute();

            //Assert
            userManagerMock.Verify(x => x.RecoverAccount("ValidUsername", "ValidPassword","ValidAnswer"), Times.Once);
        }
    }
}
