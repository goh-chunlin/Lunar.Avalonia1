using System;
using System.ComponentModel;
using System.Windows.Input;
using MsBox.Avalonia.ViewModels.Commands;

namespace Lunar.Avalonia1.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private string _message;

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public string Message
    {
        get { return _message; }
        set
        {
            _message = value;
            OnPropertyChanged(nameof(Message));
        }
    }

    public ICommand ButtonClickedCommand { get; }

    public MainViewModel()
    {
        ButtonClickedCommand = new RelayCommand(ButtonClicked);
    }

    private void ButtonClicked(object obj)
    {
        Message = "Hello, world!";
    }
}