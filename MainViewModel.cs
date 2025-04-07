using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;

namespace WPFMVVMSAMPLE
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public IAsyncRelayCommand ClickCommand { get; }
        private string _TextName;
        private bool _TestColorChange;
        private bool _IsButtonClicked;
        public MainViewModel()
        {
            ClickCommand = new AsyncRelayCommand(ClickButtonFunctionality, isClickable);
        }
        public string TextName
        {
            get
            {
                return _TextName;
            }
            set
            { 
                if(value !=null  && _TextName !=value)
                {
                    _TextName = value;
                    propertyChanged(nameof(TextName));
                }
            }
        }
        public bool TestColorChange
        {
            get
            {
                return _TestColorChange;
            }
            set
            {
                if (value != null && value != _TestColorChange)
                {
                    _TestColorChange = value;
                    propertyChanged(nameof(TestColorChange));
                }
            }
        }
        public bool IsButtonClicked
        {
            get
            {
                return _IsButtonClicked;
            }
            set
            {
                if(value != null && _IsButtonClicked != value)
                {
                    _IsButtonClicked = value;
                    propertyChanged(nameof(IsButtonClicked));
                }
            }
        }
        public bool isClickable()
        {
            return true;
        }
        public async Task ClickButtonFunctionality()
        {
            TestColorChange = true;
            IsButtonClicked = true;
        }
        public void propertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
