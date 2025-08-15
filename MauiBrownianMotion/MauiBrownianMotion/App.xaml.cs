using MauiBrownianMotion.ViewModels;

namespace MauiBrownianMotion
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
            {
#if WINDOWS
                var mauiWin = handler.PlatformView as Microsoft.UI.Xaml.Window;
                if (mauiWin != null)
                {
                    var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(mauiWin);
                    var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
                    var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                    appWindow?.SetPresenter(Microsoft.UI.Windowing.AppWindowPresenterKind.FullScreen);
                }
#endif
            });
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());
#if WINDOWS
            window.Created += (s, e) =>
            {
                var mauiWin = window.Handler?.PlatformView as Microsoft.UI.Xaml.Window;
                if (mauiWin != null)
                {
                    var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(mauiWin);
                    var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
                    var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                    appWindow?.SetPresenter(Microsoft.UI.Windowing.AppWindowPresenterKind.Overlapped);
                    appWindow?.Resize(new Windows.Graphics.SizeInt32 { Width = 1600, Height = 900 });
                    appWindow?.Move(new Windows.Graphics.PointInt32 { X = 0, Y = 0 });
                }
            };
#endif
            return window;
        }
    }
}