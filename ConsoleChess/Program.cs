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
                    Console.Clear();
                    Screen.printBoard(match.board);

                    Console.Write("\nOrigin: ");
                    Position origin = Screen.readPositionChess().toPosition();

                    bool[,]possibleMoves = match.board.piece(origin).possibleMoves();

                    Console.Clear();
                    Screen.printBoard(match.board, possibleMoves);

                    Console.Write("Destination: ");
                    Position destination = Screen.readPositionChess().toPosition();

                    match.executeMove(origin, destination);
                }

            }
            catch (Exception e)
            {
               Console.WriteLine(e.Message);
            }
        }
    }
}