using API;
using BLL.Contracts.Repository;
using BLL.Domain;
using Formula1.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Formula1.IntegrationTests.Controllers
{


    public class Formula1ControllerTests
    {
        private HttpClient _client;

        [OneTimeSetUp]
        public void Setup()
        {
            _client = new CustomWebApplicationFactory<Startup>().CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });
        }

        [Test]
        public async Task Formula1sApi_ResultsFormula1Teams()
        {
            //Act
            var result = await _client.GetAsync("/api/formula1s");

            var formula1Teams = JsonSerializer.Deserialize<List<Formula1Team>>(
                await result.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            //Assert
            Assert.IsTrue(formula1Teams.Any());
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [Test]
        public async Task CreateApi_SavesFormula1Team()
        {
            //Arrange
            var formula1Team = new Formula1Team { Name = "CreatedTestName", FoundationDate = new DateTimeOffset(new DateTime(1900, 1, 1)), IsFeePaid = true, Victories = 3 };
            var content = new StringContent(JsonSerializer.Serialize(formula1Team), Encoding.UTF8, "application/json");

            //Act
            var result = await _client.PostAsync("/api/formula1s/create", content);

            //Assert

            Assert.Equals(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
