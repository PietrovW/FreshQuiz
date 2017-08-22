using FreshQuiz.DAL.Repositorys;

namespace FreshQuiz.Services.Data
{
    public interface IUnitOfWork
    {
        ExamineRepository GetExamine { get; }
        QuestionRepository GetQuestion { get; }
    }
}
