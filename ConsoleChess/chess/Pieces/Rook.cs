using board;

namespace chess.pieces
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "R";
        }

        private bool canMove(Position position)
        {
            Piece p = board.piece(position);
            return p == null || p.color != this.color;
        }
        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];
            Position pos = new Position(0, 0);

            //above
            pos.defineValues(position.row - 1, position.column);
            while(board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.row = pos.row - 1;
            }

            //below
            pos.defineValues(position.row + 1, position.column);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.row = pos.row + 1;
            }

            //right
            pos.defineValues(position.row, position.column + 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }

            //left
            pos.defineValues(position.row, position.column - 1);
            while (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != this.color)
                {
                    break;
                }
                pos.column = pos.column - 1;
            }
            return mat;
        }

    }
}