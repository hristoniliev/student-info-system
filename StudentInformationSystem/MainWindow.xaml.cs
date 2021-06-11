using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
            LoginHomeWindow homeWindow = new LoginHomeWindow();
            homeWindow.Show();
            this.Close();
        }
        public MainWindow(object sender) 
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            const string message = "Are you sure you want to quit ''Студентска информационна система'' ?";
            const string caption = "Quit Студентска информационна система";
            var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        public void ClearAllTextBoxes()
        {
            foreach (var item in MainGrid.Children)
            {

                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
            }
        }
        public void GetStudentByFacNumber(string FacNumber)
        {
            StudentData studentdata = new StudentData();
            foreach (Student student in studentdata.TestStudents)
            {
                if (FacNumber == student._facNumber)
                {
                    txtFirstName.Text = student._firstName;
                    txtMiddleName.Text = student._middleName;
                    txtLastName.Text = student._lastName;
                    txtFaculty.Text = student._faculty;
                    txtSpecialty.Text = student._specialty;
                    txtDegree.Text = student._degree;
                    txtStatus.Text = student._status;
                    txtFacNumber.Text = student._facNumber;
                    txtYear.Text = student._year.ToString();
                    txtFlow.Text = student._flow.ToString();
                    txtGroup.Text = student._group.ToString();
                }
            }
        }
        public void DisableAllControls()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = false;
                }
                if (item is Label)
                {
                    ((Label)item).IsEnabled = false;
                }
            }
        }
        public void EnableAllControls()
        {
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).IsEnabled = true;
                }
                if (item is Label)
                {
                    ((Label)item).IsEnabled = true;
                }
            }

        }
    }
}
