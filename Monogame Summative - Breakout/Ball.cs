using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Summative___Breakout
{
    public class Ball
    {
        private Rectangle _ballRect;
        private Vector2 _ballVelocity;
        private Texture2D _texture;

        public Rectangle Rect => _ballRect;

        public bool _isMoving { get; set; } = false;

        public Ball(Rectangle ballRect, Texture2D texture, Vector2 velocity)
        {
            _ballRect = ballRect;
            _texture = texture;
            _ballVelocity = velocity;
        }

        public void Bounce(bool horizontal)
        {
            if (horizontal)
                _ballVelocity.X *= -1;
            else 
                _ballVelocity.Y *= -1;
        }

        public void Update(Paddle paddle)
        {
            if (_isMoving)
                _ballRect.X += (int)_ballVelocity.X;

            if (paddle.Intersects(_ballRect))
            {

                _ballVelocity.Y = -Math.Abs(_ballVelocity.Y);

                _ballRect.Y = paddle._paddleRect.Top - _ballRect.Height;

                float paddleCentre = paddle._paddleRect.X + (paddle._paddleRect.Width / 2f);
                float ballCentre = _ballRect.X + (_ballRect.Width / 2f);

                float relativeIntresect = (ballCentre - paddleCentre) / (paddle._paddleRect.Width / 2f);

                _ballVelocity.X = relativeIntresect * 3;

                if (relativeIntresect == 0 || _ballVelocity.X == 0)
                {
                    _ballVelocity.X += 1;
                    _ballVelocity.X *= -1;
                }

            }

            if (_isMoving)
                _ballRect.Y += (int)_ballVelocity.Y;

            if (!_isMoving)
            {
                _ballRect.X = paddle._paddleRect.X + (paddle._paddleRect.Width / 2) - (_ballRect.Width / 2);

                _ballRect.Y = paddle._paddleRect.Y - _ballRect.Height;

                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    _isMoving = true;
                    
                    _ballVelocity.X += 2;

                    if(_ballRect.X > 350)
                        _ballVelocity.X *= 1;
                    else if (_ballRect.X < 350)
                        _ballVelocity.X *= -1;
                        
                    _ballVelocity.Y *= -1;

                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _ballRect, Color.White);
        }

    }
}
