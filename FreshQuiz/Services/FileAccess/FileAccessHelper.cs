using SQLite.Net.Interop;

namespace FreshQuiz.Services.FileAccess
{
   public class FileAccessHelper: IFileAccessHelper
    {
        private readonly string _path;
        private readonly ISQLitePlatform _sqlitePlatform;
        public FileAccessHelper(string path, ISQLitePlatform sqlitePlatform)
        {
            _path = path;
            _sqlitePlatform = sqlitePlatform;
        }
        public string GetLocalFilePath { get => _path; }
        public ISQLitePlatform GetISQLitePlatform { get => _sqlitePlatform; }
    }
}
