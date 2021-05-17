using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Project.Entity.Concrete;

namespace EmlakOfisi.Project.Business.Abstract
{
    public interface ICityService
    {
        List<City> GetList();
    }
}
