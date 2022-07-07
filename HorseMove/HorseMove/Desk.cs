namespace HorseMove
{
    public class Desk
    {
        private readonly int _size;

        private int _startX;
        private int _startY;

        private List<List<string>> _board = new List<List<string>>();
        public List<List<int>> visitedCoords = new List<List<int>>();

        public int turnCount;

        public int Size => _size;
        public int StartX => _startX;
        public int StartY => _startY;

        public Desk(int size)
        {
            _size = size;
            turnCount = 0;

            FillDesk();
        }

        public Desk(Desk desk, int currentX, int currentY)
        {
            _size = desk._size;

            var tempList = new List<List<int>>(desk.visitedCoords);
            visitedCoords = tempList;

            turnCount = desk.turnCount;

            FillDesk();

            CopyBoards(desk);

            _board[currentX][currentY] = $"{turnCount}";
            _startX = currentX;
            _startY = currentY;
        }

        private void CopyBoards(Desk desk)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _board[i][j] = desk._board[i][j];
                }
            }
        }

        private void FillDesk()
        {
            for (int i = 0; i < _size; i++)
            {
                var row = new List<string>();

                for (int j = 0; j < _size; j++)
                {
                    row.Add("0");
                }

                _board.Add(row);
            }
        }

        public void SetStartPosition(int x, int y)
        {
            _board[x][y] = "X";
            _startX = x;
            _startY = y;
        }

        public void PrintDesk()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write($"{_board[i][j], 2}" + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
