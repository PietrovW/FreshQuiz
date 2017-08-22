using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshQuiz.DAL.Repositorys
{
    public interface IRepository<T> : IDisposable
    {
        Task<int> CountAsync();

        Task<T> GetByIdAsync(int idValue);
        Task<int> InsertOrReplaceAsync(T question);
        Task<List<T>> GetAllAsync();
        Task<int> DeleteAsync(T question);
    }
}
