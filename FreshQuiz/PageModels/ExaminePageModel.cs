using FreshMvvm;
using FreshQuiz.DAL.Repositorys;
using FreshQuiz.Models;
using FreshQuiz.Services.Data;
using PropertyChanged;
using System.Windows.Input;
using Xamarin.Forms;

namespace FreshQuiz.PageModels
{
    [ImplementPropertyChanged]
    public class ExaminePageModel : FreshBasePageModel
    {
        private IRepository<Question> _repository;
        private IUnitOfWork _IUnitOfWork;
        public ExaminePageModel(IUnitOfWork IUnitOfWork)
        {
            _IUnitOfWork = IUnitOfWork;
            _repository = _IUnitOfWork.GetQuestion;
        }

        private Question _question;

        public string QuestionTitle
        {
            get { return _question.Contents; }
        }

        public string ExamineContents
        {
            get { return _question.Contents; }
            set { _question.Contents = value; }
        }
        public string ContactAnswe_1
        {
            get { return _question.Answe_1; }
            set { _question.Answe_1 = value; }
        }

        public string ContactAnswe_2
        {
            get { return _question.Answe_2; }
            set { _question.Answe_2 = value; }
        }
        public string ContactAnswe_3
        {
            get { return _question.Answe_3; }
            set { _question.Answe_3 = value; }
        }
        public override void Init(object initData)
        {
            _question = initData as Question;
            if (_question == null) _question = new Question();
            base.Init(initData);
        }
        public ICommand SaveCommand
        {
            get
            {
                return new Command(async () => {
                    if (_question.IsValid())
                    {
                        await _repository.InsertOrReplaceAsync(_question);
                        await CoreMethods.PopPageModel(_question);
                    }
                });
            }
        }
    }
}
