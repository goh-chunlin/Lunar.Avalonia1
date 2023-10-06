using System.Collections.ObjectModel;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using Lunar.Avalonia1.Models;

namespace Lunar.Avalonia1.ViewModels;

public class AccountSummaryViewModel: ObservableObject
{
    public ObservableCollection<Song> AccountSummary { get; set; }

    public string WelcomeText { get; set; }

    public AccountSummaryViewModel()
    {
        AccountSummary = new ObservableCollection<Song>(Song.Songs);
        WelcomeText = "How are you?";
    }
}