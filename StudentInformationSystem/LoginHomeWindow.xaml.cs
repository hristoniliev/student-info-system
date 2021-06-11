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
using UserLogin;

namespace StudentInformationSystem
{
    /// <summary>
    /// Interaction logic for LoginHomeWindow.xaml
    /// </summary>
    public partial class LoginHomeWindow : Window
    {
        public LoginHomeWindow()
        {
            InitializeComponent();
        }
 
        public void button1_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow = new MainWindow(sender);
            //mainWindow.Show();
            //this.Close();
            
            LoginValidation log = new LoginValidation(textBoxUsername.Text, passwordBox1.Text, Program.FunctionOnError);
            User user = null;
            if (log.ValidateUserInput(ref user))
            {
                MainWindow mainWindow = new MainWindow(sender);
                mainWindow.Show();
                this.Close();
                mainWindow.GetStudentByFacNumber(user.FacNumber);
                //ViewModel vm = new ViewModel();
                //_ = vm.Student;

               
            }
            errormessage.Text = (log._errorMessage);  
        }
        
    }
}
