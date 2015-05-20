namespace Data.Maybe.Exception
{
    public class MaybeException : System.Exception
    {
        public MaybeException()
            : base()
        { }
        public MaybeException(string message)
            : base(message)
        { }
        public MaybeException(string message, System.Exception innerException)
            : base(message, innerException)
        { }
    }
}
