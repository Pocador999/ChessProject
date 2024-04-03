using board;

namespace chess.Pieces
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
