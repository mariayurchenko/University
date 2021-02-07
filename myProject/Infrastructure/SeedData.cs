using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myProject.Data.Models;
//using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public class SeedData
    {
        private static Dictionary<string, Course> course;
        private static Dictionary<string, Course> Courses
        {
            get
            {
                if (course == null)
                {
                    var list = new Course[]
                    {
                        new Course {NAME = "C#./NET", DESCRIPTION = "C# course"},
                        new Course {NAME = "JAVA", DESCRIPTION = "JAVA course"}
                    };

                    course = new Dictionary<string, Course>();
                    foreach (Course el in list)
                        course.Add(el.NAME, el);
                }

                return course;
            }
        }
        private static Dictionary<string, Group> group;
        private static Dictionary<string, Group> Groups
        {
            get
            {
                if (group == null)
                {
                    var list = new Group[]
                    {
                        new Group {NAME = "PD-11", Course = Courses["JAVA"]},
                        new Group {NAME = "SR-01", Course = Courses["C#./NET"]},
                        new Group {NAME = "PD-12", Course = Courses["JAVA"]},
                        new Group {NAME = "PD-13", Course = Courses["JAVA"]},
                        new Group {NAME = "SR-02", Course = Courses["C#./NET"]}
                    };

                    group = new Dictionary<string, Group>();
                    foreach (Group el in list)
                        group.Add(el.NAME, el);
                }

                return group;
            }
        }
        public static void Initial(AppDBContent content)
        {
            if (!content.Course.Any())
                content.Course.AddRange(Courses.Select(c => c.Value));

            if (!content.Group.Any())
                content.Group.AddRange(Groups.Select(c => c.Value));

            if (!content.Student.Any())
            {
                content.Student.AddRange(
                    new Student {FIRST_NAME = "Ethelbert", LAST_NAME = "Quinn", Group = Groups["PD-11"]},
                    new Student {FIRST_NAME = "Gavin", LAST_NAME = "Wilson", Group = Groups["SR-02"]},
                    new Student {FIRST_NAME = "Hector", LAST_NAME = "Garrison", Group = Groups["SR-01"]},
                    new Student {FIRST_NAME = "Emily", LAST_NAME = "Harrell", Group = Groups["PD-12"]},
                    new Student {FIRST_NAME = "Millicent", LAST_NAME = "Curtis", Group = Groups["SR-02"]},
                    new Student {FIRST_NAME = "Ann", LAST_NAME = "Andrews", Group = Groups["SR-02"]},
                    new Student {FIRST_NAME = "Jacob", LAST_NAME = "Holmes", Group = Groups["PD-12"]},
                    new Student {FIRST_NAME = "Jocelyn", LAST_NAME = "Richard", Group = Groups["PD-11"]},
                    new Student {FIRST_NAME = "Magdalen", LAST_NAME = "Terry", Group = Groups["PD-11"]},
                    new Student {FIRST_NAME = "Jasmin", LAST_NAME = "Goodman", Group = Groups["PD-11"]},
                    new Student {FIRST_NAME = "Alexander", LAST_NAME = "Ford", Group = Groups["PD-11"]},
                    new Student {FIRST_NAME = "Ashlyn", LAST_NAME = "Stevens", Group = Groups["PD-13"]},
                    new Student {FIRST_NAME = "Asher", LAST_NAME = "McDowell", Group = Groups["PD-11"]},
                    new Student {FIRST_NAME = "Kerry", LAST_NAME = "Newton", Group = Groups["PD-11"]},
                    new Student {FIRST_NAME = "Christal", LAST_NAME = "Palmer", Group = Groups["SR-02"]},
                    new Student {FIRST_NAME = "John", LAST_NAME = "Watson", Group = Groups["SR-01"]},
                    new Student {FIRST_NAME = "Fay", LAST_NAME = "Sullivan", Group = Groups["SR-01"]},
                    new Student {FIRST_NAME = "Wesley", LAST_NAME = "Hicks", Group = Groups["PD-11"]},
                    new Student {FIRST_NAME = "Imogen", LAST_NAME = "Maxwell", Group = Groups["PD-11"]},
                    new Student {FIRST_NAME = "Alicia", LAST_NAME = "Mitchell", Group = Groups["PD-11"]},
                    new Student {FIRST_NAME = "Claud", LAST_NAME = "Perkins", Group = Groups["SR-01"]},
                    new Student {FIRST_NAME = "Margaret", LAST_NAME = "Jackson", Group = Groups["PD-12"]},
                    new Student {FIRST_NAME = "Peter", LAST_NAME = "Barton", Group = Groups["SR-02"]},
                    new Student {FIRST_NAME = "Rosalind", LAST_NAME = "Norton", Group = Groups["SR-02"]},
                    new Student {FIRST_NAME = "Emory", LAST_NAME = "Harris", Group = Groups["SR-02"]},
                    new Student {FIRST_NAME = "Griffin", LAST_NAME = "Holland", Group = Groups["SR-01"]},
                    new Student {FIRST_NAME = "Olivia", LAST_NAME = "Washington", Group = Groups["SR-01"]},
                    new Student {FIRST_NAME = "Amber", LAST_NAME = "Oliver", Group = Groups["PD-11"]},
                    new Student {FIRST_NAME = "Shana", LAST_NAME = "Miller", Group = Groups["PD-11"]},
                    new Student {FIRST_NAME = "Ross", LAST_NAME = "Ferguson", Group = Groups["SR-01"]},
                    new Student {FIRST_NAME = "Rosalyn", LAST_NAME = "Norton", Group = Groups["SR-01"]},
                    new Student {FIRST_NAME = "Abner", LAST_NAME = "Powers", Group = Groups["PD-13"]},
                    new Student {FIRST_NAME = "Emma", LAST_NAME = "Hubbard", Group = Groups["SR-01"]},
                    new Student {FIRST_NAME = "Olivia", LAST_NAME = "Horton", Group = Groups["SR-01"]},
                    new Student {FIRST_NAME = "Easter", LAST_NAME = "Clarke", Group = Groups["SR-02"]},
                    new Student {FIRST_NAME = "William", LAST_NAME = "Watkins", Group = Groups["SR-02"]},
                    new Student {FIRST_NAME = "Anthony", LAST_NAME = "Harrison", Group = Groups["SR-02"]},
                    new Student {FIRST_NAME = "Dennis", LAST_NAME = "Booker", Group = Groups["SR-02"]},
                    new Student {FIRST_NAME = "Mark", LAST_NAME = "Montgomery", Group = Groups["PD-11"]},
                    new Student {FIRST_NAME = "David", LAST_NAME = "Morrison", Group = Groups["SR-01"]}
                );
            }
            content.SaveChanges();
        }
    }
    
}
