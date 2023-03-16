namespace Games.Interfaces
{
    public interface IBettingGame
    {
        (string playView, double playCoefficient) NextResult();
    }
}