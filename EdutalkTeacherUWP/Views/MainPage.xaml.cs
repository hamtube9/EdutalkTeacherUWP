using System.Collections.Generic;
using System.Linq;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EdutalkTeacherUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationViewTitleBar titlebar = ApplicationView.GetForCurrentView().TitleBar;

            titlebar.ButtonBackgroundColor = Windows.UI.Color.FromArgb(255, 126, 188, 66);
            titlebar.ButtonForegroundColor = Windows.UI.Colors.White;
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PropertyPageChanged();
        }

        void PropertyPageChanged()
        {
            double totalwidth = ((Frame)Window.Current.Content).ActualWidth;
            IEnumerable<PivotHeaderItem> items = FindVisualChildren<PivotHeaderItem>(rootPivot);
            int headitemcount = items.Count();
            for (int i = 0; i < headitemcount; i++)
            {
                items.ElementAt<PivotHeaderItem>(i).Width = totalwidth / headitemcount;
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            PropertyPageChanged();
        }

       
    }
}
