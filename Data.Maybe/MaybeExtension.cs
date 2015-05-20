using System;
using Data.Maybe.Exception;

namespace Data.Maybe
{
    public static class MaybeExtension
    {
        public static T FromMaybe<T>(this Maybe<T> m, T defaultValue) {
            return m.HasValue ? m.Value : defaultValue;
        }

        public static T FromMaybe<T>(this Maybe<T> m) {
            if (m.HasValue) {
                return m.Value;
            }
            else {
                throw new MaybeException();
            }
        }

        public static T FromMaybe<T>(this Maybe<T> m, Func<T> exceptHandler) {
            if (m.HasValue) {
                return m.Value;
            }
            else {
                return exceptHandler();
            }
        }
    }
}
