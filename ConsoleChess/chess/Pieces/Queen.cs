using board;

namespace chess.pieces
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
