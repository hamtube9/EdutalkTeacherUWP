using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Settings.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EdutalkTeacherUWP.ViewModels
{
    public class UpdatePhonePageViewModel : ViewModelBase
    {
        public string Phone { set; get; }
        IApplicationSettings applicationSettings;
        IAccountService accountService;
        public UpdatePhonePageViewModel()
        {
            accountService = new AccountService();
            applicationSettings = new ApplicationSettings();
            Phone = (applicationSettings.GetCurrentUser()).Phone != null ? (applicationSettings.GetCurrentUser()).Phone : "";
        }

    
        public async Task<bool> VerifyPhone()
        {
            if (Phone == (applicationSettings.GetCurrentUser()).Phone)
            {
            }
            var result = await accountService.GetPinCodeVerify(Phone);
            if (result == false)
            {
                Toast("Số điện thoại này đã được sử dụng");
                return false;
            }
            return true;
        }

    }
}
