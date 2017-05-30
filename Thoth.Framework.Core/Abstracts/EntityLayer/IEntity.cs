using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thoth.Framework.Core.Abstracts.EntityLayer
{
    public interface IEntity
    {
        [Key]
        [Column("id", TypeName = "int")]
        int Id { get; set; }

        [Column("created_at", TypeName = "datetime2")]
        DateTime CreatedAt { get; set; }

        [Column("user_id_created", TypeName = "int")]
        int UserIdCreated { get; set; }

        [Column("is_modified", TypeName = "bit")]
        Boolean IsModified { get; set; }

        [Column("modified_at", TypeName = "datetime2")]
        DateTime ModifiedAt { get; set; }

        [Column("user_id_modified", TypeName = "int")]
        int UserIdModified { get; set; }

        [Column("is_deleted", TypeName = "bit")]
        Boolean IsDeleted { get; set; }

        [Column("is_versioned", TypeName = "bit")]
        Boolean IsVersioned { get; set; }

        [Column("version", TypeName = "int")]
        int Version { get; set; }

        [Column("parent_id", TypeName = "int")]
        int? ParentId { get; set; }

    }
}
