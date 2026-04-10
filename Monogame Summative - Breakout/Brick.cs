using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Summative___Breakout
{
    public class Brick
    {

        private Rectangle _brickRect;
        private Texture2D _texture;
        private Color _tint;
        private bool _isVisible;

        public Brick (Texture2D texture, Rectangle brickRect, Color color)
        {
            _brickRect = brickRect;
            _texture = texture;
            _tint = color;
            _isVisible = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_isVisible)
                spriteBatch.Draw(_texture,_brickRect, _tint);
        }
    }
}
