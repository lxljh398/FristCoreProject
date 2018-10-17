using System;
using System.Collections.Generic;
using System.Text;

namespace CastleWindsor
{
    public interface IHello
    {
        void SayHello(string name);
    }


    public interface IShhHello : IHello
    {

    }
    public interface IHZHello : IHello
    {

    }
    public interface IBJHello : IHello
    {

    }
}
