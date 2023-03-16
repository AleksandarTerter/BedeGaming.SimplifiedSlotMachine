using System.Collections.ObjectModel;
using Games.Models;

namespace Games
{
    internal class SlotMachineCombinationsGenerator<T> where T : IОccurrence
    {
        private ОccurrenceGenerator<T> SymbolGenerator { get; init; }
        private byte CombinationSize { get; init; }
        private byte CombinationsCount { get; init; }

        internal ReadOnlyCollection<ReadOnlyCollection<T>> GetRandom()
        {
            T[][] combinations = new T[CombinationsCount][];
            for (int combinationIndex = 0; combinationIndex < combinations.Length; combinationIndex++)
            {
                T[] combination = new T[CombinationSize];
                for (int i = 0; i < combination.Length; i++)
                    combination[i] = SymbolGenerator.GetRandom();

                combinations[combinationIndex] = combination;
            }

            return combinations.Select(combination => combination.AsReadOnly()).ToArray().AsReadOnly();
        }

        internal SlotMachineCombinationsGenerator(ОccurrenceGenerator<T> symbolGenerator, byte symbolsPerCombination, byte combinationsPerGamble)
        {
            SymbolGenerator = symbolGenerator;
            CombinationSize = symbolsPerCombination;
            CombinationsCount = combinationsPerGamble;
        }
    }

}
