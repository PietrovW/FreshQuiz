using FreshMvvm;
using FreshQuiz.Services.FileAccess;

namespace FreshQuiz.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            IFileAccessHelper fileAccessHelper = new FileAccessHelper(FileAccessHelperUWP.GetLocalFilePath(GlobalSettings.DATA_BASE_FILE_NAME),new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT());
            FreshIOC.Container.Register<IFileAccessHelper>(fileAccessHelper);
            LoadApplication(new FreshQuiz.App());
        }
    }
}
