using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace EasyMVVM
{
    public class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> _BackingProperty;
        public ObservableCollection<string> BoundProperty
        {
            get
            {
                return _BackingProperty;
            }
            set
            {
                _BackingProperty = value;
                PropChanged("BoundProperty");
            }
        }
        public MainWindowVM()
        {
            Model m = new Model();
            BoundProperty = m.GetData();
        }
        public void PropChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}   
