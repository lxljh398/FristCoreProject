using Autofac;
using Autofac.Builder;
using System;

namespace AutofacProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Service.Dal<>)).As(typeof(Service.IDal<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(RepositoryService.Repository<>)).As(typeof(RepositoryService.IRepository<>)).InstancePerDependency();

            builder.Register(c => new PersionBll((RepositoryService.IRepository<Persion>)c.Resolve(typeof(RepositoryService.IRepository<Persion>))));
            builder.Register(c => new CustomBll((RepositoryService.IRepository<Custom>)c.Resolve(typeof(RepositoryService.IRepository<Custom>))));

            //var container = builder.Build()教程里都是使用这行代码，
            //我本地测试需要加入ContainerBuildOptions枚举选项。
            using (var container = builder.Build(ContainerBuildOptions.None))
            {

                // var repository= container.Resolve(typeof(IRepository<Persion>),new TypedParameter());
                // IRepository<Persion> _repository = repository as Repository<Persion>;
                // var m = new PersionBll(_repository);
                Persion p = new Persion();
                p.Name = "小人";
                p.Age = 27;
                var m = container.Resolve<PersionBll>();
                m.Insert(p);
                Custom c = new Custom();
                c.CustomName = "小小";
                c.CustomID = 10;
                var cc = container.Resolve<CustomBll>();
                cc.Update(c);
            }

            Console.ReadKey();
        }
    }
}
