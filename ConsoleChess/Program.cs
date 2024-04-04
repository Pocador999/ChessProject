using board;
using chess;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.printMatch(match);

                        Console.Write("\nOrigin: ");
                        Position origin = Screen.readPositionChess().toPosition();

                        match.validateOriginPosition(origin);

                        bool[,] possibleMoves = match.board.piece(origin).possibleMoves();

                        Console.Clear();
                        Screen.printBoard(match.board, possibleMoves);

                        Console.Write("\nDestination: ");
                        Position destination = Screen.readPositionChess().toPosition();

                        match.validateFinalPosition(origin, destination);
                        match.makePlay(origin, destination);
                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch (Exception e)
            {
               Console.WriteLine(e.Message);
            }
        }
    }
}