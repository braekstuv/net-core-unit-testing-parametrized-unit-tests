using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StudentApp.Domain
{
    public class ClassOfStudents
    {
        public int Year {get;private set;}
        public List<Student> _students = new List<Student>();

        public ClassOfStudents(int year)
        {
            Year = year;
        }

        public void AddStudents(IEnumerable<Student> students){
            _students.AddRange(students);
            SortStudents();
        }

        private void SortStudents()
        {
            _students = _students
            .OrderByDescending(x => x.Grades.Count)
            .ThenByDescending(x => x.Grades.Average(y => y.Score.GetPercentage()))
            .ThenBy(x => x.DateOfBirth)
            .ThenBy(x => x.LastName+x.FirstName)
            .ToList();
        }

        public IReadOnlyCollection<Student> Students => _students;
    }
}
