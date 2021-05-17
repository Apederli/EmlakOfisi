using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Project.Business.Abstract;
using EmlakOfisi.Project.DataAccess.Abstract;
using EmlakOfisi.Project.Entity.Concrete;

namespace EmlakOfisi.Project.Business.Concrete
{
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public List<Room> GetList()
        {
           return _roomDal.GetList();
        }
    }
}
