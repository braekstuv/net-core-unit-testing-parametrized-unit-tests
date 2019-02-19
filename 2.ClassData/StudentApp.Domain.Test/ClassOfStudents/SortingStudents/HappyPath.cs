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
        [ClassData(typeof(RandomOrderStudentListData))]
        [ClassData(typeof(ReverseOrderStudentListData))]
        public void SortingStudents_GivenUnorderedList_ShouldReturnListInExpectedOrder(IEnumerable<Student> unordered, IEnumerable<Student> ordered){
            //Arrange
            var classOfStudents = new ClassOfStudents(0);
            
            //Act
            classOfStudents.AddStudents(unordered);

            //Assert
            classOfStudents.Students.Should().ContainInOrder(ordered);
        }

        [Theory]
        [ClassData(typeof(CompareStudentToSucessorsData))]
        public void SortingStudents_GivenUnorderedListAndStudent_StudentShouldBeAtExpectedPosition(Student firstStudent, Student secondStudent, string because){
            //Arrange
            var classOfStudents = new ClassOfStudents(0);
           
            //Act
            classOfStudents.AddStudents(new List<Student>{secondStudent, firstStudent});

            //Assert
            classOfStudents.Students.ToList()[0].Should().Be(firstStudent, because);
        }
    }

    public class CompareStudentToSucessorsData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var students = TestStudents.OrderedStudentsWithOrderReasonList.ToList();
            for(int i = 0; i < students.Count-1; i++){
                var firstStudent = students[i];
                foreach (var secondStudent in students.Skip(i+1))
                {
                    yield return new object[] { firstStudent.Student, secondStudent.Student, firstStudent.OrderReason };
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class RandomOrderStudentListData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var orderedStudents = TestStudents.GetOrderedStudentsList();
            var shuffleStudents = TestStudents.GetOrderedStudentsList();
            do{
                shuffleStudents.Shuffle();
            }while(shuffleStudents.All(x => shuffleStudents.IndexOf(x) == orderedStudents.IndexOf(x)));
            yield return new object[] { shuffleStudents, orderedStudents };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ReverseOrderStudentListData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            var orderedStudents = TestStudents.GetOrderedStudentsList();
            var reverseStudents = TestStudents.GetOrderedStudentsList();
            reverseStudents.Reverse();
            yield return new object[] { reverseStudents, orderedStudents };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public static class TestStudents{
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

        public static readonly IReadOnlyCollection<(Student Student, string OrderReason)> OrderedStudentsWithOrderReasonList =
            new List<(Student student, string orderReason)>(){
                (HighestGradeCount, "this student has the highest grade count"),
                (HighestGradeAverage, "this student has the highest grade average"),
                (OldestStudent, "this student is the oldest"),
                (AlphabeticalFirstStudent, "this student is alphabetically first"),
                (LastStudent, "this student should be last")
            };

        public static List<Student> GetOrderedStudentsList(){
           return OrderedStudentsWithOrderReasonList.Select(x => x.Student).ToList();
        }
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