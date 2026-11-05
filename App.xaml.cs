using restaurantsListInUI.Services;

namespace restaurantsListInUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DataRepository.FillFakeData();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}