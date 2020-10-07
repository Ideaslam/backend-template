﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edura.Data.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable where TContext : DbContext, new()
    {
        //Here TContext is nothing but your DBContext class
        //In our example it is EmployeeDBContext class
        private readonly ApplicationDbContext _context;
        private bool _disposed;
        private string _errorMessage = string.Empty;
        private Dictionary<string, object> _repositories;

        private IDbContextTransaction _objTran;
        //Using the Constructor we are initializing the _context variable is nothing but
        //we are storing the DBContext (EmployeeDBContext) object in _context variable
        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
        }

        public UnitOfWork(DbContextOptions options)
        {
            _context = new ApplicationDbContext(options);
        }
        //The Dispose() method is used to free unmanaged resources like files, 
        //database connections etc. at any time.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //This Context property will return the DBContext object i.e. (EmployeeDBContext) object
        public ApplicationDbContext Context
        {
            get { return _context; }
        }
        //This CreateTransaction() method will create a database Trnasaction so that we can do database operations by
        //applying do evrything and do nothing principle
        public void CreateTransaction()
        {
             _objTran= _context.Database.BeginTransaction();
        }
        //If all the Transactions are completed successfuly then we need to call this Commit() 
        //method to Save the changes permanently in the database
        public void Commit()
        {
            _objTran.Commit();
        }
        //If atleast one of the Transaction is Failed then we need to call this Rollback() 
        //method to Rollback the database changes to its previous state
        public void Rollback()
        {
            _objTran.Rollback();
            _objTran.Dispose();
        }
        //This Save() Method Implement DbContext Class SaveChanges method so whenever we do a transaction we need to
        //call this Save() method so that it will make the changes in the database

        public void Save()
        {
            try
            {
                _context.SaveChanges();
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
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }
        public GenericRepository<T> GenericRepository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();
            var type = typeof(T).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<T>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (GenericRepository<T>)_repositories[type];
        }
    }
}