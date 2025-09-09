namespace HexClor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //Main Page is the Startup Page
            return new Window(new MainPage());
        }
    }
}