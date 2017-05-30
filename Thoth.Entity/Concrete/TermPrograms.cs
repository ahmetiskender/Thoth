using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Thoth.Framework.Core.Abstracts.EntityLayer;

namespace Thoth.Entity.Concrete
{
    [Serializable]
    [Table("thoth_term_programs", Schema = "ydyazilim_thoth")]
    public class TermPrograms : IEntity
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("term_class_id", TypeName = "int")]
        public int TermClassId { get; set; }

        [Column("ref_day_id", TypeName = "int")]
        public int RefDayId { get; set; }

        [Column("ref_time_id", TypeName = "int")]
        public int RefTimeId { get; set; }

        [Column("ref_lesson_id", TypeName = "int")]
        public int RefLessonId { get; set; }

        [Column("user_id", TypeName = "int")]
        public int UserId { get; set; }

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

        [Column("parent_id", TypeName = "int")]
        public int? ParentId { get; set; }

        [ForeignKey("TermClassId")]
        public virtual TermClasses TermClassesObject { get; set; }

        [ForeignKey("RefDayId")]
        public virtual RefDays RefDaysObject { get; set; }

        [ForeignKey("RefTimeId")]
        public virtual RefTimes RefTimesObject { get; set; }

        [ForeignKey("RefLessonId")]
        public virtual RefLessons RefLessonsObject { get; set; }

        [ForeignKey("UserId")]
        public virtual Users UsersObject { get; set; }

    }

}
