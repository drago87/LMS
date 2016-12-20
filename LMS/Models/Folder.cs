using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LMS.Models
{
    public class Folder
    {
        [Key]
        public int FolderID { get; set; }
        [DisplayName("Folder Name")]
        public string FolderName { get; set; }
        [ForeignKey("Files")]
        public Files _Files { get; set; }

        public virtual List<Files> Files { get; set; }
    }
}
