using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Exam.Models;
using EdutalkTeacherUWP.Exam.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.ViewModels
{
    public class ViewExamPageViewModel : ViewModelBase
    {
        ResultModel exam;
        public ObservableCollection<GroupQuestionModel> Questions { set; get; }
        IExamService examService;
        public ViewExamPageViewModel()
        {
            examService = new ExamService();
        }

        public async Task LoadHomework(int CourseStudentId, int ClassroomId, int Lesson,bool IsHomeWork)
        {
            exam = await examService.GetResultAsync(CourseStudentId, ClassroomId, Lesson, IsHomeWork);
            Questions = new ObservableCollection<GroupQuestionModel>(exam.Test.Questions);
        }
    }
}
