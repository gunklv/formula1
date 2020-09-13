using API.Controllers;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.IdentityModel.Tokens.Jwt;

namespace Formula1.API.UnitTests.Controllers
{
    [TestFixture]
    public class AuthenticationControllerTests
    {
        private AuthenticationController _authenticationController;
        private readonly Mock<IConfiguration> _configuration = new Mock<IConfiguration>();

        [SetUp]
        public void SetUp()
        {
            var configurationSection = new Mock<IConfigurationSection>();
            configurationSection.Setup(x => x.Value).Returns("PDv7DrqznYL6nv7DrqzjnQYO9JxIsWdcjnQYL6nu0f");
            _configuration.Setup(x => x.GetSection("Jwt:Secret")).Returns(configurationSection.Object);
            _authenticationController = new AuthenticationController(_configuration.Object);
        }

        [Test]
        public void SignIn_GeneratesProperClaimResponse()
        {
            //Arrange
            var userViewModel = new UserViewModel { UserName="TestUserName", Password="TestPassword12345" };
            var handler = new JwtSecurityTokenHandler();

            //Act
            var result = (OkObjectResult)_authenticationController.SignIn(userViewModel);
            var token = handler.ReadJwtToken((string)result.Value);

            //Assert
            Assert.IsTrue(token.Payload["name"].ToString() == userViewModel.UserName);
        }
    }
}
