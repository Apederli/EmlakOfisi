using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Project.Entity.Concrete;

namespace EmlakOfisi.Project.Business.Abstract
{
    public interface IAdvertisementService
    {
        Advertisement Add(Advertisement advertisement);

        List<Advertisement> GetList(string userId, string roomCount = null, string cityId = null);

        Advertisement Get(int id);

        void Update(Advertisement advertisement);
    }
}
