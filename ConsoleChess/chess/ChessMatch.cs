﻿using board;
using chess.pieces;
using System.Reflection.PortableExecutable;

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
        public bool check { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            check = false;
            finished = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            placePieces();
        }

        public Piece executeMove(Position origin, Position destination)
        {
            Piece p = board.removePiece(origin);
            p.incrementMoves();
            Piece capturedPiece = board.removePiece(destination);
            board.placePiece(p, destination);
            if(capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }

            // # Short Castle
            if (p is King && destination.column == origin.column + 2)
            {
                Position originR = new Position(origin.row, origin.column + 3);
                Position destinationR = new Position(origin.row, origin.column + 1);
                Piece R = board.removePiece(originR);
                R.incrementMoves();
                board.placePiece(R, destinationR);
            }

            // # Long Castle
            if (p is King && destination.column == origin.column - 2)
            {
                Position originR = new Position(origin.row, origin.column - 4);
                Position destinationR = new Position(origin.row, origin.column - 1);
                Piece R = board.removePiece(originR);
                R.incrementMoves();
                board.placePiece(R, destinationR);
            }

            return capturedPiece;
        }

        public void undoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece p = board.removePiece(destination);
            p.decrementMoves();
            if(capturedPiece != null)
            {
                board.placePiece(capturedPiece, destination);
                captured.Remove(capturedPiece);
            }
            board.placePiece(p, origin);

            // # Short Castle
            if (p is King && destination.column == origin.column + 2)
            {
                Position originR = new Position(origin.row, origin.column + 3);
                Position destinationR = new Position(origin.row, origin.column + 1);
                Piece R = board.removePiece(destinationR);
                R.decrementMoves();
                board.placePiece(R, originR);
            }

            // # Long Castle
            if (p is King && destination.column == origin.column - 2)
            {
                Position originR = new Position(origin.row, origin.column - 4);
                Position destinationR = new Position(origin.row, origin.column - 1);
                Piece R = board.removePiece(destinationR);
                R.decrementMoves();
                board.placePiece(R, originR);
            }
        }

        public void makePlay(Position origin, Position destination)
        {
            Piece capturedPiece = executeMove(origin, destination);

            if (isInCheck(currentPlayer))
            {
                undoMove(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            if (isInCheck(oponent(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (testCheckMate(oponent(currentPlayer)))
            {
                finished = true;
            }
            else
            {
                turn++;
                changePlayer();
            }
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

        private Color oponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }
        private Piece king (Color color)
        {
            foreach (Piece x in piecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool isInCheck(Color color)
        {
            foreach(Piece x in piecesInGame(oponent(color)))
            {
                Piece K = king(color);
                if (K == null)
                {
                    throw new BoardException("There is no king of color " + color + " on the board!");
                }

                bool[,] mat = x.possibleMoves();
                if (mat[K.position.row, K.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testCheckMate(Color color)
        {
            if (!isInCheck(color))
            {
                return false;
            }
            foreach(Piece x in piecesInGame(color))
            {
                bool[,] mat = x.possibleMoves();
                for(int i = 0; i < board.rows; i++)
                {
                    for(int j = 0; j < board.columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = executeMove(origin, destination);
                            bool checkTest = isInCheck(color);
                            undoMove(origin, destination, capturedPiece);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }   

        public void placeNewPiece(char column, int row, Piece p)
        {
            board.placePiece(p, new ChessPosition(column, row).toPosition());
            pieces.Add(p);
        }

        private void placePieces()
        {
            placeNewPiece('a', 1, new Rook(board, Color.White));
            placeNewPiece('b', 1, new Horse(board, Color.White));
            placeNewPiece('c', 1, new Bishop(board, Color.White));
            placeNewPiece('d', 1, new Queen(board, Color.White));
            placeNewPiece('e', 1, new King(board, Color.White, this));
            placeNewPiece('f', 1, new Bishop(board, Color.White));
            placeNewPiece('g', 1, new Horse(board, Color.White));
            placeNewPiece('h', 1, new Rook(board, Color.White));
            placeNewPiece('a', 2, new Pawn(board, Color.White));
            placeNewPiece('b', 2, new Pawn(board, Color.White));
            placeNewPiece('c', 2, new Pawn(board, Color.White));
            placeNewPiece('d', 2, new Pawn(board, Color.White));
            placeNewPiece('e', 2, new Pawn(board, Color.White));
            placeNewPiece('f', 2, new Pawn(board, Color.White));
            placeNewPiece('g', 2, new Pawn(board, Color.White));
            placeNewPiece('h', 2, new Pawn(board, Color.White));

            placeNewPiece('a', 8, new Rook(board, Color.Black));
            placeNewPiece('b', 8, new Horse(board, Color.Black));
            placeNewPiece('c', 8, new Bishop(board, Color.Black));
            placeNewPiece('d', 8, new Queen(board, Color.Black));
            placeNewPiece('e', 8, new King(board, Color.Black, this));

            placeNewPiece('h', 8, new Rook(board, Color.Black));
            placeNewPiece('a', 7, new Pawn(board, Color.Black));
            placeNewPiece('b', 7, new Pawn(board, Color.Black));
            placeNewPiece('c', 7, new Pawn(board, Color.Black));
            placeNewPiece('d', 7, new Pawn(board, Color.Black));
            placeNewPiece('e', 7, new Pawn(board, Color.Black));
            placeNewPiece('f', 7, new Pawn(board, Color.Black));
            placeNewPiece('g', 7, new Pawn(board, Color.Black));
            placeNewPiece('h', 7, new Pawn(board, Color.Black));
        }
    }
}