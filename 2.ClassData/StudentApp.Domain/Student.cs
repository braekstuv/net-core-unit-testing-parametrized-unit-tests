using System;
using System.Collections.Generic;

namespace StudentApp.Domain
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Grade> Grades {get;set;} = new List<Grade>();
    }
}
