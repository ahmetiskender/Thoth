using Thoth.Data.Abstract; 
using Thoth.Entity.Concrete;
using Thoth.Framework.Core.Concretes.DataLayer;  

namespace Thoth.Data.Concrete.EntityFramework
{
   public class EfRefActivityTypesDal :Data<RefActivityTypes, ThothContext >, IRefActivityTypesDal
   {
      
   }
}