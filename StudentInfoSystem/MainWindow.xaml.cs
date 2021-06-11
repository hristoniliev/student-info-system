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
using System.Data;
using System.Data.SqlClient;
using UserLoginNEW;

namespace StudentInfoSystem
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
            //LoginHomeWindow homeWindow = new LoginHomeWindow();
            //homeWindow.Show();
            //this.Close();
            FillStudStatusChoices();
            this.DataContext = this;
        }
        public MainWindow(object sender)
        {
            InitializeComponent();
            DataContext = new ViewModel();
            FillStudStatusChoices();
            this.DataContext = this; 
        }
        public List<string> StudStatusChoices { get; set; }
        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr
                FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        public bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            return countStudents == 0;
        }

        public bool TestUsersIfEmpty() 
        {
            UserInfoContext context = new UserInfoContext();
            IEnumerable<User> queryUsers = context.Users;
            int countUsers = queryUsers.Count();
            return countUsers == 0;
        }
        private void isEmptyStudentsBtn_Click(object sender, RoutedEventArgs e)
        {
            bool isEmpty = TestStudentsIfEmpty();
            if (isEmpty)
            {
                CopyTestStudents();
                MessageBox.Show("Successfully added student");
            }
            else
            {
                MessageBox.Show(isEmpty.ToString());
            }
        }
        private void isEmptyUsersButton_Click(object sender, RoutedEventArgs e)
        {
            bool isEmpty = TestUsersIfEmpty();
            if (isEmpty)
            {
                CopyTestUsers();
                MessageBox.Show("Successfully added user");
            }
            else 
            {
                MessageBox.Show(isEmpty.ToString());
            }
        }
        public void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            StudentData studentdata = new StudentData();
            foreach (Student student in studentdata._testStudents)
            {
                context.Students.Add(student);
            }
            context.SaveChanges();
        }
        public void CopyTestUsers()
        {
            UserInfoContext context = new UserInfoContext();
            StudentData studentdata = new StudentData();
            foreach (User user in UserData._testUsers)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
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
                if (FacNumber == student.FacNumber)
                {
                    txtFirstName.Text = student.FirstName;
                    txtMiddleName.Text = student.MiddleName;
                    txtLastName.Text = student.LastName;
                    txtFaculty.Text = student.Faculty;
                    txtSpecialty.Text = student.Specialty;
                    txtDegree.Text = student.Degree;
                    //listStatus.Text = student._status;
                    txtFacNumber.Text = student.FacNumber;
                    txtYear.Text = student.Year.ToString();
                    txtFlow.Text = student.Flow.ToString();
                    txtGroup.Text = student.Group.ToString();
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
