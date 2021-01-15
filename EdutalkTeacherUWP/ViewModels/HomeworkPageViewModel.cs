using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Exam.Models;
using EdutalkTeacherUWP.Exam.Service;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EdutalkTeacherUWP.ViewModels
{
    public class HomeworkPageViewModel : ViewModelBase
    {
        public ObservableCollection<HomeworkResultModel> Results { get; set; }
        public bool IsRefreshing { get; set; }
        public int Lesson { get; set; }
        public long ClassroomId { get; set; }
        public GroupQuestionModel SelectedQuestion { set; get; }
        IExamService service;
        public HomeworkPageViewModel()
        {
            service = new ExamService();
        }
        public async Task LoadAllStudent()
        {
            var homeworks = await service.GetHomeworksAsync(Lesson, ClassroomId);
            var listUserHomwork = new List<HomeworkResultModel>(homeworks);
            var listStudent = await service.GetStudentsAsync(ClassroomId);
            foreach (var item in listStudent)
            {
                if (homeworks.FirstOrDefault(h => h.User.Id == item.Id) == null)
                {
                    listUserHomwork.Add(new HomeworkResultModel() { User = item });
                }
            }
            Results = new ObservableCollection<HomeworkResultModel>(listUserHomwork);
        }

        ICommand _viewHomeworkCommand;
        public ICommand ViewHomeworkCommand => _viewHomeworkCommand = _viewHomeworkCommand ?? new DelegateCommand<HomeworkResultModel>(ViewHomework);

        private void ViewHomework(HomeworkResultModel obj)
        {

        }
    }
}
