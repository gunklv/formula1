using BLL.Domain;
using System;
using System.Collections.Generic;

namespace Formula1.IntegrationTests.Seeds
{
    public static class Formula1Teams
    {
        public static List<Formula1Team> Seed()
            => new List<Formula1Team>
            {
                new Formula1Team { Name = "TestName", FoundationDate = new DateTimeOffset(new DateTime(1900, 1, 1)), IsFeePaid = true, Victories = 4 }
            };
    }
}
