﻿using HealthyEating.Client.Core.Commands;
using HealthyEating.Client.Core.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Tests.Core.Commands.UserCommands.DeleteAccountCommandTests
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

           
            readerMock.Setup(x => x.Read()).Returns("valid answer");
            var command = new DeleteAccountCommand(readerMock.Object, writerMock.Object, userManagerMock.Object);

            //Act
            command.Execute();

            //Assert
            userManagerMock.Verify(x => x.DeleteAccount("valid answer"), Times.Once);

        }
    }
}
