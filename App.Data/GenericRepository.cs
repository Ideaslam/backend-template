using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Edura.Data.UnitOfWork;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Edura.Data
{
    public abstract class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private DbSet<T> _entities;

        private string _errorMessage = string.Empty;

        private bool _isDisposed;
        protected ApplicationDbContext Context { get; set; }
        public GenericRepository(IUnitOfWork<ApplicationDbContext> unitOfWork)
        {
            _isDisposed = false;
            this.Context = unitOfWork.Context;
        }

        public virtual IQueryable<T> Table
        {
            get { return Entities; }
        }
        protected virtual DbSet<T> Entities
        {
            get { return _entities ?? (_entities = Context.Set<T>()); }
        }
        public virtual IQueryable<T> GetAll()
        {
            return this.Entities.AsQueryable<T>();
        }

        public virtual T GetByID(object id)
        {
            return Entities.Find(id);
        }
        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }
        public virtual IQueryable<T> FindAll()
        {
            return this.Context.Set<T>();
        }

        public T Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                Entities.Add(entity);
                if (Context == null || _isDisposed)
                    Context = new ApplicationDbContext();
                return entity;

            }
            catch (DbUpdateException e)
            {
                SqlException s = e.InnerException.InnerException as SqlException;
                if (s != null && s.Number == 2627)
                {
                    _errorMessage += string.Format("Part number '{0}' already exists.", s.Number);
                }
                else
                {
                    _errorMessage += string.Format("An error occured - please contact your system administrator.");
                }
                throw;
            }

        }

        public IEnumerable<T> BulkInsert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("entities");
                }

                Context.ChangeTracker.AutoDetectChangesEnabled = false;
                Context.Set<T>().AddRange(entities);
                Context.SaveChanges();

                return entities;
            }
            catch (DbUpdateException e)
            {
                SqlException s = e.InnerException.InnerException as SqlException;
                if (s != null && s.Number == 2627)
                {
                    _errorMessage += string.Format("Part number '{0}' already exists.", s.Number);
                }
                else
                {
                    _errorMessage += string.Format("An error occured - please contact your system administrator.");
                }
                throw;
            }
        }


        public virtual void BulkUpdate(List<T> entityList)
        {
            try
            {
                if (entityList == null)
                    throw new ArgumentNullException("entity");
                if (Context == null || _isDisposed)
                    Context = new ApplicationDbContext();
                foreach (var entityToUpdate in entityList)
                {
                    SetEntryModified(entityToUpdate);

                }

            }
            catch (DbUpdateException e)
            {
                SqlException s = e.InnerException.InnerException as SqlException;
                if (s != null && s.Number == 2627)
                {
                    _errorMessage += string.Format("Part number '{0}' already exists.", s.Number);
                }
                else
                {
                    _errorMessage += string.Format("An error occured - please contact your system administrator.");
                }

                throw;
            }
        }

        public virtual T Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                if (Context == null || _isDisposed)
                    Context = new ApplicationDbContext();
                SetEntryModified(entity);
                return entity;

            }
            catch (DbUpdateException e)
            {
                SqlException s = e.InnerException.InnerException as SqlException;
                if (s != null && s.Number == 2627)
                {
                    _errorMessage += string.Format("Part number '{0}' already exists.", s.Number);
                }
                else
                {
                    _errorMessage += string.Format("An error occured - please contact your system administrator.");
                }

                throw;
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                if (Context == null || _isDisposed)
                    Context = new ApplicationDbContext();
                Entities.Remove(entity);
            }

            catch (ConstraintException e)
            {
                throw e;
            }
            catch (DbUpdateException e)
            {
                SqlException s = e.InnerException.InnerException as SqlException;
                if (s != null && s.Number == 2627)
                {
                    _errorMessage += string.Format("Part number '{0}' already exists.", s.Number);
                }
                else
                {
                    _errorMessage += string.Format("An error occured - please contact your system administrator.");
                }

                throw e;
            }
        }

        public virtual void SetEntryModified(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return this.Entities.AsQueryable<T>().Where(expression).AsNoTracking();
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = Entities;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                
                query = orderBy(query);
            }
            
            return query;
        }

        public IQueryable<T> OrderBy(IQueryable<T> query, string orderColumn = "", string orderType="")
        {
            var orderBy = SortingHelper<T>.GetOrderBy(orderColumn, orderType);

            return orderBy(query);
        }

        public T ExecWithStoreProcedure_SingleEntity(string query, params object[] parameters)
        {
            var xxx = Context.Set<T>().FromSqlRaw(query, parameters);
            return xxx.AsEnumerable().FirstOrDefault();

        }

        public virtual bool Exists(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = Entities;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (query.Any())
            {
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
            _isDisposed = true;
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = Entities.Find(id);
            if (entityToDelete != null)
                Delete(entityToDelete);
        }
        public  virtual void _UpdateByPropList(T entity, params string[] properties)
        {
            Context.Set<T>().Attach(entity);

            foreach (var property in properties)
                Context.Entry<T>(entity)
                    .Property(property)
                    .IsModified = true;

        }

        public virtual void BulkUpdateByPropList(List<T> list, params string[] properties)
        {
            foreach (var entity in list)
            {
                Context.Set<T>().Attach(entity);

                foreach (var property in properties)
                    Context.Entry<T>(entity)
                        .Property(property)
                        .IsModified = true;
            }

        }

    }

}
