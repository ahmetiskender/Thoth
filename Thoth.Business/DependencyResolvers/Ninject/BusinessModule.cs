using System;
using Thoth.Business.Abstract; 
using Ninject.Modules;
using Thoth.Business.Concrete.Managers;
using Thoth.Data.Abstract;
using Thoth.Data.Concrete.EntityFramework;

namespace Thoth.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
			Bind<IRefTimesService>().To<RefTimesManager>().InSingletonScope();
			Bind<IRefTimesDal>().To<EfRefTimesDal>().InSingletonScope();

			Bind<ITermClassesService>().To<TermClassesManager>().InSingletonScope();
			Bind<ITermClassesDal>().To<EfTermClassesDal>().InSingletonScope();

			Bind<IRefUserTypesService>().To<RefUserTypesManager>().InSingletonScope();
			Bind<IRefUserTypesDal>().To<EfRefUserTypesDal>().InSingletonScope();

			Bind<IRefCitiesService>().To<RefCitiesManager>().InSingletonScope();
			Bind<IRefCitiesDal>().To<EfRefCitiesDal>().InSingletonScope();

			Bind<IActivitiesService>().To<ActivitiesManager>().InSingletonScope();
			Bind<IActivitiesDal>().To<EfActivitiesDal>().InSingletonScope();

			Bind<ITermClassActivitiesService>().To<TermClassActivitiesManager>().InSingletonScope();
			Bind<ITermClassActivitiesDal>().To<EfTermClassActivitiesDal>().InSingletonScope();

			Bind<IRefActivityByService>().To<RefActivityByManager>().InSingletonScope();
			Bind<IRefActivityByDal>().To<EfRefActivityByDal>().InSingletonScope();

			Bind<IBeaconsService>().To<BeaconsManager>().InSingletonScope();
			Bind<IBeaconsDal>().To<EfBeaconsDal>().InSingletonScope();

			Bind<ITermProgramsService>().To<TermProgramsManager>().InSingletonScope();
			Bind<ITermProgramsDal>().To<EfTermProgramsDal>().InSingletonScope();

			Bind<IRefCountiesService>().To<RefCountiesManager>().InSingletonScope();
			Bind<IRefCountiesDal>().To<EfRefCountiesDal>().InSingletonScope();

			Bind<IRefActivityTypesService>().To<RefActivityTypesManager>().InSingletonScope();
			Bind<IRefActivityTypesDal>().To<EfRefActivityTypesDal>().InSingletonScope();

			Bind<IBuildingClassBeaconsService>().To<BuildingClassBeaconsManager>().InSingletonScope();
			Bind<IBuildingClassBeaconsDal>().To<EfBuildingClassBeaconsDal>().InSingletonScope();

			Bind<IRefCountriesService>().To<RefCountriesManager>().InSingletonScope();
			Bind<IRefCountriesDal>().To<EfRefCountriesDal>().InSingletonScope();

			Bind<IBuildingClassesService>().To<BuildingClassesManager>().InSingletonScope();
			Bind<IBuildingClassesDal>().To<EfBuildingClassesDal>().InSingletonScope();

			Bind<IRefDaysService>().To<RefDaysManager>().InSingletonScope();
			Bind<IRefDaysDal>().To<EfRefDaysDal>().InSingletonScope();

			Bind<IMediaService>().To<MediaManager>().InSingletonScope();
			Bind<IMediaDal>().To<EfMediaDal>().InSingletonScope();

			Bind<IRefFloorNumbersService>().To<RefFloorNumbersManager>().InSingletonScope();
			Bind<IRefFloorNumbersDal>().To<EfRefFloorNumbersDal>().InSingletonScope();

			Bind<IBuildingsService>().To<BuildingsManager>().InSingletonScope();
			Bind<IBuildingsDal>().To<EfBuildingsDal>().InSingletonScope();

			Bind<ITermClassUsersService>().To<TermClassUsersManager>().InSingletonScope();
			Bind<ITermClassUsersDal>().To<EfTermClassUsersDal>().InSingletonScope();

			Bind<IRefLessonTopicsService>().To<RefLessonTopicsManager>().InSingletonScope();
			Bind<IRefLessonTopicsDal>().To<EfRefLessonTopicsDal>().InSingletonScope();

			Bind<IClassActivityLogsService>().To<ClassActivityLogsManager>().InSingletonScope();
			Bind<IClassActivityLogsDal>().To<EfClassActivityLogssDal>().InSingletonScope();

			Bind<IUsersService>().To<UsersManager>().InSingletonScope();
			Bind<IUsersDal>().To<EfUsersDal>().InSingletonScope();

            Bind<IUserTokensService>().To<UserTokensManager>().InSingletonScope();
            Bind<IUserTokensDal>().To<EfUserTokensDal>().InSingletonScope();

            Bind<IRefLessonsService>().To<RefLessonsManager>().InSingletonScope();
			Bind<IRefLessonsDal>().To<EfRefLessonsDal>().InSingletonScope();

			Bind<IGroupUsersService>().To<GroupUsersManager>().InSingletonScope();
			Bind<IGroupUsersDal>().To<EfGroupUsersDal>().InSingletonScope();

			Bind<IRefMimeTypesService>().To<RefMimeTypesManager>().InSingletonScope();
			Bind<IRefMimeTypesDal>().To<EfRefMimeTypesDal>().InSingletonScope();

			Bind<IRefSchoolTypesService>().To<RefSchoolTypesManager>().InSingletonScope();
			Bind<IRefSchoolTypesDal>().To<EfRefSchoolTypesDal>().InSingletonScope();

            Bind<IPlaceholderService>().To<PlaceholderManager>().InSingletonScope();
            Bind<IPlaceholderDal>().To<EfPlaceholderDal>().InSingletonScope();

            Bind<ISchoolservice>().To<SchoolsManager>().InSingletonScope();
            Bind<ISchoolsDal>().To<EfSchoolsDal>().InSingletonScope();

            Bind<ITabletsService>().To<TabletsManager>().InSingletonScope();
            Bind<ITabletsDal>().To<EfTabletsDal>().InSingletonScope();

            Bind<ITermsService>().To<TermsManager>().InSingletonScope();
            Bind<ITermsDal>().To<EfTermsDal>().InSingletonScope();

            Bind<ITypeUsersService>().To<TypeUsersManager>().InSingletonScope();
            Bind<ITypeUsersDal>().To<EfTypeUsersDal>().InSingletonScope();

            Bind<IGroupsService>().To<GroupsManager>().InSingletonScope();
            Bind<IGroupsDal>().To<EfGroupsDal>().InSingletonScope();

        }
    }
}
