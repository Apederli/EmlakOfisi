using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Project.Business.Abstract;
using EmlakOfisi.Project.DataAccess.Abstract;
using EmlakOfisi.Project.Entity.Concrete;

namespace EmlakOfisi.Project.Business.Concrete
{
    public class AdvertismentManager : IAdvertisementService
    {
        private readonly IAdvertismentDal _advertismentDal;

        private readonly IRoomDal _roomDal;

        private readonly ICityService _cityService;

        public AdvertismentManager(IAdvertismentDal advertismentDal, IRoomDal roomDal, ICityService cityService)
        {
            _advertismentDal = advertismentDal;

            _roomDal = roomDal;

            _cityService = cityService;
        }


        public Advertisement Add(Advertisement advertisement)
        {
            Advertisement addedAdvertisement = advertisement;

            addedAdvertisement.AddedTime = DateTime.Now;

            return _advertismentDal.Add(advertisement);
        }

        public List<Advertisement> GetList(string userId,  string roomCount = null, string cityId = null)
        {
 
            List<Advertisement> advertisements = _advertismentDal.GetList(x => x.AddedByAgentId == userId);
            

            if (roomCount != null || cityId != null)
                advertisements = _advertismentDal.GetList(
                    x => ((!string.IsNullOrEmpty(roomCount) && roomCount !="0") && x.RoomId == roomCount) ||
                         ((!string.IsNullOrEmpty(cityId) && cityId != "0") && x.CityId==cityId));


            List<Room> rooms = _roomDal.GetList();

            List<City> cities = _cityService.GetList();

            advertisements.ForEach(advertisement =>
            {
                cities.ForEach(city =>
                {
                    if (advertisement.CityId == city.Id.ToString())
                    {
                        advertisement.CityId = city.CityName;
                    }
                });

                 rooms.ForEach(room =>
                 {
                     if (advertisement.RoomId == room.Id.ToString())
                     {
                         advertisement.RoomId = room.RoomCount;
                     }
                 });
            });

            return advertisements;
        }

        public Advertisement Get(int id)
        {
            return _advertismentDal.Get(x => x.Id == id);
        }

        public void Update(Advertisement advertisement)
        {

            _advertismentDal.Update(advertisement);
        }
    }
}
