namespace HorseMove
{
    public class Horse
    {
        private int _startX;
        private int _startY;

        private readonly int[] _possibleXTurns = new int[] { 2, 2, -2, -2, 1, 1, -1, -1 };
        private readonly int[] _possibleYTurns = new int[] { -1, 1, 1, -1, 2, -2, 2, -2 };

        private List<Desk> _tempDesks = new List<Desk>();       

        public Horse(int startX, int startY, Desk desk)
        {
            _startX = startX;
            _startY = startY;
            desk.SetStartPosition(startX, startY);
        }   

        private bool isNotVisited(int currentX, int currentY, Desk desk)
        {
            foreach (var elem in desk.visitedCoords)
            {
                if ((elem[0] == currentX) & (elem[1] == currentY)) {
                    return false;
                }
            }

            return (currentX == _startX) & (currentY == _startY) ? false : true;
        }

        private bool isValidTurn(int currentX, int currentY, Desk desk)
        {
            return (currentX >= 0 && currentX < desk.Size) && (currentY >= 0 && currentY < desk.Size) && isNotVisited(currentX, currentY, desk);
        }

        private bool isEnd(int currentX, int currentY, int endX, int endY)
        {
            return (currentX == endX) && (currentY == endY);
        }

        private static void AddToVisitedCords(int a, int b, List<List<int>> list)
        {
            var row = new List<int>();

            row.Add(a);
            row.Add(b);

            list.Add(row);
        }

        public List<Desk> FindPossibleMoves(int endX, int endY, Desk startDesk, int numberOfOptions)
        {
            var _completedDesks = new List<Desk>();

            var queue = new Queue<Desk>();
            queue.Enqueue(startDesk);

            while ((queue.Count != 0) && (_completedDesks.Count < numberOfOptions))
            {
                Desk desk = queue.Dequeue();
                desk.turnCount++;

                int currentX = desk.StartX;
                int currentY = desk.StartY;         

                if (!_tempDesks.Contains(desk))
                {
                    _tempDesks.Add(desk);

                    for (int i = 0; i < _possibleXTurns.Length; i++)
                    {
                        int dx = currentX + _possibleXTurns[i];
                        int dy = currentY + _possibleYTurns[i];

                        if (isValidTurn(dx, dy, desk))
                        {
                            AddToVisitedCords(dx, dy, desk.visitedCoords);

                            if (isEnd(dx, dy, endX, endY))
                            {
                                _completedDesks.Add(new Desk(desk, dx, dy));
                            } 
                            else
                            {
                                queue.Enqueue(new Desk(desk, dx, dy));
                            }
                        }
                    }
                }

            }

            return _completedDesks;
        }

    }
}