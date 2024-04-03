using board;
using chess.Pieces;

namespace chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
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
            board.placePiece(new Pawn(board, Color.White), new ChessPosition('a', 2).toPosition());
            board.placePiece(new Pawn(board, Color.White), new ChessPosition('b', 2).toPosition());
            board.placePiece(new Pawn(board, Color.White), new ChessPosition('c', 2).toPosition());
            board.placePiece(new Pawn(board, Color.White), new ChessPosition('d', 2).toPosition());
            board.placePiece(new Pawn(board, Color.White), new ChessPosition('e', 2).toPosition());
            board.placePiece(new Pawn(board, Color.White), new ChessPosition('f', 2).toPosition());
            board.placePiece(new Pawn(board, Color.White), new ChessPosition('g', 2).toPosition());
            board.placePiece(new Pawn(board, Color.White), new ChessPosition('h', 2).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('a', 1).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('h', 1).toPosition());
            board.placePiece(new Knight(board, Color.White), new ChessPosition('b', 1).toPosition());
            board.placePiece(new Knight(board, Color.White), new ChessPosition('g', 1).toPosition());
            board.placePiece(new Bishop(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.placePiece(new Bishop(board, Color.White), new ChessPosition('f', 1).toPosition());
            board.placePiece(new Queen(board, Color.White), new ChessPosition('d', 1).toPosition());
            board.placePiece(new King(board, Color.White), new ChessPosition('e', 1).toPosition());

            board.placePiece(new Pawn(board, Color.Black), new ChessPosition('a', 7).toPosition());
            board.placePiece(new Pawn(board, Color.Black), new ChessPosition('b', 7).toPosition());
            board.placePiece(new Pawn(board, Color.Black), new ChessPosition('c', 7).toPosition());
            board.placePiece(new Pawn(board, Color.Black), new ChessPosition('d', 7).toPosition());
            board.placePiece(new Pawn(board, Color.Black), new ChessPosition('e', 7).toPosition());
            board.placePiece(new Pawn(board, Color.Black), new ChessPosition('f', 7).toPosition());
            board.placePiece(new Pawn(board, Color.Black), new ChessPosition('g', 7).toPosition());
            board.placePiece(new Pawn(board, Color.Black), new ChessPosition('h', 7).toPosition());
            board.placePiece(new Knight(board, Color.Black), new ChessPosition('b', 8).toPosition());
            board.placePiece(new Knight(board, Color.Black), new ChessPosition('g', 8).toPosition());
            board.placePiece(new Bishop(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.placePiece(new Bishop(board, Color.Black), new ChessPosition('f', 8).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('a', 8).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('h', 8).toPosition());
            board.placePiece(new Queen(board, Color.Black), new ChessPosition('d', 8).toPosition());
            board.placePiece(new King(board, Color.Black), new ChessPosition('e', 8).toPosition());
        }
    }
}
