using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Project.DataAccess.Abstract;
using EmlakOfisi.Project.Entity.Concrete;
using EmlakOfisi.Core.DataAccess.EntityFreamwork;
using Microsoft.EntityFrameworkCore;

namespace EmlakOfisi.Project.DataAccess.Concrete.EntityFreamwork
{
    public class EfAdminDal : EfEntityRepositoryBase<Admin, DatabaseContext>, IAdminDal
    {
        
    }
}
