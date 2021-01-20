using EdutalkTeacherUWP.Authentication.Models;
using EdutalkTeacherUWP.Common.Extensions;
using EdutalkTeacherUWP.Home.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        Task<InfoStudentModel[]> GetStudentSupportClass();
       Task<bool> SetStudentSupportClass(InfoStudentModel[] data);

        //bool ProfileUpdated { set; get; }
        //bool GuideAttendance { set; get; }
    }

    public class ApplicationSettings : IApplicationSettings
    {
        const string CurrentUserKey = "ApplicationSettings_ET_CurrentUser_Key";
        const string StudentSupportClassKey = "ApplicationSettings_ET_StudentSupportClass_Key";
        const string ProfileUpdatedKey = "ApplicationSettings_ET_ProfileUpdatedKey_Key";
        const string GuideAttendanceKey = "ApplicationSettings_ET_GuideAttendance_Key";

        Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        public UserModel GetCurrentUser()
        {
            return ((string)ApplicationData.Current.LocalSettings.Values[CurrentUserKey]).DeserializeObject<UserModel>();
        }

        public async Task<InfoStudentModel[]> GetStudentSupportClass()
        {
            try
            {
                StorageFile sampleFile = await localFolder.GetFileAsync(StudentSupportClassKey + ".txt");
                string data = await FileIO.ReadTextAsync(sampleFile);
                return data.DeserializeObject<InfoStudentModel[]>();
            }
            catch (FileNotFoundException e)
            {
                // Cannot find file
            }
            catch (IOException e)
            {
                // Get information from the exception, then throw
                // the info to the parent method.
                if (e.Source != null)
                {
                    Debug.WriteLine("IOException source: {0}", e.Source);
                }
              
            }
            return null;

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

        public async Task<bool> SetStudentSupportClass(InfoStudentModel[] data)
        {
           var result = await localFolder.CreateFileAsync(StudentSupportClassKey + ".txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(result, data.SerializeObject());
            StorageFile sampleFile = await localFolder.GetFileAsync(StudentSupportClassKey + ".txt");
            if (sampleFile != null)
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
