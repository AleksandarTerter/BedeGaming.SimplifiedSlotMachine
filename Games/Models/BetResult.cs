namespace Games.Models
{
    public readonly struct BetResult
    {
        public string View { get; init; }
        public decimal Won { get; init; }
        public BetResult(string view, decimal won)
        {
            View = view;
            Won = won;
        }
    }
}
