using Games;
using Games.Exceptions;

namespace Tests
{
    public class Valid
    {
        private const int InitialDeposit = 100;
        BettingGameInstance game;

        [SetUp]
        public void Setup()
        {
            game = new(InitialDeposit, SlotMachine.SlotMachine4Row3Slot4Symbols());
        }

        [Test]
        public void GameIsPlayable()
        {
            Assert.AreEqual(game.CanPlay, true);
        }

        [Test]
        public void CanBetAllBalance()
        {
            Assert.DoesNotThrow(() => game.Bet(InitialDeposit));
        }

        [Test]
        public void CanNotBetMoreThanBalance()
        {
            Assert.Throws<BalanceNotEnought>(() => game.Bet(InitialDeposit + 1));
        }

        [Test]
        public void CanNotBetZeroOrNegativeStake()
        {
            Assert.Throws<NegativeValue>(() => game.Bet(0));
            Assert.Throws<NegativeValue>(() => game.Bet(-1));
        }
    }

    public class InValid
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanNotCreateGameWhitZeroOrNegativeDeposit()
        {
            Assert.Throws<NegativeValue>(() => new BettingGameInstance(0, SlotMachine.SlotMachine4Row3Slot4Symbols()));
            Assert.Throws<NegativeValue>(() => new BettingGameInstance(-1, SlotMachine.SlotMachine4Row3Slot4Symbols()));
        }
    }
}