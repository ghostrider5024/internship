using Microsoft.EntityFrameworkCore;

namespace MVC2.Models
{
    public interface BaseModel<T>
    {
        #region C
        public Task<T> AddObjectAsync(T obj);
        #endregion

        #region R
        public Task<List<T>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1);
        public Task<List<T>> SearchObjectAsync(Func<T, bool> predicate = null, int pageNumber = -1, int pageSize = -1);
        public Task<T> GetObjectAsync(params object[] id);
        #endregion

        #region U
        public Task UpdateObjectAsync(T obj);
        #endregion

        #region D
        public Task DeleteObjectSync(object id);
        #endregion
    }
}
