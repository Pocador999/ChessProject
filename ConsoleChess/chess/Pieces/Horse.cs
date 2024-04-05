using board;

namespace chess.pieces
{
    class Horse : Piece
    {
        public Horse (Board board, Color color) : base(board, color){ }
        public override string ToString()
        {
            return "H";
        }
        private bool canMove(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }
        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.rows, board.columns];
            Position pos = new Position(0, 0);

            pos.defineValues(position.row - 1, position.column - 2);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row - 2, position.column - 1);
            if(board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row - 2, position.column + 1);
            if(board.validPosition(pos) && canMove(pos))
            {
                    mat[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row - 1, position.column + 2);
            if(board.validPosition(pos) && canMove(pos))
            {
                    mat[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row + 1, position.column + 2);
            if(board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row + 2, position.column + 1);
            if(board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row + 2, position.column - 1);
            if(board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }

            pos.defineValues(position.row + 1, position.column - 2);
            if(board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            return mat;
        }
       
    }
}
