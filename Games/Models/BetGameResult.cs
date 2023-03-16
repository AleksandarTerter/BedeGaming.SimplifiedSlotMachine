namespace Games.Models
{
    public readonly struct BetGameResult
    {
        public string View { get; init; }
        public decimal WinCoefficient { get; init; }
        public BetGameResult(string view, decimal winCoefficient)
        {
            View = view;
            WinCoefficient = winCoefficient;
        }
    }
}