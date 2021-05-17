using System.Net;
using Autofac;
using EmlakOfisi.Project.Business.Abstract;
using EmlakOfisi.Project.Business.Concrete;
using EmlakOfisi.Project.Business.ValidationRules.FluentValidation;
using EmlakOfisi.Project.DataAccess.Abstract;
using EmlakOfisi.Project.DataAccess.Concrete.EntityFreamwork;
using EmlakOfisi.Project.Entity.Concrete;
using FluentValidation;

namespace EmlakOfisi.Project.Business.DependencyResolvers.AutoFac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EfAdminDal>().As<IAdminDal>().SingleInstance();

            builder.RegisterType<AdminManager>().As<IAdminService>().SingleInstance();


            
            builder.RegisterType<EfAdvertismentDal>().As<IAdvertismentDal>().SingleInstance();

            builder.RegisterType<AdvertismentManager>().As<IAdvertisementService>().SingleInstance();


            builder.RegisterType<EfAgentDal>().As<IAgentDal>().SingleInstance();

            builder.RegisterType<AgentManager>().As<IAgentService>().SingleInstance();



            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();

            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();


            builder.RegisterType<EfRoomDal>().As<IRoomDal>().SingleInstance();

            builder.RegisterType<RoomManager>().As<IRoomService>().SingleInstance();



            builder.RegisterType<AgentValidator>().As<IValidator<Agent>>().InstancePerDependency();

            builder.RegisterType<AdvertisementValidator>().As<IValidator<Advertisement>>().InstancePerDependency();


        }
    }
}
