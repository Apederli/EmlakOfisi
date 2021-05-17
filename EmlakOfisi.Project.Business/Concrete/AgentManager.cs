using System;
using System.Collections.Generic;
using System.Text;
using EmlakOfisi.Project.Business.Abstract;
using EmlakOfisi.Project.DataAccess.Abstract;
using EmlakOfisi.Project.Entity.Concrete;

namespace EmlakOfisi.Project.Business.Concrete
{
    public class AgentManager : IAgentService
    {
        private readonly IAgentDal _agentDal;

        public AgentManager(IAgentDal agentDal)
        {
            _agentDal = agentDal;
        }

        public Agent Add(Agent agent)
        {
            Agent addedAgent = null;

            if (agent != null)
            {
                agent.AddedTime = DateTime.Now;
                agent.Password = "123456";
                addedAgent = _agentDal.Add(agent);
            }

            return addedAgent;
        }


        public Agent Login(Agent agent)
        {
            if (agent != null)
            {
                Agent loginAgent = _agentDal.Get(x => x.Username.Equals(agent.Username) && x.Password.Equals(agent.Password));

                if (loginAgent != null) return loginAgent;
            }

            return null;
        }

        public Agent GetById(int id)
        {
            var agent = _agentDal.Get(x => x.Id == id);
            return agent;
        }

        public void Update(Agent agent)
        {
            if (agent != null)
            {
                agent.UpdatedTime =DateTime.Now;

                _agentDal.Update(agent);
            }
        }
    }
}
