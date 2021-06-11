using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLoginNEW;

namespace StudentInfoSystem
{
    public class Student
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }
        public string Degree { get; set; }
        public string Status { get; set; }
        public string FacNumber { get; set; }
        public int Year { get; set; }
        public int Flow { get; set; }
        public int Group { get; set; }
        public int StudentId { get; set; }
        
    }   
}
