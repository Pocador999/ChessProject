using board;

namespace chess.pieces
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }
        public override string ToString()
        {
            return "H";
        }
    }
}
