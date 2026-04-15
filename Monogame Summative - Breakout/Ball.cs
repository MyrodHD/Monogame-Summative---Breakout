using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public void Update()
        {

            _ballRect.X += (int)_ballVelocity.X;
            _ballRect.Y += (int)_ballVelocity.Y;

            if (_ballRect.Y >= 475)
                _ballVelocity.Y *= -1;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _ballRect, Color.White);
        }

    }
}
