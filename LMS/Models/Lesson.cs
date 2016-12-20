﻿using System;
using System.Collections.Generic;
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
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        [ForeignKey("Subject")]
        public Subject SubjectID { get; set; }
        [ForeignKey("ClassUnit")]
        public ClassUnit ClassUnitID { get; set; }
    }
}