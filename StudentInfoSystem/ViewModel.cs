using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    public class ViewModel 
    {
        public Student Student
        {
            get
            {
                return Student;

            }
            set
            {
                MainWindow m = new MainWindow();
                if (Student != null)
                {
                    m.EnableAllControls();
                    m.GetStudentByFacNumber(Student.FacNumber);
                }
                else
                {
                    m.ClearAllTextBoxes();
                    m.DisableAllControls();
                    
                }
            }
        }
    }
}
