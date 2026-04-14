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
            window = new Rectangle(0,0,800,600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            

            base.Initialize();

            paddle = new Paddle(new Rectangle(350, 500, 100, 20), paddleTexture);
            ball = new Ball(new Rectangle(400, 400, 15, 15), ballTexture, new Vector2(0, 3));

            for (int col = 0; col < 10; col++)
            {  
               for (int row = 0; row < 10; row++)
               {
                 
                  bricks.Add(new Brick(brickTexture, new Rectangle(col * 75 + 50, row * 55 + 50, 80, 50), Color.White));

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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            paddle.Draw(_spriteBatch);

            ball.Draw(_spriteBatch);

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    bricks[row].Draw(_spriteBatch);
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
