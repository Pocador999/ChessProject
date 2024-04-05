using board;

namespace chess.pieces
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color) { }
        public override string ToString()
        {
            return "B";
        }

        private bool canMove(Position position)
        {
            Piece p = board.piece(position);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];
            Position pos = new Position(0, 0);

            //northeast
            pos.defineValues(position.row - 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.defineValues(pos.row - 1, pos.column + 1);
            }

            //southeast
            pos.defineValues(position.row + 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.defineValues(pos.row + 1, pos.column + 1);
            }

            //southwest
            pos.defineValues(position.row + 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.defineValues(pos.row + 1, pos.column - 1);
            }

            //northwest
            pos.defineValues(position.row - 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.defineValues(pos.row - 1, pos.column - 1);
            }

            return mat;
        }   
    }
}
