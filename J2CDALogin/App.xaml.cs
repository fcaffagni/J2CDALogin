using Microsoft.Maui.Controls;

namespace J2CDALogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = new Window(new Login()); // new Window(new AppShell());
            window.Width = 400;
            window.Height = 600;
            return window;
            //return new Window(new AppShell());
        }
    }
}