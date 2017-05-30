using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thoth.Business.ValidationRules
{
    public  class Listeleme
    {
        public  int Id { get; set; }

        public  string Name { get; set; }

        public  string Surname { get; set; }

        public  string Username { get; set; }

        public  string Hash { get; set; }

        public  int RefUserTypeId { get; set; }

        public  DateTime CreatedAt { get; set; }

        public  int UserIdCreated { get; set; }

        public  Boolean IsModified { get; set; }

        public  DateTime ModifiedAt { get; set; }

        public  int UserIdModified { get; set; }

        public  Boolean IsDeleted { get; set; }

        public  int UserIdDeleted { get; set; }

        public  Boolean IsVersioned { get; set; }

        public  int Version { get; set; }

        public  int? ParentId { get; set; }

        public  string EMail { get; set; }
    }
}
