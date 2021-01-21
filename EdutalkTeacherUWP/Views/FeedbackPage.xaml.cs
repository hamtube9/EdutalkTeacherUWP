using EdutalkTeacherUWP.Home.Models;
using EdutalkTeacherUWP.Home.Params;
using EdutalkTeacherUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EdutalkTeacherUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FeedbackPage : Page
    {
        FeedbackPageViewModel vm;
        public FeedbackPage()
        {
            this.InitializeComponent();
            vm = (FeedbackPageViewModel)DataContext;
        }

        protected override  async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if ((ParamsAttendanceModel)e.Parameter != null )
            {
                vm.ClassroomId = ((ParamsAttendanceModel)e.Parameter).ClassroomId;
                vm.Route = ((ParamsAttendanceModel)e.Parameter).Route;
                vm.IsSupportClass = ((ParamsAttendanceModel)e.Parameter).Route.RouteType == Home.Models.RouteType.SupportClass ? true : false;
              await  vm.LoadComment();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           var obj = (CommentModel)(((TextBox)sender).DataContext);
            obj.Comment = ((TextBox)sender).Text;

        }
    }
}
