using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshQuiz.Services.Navigation
{
    public interface INavigationService 
    {
        void AddPageWithIcon<T>(string title, string icon = "", object data = null) where T : FreshBasePageModel;
    }
}
