using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Home.Models;
using EdutalkTeacherUWP.Home.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.ViewModels
{
   public class LessonPageViewModel : ViewModelBase
    {
        public LessonModel Lesson { get; set; }
        public int LessonNumber { get; set; }
        public long ClassroomId { set; get; }
        ICourseService courseService;
        public LessonPageViewModel()
        {
            courseService = new CourseService();
        }

        public async Task LoadLesson()
        {
            Lesson = await courseService.GetLessonAsync(LessonNumber, ClassroomId);
        }
    }
}
