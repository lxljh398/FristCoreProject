using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacProject
{
    public class PersionBll : DependencyService.IDependency
    {
        private readonly RepositoryService.IRepository<Persion> _repository;
        public PersionBll(RepositoryService.IRepository<Persion> repository)
        {
            _repository = repository;
        }

        public void Insert(Persion p)
        {
            _repository.Insert(p);
        }

        public void Update(Persion p)
        {
            _repository.Update(p);
        }

        public void Delete(Persion p)
        {
            _repository.Delete(p);
        }
    }
}
