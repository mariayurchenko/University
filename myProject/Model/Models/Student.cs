using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Data.Models
{
    public class Student
    {
        [Key]
        public int STUDENT_ID { get; set; }
        [Display(Name = "Group:")]
        public int GROUP_ID { get; set; }
        [Display(Name = "First name:")]
        public string FIRST_NAME { get; set; }
        [Display(Name = "Last name:")]
        public string LAST_NAME { get; set; }
        public virtual Group Group { get; set; }
    }
}
