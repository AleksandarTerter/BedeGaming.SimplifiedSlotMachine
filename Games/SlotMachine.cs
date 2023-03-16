using System.Collections.ObjectModel;
using Games.Interfaces;

namespace Games
{
    public readonly struct SlotMachine : IBettingGame
    {
        private CombinationsGenerator<SlotMachineSymbol> CombinationsGenerator { get; init; }

        public (string playView, double playCoefficient) NextResult()
        {
            ReadOnlyCollection<ReadOnlyCollection<SlotMachineSymbol>> combinations = CombinationsGenerator.GetRandom();
            double playCoefficient = combinations.Select(CalcCoefficient).Sum();
            string playView = GetView(combinations);

            return (playView, playCoefficient);
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

        internal SlotMachine(CombinationsGenerator<SlotMachineSymbol> combinationsGenerator)
        {
            CombinationsGenerator = combinationsGenerator;
        }

        public static IBettingGame SlotMachine4Row3Slot4Symbols()
        {
            ОccurrenceGenerator<SlotMachineSymbol> symbGen = new(new HashSet<SlotMachineSymbol>() {
                new SlotMachineSymbol("A", false, 0.4, 0.45),
                new SlotMachineSymbol("B", false, 0.6, 0.35),
                new SlotMachineSymbol("P", false, 0.8, 0.15),
                new SlotMachineSymbol("*", true, 0, 0.05),
            });
            CombinationsGenerator<SlotMachineSymbol> combinGen = new(symbGen, 3, 4);

            return new SlotMachine(combinGen);
        }
    }

}
