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

                Screen.printBoard(match.board);
            }
            catch (Exception e)
            {
               Console.WriteLine(e.Message);
            }
        }
    }
}