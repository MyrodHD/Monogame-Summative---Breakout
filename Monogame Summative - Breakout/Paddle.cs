using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Summative___Breakout
{
    public class Paddle
    {
        public Rectangle _paddleRect;
        private Texture2D _texture;
        private float _speed = 10f;

        public Rectangle Rect => _paddleRect;

        public Paddle(Rectangle paddleRect, Texture2D texture)
        {
            _paddleRect = paddleRect;
            _texture = texture;
        }

        public void Update(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Left) && _paddleRect.X > 0)
            {
                _paddleRect.X -= (int)_speed;
            }
            if (keyboardState.IsKeyDown(Keys.Right) && _paddleRect.Right < 700)
            {
                _paddleRect.X += (int)_speed;
            }
        }

        public bool Intersects(Rectangle rect)
        {
            return _paddleRect.Intersects(rect);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _paddleRect, Color.White); 
        }

    }
}
