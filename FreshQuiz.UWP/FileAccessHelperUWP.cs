using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshQuiz.UWP
{
    public class FileAccessHelperUWP
    {
        public static string GetLocalFilePath(string filename)
        {
            var path = global::Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            return System.IO.Path.Combine(path, filename);
        }

    }
}
