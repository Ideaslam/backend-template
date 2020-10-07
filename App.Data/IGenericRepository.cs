using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Edura.Data
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAll();
        T GetByID(object id);
        Task<T> GetByIdAsync(object id);

        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

        IQueryable<T> OrderBy(IQueryable<T> query, string orderColumn = "", string orderType = "");

        T Insert(T entity);
        void BulkUpdate(List<T> entityList);
        IEnumerable<T> BulkInsert(IEnumerable<T> entities);

        T Update(T entity);
        void Delete(T entity);
        void Delete(object id);

        bool Exists(Expression<Func<T, bool>> filter = null);

        void _UpdateByPropList(T entity, params string[] properties);
        T ExecWithStoreProcedure_SingleEntity(string query, params object[] parameters);

        void BulkUpdateByPropList(List<T> list, params string[] properties);
    }
}
