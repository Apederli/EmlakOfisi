using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Core.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmlakOfisi.Project.Entity.Concrete
{
    public class City : IEntity
    {
        public int Id { get; set; }

        public string CityName { get; set; }
    }
}
