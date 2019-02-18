using System;
using System.Collections.Generic;

namespace StudentApp.Domain
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Grade> Grades {get;set;}
    }
}
