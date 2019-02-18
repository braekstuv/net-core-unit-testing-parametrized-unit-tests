using System;

namespace StudentApp.Domain
{
    public class Grade
    {
        public Fraction Score {get;}
        private readonly int _courseId;
        public Grade (Fraction score, int courseId){
            if(score.GetPercentage() < 0)
                throw new ArgumentException($"A student's score cannot be negative.");

            Score = score;
            _courseId = courseId;
        }


    }
}
