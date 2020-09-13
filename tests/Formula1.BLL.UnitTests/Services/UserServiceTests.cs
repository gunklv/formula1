using BLL.Contracts.Repository;
using BLL.Domain;
using BLL.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Formula1.BLL.UnitTests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private UserService _userService;
        private readonly Mock<IRepository<User>> _userRepository = new Mock<IRepository<User>>();

        [SetUp]
        public void SetUp()
        {
            _userService = new UserService(_userRepository.Object);
        }

        [Test]
        public async Task GetUser_WithExistingUserName_ReturnsProperUser()
        {
            //Arrange
            var userName = "testUserName";
            var expectedUser = new User { UserName = userName };

            _userRepository
                .Setup(x => x.FilterAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(Task.FromResult(new List<User>() { expectedUser }));

            //Act
            var resultUser = await _userService.GetUserAsync(userName);

            //Assert
            Assert.AreEqual(expectedUser, resultUser);
        }

        [Test]
        public async Task GetUser_WithNonExistingUserName_ReturnsNull()
        {
            //Arrange
            var userName = "testUserName";

            _userRepository
                .Setup(x => x.FilterAsync(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(Task.FromResult(new List<User>()));

            //Act
            var resultUser = await _userService.GetUserAsync(userName);

            //Assert
            Assert.IsNull(resultUser);
        }
    }
}
