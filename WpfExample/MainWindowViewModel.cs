using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;


namespace WpfExample
{
    class MainWindowViewModel 
    {
        private ICommand hiButtonCommand;
        private ICommand toggleExecuteCommand { get; set; }
        private bool canExecute = true;
        public string HiButtonContent
        {
            get { return "Click to hi"; }
            
        }
        public bool CanExecute
        {
            get { return this.canExecute; }
            set
            {
                if (this.canExecute == value)
                { return; }
                this.canExecute = value;
            }
        }
        public ICommand ToggleExecuteCommand
        {
            get { return this.toggleExecuteCommand; }
            set { this.toggleExecuteCommand = value; }
        }
        public ICommand HiButtonCommand
        {
            get { return this.hiButtonCommand; }
            set { this.hiButtonCommand = value; }
        }
        public MainWindowViewModel()
        {
            HiButtonCommand = new RelayCommand(ShowMsg, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
            
            
        }
        public void ShowMsg(object obj)
        {
            //MessageBox.Show(obj.ToString());
            MainWindowView mwv = new MainWindowView();
            mwv.Show();
            mwv.HelloMessage.Text = obj.ToString() + "  " + DateTime.Now.ToLongDateString();
        }
        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }
    }
}
