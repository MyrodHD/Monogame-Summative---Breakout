using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Data;

namespace Monogame_Summative___Breakout
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        Rectangle window;
        Texture2D paddleTexture;
        Texture2D ballTexture;
        Texture2D brickTexture;

        List<Brick> bricks = new List<Brick>();
        Ball ball;
        Paddle paddle;

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0,0,700,500);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            base.Initialize();

            paddle = new Paddle(new Rectangle(275, 475, 100, 20), paddleTexture);
            ball = new Ball(new Rectangle(310, 400, 15, 15), ballTexture, new Vector2(0, 2));

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 10; c++)
                {
                    int x = 20 + c * (60 + 7);
                    int y = 30 + r * (20 + 7);

                    Rectangle rect = new Rectangle(x, y, 60, 20);

                    bricks.Add(new Brick(brickTexture, rect, Color.Red));
                }
            }

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            paddleTexture = Content.Load<Texture2D>("Images/paddle");
            ballTexture = Content.Load<Texture2D>("Images/circle");
            brickTexture = Content.Load<Texture2D>("Images/rectangle");
        }

        protected override void Update(GameTime gameTime)
        {
            ball.Update();

            paddle.Update(Keyboard.GetState());

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            for (int i = bricks.Count - 1; i >= 0; i--)
            {

                if (ball.Rect.Intersects(bricks[i].Rect))
                {
                    ball.Bounce(false);
                    bricks.RemoveAt(i);
                    break;
                }

                if (ball.Rect.Intersects(paddle.Rect))
                {
                    ball.Bounce(false);
                }

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            paddle.Draw(_spriteBatch);

            ball.Draw(_spriteBatch);

            foreach (Brick b in bricks)
            {
                b.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
