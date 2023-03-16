using Games.Exceptions;
using Games.Interfaces;

namespace Games
{
    public struct BettingGameInstance
    {
        private decimal Balance { get; set; }
        private IBettingGame Game { get; init; }

        public (string playView, decimal won, decimal balance) Gamble(decimal stake)
        {
            if (stake <= 0)
                throw new NegativeValue($"Can not stake zero or negative value: {stake}");

            if (stake > Balance)
                throw new BalanceNotEnought($"Your balance is not enought: {Balance}");

            (string playView, double playCoefficient) = Game.NextResult();
            decimal won = stake * (decimal)playCoefficient;
            Balance += won - stake;

            return (playView, won, Balance);
        }

        public bool CanPlay => Balance > 0;
        public BettingGameInstance(decimal deposit, IBettingGame game)
        {
            Balance = deposit;
            Game = game;
        }
    }

}
