using FreshQuiz.Models;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshQuiz.DAL.Repositorys
{
    public class ExamineRepository : IRepository<Examine>
    {
        private readonly SQLiteAsyncConnection conn;

        public string StatusMessage { get; set; }
        public ExamineRepository(SQLiteAsyncConnection conn)
        {
            this.conn = conn;
            conn.CreateTableAsync<Examine>().Wait();
        }

        public async Task<int> DeleteAsync(Examine question)
        {
            return await conn.DeleteAsync(question).ConfigureAwait(continueOnCapturedContext: false); 
        }

        public async Task<List<Examine>> GetAllAsync()
        {
            return await conn.Table<Examine>().ToListAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<Examine> GetByIdAsync(int idValue)
        {
            return await conn.Table<Examine>().Where(x=>x.Id == idValue).FirstOrDefaultAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<int> InsertOrReplaceAsync(Examine question)
        {
            return await conn.InsertOrReplaceAsync(question).ConfigureAwait(continueOnCapturedContext: false);
        }

        public async Task<int> CountAsync()
        {
            return await conn.Table<Examine>().CountAsync().ConfigureAwait(continueOnCapturedContext: false);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
