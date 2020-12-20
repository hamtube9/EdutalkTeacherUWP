using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Authentication.Models
{
    public class UserModel 
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ReferralCode { get; set; }
        public string Code { get; set; }
        public Gender Gender { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool VerifiedPhone { get; set; }
        public AccountType AccountType { get; set; }
    }

    public enum Gender
    {
        Male, Female
    }

    public enum AccountType
    {
        Teacher, Tutor
    }
}
