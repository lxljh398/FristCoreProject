using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacProject
{
    public class RepositoryService
    {
        public interface IRepository<T> where T : class
        {
            void Insert(T entity);
            void Update(T entity);
            void Delete(T entity);
        }


        public class Repository<T> : IRepository<T> where T : class
        {
            private Service.IDal<T> _idal;
            public Repository(Service.IDal<T> idal)
            {
                _idal = idal;
            }
            public void Delete(T entity)
            {
                _idal.Delete(entity);
            }

            public void Insert(T entity)
            {
                _idal.Insert(entity);
            }

            public void Update(T entity)
            {
                _idal.Update(entity);
            }
        }
    }
}
