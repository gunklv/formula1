using BLL.Contracts.Repository;
using BLL.Domain;
using BLL.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Formula1.BLL.UnitTests.Services
{
    [TestFixture]
    public class Formula1ServiceTests
    {
        private Formula1Service _formula1Service;
        private readonly Mock<IRepository<Formula1Team>> _formula1Repository = new Mock<IRepository<Formula1Team>>();

        [SetUp]
        public void SetUp()
        {
            _formula1Service = new Formula1Service(_formula1Repository.Object);
        }

        [Test]
        public async Task CreateFormula1Team_CallsRepository()
        {
            //Arrange
            var formula1Team = new Formula1Team { Name = "TestName", FoundationDate = new DateTimeOffset(new DateTime(1900, 1, 1)), IsFeePaid = true, Victories = 4 };

            //Act
            await _formula1Service.CreateFormula1Team(formula1Team);

            //Assert
            _formula1Repository.Verify(x => x.Create(formula1Team), Times.Once());
        }

        [Test]
        public async Task DeleteFormula1Team_CallsRepository()
        {
            //Arrange
            var formula1TeamId = new Guid("0567d6a1-5c41-4fa3-bca8-ef1c3f2fd8a5");

            //Act
            await _formula1Service.DeleteFormula1Team(formula1TeamId);

            //Assert
            _formula1Repository.Verify(x => x.DeleteAsync(formula1TeamId), Times.Once());
        }

        [Test]
        public async Task UpdateFormula1Team_CallsRepository()
        {
            //Arrange
            var formula1Team = new Formula1Team { Name = "TestName", FoundationDate = new DateTimeOffset(new DateTime(1900, 1, 1)), IsFeePaid = true, Victories = 4 };

            //Act
            await _formula1Service.UpdateFormula1Team(formula1Team);

            //Assert
            _formula1Repository.Verify(x => x.UpdateAsync(formula1Team), Times.Once());
        }

        [Test]
        public async Task GetFormula1s_ReturnsProperData()
        {
            //Arrange
            var formula1Team = new List<Formula1Team>
            {
                new Formula1Team { Name="TestName1", FoundationDate = new DateTimeOffset(new DateTime(1900, 1, 1)), IsFeePaid = true, Victories = 4 },
                new Formula1Team { Name="TestName2", FoundationDate = new DateTimeOffset(new DateTime(1910, 1, 1)), IsFeePaid = false, Victories = 2 }
            };

            _formula1Repository
                .Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(new List<Formula1Team>(formula1Team)));

            //Act
            var formula1Teams = await _formula1Service.GetFormula1s();

            //Assert
            CollectionAssert.AreEqual(formula1Team, formula1Teams);
        }
    }
}
