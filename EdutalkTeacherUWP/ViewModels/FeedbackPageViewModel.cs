using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Home.Models;
using EdutalkTeacherUWP.Home.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EdutalkTeacherUWP.ViewModels
{
    public class FeedbackPageViewModel : ViewModelBase
    {
        public int ClassroomId { set; get; }
        public RouteModel Route { set; get; }
        public ObservableCollection<CommentModel> Comments { set; get; }
        public bool IsSupportClass { set; get; }
        ICourseService courseService;
        public FeedbackPageViewModel()
        {
            courseService = new CourseService();
        }

        public async Task LoadComment()
        {
            if (IsSupportClass)
            {
                var result = await courseService.GetFeedbacksSupportClassAsync(Route.Id);
                Comments = new ObservableCollection<CommentModel>(result);
            }
            else
            {
                var result = await courseService.GetFeedbacksAsync(Route.Lesson, ClassroomId);
                Comments = new ObservableCollection<CommentModel>(result);
            }
        }

        ICommand _SendFeedbackCommand;
        public ICommand SendFeedbackCommand => _SendFeedbackCommand = _SendFeedbackCommand ?? new DelegateCommand(SendFeedbackAsync);

        private async void SendFeedbackAsync()
        {
           await SendFeedback();
        }
        async Task SendFeedback()
        {
            var result = await courseService.FeedbackAsync(Comments.ToArray(), Route.Lesson, ClassroomId);
            if (result == true)
            {
                Toast("Thành công");
            }
            else
            {
                Toast("comment_error");
            }
        }
    }
}
