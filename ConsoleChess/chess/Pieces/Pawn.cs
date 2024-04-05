using board;
using System.Security.Cryptography.X509Certificates;

namespace chess.pieces
{
    class Pawn : Piece
    {
        private ChessMatch match;
        public Pawn(Board board, Color color, ChessMatch match) : base(board, color) 
        {
            this.match = match;
        }
        public override string ToString()
        {
            return "P";
        }
        public bool isThereAnEnemy(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }
        private bool isFree(Position pos)
        {
            return board.piece(pos) == null;
        }
        public override bool[,]possibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];
            Position pos = new Position(0, 0);

            if (color == Color.White)
            {
                pos.defineValues(position.row - 1, position.column);
                if (board.validPosition(pos) && isFree(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.defineValues(position.row - 2, position.column);
                Position p2 = new Position(position.row - 1, position.column);
                if (board.validPosition(p2) && isFree(p2) && board.validPosition(pos) && isFree(pos) && moves == 0)
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.defineValues(position.row - 1, position.column - 1);
                if (board.validPosition(pos) && isThereAnEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.defineValues(position.row - 1, position.column + 1);
                if (board.validPosition(pos) && isThereAnEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                // # En Passant
                if (position.row == 3)
                {
                    Position left = new Position(position.row, position.column - 1);
                    if(board.validPosition(left) && isThereAnEnemy(left) && board.piece(left) == match.vulnerableEnPassant)
                    {
                        mat[left.row - 1, left.column] = true;
                    }
                    Position right = new Position(position.row, position.column + 1);
                    if(board.validPosition(right) && isThereAnEnemy(right) && board.piece(right) == match.vulnerableEnPassant)
                    {
                        mat[right.row - 1, right.column] = true;
                    }
                }
            }
            else
            {
                pos.defineValues(position.row + 1, position.column);
                if (board.validPosition(pos) && isFree(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.defineValues(position.row + 2, position.column);
                Position p2 = new Position(position.row + 1, position.column);
                if (board.validPosition(p2) && isFree(p2) && board.validPosition(pos) && isFree(pos) && moves == 0)
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.defineValues(position.row + 1, position.column - 1);
                if (board.validPosition(pos) && isThereAnEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }
                pos.defineValues(position.row + 1, position.column + 1);
                if (board.validPosition(pos) && isThereAnEnemy(pos))
                {
                    mat[pos.row, pos.column] = true;
                }

                // # En Passant
                if (position.row == 4)
                {
                    Position left = new Position(position.row, position.column - 1);
                    if (board.validPosition(left) && isThereAnEnemy(left) && board.piece(left) == match.vulnerableEnPassant)
                    {
                        mat[left.row + 1, left.column] = true;
                    }
                    Position right = new Position(position.row, position.column + 1);
                    if (board.validPosition(right) && isThereAnEnemy(right) && board.piece(right) == match.vulnerableEnPassant)
                    {
                        mat[right.row + 1, right.column] = true;
                    }
                }

            }
            return mat;
        }
    }
}
