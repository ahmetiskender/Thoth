using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Teos.Net.Papers.Framework.Core.Entities
{
    public interface IEntity
    {
        [Key]
        [Column("id", TypeName = "int")]
        int Id { get; set; }

        [DefaultValue("(getdate())")]
        [Column("created_at", TypeName = "datetime2")]
        DateTime CreatedAt { get; set; }

        [DefaultValue("((-1))")]
        [Column("user_id_created", TypeName = "int")]
        int UserIdCreated { get; set; }

        [DefaultValue("((0))")]
        [Column("is_modified", TypeName = "bit")]
        Boolean IsModified { get; set; }

        [DefaultValue("(getdate())")]
        [Column("modified_at", TypeName = "datetime2")]
        DateTime ModifiedAt { get; set; }

        [DefaultValue("((-1))")]
        [Column("user_id_modified", TypeName = "int")]
        int UserIdModified { get; set; }

        [DefaultValue("((0))")]
        [Column("is_deleted", TypeName = "bit")]
        Boolean IsDeleted { get; set; }

        [DefaultValue("(getdate())")]
        [Column("deleted_at", TypeName = "datetime2")]
        DateTime DeletedAt { get; set; }

        [DefaultValue("((-1))")]
        [Column("user_id_deleted", TypeName = "int")]
        int UserIdDeleted { get; set; }

        [DefaultValue("((0))")]
        [Column("is_versioned", TypeName = "bit")]
        Boolean IsVersioned { get; set; }

        [DefaultValue("((1))")]
        [Column("version", TypeName = "int")]
        int Version { get; set; }

        [Column("parent_id", TypeName = "int")]
        int? ParentId { get; set; }
    }
}
