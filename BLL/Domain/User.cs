using System;

namespace BLL.Domain
{
    public class User : IEntity
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public byte[] Salt { get; set; }
    }
}
