using board;

namespace chess
{
    class ChessPosition (char column, int row)
    {
        public char column { get; set; } = column;
        public int row { get; set; } = row;

        public Position toPosition()
        {
            return new Position(8 - row, column - 'a');
        }
        public override string ToString()
        {
            return "" + column + row;
        }
    }
}
