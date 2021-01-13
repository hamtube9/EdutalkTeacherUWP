using System;
using Windows.ApplicationModel.Activation;
using Prism.Unity.Windows;
using Prism.Windows.AppModel;
using System.Threading.Tasks;
using EdutalkTeacherUWP.Api.Authorization;
using EdutalkTeacherUWP.Api.Extensions;
using Windows.UI.ViewManagement;
using EdutalkTeacherUWP.Authentication.Service;
using Acr.UserDialogs;
using System.Windows;

namespace EdutalkTeacherUWP
{
    sealed partial class App : PrismUnityApplication
    {
        public App()
        {
            this.InitializeComponent();
            ExtendedSplashScreenFactory = (splashscreen) => new SplashScreen(splashscreen);
            ApplicationView.PreferredLaunchViewSize = new Windows.Foundation.Size(1280, 960);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
          
        }

        private Task LoadAppResources()
        {
            return Task.Delay(1000);
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            return base.OnInitializeAsync(args);

        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
        }

        protected override async Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState != ApplicationExecutionState.Running)
            {
                // Here we would load the application's resources.
                await LoadAppResources();
            }
            var authHeader = new AuthHeaderManager();
            var token = authHeader.GetBearerToken().Result;
            if (!string.IsNullOrEmpty(token))
            {
                var check = NavigationService.Navigate("Main", null);
                ApplicationViewTitleBar titlebar = ApplicationView.GetForCurrentView().TitleBar;

                titlebar.ButtonBackgroundColor = Windows.UI.Color.FromArgb(255, 126, 188, 66);
                titlebar.ButtonForegroundColor = Windows.UI.Colors.White;
                return;
            }
            NavigationService.Navigate("Login", null);
            ApplicationViewTitleBar titlebar2 = ApplicationView.GetForCurrentView().TitleBar;

            titlebar2.ButtonBackgroundColor = Windows.UI.Color.FromArgb(255, 126, 188, 66);
            titlebar2.ButtonForegroundColor = Windows.UI.Colors.White;
        }


    }
}
