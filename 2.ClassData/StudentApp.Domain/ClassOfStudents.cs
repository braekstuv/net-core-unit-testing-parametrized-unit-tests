using System;
using System.Collections.Generic;

namespace StudentApp.Domain
{
    public class ClassOfStudents
    {
        public int Year {get;private set;}
        private readonly List<Student> _students = new List<Student>();

        public ClassOfStudents(int year)
        {
            Year = year;
        }

        private void AddStudents(IEnumerable<Student> students){
            _students.AddRange(students);
        }
    }
}
