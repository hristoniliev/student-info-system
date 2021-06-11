using System;
using System.Collections.Generic;
using System.Text;
using UserLoginNEW;

namespace StudentInfoSystem
{
    public class StudentValidation
    {
        public Student GetStudentDataByUser(User user) {
            Student student = new Student();
            if (user.FacNumber == null || user.FacNumber != student.FacNumber) {
                Console.WriteLine("Student not found");
            }
            return student;
        }
    }
}
