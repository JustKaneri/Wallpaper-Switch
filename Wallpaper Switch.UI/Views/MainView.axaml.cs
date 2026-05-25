using Avalonia.Controls;
using Avalonia.Media;

namespace Wallpaper_Switch.UI.Views;

public partial class MainView : UserControl
{
    private Button _activeButton;

    public MainView()
    {
        InitializeComponent();
        _activeButton = BtnHome;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DisableButton(_activeButton);
        _activeButton = sender as Button;
        EnableButton(_activeButton);
    }

    private void DisableButton(Button button)
    {
        button.Background = null;
        button.BorderBrush = null;
        button.BorderThickness = new Avalonia.Thickness(0, 0, 0, 0);
    }

    private void EnableButton(Button button)
    {
        button.BorderBrush = Brush.Parse("#5B8CFF");
        button.BorderThickness = new Avalonia.Thickness(3, 0, 0, 0);
        button.Background = Brush.Parse("#283036");
    }
}
