using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmlakOfisi.Project.Business.Abstract;
using EmlakOfisi.Project.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EmlakOfisi.Project.WebUI.Utilities
{
    public class Utilities : IUtilities
    {
        private readonly ICityService _cityService;

        private readonly IRoomService _roomService;

        private readonly IAdvertisementService _advertisementService;

        public Utilities(ICityService cityService, IRoomService roomService, IAdvertisementService advertisementService)
        {
            _cityService = cityService;
            _roomService = roomService;
            _advertisementService = advertisementService;
        }

        public SelectList SelectCity(string selectedCity = null, string userId=null)
        {
            List<City> cities = _cityService.GetList();

            if (userId!=null)
            {
                List<City> advertisementCity = new();

                List<Advertisement> advertisements = _advertisementService.GetList(userId);

                if (advertisements != null)
                {
                    advertisements.ForEach(advertisement =>
                    {
                        cities.ForEach(city =>
                        {
                            if(advertisement.CityId == city.CityName)
                                advertisementCity.Add(city);
                        });
                    });

                    advertisementCity.Insert(0, new City { CityName = "Lütfen Bir Şehir Seçiniz" });

                    var select = new SelectList(advertisementCity, "Id", "CityName", selectedCity);

                    return select;
                }
            }

            cities.Insert(0, new City { CityName = "Lütfen Bir Şehir Seçiniz" });

            var selectList = new SelectList(cities, "Id", "CityName", selectedCity);

            return selectList;
        }
        

        public SelectList SelectRoom(string selectedRoom = null, string userId = null)
        {
            List<Room> rooms = _roomService.GetList();

            if (userId != null)
            {
                List<Room> advertisementRoom = new();

                List<Advertisement> advertisements = _advertisementService.GetList(userId);

                if (advertisements != null)
                {
                    advertisements.ForEach(advertisement =>
                    {
                        rooms.ForEach(room =>
                        {
                            if (advertisement.RoomId == room.RoomCount)
                                advertisementRoom.Add(room);
                        });
                    });

                    advertisementRoom.Insert(0, new Room { RoomCount = "Lütfen Oda Tipi Seçiniz" });

                    var select = new SelectList(advertisementRoom, "Id", "RoomCount", selectedRoom);

                    return select;
                }
            }


            rooms.Insert(0, new Room { RoomCount = "Lütfen Oda Tipi Seçiniz" });

            return new SelectList(rooms, "Id", "RoomCount", selectedRoom);
        }
        

        public string UploadImages(string webRootPath, string imageClassPath, IFormFile formfile)
        {
            string fileName = null;

            if (formfile != null)
            {
                string uploadDir = Path.Combine(webRootPath, imageClassPath);

                fileName = DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss") + "-" + formfile.FileName;

                string filePath = Path.Combine(uploadDir, fileName);

                using var fileStream = new FileStream(filePath, FileMode.Create);

                formfile.CopyTo(fileStream);
            }

            return fileName;
        }
    }
}
