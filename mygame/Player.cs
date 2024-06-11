using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mygame
{
    public abstract class Player
    {
        public int Score { get; set; }
        public Paddle Paddle { get; }

        protected Player(Paddle paddle)
        {
            Paddle = paddle;
        }

        public abstract void Control();

        public virtual void UpdateScore()
        {
            Score++;
        }
    }
}
