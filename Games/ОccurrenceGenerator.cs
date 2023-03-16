using System.Collections.ObjectModel;
using Games.Interfaces;

namespace Games
{
    internal readonly struct ОccurrenceGenerator<T> where T : IОccurrence
    {
        private ReadOnlyCollection<MapedProbability<T>> MapedProbabilities { get; init; }
        private readonly Random random = new();

        public T GetRandom()
        {
            double randomDouble = random.NextDouble();
            MapedProbability<T> result = MapedProbabilities.FirstOrDefault(map => map.Start <= randomDouble && randomDouble < map.End);
            return result.Оccurrence ?? throw new InvalidOperationException("Can not generate randpm symbol.");
        }

        internal ОccurrenceGenerator(HashSet<T> posibleОccurrence)
        {
            List<MapedProbability<T>> maped = new();
            double combinedProbability = 0;
            foreach (T po in posibleОccurrence)
            {
                MapedProbability<T> mp = new(po, combinedProbability, combinedProbability + po.ProbabilityToAppear);
                combinedProbability = mp.End;
                maped.Add(mp);
            }

            if (combinedProbability != 1)
                throw new ArgumentException($"The provided posible оccurrence probabilities does not sum up to probability of 1");

            MapedProbabilities = maped.AsReadOnly();
        }
    }

}
