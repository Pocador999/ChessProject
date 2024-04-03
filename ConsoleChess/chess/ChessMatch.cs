using board;
using chess.pieces;

namespace chess
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
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

        public void makeMove(Position origin, Position destination)
        {
            executeMove(origin, destination);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos)
        {
            if(board.piece(pos) == null)
            {
                throw new BoardException("There is not a piece on the selected position!");
            }
            if(currentPlayer != board.piece(pos).color)
            {
                throw new BoardException("The selected piece is not yours!");
            }
            if(!board.piece(pos).existPossibleMoves())
            {
                throw new BoardException("There are not valid moves!");
            }
        }

        public void validateFinalPosition(Position origin, Position destination)
        {
            if(!board.piece(origin).canMoveTo(destination))
            {
                throw new BoardException("Invalid destination!");
            }
        }

        private void changePlayer()
        {
            if(currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        private void placePieces()
        {
            board.placePiece(new King(board, Color.White), new ChessPosition('c', 1).toPosition());
            board.placePiece(new Rook(board, Color.White), new ChessPosition('a', 1).toPosition());

            board.placePiece(new King(board, Color.Black), new ChessPosition('c', 8).toPosition());
            board.placePiece(new Rook(board, Color.Black), new ChessPosition('a', 8).toPosition());
        }
    }
}
