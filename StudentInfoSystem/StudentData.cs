using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLoginNEW;

namespace StudentInfoSystem
{
    public class StudentData
    {
        public List<Student> _testStudents = new List<Student>();
        public List<Student> TestStudents
        {
            get
            {
                SetData();
                return _testStudents;
            }
            set
            {
                
            }
        }
        public static Student IsThereStudent(String facNumber) 
        {
            StudentInfoContext context = new StudentInfoContext();
            Student result =
            (from st in context.Students
             where st.FacNumber == facNumber
             select st).First();
            return result;
        } 
        private void SetData() 
        {
            _testStudents.Add(new Student
            {
                FirstName = "Hristo",
                MiddleName = "Nikolaev",
                LastName = "Iliev",
                Faculty = "FKST",
                Specialty = "KSI",
                Degree = "bakalavur",
                Status = "active",
                FacNumber = "121217091",
                Year = 3,
                Flow = 9,
                Group = 38
            });
            _testStudents.Add(new Student
            {
                FirstName = "Ivan",
                MiddleName = "Georgiev",
                LastName = "Ivanov",
                Faculty = "FKST",
                Specialty = "KSI",
                Degree = "bakalavur",
                Status = "active",
                FacNumber = "121217062",
                Year = 3,
                Flow = 9,
                Group = 38
            });
        }
        
    }
}
