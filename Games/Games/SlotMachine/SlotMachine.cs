using System.Collections.ObjectModel;
using Games.Models;

namespace Games.Games.SlotMachine
{
    public class SlotMachine : IBettingGame
    {
        private SlotMachineCombinationsGenerator<SlotMachineSymbol> CombinationsGenerator { get; init; }

        public BetGameResult NextResult()
        {
            ReadOnlyCollection<ReadOnlyCollection<SlotMachineSymbol>> combinations = CombinationsGenerator.GetRandom();
            double playCoefficient = combinations.Select(CalcCoefficient).Sum();
            string playView = GetView(combinations);

            return new(playView, (decimal)playCoefficient);
        }

        private static double CalcCoefficient(IEnumerable<SlotMachineSymbol> combination)
        {
            var isWin = combination
                .Where(symbol => !symbol.IsWildcard)
                .Distinct()
                .Count() < 2;

            return isWin
                ? combination.Sum(symbol => symbol.Coefficient)
                : 0;
        }

        private static string GetView(IEnumerable<IEnumerable<SlotMachineSymbol>> combinations) =>
            string.Join(
                Environment.NewLine,
                combinations.Select(c => string.Concat(c.Select(s => s.Name))));

        internal SlotMachine(SlotMachineCombinationsGenerator<SlotMachineSymbol> combinationsGenerator)
        {
            CombinationsGenerator = combinationsGenerator;
        }
    }

}
