using board;
using chess.pieces;

namespace chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool finished { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            placePieces();
        }

        public void executeMove(Position origin, Position destination)
        {
            Piece p = board.removePiece(origin);
            p.incrementMoves();
            Piece capturedPiece = board.removePiece(destination);
            board.placePiece(p, destination);
        }

        private void placePieces()
        {
            board.placePiece(new King(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('a', 1).toPosition());
        }
    }
}
