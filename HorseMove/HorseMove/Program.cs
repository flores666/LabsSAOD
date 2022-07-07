namespace HorseMove
{
    public class Program
    {
        public static void Main()
        {
            var desk = new Desk(size:8);
            var horse = new Horse(startX:0, startY:0, desk);
            var desks = new List<Desk>();

            desks = horse.FindPossibleMoves(endX:7, endY:7, desk, numberOfOptions:15);

            Console.WriteLine();

            var count = 0;
            foreach (var elem in desks)
            {
                count++;
                elem.PrintDesk();
                Console.WriteLine();
            }

            Console.WriteLine($"Number of options: {count}");
        }
    }
}