using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control.Monad
{
    public abstract class Monad<T>
    {
        public abstract Monad<T> Return();
        public abstract Monad<U> Bind<U>(Func<Monad<U>> f);
        public abstract Monad<U> Bind<U>(Func<T, Monad<U>> f);
        public abstract void Bind(Action<T> f);
        public abstract void Bind(Action f);
    }
}
