using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Diagnostics;

namespace Wallpaper_Switch.UI;

public partial class AutoView : UserControl
{
    private Button _activeTimerData;

    public AutoView()
    {
        InitializeComponent();
        _activeTimerData = Btn1m;
        _activeTimerData.Classes.Set("active", true);
    }

    private void TimerSelector_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _activeTimerData.Classes.Set("active", false);
        _activeTimerData = sender as Button;
        _activeTimerData.Classes.Set("active", true);
        Debug.WriteLine((sender as Button).Tag);
    }
}