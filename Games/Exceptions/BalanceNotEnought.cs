namespace Games.Exceptions
{
    public class BalanceNotEnought : Exception
    {
        public BalanceNotEnought(string? message) : base(message) { }
    }
}
