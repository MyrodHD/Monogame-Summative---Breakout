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
    public class Paddle
    {
        private Texture2D _texture;
        private Rectangle _rect;
        private Rectangle _window;
        private Vector2 _speed;
        public KeyboardState _keyboardState;

        public Paddle(Texture2D texture2D, Rectangle rect, Rectangle window)
        {
            _texture = texture2D;
            _rect = rect;
            _window = window;
            _speed = Vector2.Zero;
        }

        public void Update(GameTime gameTime)
        {
            _keyboardState = Keyboard.GetState();

            if (_keyboardState.IsKeyDown(Keys.Left))
                _speed.X -= -1;
            if (_keyboardState.IsKeyDown(Keys.Right))
                _speed.X += 1;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _speed, _rect, Color.White);

        }


    }
}
