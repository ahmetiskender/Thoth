using Thoth.Business.Abstract; 
using Thoth.Data.Concrete.EntityFramework;
using Thoth.Entity.Concrete;
using Thoth.Framework.Core.Concretes.BusinessLayer; 

namespace Thoth.Business.Concrete.Managers
{
    public class RefFloorNumbersManager : Business<RefFloorNumbers,EfRefFloorNumbersDal>,IRefFloorNumbersService
    { 
         
    }
}