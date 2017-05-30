using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using Thoth.Business.Service;

namespace Thoth.Web.Services
{
    // NOT: "IService1" arabirim adını kodda ve yapılandırma dosyasında birlikte değiştirmek için "Yeniden Düzenle" menüsündeki "Yeniden Adlandır" komutunu kullanabilirsiniz.
    [ServiceContract]
    public interface IWebService
    {
        #region Servis Tanımlamaları
        [OperationContract]
        HashResponse Login(HashRequest check);

        [OperationContract]
        HashResponse Logout();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllUsers")]
        List<GetUsers> GetAllUsers();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllBeacons")]
        List<GetBeacons> GetAllBeacons();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllGroups")]
        List<GetGroups> GetAllGroups();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllGroupUsers")]
        List<GetGroupUsers> GetAllGroupUsers();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllPlaceholder")]
        List<GetPlaceholder> GetAllPlaceholder();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllSchool")]
        List<GetSchool> GetAllSchool();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllTablets")]
        List<GetTablets> GetAllTablets();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllClass")]
        List<GetClass> GetAllClass();

        [OperationContract]
        List<ClassResponse> GetAllClassUsers(ClassRequest check);

        [OperationContract]
        List<ProgramResponse> GetAllClassPrograms(ProgramRequest check);
#endregion
        // TODO: Hizmet işlemlerinizi buraya ekleyin
    }
    // Hizmet işlemlerine bileşik türler eklemek için, aşağıdaki örnekte gösterildiği şekilde bir veri sözleşmesi kullanın.
#region Türler
    public class HashResponse
    {
        [DataMember]
        public string Token { set; get; }
    }

    public class HashRequest
    {
        [DataMember]
        public string Username { set; get; }
        
        [DataMember]
        public string Password { set; get; }
    }
#endregion
}