using ChakaServers;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChakaServersTest
{
    public class ServerLogicTest
    {
        private Mock<IServerLogic> mock;

        [SetUp]
        public void Setup()
        {
            mock = new Mock<IServerLogic>();
        }

        [Test]
        public void TestServerLogic_Should_return_2()
        {
            //Arrange
            var serverArray = new List<List<int>> {
                new List<int> { 1, 0, 0 },
                new List<int> { 0, 0, 0 },
                new List<int> { 0, 0, 1 }
            };

            //Act
            mock.Setup(t => t.UpdateServer(serverArray)).Returns(2);
            IServerLogic moq = mock.Object;
            var result = moq.UpdateServer(serverArray);

            //Assert
            Assert.AreEqual(result, 2);
        }

        [Test]
        public void TestServerLogic_Should_return_4()
        {
            //Arrange
            var serverArray = new List<List<int>> {
                new List<int> { 1, 0, 0 },
                new List<int> { 0, 0, 0 },
                new List<int> { 0, 0, 1 }
            };

            //Act
            mock.Setup(t => t.UpdateServer(serverArray)).Returns(4);
            IServerLogic moq = mock.Object;
            var result = moq.UpdateServer(serverArray);

            //Assert
            Assert.AreEqual(result, 4);
        }

        [Test]
        public void TestServerLogic_Should_return_two()
        {
            //Arrange
            var serverArray = new List<List<int>> {
                new List<int> { 0, 0, 0 },
                new List<int> { 0, 1, 0 },
                new List<int> { 0, 0, 0 }
            };

            //Act
            mock.Setup(t => t.UpdateServer(serverArray)).Returns(2);
            IServerLogic moq = mock.Object;
            var result = moq.UpdateServer(serverArray);

            //Assert
            Assert.AreEqual(result, 2);
        }
    }
}
