using SQLite.Net.Interop;

namespace FreshQuiz.Helpers
{
    public class FileAccessHelper
    {
        private readonly string _path;
        private readonly ISQLitePlatform _sqlitePlatform;
        public FileAccessHelper(string path, ISQLitePlatform sqlitePlatform)
        {
            _path =path;
            _sqlitePlatform=sqlitePlatform;
        }
        public string GetLocalFilePath { get => _path; }
        public ISQLitePlatform GetISQLitePlatform { get => _sqlitePlatform; }
    }
}
