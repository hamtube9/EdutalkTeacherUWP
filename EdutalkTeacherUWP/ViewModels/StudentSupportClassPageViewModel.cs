using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Home.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.ViewModels
{
    public class StudentSupportClassPageViewModel : ViewModelBase
    {
        public ObservableCollection<InfoStudentModel> Students { set; get; }
        public StudentSupportClassPageViewModel()
        {

        }

    }
}
