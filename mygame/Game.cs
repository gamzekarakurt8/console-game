using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mygame
{
    public class Game
    {
        public int WindowHeight { get; }
        public int WindowWidth { get; }
        public int GameSpeed { get; }

        private Ball _ball;
        private Player _playerLeft;
        private Player _playerRight;

        public Game(int windowHeight, int windowWidth, int gameSpeed)
        {
            WindowHeight = windowHeight;
            WindowWidth = windowWidth;
            GameSpeed = gameSpeed;

            InitializeGame();
        }

        public void InitializeGame()
        {
            var paddleLeft = new Paddle(0, WindowHeight / 2 - 2, 4, 1);
            var paddleRight = new Paddle(WindowWidth - 1, WindowHeight / 2 - 2, 4, 1);
            _ball = new Ball(WindowWidth / 2, WindowHeight / 2, 1, 1);

            _playerLeft = new HumanPlayer(paddleLeft);
            _playerRight = new AIPlayer(paddleRight, _ball, WindowWidth, WindowHeight);
        }

        public void Update()
        {
            _ball.PositionX += _ball.DirectionX;
            _ball.PositionY += _ball.DirectionY;

            if (_ball.PositionY == 0 || _ball.PositionY == WindowHeight - 1)
            {
                _ball.DirectionY = -_ball.DirectionY;
            }

            if (_ball.PositionX == 0)
            {
                _playerRight.UpdateScore();
                ResetBall();
            }
            else if (_ball.PositionX == WindowWidth - 1)
            {
                _playerLeft.UpdateScore();
                ResetBall();
            }

            if ((_ball.PositionX == 1 && _ball.PositionY >= _playerLeft.Paddle.PositionY && _ball.PositionY < _playerLeft.Paddle.PositionY + _playerLeft.Paddle.Height) ||
                (_ball.PositionX == WindowWidth - 2 && _ball.PositionY >= _playerRight.Paddle.PositionY && _ball.PositionY < _playerRight.Paddle.PositionY + _playerRight.Paddle.Height))
            {
                _ball.DirectionX = -_ball.DirectionX;
            }

            _playerLeft.Control();
            _playerRight.Control();
        }

        public void ResetBall()
        {
            _ball.PositionX = WindowWidth / 2;
            _ball.PositionY = WindowHeight / 2;
            _ball.DirectionX = -_ball.DirectionX;
        }

        public void Draw()
        {
            Console.Clear();

            for (int i = 0; i < WindowHeight - 1; i++) 
            {
                for (int j = 0; j < WindowWidth; j++)
                {
                    if ((j == 0 && i >= _playerLeft.Paddle.PositionY && i < _playerLeft.Paddle.PositionY + _playerLeft.Paddle.Height) ||
                        (j == WindowWidth - 1 && i >= _playerRight.Paddle.PositionY && i < _playerRight.Paddle.PositionY + _playerRight.Paddle.Height))
                    {
                        Console.Write("|");
                    }
                    else if (i == _ball.PositionY && j == _ball.PositionX)
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

           
            Console.SetCursorPosition(0, WindowHeight - 1); 
            Console.WriteLine($"Player Left: {_playerLeft.Score}\t\tPlayer Right: {_playerRight.Score}");

        }
    }
}
    
