using System; 
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Web;
using Thoth.Business.Abstract;
using Thoth.Business.Concrete.Managers;
using Thoth.Business.Service;
using Thoth.Business.ValidationRules;
using Thoth.Entity.Concrete;

namespace Thoth.Web.Services
{
    // NOT: "Service1" sınıf adını kodda, svc'de ve yapılandırma dosyasında birlikte değiştirmek için "Yeniden Düzenle" menüsündeki "Yeniden Adlandır" komutunu kullanabilirsiniz.
    // NOT: Bu hizmeti test etmek üzere WCF Test İstemcisi'ni başlatmak için lütfen Çözüm Gezgini'nde Service1.svc'yi veya Service1.svc.cs'yi seçin ve hata ayıklamaya başlayın.
    public class WebService : IWebService
    {
        #region Tanımlamalar
        HashResponse response = new HashResponse();
        Verification valdation = new Verification();
        Service service = new Service();
        #endregion 

        #region Web Servis Fonksiyonları
        public HashResponse Login(HashRequest check)
        {
            response.Token = valdation.GetToken(check.Username, check.Password);

            return response;
        }
        public HashResponse Logout()
        {
            response.Token = valdation.DeleteIsToken();

            return response;
        }

        public List<GetUsers> GetAllUsers()
        {
            return service.GetAllUsers();
        }

        public List<GetBeacons> GetAllBeacons()
        {
            return service.GetAllBeacons();
        }

        public List<GetGroups> GetAllGroups()
        {
            return service.GetAllGroups();
        }

        public List<GetPlaceholder> GetAllPlaceholder()
        {
            return service.GetAllPlaceholder();
        }

        public List<GetSchool> GetAllSchool()
        {
            return service.GetAllSchool();
        }

        public List<GetTablets> GetAllTablets()
        {
            return service.GetAllTablets();
        }

        public List<ClassResponse> GetAllClassUsers(ClassRequest check)
        {
            return service.GetAllClassUsers(check);
        }

        public List<ProgramResponse> GetAllClassPrograms(ProgramRequest check)
        {
            return service.GetAllClassPrograms(check);
        }

        public List<GetClass> GetAllClass()
        {
            return service.GetAllClass();
        }

        public List<GetGroupUsers> GetAllGroupUsers()
        {
            return service.GetAllGroupUsers();
        }
        #endregion
    }
}
