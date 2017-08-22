using Android.App;
using Android.Content.PM;
using Android.OS;
using FreshMvvm;
using FreshQuiz.Core;
using FreshQuiz.Services;

namespace FreshQuiz.Droid
{
    [Activity(Label = "FreshQuiz", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Repository repositoryQuestion = new Repository(FileAccessHelper.GetLocalFilePath(GlobalSettings.DATA_BASE_FILE_NAME), new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid());
            FreshIOC.Container.Register(repositoryQuestion);
            LoadApplication(new App());
        }
    }
}

