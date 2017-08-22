using FreshMvvm;
using FreshQuiz.Helpers;
using FreshQuiz.PageModels;
using FreshQuiz.Services.Data;
using FreshQuiz.Services.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FreshQuiz
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitRegister();
            InitMenu();
      
        }
        private void InitRegister()
        {
            FreshIOC.Container.Register<IUnitOfWork, UnitOfWork>().AsSingleton();
            FreshIOC.Container.Register<INavigationService, NavigationService>().AsSingleton();
        }
        private void InitMenu()
        {
            var masterDetailNav = InitNavigation();
            masterDetailNav.Init("Menu", "menu.png");
            masterDetailNav.AddPageWithIcon<QuestionListPageModel>("Question", "inboxm.png");
            masterDetailNav.AddPageWithIcon<ExamineListPageModel>("Examine", "inboxm.png");
            MainPage = masterDetailNav;
        }
        private NavigationService InitNavigation()
        {
            var masterDetailNav  =FreshIOC.Container.Resolve<NavigationService>();
            return masterDetailNav;
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
