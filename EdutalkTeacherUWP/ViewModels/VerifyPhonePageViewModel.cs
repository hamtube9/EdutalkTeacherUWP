using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Base;
using EdutalkTeacherUWP.Settings.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.ViewModels
{
    public class VerifyPhonePageViewModel : ViewModelBase
    {
        IAccountService accountService;
        IApplicationSettings applicationSettings;
        public string PinCode { set; get; }
        public string Phone { set; get; }
        UserModel User { set; get; }
        public VerifyPhonePageViewModel()
        {
            accountService = new AccountService();
            applicationSettings = new ApplicationSettings();
            User = applicationSettings.GetCurrentUser();
        }

        public async Task<bool> VerifyAsync()
        {

            if (string.IsNullOrEmpty(PinCode))
            {
                Toast("Xin hãy nhập mã pin");
                return false;
            }

            var result = await accountService.VerifyPhone(new Api.Dtos.AuthorizationDtos.VerifyPhoneRequestDto()
            {
                Phone = Phone,
                PinCode = PinCode
            });
            if (result)
            {
                User.Phone = Phone;
                applicationSettings.SetCurrentUser(User);
                Toast("Thành công");
                return true;
            }
            else
            {
                Toast("Thất bại");
                return false;
            }
        }
    }
}
