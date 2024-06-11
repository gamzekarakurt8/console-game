using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mygame
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(Paddle paddle) : base(paddle) { }

        public override void Control()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.W)
                {
                    Paddle.MoveUp();
                }
                if (key.Key == ConsoleKey.S)
                {
                    Paddle.MoveDown(Console.WindowHeight -1);
                }
            }
        }
    }
}
