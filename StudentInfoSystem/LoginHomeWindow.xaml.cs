using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserLoginNEW;

namespace StudentInfoSystem    
{
    /// <summary>
    /// Interaction logic for LoginHomeWindow.xaml
    /// </summary>
    public partial class LoginHomeWindow : Window
    {
        public LoginHomeWindow()
        {
            InitializeComponent();
            //VALID USER DATA BELOW
            //textBoxUsername.Text = "Hristo";
            //passwordBox1.Text = "12345678";
            
        }
        public void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginValidation log = new LoginValidation(textBoxUsername.Text, passwordBox1.Text, Program.FunctionOnError);
            User user = null;
            if (log.ValidateUserInput(ref user))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
                mainWindow.GetStudentByFacNumber(user.FacNumber);
                //ViewModel vm = new ViewModel();
                //_ = vm.Student;


            }
            errormessage.Text = (log._errorMessage);
        }

        private void CustomControl1_Click(object sender, RoutedEventArgs e)
        {
            CustomTxtBlock.Text = "You have just clicked the button. " +
                "When you leave with the cursor everything will disapper";
        }

        private void CustomControl1_MouseEnter(object sender, MouseEventArgs e)
        {
            CustomTxtBlock.Text =
                "For successful login: " + Environment.NewLine +
                "1. Username must start with uppercase" + Environment.NewLine +
                "1. Username must be 5 characters at least" + Environment.NewLine +
                "2. Password must be 5 characters at least" + Environment.NewLine + Environment.NewLine +
                "Valid user data:" + Environment.NewLine +
                "Username: Hristo" + Environment.NewLine +
                "Password : 12345678";
        }

        private void CustomControl1_MouseLeave(object sender, MouseEventArgs e)
        {
            CustomTxtBlock.Text = string.Empty;
        }
    }
}
