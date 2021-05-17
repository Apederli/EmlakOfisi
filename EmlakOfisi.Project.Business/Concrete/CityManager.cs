using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Project.Business.Abstract;
using EmlakOfisi.Project.DataAccess.Abstract;
using EmlakOfisi.Project.Entity.Concrete;

namespace EmlakOfisi.Project.Business.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public List<City> GetList()
        {
           List<City> cities = _cityDal.GetList();

           return cities;
        }
    }
}
