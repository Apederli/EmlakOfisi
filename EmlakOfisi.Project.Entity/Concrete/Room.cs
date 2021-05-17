using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Core.DataAccess.Abstract;

namespace EmlakOfisi.Project.Entity.Concrete
{
    public class Room :IEntity
    {
        public int Id { get; set; }

        public string RoomCount { get; set; }
    }
}
