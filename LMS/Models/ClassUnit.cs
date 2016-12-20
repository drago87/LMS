using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LMS.Models
{
    class ClassUnit
    {
        [Key]
        public int ClassUnitID { get; set; }
        public string ClassName { get; set; }
        [ForeignKey("Folder")]
        public Folder Folders { get; set; }

        public virtual List<Folder> Folder { get; set; }
    }
}
