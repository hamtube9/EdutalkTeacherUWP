using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EdutalkTeacherUWP
{

    public sealed partial class SplashScreen : Page
    {
        private readonly Windows.ApplicationModel.Activation.SplashScreen splashScreen;
        public SplashScreen(Windows.ApplicationModel.Activation.SplashScreen splashScreen)
        {
            this.InitializeComponent();
            this.splashScreen = splashScreen;

            this.SizeChanged += ExtendedSplashScreen_SizeChanged;
            this.splashImage.ImageOpened += splashImage_ImageOpened;
        }

        void splashImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            Resize();
            Window.Current.Activate();
        }

        // Whenever the size of the application change, the image position and size need to be recalculated.
        void ExtendedSplashScreen_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Resize();
        }

        // This method is used to position and resizing the splash screen image correctly.
        private void Resize()
        {
            if (this.splashScreen == null) return;
 
            this.splashImage.Height = this.splashScreen.ImageLocation.Height;
            this.splashImage.Width = this.splashScreen.ImageLocation.Width;

            this.splashImage.SetValue(Canvas.TopProperty, this.splashScreen.ImageLocation.Top);
            this.splashImage.SetValue(Canvas.LeftProperty, this.splashScreen.ImageLocation.Left);

            this.progressRing.SetValue(Canvas.TopProperty, this.splashScreen.ImageLocation.Top + this.splashScreen.ImageLocation.Height + 50);
            this.progressRing.SetValue(Canvas.LeftProperty, this.splashScreen.ImageLocation.Left + this.splashScreen.ImageLocation.Width / 2 - this.progressRing.Width / 2);
        }
    }
}
