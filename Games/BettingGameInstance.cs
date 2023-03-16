using Games.Exceptions;
using Games.Models;

namespace Games
{
    public class BettingGameInstance
    {
        public decimal Balance { get; private set; }
        private IBettingGame Game { get; init; }

        public BetResult Bet(decimal stake)
        {
            if (stake <= 0)
                throw new NegativeValue($"Can not stake zero or negative value: {stake}");

            if (stake > Balance)
                throw new BalanceNotEnought($"Your balance is not enought: {Balance}");

            var result = Game.NextResult();
            decimal won = stake * result.WinCoefficient;
            Balance += won - stake;

            return new BetResult(result.View, won);
        }

        public bool CanPlay => Balance > 0;
        public BettingGameInstance(decimal deposit, IBettingGame game)
        {
            if (deposit <= 0)
                throw new NegativeValue($"Can not stake zero or negative value: {deposit}");

            Balance = deposit;
            Game = game;
        }
    }
}
