using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using EmlakOfisi.Project.Entity.Concrete;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmlakOfisi.Project.WebUI.ViewModel
{
    public class AdvertismenetViewModel
    {
        public int  Id { get; set; }

        public string Title { get; set; }

        public string Price { get; set; }

        public string SquareMeters { get; set; }

        public string CityId { get; set; }

        public string RoomId { get; set; }
        
        public bool Balcony { get; set; }

        public bool RentOrSale { get; set; }

        public string ImageUrl { get; set; }

        public IFormFile Photo { get; set; }

        public SelectList SelectRoom { get; set; }

        public SelectList SelectCity { get; set; }

        public SelectList SelectSaleOrRent { get; set; }

        public List<Advertisement> Advertisements { get; set; }

        public Advertisement Advertisement { get; set; }
        
    }
}
