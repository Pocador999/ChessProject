using board;

namespace chess.pieces
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color) { }
        public override string ToString()
        {
            return "K";
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
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            //northeast
            pos.defineValues(position.row - 1, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            //right
            pos.defineValues(position.row, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            //southeast
            pos.defineValues(position.row + 1, position.column + 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            //below
            pos.defineValues(position.row + 1, position.column);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            //southwest
            pos.defineValues(position.row + 1, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            //left
            pos.defineValues(position.row, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            //northwest
            pos.defineValues(position.row - 1, position.column - 1);
            if (board.validPosition(pos) && canMove(pos))
            {
                mat[pos.row, pos.column] = true;
            }
            return mat;
        }   
    }
}