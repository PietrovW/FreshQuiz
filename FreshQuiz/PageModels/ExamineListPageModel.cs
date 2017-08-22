using FreshMvvm;
using FreshQuiz.DAL.Repositorys;
using FreshQuiz.Models;
using FreshQuiz.Services.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FreshQuiz.PageModels
{
    public class ExamineListPageModel : FreshBasePageModel
    {
        private IRepository<Examine> _repository;
        private Examine _selectedContact = null;
        private IUnitOfWork _iUnitOfWork;
        public ObservableCollection<Examine> Contacts { get; private set; }

       public Examine SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                if (value != null) EditExamineCommand.Execute(value);
            }
        }
        public ExamineListPageModel(IUnitOfWork _IUnitOfWork)
        {
            
            Contacts = new ObservableCollection<Examine>();
            _iUnitOfWork = _IUnitOfWork;
            this._repository = _IUnitOfWork.GetExamine;
        }
        public ExamineListPageModel()
        {
            Contacts = new ObservableCollection<Examine>();
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

        public ICommand AddExamineCommand
        {
            get
            {
                return new Command(async () => {
                    await CoreMethods.PushPageModel<QuestionPageModel>();
                });
            }
        }

        public ICommand EditExamineCommand
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
            Task<List<Examine>> getContactsTask = _repository.GetAllAsync();
            getContactsTask.Wait();
            foreach (var contact in getContactsTask.Result)
            {
                Contacts.Add(contact);
            }
        }

        private void CreateSampleData()
        {
            var contact1 = new Examine
            {
                Name="1"
            };


            var contact2 = new Examine
            {
                Name = "2"
            };
            var contact3 = new Examine
            {
                Name = "3"
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
