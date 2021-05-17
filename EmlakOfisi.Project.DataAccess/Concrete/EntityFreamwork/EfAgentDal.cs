using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Core.DataAccess.EntityFreamwork;
using EmlakOfisi.Project.DataAccess.Abstract;
using EmlakOfisi.Project.Entity.Concrete;

namespace EmlakOfisi.Project.DataAccess.Concrete.EntityFreamwork
{
    public class EfAgentDal: EfEntityRepositoryBase<Agent,DatabaseContext>, IAgentDal
    {
    }
}
