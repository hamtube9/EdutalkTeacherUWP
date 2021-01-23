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
        public string PinCode { set; get; }
        public string Phone { set; get; }
        public VerifyPhonePageViewModel()
        {
            accountService = new AccountService();
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
