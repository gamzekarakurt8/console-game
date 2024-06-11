using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mygame
{
    public class AIPlayer : Player
    {
        private Ball _ball;
        private int _windowWidth;
        private int _windowHeight;

        public AIPlayer(Paddle paddle, Ball ball, int windowWidth, int windowHeight)
            : base(paddle)
        {
            _ball = ball;
            _windowWidth = windowWidth;
            _windowHeight = windowHeight;
        }

        public override async void Control()
        {
            await Task.Run(() =>
            {
                if (_ball.PositionX >= _windowWidth / 2 && _ball.DirectionX == 1)
                {
                    if (_ball.PositionY < Paddle.PositionY + Paddle.Height / 2 && Paddle.PositionY > 0)
                    {
                        Paddle.MoveUp();
                    }
                    else if (_ball.PositionY > Paddle.PositionY + Paddle.Height / 2 && Paddle.PositionY < _windowHeight - Paddle.Height)
                    {
                        Paddle.MoveDown(_windowHeight - 1);
                    }
                }
            });
        }
    }
}
