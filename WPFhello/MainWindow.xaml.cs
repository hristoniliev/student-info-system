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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);
            //peopleListBox.Items.Add("James");
            ListBoxItem david = new ListBoxItem();
            david.Content = "David";
            peopleListBox.Items.Add(david);
            peopleListBox.SelectedItem = james;
           
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox) 
                {
                    s = s + ((TextBox)item).Text;
                    s = s + '\n' ;
                    
                }
            }
            if (txtName.Text.Length >= 2 && txt2Name.Text.Length >= 2 && txt3Name.Text.Length >= 2)
            {
            MessageBox.Show("Здравей " + s + "!!!\nTова е твоята първа програма на Visual Studio!");                
            }
            else MessageBox.Show("Твърде кратко име", "Опитай пак");
            
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            const string message = "Are you sure?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) 
            {
                e.Cancel = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("This is Windows Presentation Foundation!");
            //TextBlock1.Text = DateTime.Now.ToString();
            MyMessage anorhetWindow = new MyMessage();
            anorhetWindow.Show();
        }

        private void GreetingButon_Click(object sender, RoutedEventArgs e)
        {
            string greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi " + greetingMsg);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in MainGrid.Children) 
            {
                if (item is TextBox)
                    ((TextBox)item).Clear();
            }
        }
    }
}
