using Thoth.Framework.Core.Infrastructure;
using Thoth.Business.Abstract;
using Ninject.Modules; 
namespace Thoth.Business.DependencyResolvers.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
			Bind<IRefTimesService>().ToConstant(WcfProxy<IRefTimesService>.CreateChannel()).InSingletonScope();
            Bind<ITermsService>().ToConstant(WcfProxy<ITermsService>.CreateChannel()).InSingletonScope();
            Bind<ITermClassesService>().ToConstant(WcfProxy<ITermClassesService>.CreateChannel()).InSingletonScope();
			Bind<IRefUserTypesService>().ToConstant(WcfProxy<IRefUserTypesService>.CreateChannel()).InSingletonScope();
			Bind<IRefCitiesService>().ToConstant(WcfProxy<IRefCitiesService>.CreateChannel()).InSingletonScope();
			Bind<IActivitiesService>().ToConstant(WcfProxy<IActivitiesService>.CreateChannel()).InSingletonScope();
			Bind<ITermClassActivitiesService>().ToConstant(WcfProxy<ITermClassActivitiesService>.CreateChannel()).InSingletonScope();
			Bind<IRefActivityByService>().ToConstant(WcfProxy<IRefActivityByService>.CreateChannel()).InSingletonScope();
			Bind<IBeaconsService>().ToConstant(WcfProxy<IBeaconsService>.CreateChannel()).InSingletonScope();
			Bind<ITermProgramsService>().ToConstant(WcfProxy<ITermProgramsService>.CreateChannel()).InSingletonScope();
			Bind<IRefCountiesService>().ToConstant(WcfProxy<IRefCountiesService>.CreateChannel()).InSingletonScope();
			Bind<IRefActivityTypesService>().ToConstant(WcfProxy<IRefActivityTypesService>.CreateChannel()).InSingletonScope();
			Bind<IBuildingClassBeaconsService>().ToConstant(WcfProxy<IBuildingClassBeaconsService>.CreateChannel()).InSingletonScope();
			Bind<IRefCountriesService>().ToConstant(WcfProxy<IRefCountriesService>.CreateChannel()).InSingletonScope();
			Bind<IBuildingClassesService>().ToConstant(WcfProxy<IBuildingClassesService>.CreateChannel()).InSingletonScope();
			Bind<IRefDaysService>().ToConstant(WcfProxy<IRefDaysService>.CreateChannel()).InSingletonScope();
			Bind<IMediaService>().ToConstant(WcfProxy<IMediaService>.CreateChannel()).InSingletonScope();
			Bind<IRefFloorNumbersService>().ToConstant(WcfProxy<IRefFloorNumbersService>.CreateChannel()).InSingletonScope();
			Bind<IBuildingsService>().ToConstant(WcfProxy<IBuildingsService>.CreateChannel()).InSingletonScope();
			Bind<ITermClassUsersService>().ToConstant(WcfProxy<ITermClassUsersService>.CreateChannel()).InSingletonScope();
			Bind<IRefLessonTopicsService>().ToConstant(WcfProxy<IRefLessonTopicsService>.CreateChannel()).InSingletonScope();
			Bind<IClassActivityLogsService>().ToConstant(WcfProxy<IClassActivityLogsService>.CreateChannel()).InSingletonScope();
			Bind<IUsersService>().ToConstant(WcfProxy<IUsersService>.CreateChannel()).InSingletonScope();
            Bind<IUserTokensService>().ToConstant(WcfProxy<IUserTokensService>.CreateChannel()).InSingletonScope();
            Bind<IRefLessonsService>().ToConstant(WcfProxy<IRefLessonsService>.CreateChannel()).InSingletonScope();
			Bind<IGroupUsersService>().ToConstant(WcfProxy<IGroupUsersService>.CreateChannel()).InSingletonScope();
			Bind<IRefMimeTypesService>().ToConstant(WcfProxy<IRefMimeTypesService>.CreateChannel()).InSingletonScope();
			Bind<IRefSchoolTypesService>().ToConstant(WcfProxy<IRefSchoolTypesService>.CreateChannel()).InSingletonScope();
			Bind<IPlaceholderService>().ToConstant(WcfProxy<IPlaceholderService>.CreateChannel()).InSingletonScope();
			Bind<ISchoolservice>().ToConstant(WcfProxy<ISchoolservice>.CreateChannel()).InSingletonScope();
			Bind<ITabletsService>().ToConstant(WcfProxy<ITabletsService>.CreateChannel()).InSingletonScope();
            Bind<ITypeUsersService>().ToConstant(WcfProxy<ITypeUsersService>.CreateChannel()).InSingletonScope();
            Bind<IGroupsService>().ToConstant(WcfProxy<IGroupsService>.CreateChannel()).InSingletonScope();
        }
    }
}