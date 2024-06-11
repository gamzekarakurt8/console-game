using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mygame
{
    public abstract class GameObject
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public GameObject(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public abstract void Draw();
    }
}
