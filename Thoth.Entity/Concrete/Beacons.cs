using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Thoth.Framework.Core.Abstracts.EntityLayer;

namespace Thoth.Entity.Concrete
{
    [Serializable]
    [Table("thoth_beacons", Schema = "ydyazilim_thoth")]
    public class Beacons :IEntity
    {
        [Key]
	    [Column("id", TypeName = "int")]
	    public int Id { get; set; }

	    [Column("uuid", TypeName = "bigint")]
	    public long Uuid { get; set; }

	    [Column("major", TypeName = "int")]
	    public int Major { get; set; }

	    [Column("minor", TypeName = "int")]
	    public int Minor { get; set; }

	    [DefaultValue("(getdate())")]
	    [Column("created_at", TypeName = "datetime2")]
	    public DateTime CreatedAt { get; set; }

	    [DefaultValue("((-1))")]
	    [Column("user_id_created", TypeName = "int")]
	    public int UserIdCreated { get; set; }

	    [DefaultValue("((0))")]
	    [Column("is_modified", TypeName = "bit")]
	    public Boolean IsModified { get; set; }

	    [DefaultValue("(getdate())")]
	    [Column("modified_at", TypeName = "datetime2")]
	    public DateTime ModifiedAt { get; set; }

	    [DefaultValue("((-1))")]
	    [Column("user_id_modified", TypeName = "int")]
	    public int UserIdModified { get; set; }

	    [DefaultValue("((0))")]
	    [Column("is_deleted", TypeName = "bit")]
	    public Boolean IsDeleted { get; set; }

	    //[DefaultValue("(getdate())")]
	    //[Column("deleted_at", TypeName = "datetime2")]
	    //public DateTime DeletedAt { get; set; }

	    [DefaultValue("((-1))")]
	    [Column("user_id_deleted", TypeName = "int")]
	    public int UserIdDeleted { get; set; }

	    [DefaultValue("((0))")]
	    [Column("is_versioned", TypeName = "bit")]
	    public Boolean IsVersioned { get; set; }

	    [DefaultValue("((1))")]
	    [Column("version", TypeName = "int")]
	    public int Version { get; set; }

	    [DefaultValue("((0))")]
	    [Column("parent_id", TypeName = "int")]
	    public int? ParentId { get; set; }

    }

}
