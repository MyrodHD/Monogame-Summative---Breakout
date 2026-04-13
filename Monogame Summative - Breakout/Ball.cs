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

        public Ball(Rectangle ballRect, Texture2D texture, Vector2 velocity)
        {
            _ballRect = ballRect;
            _texture = texture;
            _ballVelocity = velocity;
        }

        public void Update()
        {
            _ballRect.X += (int)_ballVelocity.X;
            _ballRect.Y += (int)_ballVelocity.Y;

            if (_ballRect.X <= 0 || _ballRect.X + _ballRect.Width >= 800)
                _ballVelocity.X *= -1;
            
            if (_ballRect.Y <= 0)
                _ballVelocity.Y *= -1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _ballRect, Color.White);
        }

    }
}
