using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using System;
using FreshQuiz.DAL.Repositorys;
using FreshQuiz.Services.FileAccess;

namespace FreshQuiz.Services.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private  ExamineRepository _ExamineRepository=null;
        private  QuestionRepository _QuestionRepository=null;
        private readonly SQLiteAsyncConnection conn;
        private readonly IFileAccessHelper _fileAccessHelper;
        public string StatusMessage { get; set; }

        public UnitOfWork(IFileAccessHelper FileAccessHelper)
        {
            _fileAccessHelper = FileAccessHelper;
            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(_fileAccessHelper.GetISQLitePlatform, new SQLiteConnectionString(_fileAccessHelper.GetLocalFilePath, storeDateTimeAsTicks: false)));
            conn = new SQLiteAsyncConnection(connectionFactory);
        }

        public ExamineRepository GetExamine { get { if (_ExamineRepository == null) return _ExamineRepository = new ExamineRepository(conn); else return _ExamineRepository; } }
        
        public QuestionRepository GetQuestion { get { if (_QuestionRepository == null) return _QuestionRepository = new QuestionRepository(conn); else return _QuestionRepository; } }
    }
}
