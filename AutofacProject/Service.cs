using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacProject
{
    public class Service
    {
        public interface IDal<T> where T : class
        {
            void Insert(T entity);
            void Update(T entity);
            void Delete(T entity);
        }


        public class Dal<T> : IDal<T> where T : class
        {
            public void Delete(T entity)
            {
                Console.WriteLine("删除一个实体对象");
            }

            public void Insert(T entity)
            {
                Console.WriteLine("添加一个实体对象");
            }

            public void Update(T entity)
            {
                Console.WriteLine("修改一个实体对象");
            }
        }
    }
}
