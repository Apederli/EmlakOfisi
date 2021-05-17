using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using EmlakOfisi.Project.Business.Abstract;
using EmlakOfisi.Project.DataAccess.Abstract;
using EmlakOfisi.Project.Entity.Concrete;

namespace EmlakOfisi.Project.Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

       

        public Admin Get(Admin admin)
        {
            if (admin != null)
            {
                Admin loginAdmin = _adminDal.Get(x => x.Username.Equals(admin.Username) && x.Password.Equals(admin.Password));

                if (loginAdmin != null) return loginAdmin;
            }

            return null;

        }
    }
}
