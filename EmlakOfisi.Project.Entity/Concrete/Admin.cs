using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Core.DataAccess.Abstract;

namespace EmlakOfisi.Project.Entity.Concrete
{
    public class Admin : IEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
