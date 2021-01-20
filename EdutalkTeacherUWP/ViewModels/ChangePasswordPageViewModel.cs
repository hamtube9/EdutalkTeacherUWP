using EdutalkTeacherUWP.Authentication.Models;
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
    public class ChangePasswordPageViewModel : ViewModelBase
    {
        public string OldPassword { set; get; }
        public string NewPassword { set; get; }
        public string ConfirmNewPassword { set; get; }
        IAccountService accountService;
        public ChangePasswordPageViewModel()
        {
            accountService = new AccountService();
        }

        ICommand _ChangePasswordCommand;
        public ICommand ChangePasswordCommand => _ChangePasswordCommand = _ChangePasswordCommand ?? new DelegateCommand(ChangePassword);

        private async void ChangePassword()
        {
            if (string.IsNullOrEmpty(OldPassword))
            {
                ToastError("Mật khẩu hiện tại không thể bỏ trống");
                return;
            }

            if (string.IsNullOrEmpty(NewPassword))
            {
                ToastError("Mật khẩu mới không thể bỏ trống");
                return;
            }

            if (string.IsNullOrEmpty(ConfirmNewPassword))
            {
                ToastError("Hãy nhập lại mật khẩu mới");
                return;
            }
            if(NewPassword != ConfirmNewPassword)
            {
                ToastError("Mật khẩu mới và nhập lại không trùng khớp");
                return;
            }
            await ChangePasswordAsync();
        }

        async Task ChangePasswordAsync()
        {
            var result = await accountService.ChangePasswordAsync(OldPassword, NewPassword);
            if (result == null)
            {
                ToastError("Đổi mật khẩu không thành công");
                return;
            }
         
            if(result.Success == true)
            {
                ToastSuccess("Đổi mật khẩu thành công");
            }
            else
            {
                Toast(result.Messenger);
                return;
            }

        }
    }
}
