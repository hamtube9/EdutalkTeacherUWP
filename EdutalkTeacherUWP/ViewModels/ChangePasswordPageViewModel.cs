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

        //ICommand _ChangePasswordCommand;
        //public ICommand ChangePasswordCommand => _ChangePasswordCommand = _ChangePasswordCommand ?? new DelegateCommand(ChangePassword);

        public async Task<bool> ChangePassword()
        {
            if (string.IsNullOrEmpty(OldPassword))
            {
                ToastError("Mật khẩu hiện tại không thể bỏ trống");
                return false;
            }

            if (string.IsNullOrEmpty(NewPassword))
            {
                ToastError("Mật khẩu mới không thể bỏ trống");
                return false;
            }

            if (string.IsNullOrEmpty(ConfirmNewPassword))
            {
                ToastError("Hãy nhập lại mật khẩu mới");
                return false;
            }
            if (NewPassword != ConfirmNewPassword)
            {
                ToastError("Mật khẩu mới và nhập lại không trùng khớp");
                return false;
            }
            return await ChangePasswordAsync();
        }

        async Task<bool> ChangePasswordAsync()
        {
            var result = await accountService.ChangePasswordAsync(OldPassword, NewPassword);
            if (result == null)
            {
                ToastError("Đổi mật khẩu không thành công");
                return false;
            }

            if (result.Success == true)
            {
                ToastSuccess("Đổi mật khẩu thành công");
                return true;
            }
            else
            {
                Toast(result.Messenger);
                return false;
            }

        }
    }
}
