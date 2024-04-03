namespace board
{
    class Position (int row, int column)
    {
        public int row { get; set; } = row;
        public int column { get; set; } = column;

        public void defineValues(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public override string ToString()
        {
            return row + ", " + column;
        }
    }
}