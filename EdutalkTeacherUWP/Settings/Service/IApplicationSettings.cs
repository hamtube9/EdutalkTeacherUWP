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
        UserModel GetCurrentUser();
        bool SetCurrentUser(UserModel user);
        //bool ProfileUpdated { set; get; }
        //bool GuideAttendance { set; get; }
    }

    public class ApplicationSettings : IApplicationSettings
    {
        const string CurrentUserKey = "ApplicationSettings_ET_CurrentUser_Key";
        const string ProfileUpdatedKey = "ApplicationSettings_ET_ProfileUpdatedKey_Key";
        const string GuideAttendanceKey = "ApplicationSettings_ET_GuideAttendance_Key";


        public UserModel GetCurrentUser()
        {
            return ((string)ApplicationData.Current.LocalSettings.Values[CurrentUserKey]).DeserializeObject<UserModel>();
        }

        public bool SetCurrentUser(UserModel user)
        {
            ApplicationData.Current.LocalSettings.Values.Remove(CurrentUserKey);
            ApplicationData.Current.LocalSettings.Values[CurrentUserKey] = user.SerializeObject();
            if(((string)ApplicationData.Current.LocalSettings.Values[CurrentUserKey]).DeserializeObject<UserModel>() != null)
            {
                return true;
            }
            return false;
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
