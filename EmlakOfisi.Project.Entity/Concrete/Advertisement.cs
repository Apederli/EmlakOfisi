using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Core.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmlakOfisi.Project.Entity.Concrete
{
    public class Advertisement : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Price { get; set; }

        public string CityId { get; set; }

        public string SquareMeters { get; set; }

        public string RoomId { get; set; }

        public bool Balcony { get; set; }

        public bool RentOrSale { get; set; }

        public string AddedByAgentId { get; set; }

        public string ImageUrl { get; set; }

        public DateTime? AddedTime { get; set; }

        public DateTime? UpdatedTime { get; set; }
        

    }
}
