using SQLite.Net.Interop;

namespace FreshQuiz.Services.FileAccess
{
    public interface IFileAccessHelper
    {
        string GetLocalFilePath { get; }
        ISQLitePlatform GetISQLitePlatform { get ; }
    }
}
