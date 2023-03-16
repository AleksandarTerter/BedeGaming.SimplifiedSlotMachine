using Games.Interfaces;

namespace Games
{
    internal readonly struct SlotMachineSymbol : IОccurrence
    {
        public string Name { get; init; }
        public bool IsWildcard { get; init; }
        public double Coefficient { get; init; }
        public double ProbabilityToAppear { get; init; }

        internal SlotMachineSymbol(string name, bool isWildcard, double coefficient, double probabilityToAppear)
        {
            Name = name;
            IsWildcard = isWildcard;
            Coefficient = coefficient;
            ProbabilityToAppear = probabilityToAppear;
        }

        public override bool Equals(object? obj) =>
            obj is SlotMachineSymbol symbol
            && Name == symbol.Name;

        public override int GetHashCode() => HashCode.Combine(Name);
    }

}
