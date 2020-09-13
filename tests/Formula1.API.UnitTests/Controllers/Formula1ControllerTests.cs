using API.Controllers;
using BLL.Contracts.Services;
using BLL.Domain;
using Moq;
using NUnit.Framework;
using System;

namespace Formula1.API.UnitTests.Controllers
{
    [TestFixture]
    public class Formula1ControllerTests
    {
        private Formula1Controller _formula1Controller;
        private readonly Mock<IFormula1Service> _formula1Service = new Mock<IFormula1Service>();

        [SetUp]
        public void SetUp()
        {
            _formula1Controller = new Formula1Controller(_formula1Service.Object);
        }

        [Test]
        public void GetFormula1s_UsesProperServiceMethod()
        {
            //Act
            var result = _formula1Controller.GetFormula1s();

            //Assert
            _formula1Service.Verify(x => x.GetFormula1s(), Times.Once());
        }

        [Test]
        public void CreateFormula1_UsesProperServiceMethod()
        {
            //Assert
            var formula1Team = new Formula1Team { Name = "TestName", FoundationDate = new DateTimeOffset(new DateTime(1900, 1, 1)), IsFeePaid = true, Victories = 4 };

            //Act
            var result = _formula1Controller.CreateFormula1(formula1Team);

            //Assert
            _formula1Service.Verify(x => x.CreateFormula1Team(It.Is<Formula1Team>(x => x == formula1Team)), Times.Once());
        }

        [Test]
        public void UpsertFormula1_UsesProperServiceMethod()
        {
            //Assert
            var formula1Team = new Formula1Team { Name = "TestName", FoundationDate = new DateTimeOffset(new DateTime(1900, 1, 1)), IsFeePaid = true, Victories = 4 };

            //Act
            var result = _formula1Controller.UpdateFormula1(formula1Team);

            //Assert
            _formula1Service.Verify(x => x.UpdateFormula1Team(It.Is<Formula1Team>(x => x == formula1Team)), Times.Once());
        }

        [Test]
        public void DeleteFormula1_UsesProperServiceMethod()
        {
            //Assert
            var formula1TeamId = new Guid("0567d6a1-5c41-4fa3-bca8-ef1c3f2fd8a5");

            //Act
            var result = _formula1Controller.DeleteFormula1(formula1TeamId);

            //Assert
            _formula1Service.Verify(x => x.DeleteFormula1Team(It.Is<Guid>(x => x == formula1TeamId)), Times.Once());
        }
    }
}
