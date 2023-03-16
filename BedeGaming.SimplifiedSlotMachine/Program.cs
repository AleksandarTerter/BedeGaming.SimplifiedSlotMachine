using Games;
using Games.Exceptions;
using Games.Games.SlotMachine;
using Games.Models;

decimal deposit;
do Console.Write("Please deposit money you would like to play with:");
while (!decimal.TryParse(Console.ReadLine(), out deposit));

IBettingGame bettingGame = new SlotMachine4Row3Slot4Symbols();
BettingGameInstance game = new(deposit, bettingGame);

while (game.CanPlay)
{
    decimal stake;
    do Console.Write("Enter stake amount:");
    while (!decimal.TryParse(Console.ReadLine(), out stake));

    try
    {
        BetResult result = game.Bet(stake);
        Console.WriteLine(result.View);
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine($"You have won: {Math.Round(result.Won, 1)}");
        Console.WriteLine($"Current balance is: {Math.Round(game.Balance, 1)}");
    }
    catch (Exception ex) when (ex is BalanceNotEnought || ex is NegativeValue)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Game is over!");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Come play again!");
