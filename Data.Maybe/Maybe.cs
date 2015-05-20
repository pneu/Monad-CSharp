using System;
using Control.Monad;

namespace Data.Maybe
{
    public class Maybe<T> : Monad<T>
    {
        public static Maybe<T> Nothing = new Maybe<T>();
        public static Maybe<T> Just(T value) {
            return new Maybe<T>(value);
        }

        internal readonly T Value;
        internal readonly bool HasValue = false;
        private Maybe() { }
        private Maybe(T v) {
            Value = v;
            HasValue = true;
        }

        public Maybe<T> ReturnMaybe() {
            return Just(Value);
        }

        public Maybe<U> Bind<U>(Func<Maybe<U>> f) {
            if (HasValue) {
                return f();
            }
            else {
                return Maybe<U>.Nothing;
            }
        }

        public Maybe<U> Bind<U>(Func<T, Maybe<U>> f) {
            if (HasValue) {
                return f(Value);
            }
            else {
                return Maybe<U>.Nothing;
            }
        }

        public override void Bind(Action<T> f) {
            if (HasValue) {
                f(Value);
            }
        }

        public override void Bind(Action f) {
            if (HasValue) {
                f();
            }
        }

        #region Monad Interface
        public override Monad<T> Return() {
            return (Monad<T>)(this.ReturnMaybe());
        }

        public override Monad<U> Bind<U>(Func<Monad<U>> f) {
            return this.Bind<U>(f);
        }

        public override Monad<U> Bind<U>(Func<T, Monad<U>> f) {
            return this.Bind<U>(f);
        }

        #endregion
    }
}
