using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Project.Entity.Concrete;

namespace EmlakOfisi.Project.Business.Abstract
{
    public interface IAgentService
    {
        Agent Add(Agent agent);

        Agent Login(Agent agent);

        Agent  GetById(int id);

        void Update(Agent agent);
    }
}
