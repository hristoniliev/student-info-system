using System;
using System.Collections.Generic;
using System.Text;
using UserLogin;

namespace StudentInformationSystem
{
    public class StudentValidation
    {
        public Student GetStudentDataByUser(User user) {
            Student student = new Student();
            if (user.FacNumber == null || user.FacNumber != student._facNumber) {
                Console.WriteLine("Student not found");
            }
            return student;
        }
    }
}
