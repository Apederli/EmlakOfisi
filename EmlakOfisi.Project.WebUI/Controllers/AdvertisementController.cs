using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmlakOfisi.Project.Business.Abstract;
using EmlakOfisi.Project.Business.ValidationRules.FluentValidation;
using EmlakOfisi.Project.Entity.Concrete;
using EmlakOfisi.Project.WebUI.Attiributes;
using EmlakOfisi.Project.WebUI.Utilities;
using EmlakOfisi.Project.WebUI.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EmlakOfisi.Project.WebUI.Controllers
{
    [AgentNeeded]
    [Route("advertisement")]
    public class AdvertisementController : Controller
    {
        private readonly IUtilities _utilities;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IAdvertisementService _advertisementService;

        public AdvertisementController(IUtilities utilities, IHttpContextAccessor httpContextAccessor, IAdvertisementService advertisementService, IWebHostEnvironment webHostEnvironment)
        {
            _utilities = utilities;
            _httpContextAccessor = httpContextAccessor;
            _advertisementService = advertisementService;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("add")]
        public IActionResult Add()
        {
            AdvertismenetViewModel advertismenetViewModel = new AdvertismenetViewModel()
            {
                SelectCity = _utilities.SelectCity(),

                SelectRoom = _utilities.SelectRoom()
            };

            return View(advertismenetViewModel);
        }


        [Route("add")]
        [HttpPost]
        public IActionResult Add(Advertisement advertisement, bool rentSale, bool balcony, IFormFile imageUrl)
        {
          
            if (_httpContextAccessor.HttpContext != null)
            {
                if (ModelState.IsValid)
                {
                    var image = _utilities.UploadImages(_webHostEnvironment.WebRootPath, "images", imageUrl);

                    var userId = _httpContextAccessor.HttpContext.Session.GetString("userId");

                    Advertisement addedAdvertisement = new Advertisement()
                    {
                        Title = advertisement.Title,
                        Price = advertisement.Price,
                        CityId = advertisement.CityId,
                        SquareMeters = advertisement.SquareMeters,
                        RoomId = advertisement.RoomId,
                        Balcony = balcony,
                        RentOrSale = rentSale,
                        AddedByAgentId = userId,
                        ImageUrl = image
                    };

                    _advertisementService.Add(addedAdvertisement);

                    return RedirectToAction("List");
                }
               
            }

            AdvertismenetViewModel advertismenetViewModel = new AdvertismenetViewModel()
            {
                SelectCity = _utilities.SelectCity(),
                SelectRoom = _utilities.SelectRoom()
            };
            
            return View(advertismenetViewModel);
        }
        
        [Route("list")]
        public IActionResult List(string selectedCity = null, string selectedRoom = null )
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                var userId = _httpContextAccessor.HttpContext.Session.GetString("userId");

                List<Advertisement> advertisements = _advertisementService.GetList(userId, selectedRoom,selectedCity);

                AdvertismenetViewModel advertismenetViewModel = new AdvertismenetViewModel()
                {
                    Advertisements = advertisements,

                    SelectCity = _utilities.SelectCity(selectedCity, userId),
                    
                    SelectRoom = _utilities.SelectRoom(selectedRoom, userId)
                };

                return View(advertismenetViewModel);
            }

            return View();
        }

        [Route("update")]
        public IActionResult UpdateAdvertisement(int id)
        {
            Advertisement advertisement = _advertisementService.Get(id);

            AdvertismenetViewModel advertismenetViewModel = new AdvertismenetViewModel()
            {
                SelectCity = _utilities.SelectCity(),

                SelectRoom = _utilities.SelectRoom(),

                Title = advertisement.Title,

                Price = advertisement.Price,

                Balcony = advertisement.Balcony,

                RentOrSale = advertisement.RentOrSale,

                CityId = advertisement.CityId,

                SquareMeters = advertisement.SquareMeters,

                RoomId = advertisement.RoomId
            };

            return View(advertismenetViewModel);
        }


        [Route("update")]
        [HttpPost]
        public IActionResult UpdateAdvertisement(Advertisement advertisement , IFormFile imageUrl)
        {

            Advertisement updatedAdvertisement = _advertisementService.Get(advertisement.Id);

            if (updatedAdvertisement != null)
            {
                if (imageUrl != null)
                {
                    var image = _utilities.UploadImages(_webHostEnvironment.WebRootPath, "images", imageUrl);

                    updatedAdvertisement.ImageUrl = image;
                }

                updatedAdvertisement.RoomId = advertisement.RoomId;
                updatedAdvertisement.Balcony = advertisement.Balcony;
                updatedAdvertisement.CityId = advertisement.CityId;
                updatedAdvertisement.Price = advertisement.Price;
                updatedAdvertisement.RentOrSale = advertisement.RentOrSale;
                updatedAdvertisement.SquareMeters = advertisement.SquareMeters;
                updatedAdvertisement.UpdatedTime =DateTime.Now;

                _advertisementService.Update(updatedAdvertisement);

                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }
    }
}
