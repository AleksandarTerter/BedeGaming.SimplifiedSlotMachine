namespace Games.Games.SlotMachine
{
    public class SlotMachine4Row3Slot4Symbols : SlotMachine
    {
        public SlotMachine4Row3Slot4Symbols() : base(
            new(new(new HashSet<SlotMachineSymbol>() {
                new SlotMachineSymbol("A", false, 0.4, 0.45),
                new SlotMachineSymbol("B", false, 0.6, 0.35),
                new SlotMachineSymbol("P", false, 0.8, 0.15),
                new SlotMachineSymbol("*", true, 0, 0.05),
            }),
                3,
                4))
        { }
    }
}
