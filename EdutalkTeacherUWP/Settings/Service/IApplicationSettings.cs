using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace EdutalkTeacherUWP.Settings.Service
{
    public interface IApplicationSettings
    {
        UserModel CurrentUser { get; set; }
        //bool ProfileUpdated { set; get; }
        //bool GuideAttendance { set; get; }
    }

    public class ApplicationSettings : IApplicationSettings
    {
        const string CurrentUserKey = "ApplicationSettings_ET_CurrentUser_Key";
        const string ProfileUpdatedKey = "ApplicationSettings_ET_ProfileUpdatedKey_Key";
        const string GuideAttendanceKey = "ApplicationSettings_ET_GuideAttendance_Key";

        public UserModel CurrentUser
        {
            get => ((string)ApplicationData.Current.LocalSettings.Values[CurrentUserKey]).DeserializeObject<UserModel>();
            set => ApplicationData.Current.LocalSettings.Values[CurrentUserKey] = value.SerializeObject();
        }

        //public bool ProfileUpdated
        //{
        //    get => Preferences.Get(ProfileUpdatedKey, true);
        //    set => Preferences.Set(ProfileUpdatedKey, value);
        //}

        //public bool GuideAttendance
        //{
        //    get => Preferences.Get(GuideAttendanceKey, false);
        //    set => Preferences.Set(GuideAttendanceKey, true);
        //}
    }
}
