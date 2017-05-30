using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Thoth.Business.Abstract;
using Thoth.Business.Concrete.Managers;

namespace Thoth.Business.Service
{
    public class Service
    {
        #region Tanımlamalar
        IUsersService users = new UsersManager();
        IBeaconsService beacons = new BeaconsManager();
        IGroupsService groups = new GroupsManager();
        IPlaceholderService placeholder = new PlaceholderManager();
        IGroupUsersService usergroups = new GroupUsersManager();
        ISchoolservice schools = new SchoolsManager();
        ITabletsService tablets = new TabletsManager();
        ITermClassUsersService classusers = new TermClassUsersManager();
        ITermProgramsService programs = new TermProgramsManager();
        IBuildingClassBeaconsService buildingclassbeacons = new BuildingClassBeaconsManager();
        IBuildingClassesService buildingclasses = new BuildingClassesManager();
        IBuildingsService buildings = new BuildingsManager();
        IRefFloorNumbersService floors = new RefFloorNumbersManager();
        IRefCitiesService cities = new RefCitiesManager();
        IRefCountiesService counties = new RefCountiesManager();
        IRefCountriesService countries = new RefCountriesManager();
        ITermClassesService termclasses = new TermClassesManager();
        IRefLessonsService lessons = new RefLessonsManager();
        IRefLessonTopicsService lessontopics = new RefLessonTopicsManager();
        IRefSchoolTypesService refschooltypes = new RefSchoolTypesManager();
        IRefDaysService days = new RefDaysManager();
        IRefTimesService times = new RefTimesManager();
        IRefUserTypesService types = new RefUserTypesManager();
        ITermsService terms = new TermsManager();
        #endregion

        #region Web Servis Fonksiyonları

        public List<GetUsers> GetAllUsers()
        {
            try
            {
                var user = users.GetAll();

                List<GetUsers> results = new List<GetUsers>();
                foreach (var temp in user)
                {
                    var usr = users.GetAll(x => x.Id == temp.UserIdCreated).FirstOrDefault();
                    var type = types.GetAll(x => x.Id == temp.RefUserTypeId).FirstOrDefault();
                    string name = "";
                    string surname = "";
                    if (usr != null) { name = usr.Name; surname = usr.Surname; }
                    results.Add(new GetUsers() { UserId = temp.Id, Name = temp.Name, Surname = temp.Surname, Username = temp.Username, EMail = temp.EMail, RefUserType = type.Name, CreatedAt = temp.CreatedAt, UserCreated = name + " " + surname });
                }
                return results;
            }
            catch (Exception ex)
            {
                //  Return any exception messages back to the Response header
                OutgoingWebResponseContext responsee = WebOperationContext.Current.OutgoingResponse;
                responsee.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responsee.StatusDescription = ex.Message.Replace("\r\n", "");
                return null;
            }
        }


        public List<GetBeacons> GetAllBeacons()
        {
            try
            {
                var beacon = beacons.GetAll();

                List<GetBeacons> results = new List<GetBeacons>();

                foreach (var temp in beacon)
                {
                    var user = users.GetAll(x => x.Id == temp.UserIdCreated).FirstOrDefault();
                    var bcb = buildingclassbeacons.GetAll(x => x.BeaconId == temp.Id).FirstOrDefault();
                    var bc = buildingclasses.GetAll(x => x.Id == bcb.BuildingClassId).FirstOrDefault();
                    var building = buildings.GetAll(x => x.Id == bc.BuildingId).FirstOrDefault();
                    var floor = floors.GetAll(x => x.Id == bc.RefFloorNumberId).FirstOrDefault();
                    var school = schools.GetAll(x => x.Id == building.SchoolId).FirstOrDefault();
                    var city = cities.GetAll(x => x.Id == building.RefCityId).FirstOrDefault();
                    var county = counties.GetAll(x => x.Id == building.RefCountyId).FirstOrDefault();
                    var country = countries.GetAll(x => x.Id == building.RefCountryId).FirstOrDefault();

                    results.Add(new GetBeacons() { Country = country.Name, County = county.Name, City = city.Name, School = school.Name, Floor = floor.Name, Class = bc.Name, BeaconId = temp.Id, Data = temp.Uuid.ToString() + temp.Major.ToString() + temp.Minor.ToString(), CreatedAt = temp.CreatedAt, UserCreated = user.Name + " " + user.Surname });
                }
                return results;
            }
            catch (Exception ex)
            {
                //  Return any exception messages back to the Response header
                OutgoingWebResponseContext responsee = WebOperationContext.Current.OutgoingResponse;
                responsee.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responsee.StatusDescription = ex.Message.Replace("\r\n", "");
                return null;
            }
        }

        public List<GetGroups> GetAllGroups()
        {
            try
            {
                var group = groups.GetAll();
                if (group != null) { }
                List<GetGroups> results = new List<GetGroups>();
                foreach (var temp in group)
                {
                    var tc = termclasses.GetAll(x => x.Id == temp.TermClassId).FirstOrDefault();
                    var lesson = lessons.GetAll(x => x.Id == temp.RefLessonId).FirstOrDefault();
                    var lt = lessontopics.GetAll(x => x.Id == temp.RefLessonTopicId).FirstOrDefault();

                    results.Add(new GetGroups() { Class = tc.Name, Name = temp.Name, Lesson = lesson.Name, Topic = lt.Name });
                }
                return results;
            }
            catch (Exception ex)
            {
                //  Return any exception messages back to the Response header
                OutgoingWebResponseContext responsee = WebOperationContext.Current.OutgoingResponse;
                responsee.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responsee.StatusDescription = ex.Message.Replace("\r\n", "");
                return null;
            }
        }

        public List<GetPlaceholder> GetAllPlaceholder()
        {
            try
            {
                var plc = placeholder.GetAll();

                List<GetPlaceholder> results = new List<GetPlaceholder>();
                foreach (var temp in plc)
                {
                    var user = users.GetAll(x => x.Id == temp.UserId).FirstOrDefault();
                    var tc = termclasses.GetAll(x => x.Id == temp.TermClassId).FirstOrDefault();
                    var lesson = lessons.GetAll(x => x.Id == temp.RefLessonId).FirstOrDefault();
                    var topic = lessontopics.GetAll(x => x.Id == temp.RefLessonTopicId).FirstOrDefault();
                    results.Add(new GetPlaceholder() { IsOver = temp.IsOver, Teacher = user.Name, Class = tc.Name, Lesson = lesson.Name, Topic = topic.Name });
                }
                return results;
            }
            catch (Exception ex)
            {
                //  Return any exception messages back to the Response header
                OutgoingWebResponseContext responsee = WebOperationContext.Current.OutgoingResponse;
                responsee.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responsee.StatusDescription = ex.Message.Replace("\r\n", "");
                return null;
            }
        }

        public List<GetSchool> GetAllSchool()
        {
            try
            {
                var school = schools.GetAll();

                List<GetSchool> results = new List<GetSchool>();
                foreach (var temp in school)
                {
                    var refschooltype = refschooltypes.GetAll(x => x.Id == temp.RefSchoolTypeId).FirstOrDefault();
                    var building = buildings.GetAll(x => x.SchoolId == temp.Id).FirstOrDefault();
                    var city = cities.GetAll(x => x.Id == building.RefCityId).FirstOrDefault();
                    var county = counties.GetAll(x => x.Id == building.RefCountyId).FirstOrDefault();
                    var country = countries.GetAll(x => x.Id == building.RefCountryId).FirstOrDefault();

                    results.Add(new GetSchool() { Name = temp.Name, Type = refschooltype.Name, Building = building.Name, City = city.Name, County = county.Name, Country = country.Name });
                }
                return results;
            }
            catch (Exception ex)
            {
                //  Return any exception messages back to the Response header
                OutgoingWebResponseContext responsee = WebOperationContext.Current.OutgoingResponse;
                responsee.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responsee.StatusDescription = ex.Message.Replace("\r\n", "");
                return null;
            }
        }

        public List<GetTablets> GetAllTablets()
        {
            try
            {
                var tablet = tablets.GetAll();

                List<GetTablets> results = new List<GetTablets>();
                foreach (var temp in tablet)
                {
                    var user = users.GetAll(x => x.Id == temp.UserId).FirstOrDefault();

                    results.Add(new GetTablets() { Id = temp.Id, FullName = user.Name + " " + user.Surname });
                }
                return results;
            }
            catch (Exception ex)
            {
                //  Return any exception messages back to the Response header
                OutgoingWebResponseContext responsee = WebOperationContext.Current.OutgoingResponse;
                responsee.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responsee.StatusDescription = ex.Message.Replace("\r\n", "");
                return null;
            }
        }

        public List<ClassResponse> GetAllClassUsers(ClassRequest check)
        {
            try
            {
                if (check.ClassName == null)
                {
                    var classuser = classusers.GetAll();

                    List<ClassResponse> results = new List<ClassResponse>();
                    foreach (var temp in classuser)
                    {
                        var user = users.GetAll(x => x.Id == temp.UserId).FirstOrDefault();
                        var termclass = termclasses.GetAll(x => x.Id == temp.TermClassId).FirstOrDefault();

                        results.Add(new ClassResponse() { StudentName = user.Name + " " + user.Surname, StudentId = user.Id, ClassName = termclass.Name });
                    }
                    return results;
                }
                else
                {
                    var classuser = classusers.GetAll();
                    var termclass = termclasses.GetAll(x => x.Name == check.ClassName).FirstOrDefault();

                    List<ClassResponse> results = new List<ClassResponse>();
                    foreach (var temp in classuser)
                    {
                        if (temp.TermClassId == termclass.Id)
                        {
                            var user = users.GetAll(x => x.Id == temp.UserId).FirstOrDefault();

                            results.Add(new ClassResponse() { StudentName = user.Name + " " + user.Surname, StudentId = user.Id, ClassName = termclass.Name });
                        }

                    }
                    return results;
                }
            }
            catch (Exception ex)
            {
                //  Return any exception messages back to the Response header
                OutgoingWebResponseContext responsee = WebOperationContext.Current.OutgoingResponse;
                responsee.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responsee.StatusDescription = ex.Message.Replace("\r\n", "");
                return null;
            }
        }

        public List<ProgramResponse> GetAllClassPrograms(ProgramRequest check)
        {
            try
            {
                if (check.ClassName == null)
                {
                    var program = programs.GetAll();

                    List<ProgramResponse> results = new List<ProgramResponse>();
                    foreach (var temp in program)
                    {
                        var user = users.GetAll(x => x.Id == temp.UserId).FirstOrDefault();
                        var termclass = termclasses.GetAll(x => x.Id == temp.TermClassId).FirstOrDefault();
                        var day = days.GetAll(x => x.Id == temp.RefDayId).FirstOrDefault();
                        var time = times.GetAll(x => x.Id == temp.RefTimeId).FirstOrDefault();
                        var lesson = lessons.GetAll(x => x.Id == temp.RefLessonId).FirstOrDefault();

                        results.Add(new ProgramResponse() { LessonName = lesson.Name, TeacherName = user.Name + " " + user.Surname, Time = time.Name, Day = day.Name, ClassName = termclass.Name });
                    }
                    return results;
                }
                else
                {
                    var program = programs.GetAll();
                    var termclass = termclasses.GetAll(x => x.Name == check.ClassName).FirstOrDefault();

                    List<ProgramResponse> results = new List<ProgramResponse>();
                    foreach (var temp in program)
                    {
                        if (temp.TermClassId == termclass.Id)
                        {
                            var user = users.GetAll(x => x.Id == temp.UserId).FirstOrDefault();
                            var day = days.GetAll(x => x.Id == temp.RefDayId).FirstOrDefault();
                            var time = times.GetAll(x => x.Id == temp.RefTimeId).FirstOrDefault();
                            var lesson = lessons.GetAll(x => x.Id == temp.RefLessonId).FirstOrDefault();

                            results.Add(new ProgramResponse() { LessonName = lesson.Name, TeacherName = user.Name + " " + user.Surname, Time = time.Name, Day = day.Name, ClassName = termclass.Name });
                        }

                    }
                    return results;
                }
            }
            catch (Exception ex)
            {
                //  Return any exception messages back to the Response header
                OutgoingWebResponseContext responsee = WebOperationContext.Current.OutgoingResponse;
                responsee.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responsee.StatusDescription = ex.Message.Replace("\r\n", "");
                return null;
            }
        }

        public List<GetClass> GetAllClass()
        {
            try
            {
                var bc = buildingclasses.GetAll();

                List<GetClass> results = new List<GetClass>();
                foreach (var temp in bc)
                {
                    var building = buildings.GetAll(x => x.Id == temp.BuildingId).FirstOrDefault();
                    var floor = floors.GetAll(x => x.Id == temp.RefFloorNumberId).FirstOrDefault();
                    var school = schools.GetAll(x => x.Id == building.SchoolId).FirstOrDefault();
                    var termclass = termclasses.GetAll(x => x.BuildingClassId == temp.Id).FirstOrDefault();
                    if (termclass != null)
                    {
                        var term = terms.GetAll(x => x.Id == termclass.TermId).FirstOrDefault();

                        results.Add(new GetClass() { BuildingClassName = temp.Name, BuildingName = building.Name, Floor = floor.Name, SchoolName = school.Name, ClassName = termclass.Name, Term = term.Name });
                    }

                }
                return results;
            }
            catch (Exception ex)
            {
                //  Return any exception messages back to the Response header
                OutgoingWebResponseContext responsee = WebOperationContext.Current.OutgoingResponse;
                responsee.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responsee.StatusDescription = ex.Message.Replace("\r\n", "");
                return null;
            }
        }

        public List<GetGroupUsers> GetAllGroupUsers()
        {
            try
            {
                var usergroup = usergroups.GetAll();

                List<GetGroupUsers> results = new List<GetGroupUsers>();
                foreach (var temp in usergroup)
                {
                    var user = users.GetAll(x => x.Id == temp.UserId).FirstOrDefault();
                    var group = groups.GetAll(x => x.Id == temp.GroupId).FirstOrDefault();

                    results.Add(new GetGroupUsers() { GroupName = group.Name, StudentName = user.Name + " " + user.Surname });
                }
                return results;
            }
            catch (Exception ex)
            {
                //  Return any exception messages back to the Response header
                OutgoingWebResponseContext responsee = WebOperationContext.Current.OutgoingResponse;
                responsee.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                responsee.StatusDescription = ex.Message.Replace("\r\n", "");
                return null;
            }
        }
        #endregion
    }

    #region Türler
    [DataContract]
    public class GetUsers
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string EMail { get; set; }

        [DataMember]
        public string RefUserType { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public string UserCreated { get; set; }

    }

    [DataContract]
    public class GetBeacons
    {
        [DataMember]
        public int BeaconId { get; set; }

        [DataMember]
        public string Data/*uuid+major+minor*/ { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string County { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string School { get; set; }

        [DataMember]
        public string Floor { get; set; }

        [DataMember]
        public string Class { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }

        [DataMember]
        public string UserCreated { get; set; }

    }

    [DataContract]
    public class GetGroups
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Class { get; set; }

        [DataMember]
        public string Lesson { get; set; }

        [DataMember]
        public string Topic { get; set; }
    }

    [DataContract]
    public class GetPlaceholder
    {
        [DataMember]
        public bool IsOver { get; set; }

        [DataMember]
        public string Teacher { get; set; }

        [DataMember]
        public string Lesson { get; set; }

        [DataMember]
        public string Topic { get; set; }

        [DataMember]
        public string Class { get; set; }
    }

    [DataContract]
    public class GetSchool
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Building { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string County { get; set; }

        [DataMember]
        public string Country { get; set; }
    }

    [DataContract]
    public class GetTablets
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FullName { get; set; }
    }

    public class ClassRequest
    {
        public string ClassName { set; get; }
    }

    public class ClassResponse
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
    }

    public class ProgramRequest
    {
        public string ClassName { get; set; }
    }

    public class ProgramResponse
    {
        public string LessonName { get; set; }
        public string Time { get; set; }
        public string Day { get; set; }
        public string TeacherName { get; set; }
        public string ClassName { get; set; }
    }

    [DataContract]
    public class GetClass
    {
        [DataMember]
        public string ClassName { get; set; }

        [DataMember]
        public string SchoolName { get; set; }

        [DataMember]
        public string BuildingName { get; set; }

        [DataMember]
        public string Floor { get; set; }

        [DataMember]
        public string Term { get; set; }

        [DataMember]
        public string BuildingClassName { get; set; }
    }

    [DataContract]
    public class GetGroupUsers
    {
        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public string StudentName { get; set; }
    }
    #endregion
}
