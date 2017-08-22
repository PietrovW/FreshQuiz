using FreshQuiz.Models;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreshQuiz.DAL.Repositorys
{
    public class QuestionRepository : IRepository<Question>
    {
        private readonly SQLiteAsyncConnection conn;
        public string StatusMessage { get; set; }
        public QuestionRepository(SQLiteAsyncConnection conn)
        {
            this.conn = conn;
            conn.CreateTableAsync<Question>().Wait();
        }

        public async Task<int> DeleteAsync(Question question)
        {
            return await conn.DeleteAsync(question).ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<List<Question>> GetAllAsync()
        {
            return await conn.Table<Question>().ToListAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<Question> GetByIdAsync(int idValue)
        {
            return await conn.Table<Question>().Where(x => x.Id == idValue).FirstOrDefaultAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<int> InsertOrReplaceAsync(Question question)
        {
            return await conn.InsertOrReplaceAsync(question).ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<int> CountAsync()
        {
           // var test = conn.Table<Question>().ConfigureAwait(continueOnCapturedContext: false);
            return await conn.Table<Question>().CountAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
