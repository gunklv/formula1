using System;

namespace BLL.Domain
{
    public class Formula1Team : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset FoundationDate { get; set; }

        public int Victories { get; set; }

        public bool IsFeePaid { get; set; }
    }
}
