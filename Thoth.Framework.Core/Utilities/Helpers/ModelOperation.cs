using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thoth.Framework.Core.Utilities.Helpers
{
    public static class ModelOperation<T>
    {
        public static T Modify(dynamic model, Op operation)
        {
           

            //TODO: Ef içine OwnerId şu ve Id şu ise Update yap gibi şeyler eklenebilir.
            if (operation == Op.Insert)
            {
                model.CreatedAt = DateTime.Now; 
                model.IsModified = false;
                model.ModifiedAt = DateTime.Now; 
                model.IsDeleted = false; 
                model.IsVersioned = false;
                model.Version = 1;
                model.ParentId = null;

            }
            else if (operation == Op.Update)
            {
                model.IsModified = true;
                model.ModifiedAt = DateTime.Now; 
            }
            else if (operation == Op.Delete)
            {
                model.IsDeleted = true;
                model.ModifiedAt = DateTime.Now; 
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
