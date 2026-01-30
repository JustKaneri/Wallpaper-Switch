using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;

namespace Wallpaper_Switch.UI;

public partial class WindowHeaders : UserControl
{
    public WindowHeaders()
    {
        InitializeComponent();
    }

    public void CloseWindow(object sender, RoutedEventArgs args)
    {
        this.FindAncestorOfType<Window>()?.Close();
    }

    public void MinimizedWindow(object sender, RoutedEventArgs args)
    {
        if (this.FindAncestorOfType<Window>() is { } window)
            window.WindowState = WindowState.Minimized;
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);

        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            if (this.FindAncestorOfType<Window>() is { } window)
            {
                window.BeginMoveDrag(e);
            }
        }
    }
}