using System.Data.Entity;
using Thoth.Entity.Concrete;

namespace Thoth.Data.Concrete.EntityFramework
{
    public class ThothContext:DbContext
    {
        public ThothContext ()
            : base("ThothContext")
        {
        }

		public DbSet<RefTimes> RefTimesTbl { get; set; }
		public DbSet<RefUserTypes> RefUserTypesTbl { get; set; }
		public DbSet<RefCities> RefCitiesTbl { get; set; }
		public DbSet<Activities> ActivitiesTbl { get; set; }
		public DbSet<TermClassActivities> TermClassActivitiesTbl { get; set; }
		public DbSet<RefActivityBy> RefActivityByTbl { get; set; }
		public DbSet<Beacons> BeaconsTbl { get; set; }
		public DbSet<RefCounties> RefCountiesTbl { get; set; }
		public DbSet<RefActivityTypes> RefActivityTypesTbl { get; set; }
		public DbSet<BuildingClassBeacons> BuildingClassBeaconsTbl { get; set; }
		public DbSet<RefCountries> RefCountriesTbl { get; set; }
		public DbSet<BuildingClasses> BuildingClassesTbl { get; set; }
		public DbSet<RefDays> RefDaysTbl { get; set; }
		public DbSet<Media> MediaTbl { get; set; }
		public DbSet<RefFloorNumbers> RefFloorNumbersTbl { get; set; }
		public DbSet<Buildings> BuildingsTbl { get; set; }
		public DbSet<RefLessonTopics> RefLessonTopicsTbl { get; set; }
		public DbSet<ClassActivityLogs> ClassActivityLogsTbl { get; set; }
		public DbSet<Users> UsersTbl { get; set; }
        public DbSet<UserTokens> UserTokensTbl { get; set; }
        public DbSet<RefLessons> RefLessonsTbl { get; set; }
        public DbSet<GroupUsers> GroupUsersTbl { get; set; }
		public DbSet<RefMimeTypes> RefMimeTypesTbl { get; set; }
		public DbSet<RefSchoolTypes> RefSchoolTypesTbl { get; set; }
		public DbSet<Placeholder> PlaceholderTbl { get; set; }
		public DbSet<Schools> SchoolsTbl { get; set; }
		public DbSet<Tablets> TabletsTbl { get; set; }
        public DbSet<TermClasses> TermClassesTbl { get; set; }
        public DbSet<TermClassUsers> TermClassUsersTbl { get; set; }
        public DbSet<TermPrograms> TermProgramsTbl { get; set; }
        public DbSet<Terms> TermsTbl { get; set; }
        public DbSet<TypeUsers> TypeUsersTbl { get; set; }
        public DbSet<Groups> GroupsTbl { get; set; }
    }
}
