using FreshMvvm;
using FreshQuiz.DAL.Repositorys;
using FreshQuiz.Models;
using FreshQuiz.Services.Data;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FreshQuiz.PageModels
{
    public class QuestionListPageModel : FreshBasePageModel
    {
        private IRepository<Question> _repository;
        private Question _selectedContact = null;
            
        public ObservableCollection<Question> Contacts { get; private set; }

       public Question SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                if (value != null) EditContactCommand.Execute(value);
            }
        }
         
        private IUnitOfWork _IUnitOfWork;
        public QuestionListPageModel(IUnitOfWork _IUnitOfWork)
        {
            Contacts = new ObservableCollection<Question>();
            this._IUnitOfWork = _IUnitOfWork;
            this._repository = _IUnitOfWork.GetQuestion;
        }

        public override void Init(object initData)
        {
            LoadContacts();
            if (Contacts.Count() < 1)
            {
                CreateSampleData();
            }
        }


        public override void ReverseInit(object returnedData)
        {
            LoadContacts();
            base.ReverseInit(returnedData);
        }

        public ICommand AddContactCommand
        {
            get
            {
                return new Command(async () => {
                    await CoreMethods.PushPageModel<QuestionPageModel>();
                });
            }
        }

        public ICommand EditContactCommand
        {
            get
            {
                return new Command(async (contact) => {

                    await CoreMethods.PushPageModel<QuestionPageModel>(contact);
                });
            }
        }

        private void LoadContacts()
        {
            Contacts.Clear();

            try
            {
                var getContactsTask = _repository.GetAllAsync();
                getContactsTask.Wait();
                foreach (var contact in getContactsTask.Result)
                {
                    Contacts.Add(contact);
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        private void CreateSampleData()
        {
            var contact1 = new Question
            {
                Contents= "Temat 1",
                Answe_1="Pytanie 1 1",
                Answe_2 = "Pytanie 2 1",
                Answe_3 = "Pytanie 3 1",
            };


            var contact2 = new Question
            {
                Contents = "Temat 2",
                Answe_1 = "Pytanie 1 2",
                Answe_2 = "Pytanie 2 2",
                Answe_3 = "Pytanie 3 2",
            };


            var contact3 = new Question
            {
                Contents = "Temat 3",
                Answe_1 = "Pytanie 1 3",
                Answe_2 = "Pytanie 2 3",
                Answe_3 = "Pytanie 3 3",
            };

            var task1 = _repository.InsertOrReplaceAsync(contact1);
            var task2 = _repository.InsertOrReplaceAsync(contact2);
            var task3 = _repository.InsertOrReplaceAsync(contact3);

            
            var allTasks = Task.WhenAll(task1, task2, task3);
            allTasks.Wait();

            LoadContacts();
        }
    }
}
