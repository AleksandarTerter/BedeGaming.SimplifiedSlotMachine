namespace Games.Games.SlotMachine
{
    internal class MapedProbability<T>
    {
        public T Оccurrence { get; init; }
        public double Start { get; init; }
        public double End { get; init; }

        internal MapedProbability(T occurrence, double start, double end)
        {
            if (start < 0)
                throw new ArgumentException($"Start of MapedProbability can not be less than 0");

            if (end > 1)
                throw new ArgumentException($"End of MapedProbability can not be bigger than 1");

            if (end < start)
                throw new ArgumentException($"Start of MapedProbability can not be lower than end");

            Оccurrence = occurrence;
            Start = start;
            End = end;
        }
    }

}
