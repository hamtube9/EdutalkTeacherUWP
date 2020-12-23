using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdutalkTeacherUWP.Api.Dtos
{
    public class UserResultDto
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public ProfileDto Profile { set; get; }
    }
    public class ProfileDto
    {
        public string IntroCode { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public FeaturedImageDto Avatar { get; set; }
        public int VerifiedPhone { set; get; }
        public string AccountType { get; set; }
    }
    public class FeaturedImageDto
    {
        public string Path { get; set; }
    }
}
