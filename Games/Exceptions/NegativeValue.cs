namespace Games.Exceptions
{
    public class NegativeValue : Exception
    {
        public NegativeValue(string? message) : base(message) { }
    }
}
