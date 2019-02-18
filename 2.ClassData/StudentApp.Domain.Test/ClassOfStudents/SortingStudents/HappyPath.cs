using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace StudentApp.Domain.Test
{
    public class HappyPath{
        [Theory]
        [ClassData(typeof(UnorderedListTestData))]
        public void SortingStudents_GivenUnorderedList_ShouldReturnListInExpectedOrder(IEnumerable<Student> unordered, IEnumerable<Student> ordered){
            //Arrange
            var classOfStudents = new ClassOfStudents(0);
            
            //Act
            classOfStudents.AddStudents(unordered);

            //Assert
            classOfStudents.Students.Should().ContainInOrder(ordered);
        }

        [Theory]
        [ClassData(typeof(OrderedStudentsTestData))]
        public void SortingStudents_GivenUnorderedListAndStudent_StudentShouldBeAtExpectedPosition(Student firstStudent, Student lastStudent, string because){
            //Arrange
            var classOfStudents = new ClassOfStudents(0);

            //Act
            classOfStudents.AddStudents(new List<Student>{lastStudent, firstStudent});

            //Assert
            classOfStudents.Students.Should().HaveElementAt(0, firstStudent, because);
        }
    }

    public class OrderedStudentsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {TestStudents.HighestGradeCount, TestStudents.LastStudent, $"the student that is expected to be first has the highest grade count" };
            yield return new object[] {TestStudents.HighestGradeAverage, TestStudents.LastStudent, $"the student that is expected to be first has the highest grade average" };
            yield return new object[] {TestStudents.OldestStudent, TestStudents.LastStudent, $"the student that is expected to be first is the oldest"};
            yield return new object[] {TestStudents.AlphabeticalFirstStudent, TestStudents.LastStudent, $"the student that is expected to be first is alphabetically first by first and last name"};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UnorderedListTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new[] {TestStudents.ReverseOrderedStudentList, TestStudents.OrderedStudentList};
            yield return new[] {TestStudents.ShuffledOrderedStudentList, TestStudents.OrderedStudentList};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static class TestStudents{
        public static IReadOnlyCollection<Student> OrderedStudentList =>
            new List<Student>(){
                HighestGradeCount,
                HighestGradeAverage,
                OldestStudent,
                AlphabeticalFirstStudent,
                LastStudent
            };

        public static IReadOnlyCollection<Student> ReverseOrderedStudentList 
        {
            get{
                var students = OrderedStudentList.ToList();
                students.Reverse();
                return students;
            }
        }

        public static IReadOnlyCollection<Student> ShuffledOrderedStudentList 
        {
            get{
                var students = OrderedStudentList.ToList();
                students.Shuffle();
                return students;
            }
        }

        public static readonly Student HighestGradeCount = new Student{
            Grades = new List<Grade>(){
                new Grade(new Fraction(1,1),1),
                new Grade(new Fraction(1,2),2)
            },
            DateOfBirth = new DateTime(1995,02,05)
        };

        public static readonly Student HighestGradeAverage = new Student{
            Grades = new List<Grade>(){
                new Grade(new Fraction(1,1),1),
            },
            DateOfBirth = new DateTime(1995,02,05)
        };

        public static readonly Student OldestStudent = new Student{
            Grades = new List<Grade>(){
                new Grade(new Fraction(1,2),1),
            },
            DateOfBirth = new DateTime(1990,02,10)
        };

        public static readonly Student AlphabeticalFirstStudent = new Student{
            FirstName = "AAAA",
            LastName = "AAAAA",
            Grades = new List<Grade>(){
                new Grade(new Fraction(1,2),1),
            },
            DateOfBirth = new DateTime(1995,02,05)
        };

        public static readonly Student LastStudent = new Student{
            FirstName = "ZZZZZZ",
            LastName = "ZZZZZZZ",
            Grades = new List<Grade>(){
                new Grade(new Fraction(1,2),1),
            },
            DateOfBirth = new DateTime(1995,02,05)
        };

    }
    public static class ShuffleListExtension{
        private static Random rng = new Random();  

        public static void Shuffle<T>(this IList<T> list)  
        {  
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = rng.Next(n + 1);  
                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }
    }
    
}