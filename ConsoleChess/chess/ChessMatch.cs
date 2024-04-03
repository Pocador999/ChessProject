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
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            placePieces();
        }

        public void executeMove(Position origin, Position destination)
        {
            Piece p = board.removePiece(origin);
            p.incrementMoves();
            Piece capturedPiece = board.removePiece(destination);
            board.placePiece(p, destination);
            if(capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
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

        public HashSet<Piece> capturedPiece(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in captured)
            {
                if(x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in pieces)
            {
                if(x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPiece(color));
            return aux;
        }

        public void placeNewPiece(char column, int row, Piece p)
        {
            board.placePiece(p, new ChessPosition(column, row).toPosition());
            pieces.Add(p);
        }

        private void placePieces()
        {
            placeNewPiece('c', 1, new Rook(board, Color.White));
            placeNewPiece('c', 2, new Rook(board, Color.White));
            placeNewPiece('d', 2, new Rook(board, Color.White));
            placeNewPiece('e', 2, new Rook(board, Color.White));
            placeNewPiece('e', 1, new Rook(board, Color.White));
            placeNewPiece('d', 1, new King(board, Color.White));

            placeNewPiece('c', 7, new Rook(board, Color.Black));
            placeNewPiece('c', 8, new Rook(board, Color.Black));
            placeNewPiece('d', 7, new Rook(board, Color.Black));
            placeNewPiece('e', 7, new Rook(board, Color.Black));
            placeNewPiece('e', 8, new Rook(board, Color.Black));
            placeNewPiece('d', 8, new King(board, Color.Black));
        }
    }
}
