using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacProject
{
    public class CustomBll : DependencyService.IDependency
    {
        private readonly RepositoryService.IRepository<Custom> _repository;
        public CustomBll(RepositoryService.IRepository<Custom> repository)
        {
            _repository = repository;
        }

        public void Insert(Custom c)
        {
            _repository.Insert(c);
        }

        public void Update(Custom c)
        {
            _repository.Update(c);
        }

        public void Delete(Custom c)
        {
            _repository.Delete(c);
        }
    }
}
