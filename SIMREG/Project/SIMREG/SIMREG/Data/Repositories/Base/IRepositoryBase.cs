using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMREG.Data.Repositories.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        //int Delete(long id);
        //int Delete(string id);
        //int Save();
    }
}