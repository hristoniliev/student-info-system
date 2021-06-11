using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInformationSystem
{
    class StudentData
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

        private void SetData() 
        {
            _testStudents.Add(new Student
            {
                _firstName = "Hristo",
                _middleName = "Nikolaev",
                _lastName = "Iliev",
                _faculty = "FKST",
                _specialty = "KSI",
                _degree = "bakalavur",
                _status = "active",
                _facNumber = "121217091",
                _year = 3,
                _flow = 9,
                _group = 38
            });
            _testStudents.Add(new Student
            {
                _firstName = "Ivan",
                _middleName = "Georgiev",
                _lastName = "Ivanov",
                _faculty = "FKST",
                _specialty = "KSI",
                _degree = "bakalavur",
                _status = "active",
                _facNumber = "121217000",
                _year = 3,
                _flow = 9,
                _group = 38
            });
        }
        
    }
}
