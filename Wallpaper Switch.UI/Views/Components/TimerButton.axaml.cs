using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace Wallpaper_Switch.UI;

public partial class TimerButton : UserControl
{
    private struct StateMachine
    {
        public string Text;
        public string ColorFont;
    }

    private readonly StateMachine _enableTimer;
    private readonly StateMachine _disableTimer;

    private StateMachine _currectState;

    public TimerButton()
    {
        InitializeComponent();

        _enableTimer = new StateMachine() { Text = "Timer ON", ColorFont = "#5b9c8d" };
        _disableTimer = new StateMachine() { Text = "Timer OFF", ColorFont = "#335c52" };

        _currectState = _disableTimer;
    }
}