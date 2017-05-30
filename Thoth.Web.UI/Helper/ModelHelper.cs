using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Thoth.Web.UI.Helper;

namespace Thoth.Web.UI.Helpers
{
    public static class ModelHelper
    {
        public static object convertObjectToObject(object value, object emptyObject)
        {
            System.Reflection.MemberInfo[] pis = value.GetType().GetMembers();
            foreach (System.Reflection.MemberInfo pi in pis)
            {
                if (pi.MemberType == MemberTypes.Property)
                {
                    PropertyInfo propertyInfo = emptyObject.GetType().GetProperty(pi.Name);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(emptyObject, value.GetType().GetProperty(pi.Name).GetValue(value, null), null);
                    }
                }
            }
            return emptyObject;
        }
    }
    public static class ModelOperation<T>
    {
        public static T Modify(dynamic model, Op operation)
        {
            int userId = -1 /*UserHelper.GetCurrentMemberUserId()*/;

            //TODO: Ef içine OwnerId şu ve Id şu ise Update yap gibi şeyler eklenebilir.
            if (operation == Op.Insert)
            {
                model.CreatedAt = DateTime.Now;
                model.UserIdCreated = userId;
                model.IsModified = false;
                model.ModifiedAt = DateTime.Now;
                model.UserIdModified = userId;
                model.IsDeleted = false;
                model.DeletedAt = DateTime.Now;
                model.UserIdDeleted = -1;
                model.IsVersioned = false;
                model.Version = 1;
                model.ParentId = 1;

            }
            else if (operation == Op.Update)
            {
                model.IsModified = true;
                model.ModifiedAt = DateTime.Now;
                model.UserIdModified = userId;
            }
            else if (operation == Op.Delete)
            {
                model.IsDeleted = true;
                model.DeletedAt = DateTime.Now;
                model.UserIdDeleted = userId;
            }
            return model;
        }

        public static List<T> Shuffle(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }

    public enum Op
    {
        Insert,
        Update,
        Delete
    }
}
