using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class Lesson
    {
        [Key]
        public int LessonID { get; set; }
        [DisplayName("Lesson Start")]
        public DateTime StartTime { get; set; }
        [DisplayName("Lesson Done")]
        public DateTime StopTime { get; set; }
        [ForeignKey("subject")]
        public Subject SubjectID { get; set; }
        [ForeignKey("classUnit")]
        public ClassUnit ClassUnitID { get; set; }

        public virtual Subject subject { get; set; }

        public virtual ClassUnit classUnit { get; set; }
    }
}