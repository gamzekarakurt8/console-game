using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mygame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int windowHeight = 20;
            int windowWidth = 40;
            int gameSpeed = 100;

            Game game = new Game(windowHeight, windowWidth, gameSpeed);

            while (true)
            {
                game.Update();
                game.Draw();
                Thread.Sleep(gameSpeed);
            }

            Console.ReadLine();

        }
    }
 }

