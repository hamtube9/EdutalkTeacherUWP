using EdutalkTeacherUWP.Authentication.Models;
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
    public class SupportClassPageViewModel : ViewModelBase
    {
        public bool IsOffline { set; get; }
        public DateTime Date { set; get; } = DateTime.Today.AddDays(1);
        public OnlineMode Mode { get; set; } = OnlineMode.Online;
        public bool IsTutorLead { set; get; }
        public TimeSpan TimePicker { set; get; } = DateTime.Now.TimeOfDay;
        public DateTimeOffset DatePicker { set; get; } = DateTime.Today;
        public ObservableCollection<RoomModel> Rooms { set; get; }
        UserModel Tutor { set; get; }
        public List<UserModel> Tutors { set; get; }
        public long ClassroomId { set; get; }
        public int Lesson { set; get; }
        public string ZoomPassword { set; get; }
        public string ZoomId { set; get; }
        public string Name { set; get; }
        public string TutorName { set; get; }
        public bool IsHaveTutor { set; get; }
        public string Room { set; get; }
        public string Note { set; get; }
       public List<InfoStudentModel> SourceStudents { set; get; }
       public List<InfoStudentModel> Students { set; get; }

        ISupportClassService supportClassService;
        public SupportClassPageViewModel()
        {
            supportClassService = new SupportClassService();
        }

         ICommand _OfflineCommand;
        public ICommand OfflineCommand => _OfflineCommand = _OfflineCommand ?? new DelegateCommand(OfflineClass);

        private void OfflineClass()
        {
            IsOffline = true;
            Mode = OnlineMode.Offline;
        }


        ICommand _OnlineCommand;
        public ICommand OnlineCommand => _OnlineCommand = _OnlineCommand ?? new DelegateCommand(OnlineClass);

        private void OnlineClass()
        {
            IsOffline = false;
            Mode = OnlineMode.Online;
        }

        public async Task LoadRooms()
        {
            var result = await supportClassService.GetRoomAsync(ClassroomId,Date);
            Rooms = new ObservableCollection<RoomModel>(result);
            if(Rooms.Count > 0)
            {
                Rooms[0].IsSelected = true;
            }
            Room = Rooms.Count > 0 && Rooms[0] != null ? Rooms[0].Name : "không có phòng chờ";
        }

        public async Task LoadTutor()
        {
            var tutors = await supportClassService.GetAllTutorAsync(ClassroomId);
            Tutors = new List<UserModel>(tutors);
            if (Tutors?.Count > 0)
            {
                Tutor = Tutors[0];
            }
            TutorName = Tutor != null ? Tutor.FullName : "Không có trợ giảng" ;
            IsHaveTutor = Tutor != null ? true : false;
        }
        public async Task LoadStudent()
        {
            SourceStudents = new List<InfoStudentModel>((await supportClassService.GetStudentsAsync(ClassroomId)).Select(d => new InfoStudentModel { User = d }));
        }
 

        // ICommand _CreateSupportClassCommand;
        //public ICommand CreateSupportClassCommand => _CreateSupportClassCommand = _CreateSupportClassCommand ?? new DelegateCommand(CreateSupportClass);

        public async Task<bool> CreateSupportClass()
        {
            if (string.IsNullOrEmpty(Name))
            {
                Toast("Vui lòng nhập tên lớp");
                return false;
            }
            //if (Date < DateTime.Now)
            //{
            //    Toast("Thời gian không thể nhỏ hơn buổi học tiếp");
            //    return false;
            //}
            if (Students == null || Students.Count == 0)
            {
                Toast("Vui lòng thêm học sinh vào buổi học phụ đạo");
                return false;
            }
           return await CreateClass();
        }

        async Task<bool> CreateClass()
        {
            if(Rooms.Count == 0)
            {
                Toast("Hiện tại không có lớp trống");
                return false ;
            }
            var result = await supportClassService.CreateTutoringAsync(ClassroomId, Name, Note, IsOffline == false ? null : Rooms?.FirstOrDefault(q => q.IsSelected == true).Id, Date, Students.Select(d => d.User).ToArray(), IsOffline == false ? ZoomId : null, IsOffline == false ? ZoomPassword : null, Mode, !IsTutorLead, Tutor?.Id);
            if (result)
            {
                Toast("Tạo thành công");
                Name = string.Empty;
                Note = string.Empty;
                TimePicker  = DateTime.Now.TimeOfDay;
                DatePicker  = DateTime.Today;
                return true;
            }
            else
            {
                Toast("Tạo thất bại");
                return false;
            }
        }
    }
}
