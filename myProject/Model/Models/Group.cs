using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Data.Models
{
    public class Group
    {
        [Key]
        public int GROUP_ID { get; set; }
        [Display(Name = "Course:")]
        public int COURSE_ID { get; set; }
        [Display(Name = "Name:")]
        public string NAME { get; set; }
        public virtual Course Course { get; set; }
    }
}
