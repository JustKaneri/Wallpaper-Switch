using Avalonia.Controls;
using Avalonia.Media;

namespace Wallpaper_Switch.UI.Views;

public partial class MainView : UserControl
{
    private Button _activeButton;
    private object _homeView;
    private object _sourceView;
    private object _autoView;
    private object _settingsView;

    public MainView()
    {
        InitializeComponent();
        InitView();

        _activeButton = BtnHome;
        _activeButton.Classes.Set("active", true);

        MainContent.Content = _homeView;
    }

    private void InitView()
    {
        _homeView = new HomeView();
        _sourceView = new SourceView();
        _autoView = new AutoView();
        _settingsView = new SettingView();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _activeButton.Classes.Set("active", false);
        _activeButton = sender as Button;
        _activeButton.Classes.Set("active", true);
    }

    private void DisableButton(Button button)
    {
        //button.Background = null;
        //button.BorderBrush = null;
        //button.BorderThickness = new Avalonia.Thickness(0, 0, 0, 0);
    }

    private void EnableButton(Button button)
    {
        //button.BorderBrush = Brush.Parse("#5B8CFF");
        //button.BorderThickness = new Avalonia.Thickness(3, 0, 0, 0);
        //button.Background = Brush.Parse("#283036");
    }

    private void BtnHome_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainContent.Content = _homeView;
        Button_Click(sender, e);
    }

    private void BtnSource_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainContent.Content = _sourceView;
        Button_Click(sender, e);
    }

    private void BtnAuto_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainContent.Content = _autoView;
        Button_Click(sender, e);
    }

    private void BtnSettings_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainContent.Content = _settingsView;
        Button_Click(sender, e);
    }
}
