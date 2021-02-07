using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Data.Models
{
    public class Course
    {
        [Key]
        public int COURSE_ID { get; set; }
        [Display(Name = "Name:")]
        public string NAME { get; set; }
        [Display(Name = "Description:")]
        public string DESCRIPTION { get; set; }
    }
}
