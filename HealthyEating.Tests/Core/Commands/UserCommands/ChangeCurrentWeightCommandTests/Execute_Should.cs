using HealthyEating.Client.Core.Commands;
using HealthyEating.Client.Core.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Tests.Core.Commands.UserCommands.ChangeCurrentWeightCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void InvokeUserManagerCommand_WhenParamatersAreCorrect()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var userManagerMock = new Mock<IUserManager>();

            
            readerMock.Setup(x => x.Read()).Returns(It.IsAny<double>().ToString());
            var command = new ChangeCurrentWeightCommand(readerMock.Object,writerMock.Object, userManagerMock.Object);

            //Act
            command.Execute();

            //Assert
            userManagerMock.Verify(x => x.ChangeCurrentWeight(It.IsAny<double>()), Times.Once);
        }

        [TestMethod]
        public void ThrowFormatException_WhenParametersAreNotCorrect()
        {
            //Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var userManagerMock = new Mock<IUserManager>();

          
            readerMock.Setup(x => x.Read()).Returns("Not a number");
            var command = new ChangeCurrentWeightCommand(readerMock.Object, writerMock.Object, userManagerMock.Object);

            //Act&Assert
            Assert.ThrowsException<FormatException>(() => command.Execute());
           
        }
    }
}
