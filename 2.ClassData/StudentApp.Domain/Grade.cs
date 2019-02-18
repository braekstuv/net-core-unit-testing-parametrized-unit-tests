using System;

namespace StudentApp.Domain
{
    public class Grade
    {
        private Fraction _score {get;set;}
        private readonly int _courseId;
        public Grade (Fraction score, int courseId){
            _score = score;
            _courseId = courseId;
        }
    }
}
