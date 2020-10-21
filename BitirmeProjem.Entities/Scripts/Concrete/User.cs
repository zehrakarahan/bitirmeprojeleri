using Core.Entities;
using System;
using System.Collections.Generic;

namespace BitirmeProjem.Entities.Concrete
{
    public partial class User : IEntity
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
