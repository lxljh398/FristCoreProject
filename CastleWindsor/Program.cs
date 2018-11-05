using System;
using System.Collections;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace CastleWindsor
{
    class Program
    {
        //https://www.jianshu.com/p/6154d565c3a3?tdsourcetag=s_pctim_aiomsg
        //控制反转 IoC微软官方Castle.Windsor类库
        static void Main(string[] args)
        {
            IWindsorContainer _container = new WindsorContainer();
            //_container.Register(Component.For<IHello>().ImplementedBy<Fun.SHHello>(),Component.For<IHello>().ImplementedBy<Fun.HangzhouHello>(),Component.For<IHello>().ImplementedBy<Fun.BeijingHello>());



            //_container.Register(Component.For<Fun.SHHello, IHello>().ImplementedBy<Fun.SHHello>(),Component.For<Fun.HangzhouHello, IHello>().ImplementedBy<Fun.HangzhouHello>(),Component.For<Fun.BeijingHello, IHello>().ImplementedBy<Fun.BeijingHello>());
            //var hz = _container.Resolve<Fun.HangzhouHello>();
            //hz.SayHello("hz");

            //var bj = _container.Resolve<Fun.BeijingHello>();
            //bj.SayHello("bj");

            //var shh = _container.Resolve<Fun.SHHello>();
            //shh.SayHello("shh");





            //_container.Register(Component.For<IShhHello>().ImplementedBy<Fun.SHHello>(), Component.For<IHZHello>().ImplementedBy<Fun.HangzhouHello>(), Component.For<IBJHello>().ImplementedBy<Fun.BeijingHello>());


            //var hz = _container.Resolve<IHZHello>();
            //hz.SayHello("hz");

            //var bj = _container.Resolve<IBJHello>();
            //bj.SayHello("bj");

            //var shh = _container.Resolve<IShhHello>();
            //shh.SayHello("shh");
            //Console.ReadKey();

            var a = Power(2, 8);
            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }
            Console.ReadKey();
        }

        public static IEnumerable Power(int number, int exponent)
        {
            int result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
            yield return 3;
            yield return 4;
        }
    }
}
