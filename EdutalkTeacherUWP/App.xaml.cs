using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Prism.Unity.Windows;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP
{
    sealed partial class App : PrismUnityApplication
    {
   
        public App()
        {
            this.InitializeComponent();
            ExtendedSplashScreenFactory = (splashscreen) => new SplashScreen(splashscreen);
        }

        private Task LoadAppResources()
        {
            return Task.Delay(1000);
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
        }

        protected override async  Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState != ApplicationExecutionState.Running)
            {
                // Here we would load the application's resources.
                await LoadAppResources();
            }

            NavigationService.Navigate("Login", null);
        }
 
      
    }
}
