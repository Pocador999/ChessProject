using board;

namespace chess.Pieces
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }
        public override string ToString()
        {
            return "Q";
        }
    }
}
