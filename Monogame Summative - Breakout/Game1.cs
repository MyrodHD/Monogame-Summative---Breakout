using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;

namespace Monogame_Summative___Breakout
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public enum Screen
        {
            Intro,
            Main,
            Victory,
            Lost
        }

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

        KeyboardState keyboardState;
        KeyboardState previousState;

        Screen screen;

        int score;
        float time;

        SpriteFont scoreFont;

        Color color;

        Random generator;

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0,0,700,500);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            screen = Screen.Intro;

            score = 0;

            time = 0f;

            generator = new Random();



            base.Initialize();

            paddle = new Paddle(new Rectangle(275, 475, 100, 20), paddleTexture);
            ball = new Ball(new Rectangle(310, 450, 15, 15), ballTexture, new Vector2(0, 2));

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 10; c++)
                {

                    color = new Color(
                        generator.Next(0, 256),
                        generator.Next(0, 126),
                        generator.Next(0, 256)
                    );

                    int x = 20 + c * (60 + 7);
                    int y = 30 + r * (20 + 7);

                    Rectangle rect = new Rectangle(x, y, 60, 20);

                    bricks.Add(new Brick(brickTexture, rect, color));
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

            scoreFont = Content.Load<SpriteFont>("Font/ScoreFont");
        }

        protected override void Update(GameTime gameTime)
        {
            ball.Update(paddle);

            paddle.Update(Keyboard.GetState());

            keyboardState = Keyboard.GetState();
            previousState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (screen == Screen.Intro)
            {
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    screen = Screen.Main;
                }
            }

            if (screen == Screen.Main)
            {
                time -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                for (int i = bricks.Count - 1; i >= 0; i--)
                {

                    Rectangle overlap = Rectangle.Intersect(ball.Rect, bricks[i].Rect);

                    if (ball.Rect.Intersects(bricks[i].Rect))
                    {
                        Rectangle tempRect = ball.Rect;


                        if (overlap.Width < overlap.Height)
                        {
                            ball.Bounce(true);

                            if (ball.Rect.Center.X < bricks[i].Rect.Center.X)
                            {
                                tempRect.X -= overlap.Width;
                            }
                            else
                            {
                                tempRect.X += overlap.Width;
                            }
                        }
                        else
                        {
                            ball.Bounce(false);

                            if (ball.Rect.Center.Y < bricks[i].Rect.Center.Y)
                            {
                                tempRect.Y -= overlap.Height;
                            }
                            else
                            {
                                tempRect.Y += overlap.Height;
                            }
                        }

                        bricks.RemoveAt(i);
                        score += 10;
                        break;
                    }

                }

                if (ball.Rect.Intersects(paddle.Rect))
                    ball.Bounce(true);

                if (ball.Rect.Left <= 0 || ball.Rect.Right > _graphics.PreferredBackBufferWidth)
                    ball.Bounce(true);
                    

                if (ball.Rect.Top <= 0)
                    ball.Bounce(false);
                

                if (ball.Rect.Top >= 500)
                {
                    screen = Screen.Lost;
                }

                if (bricks.Count == 0)
                {
                    screen = Screen.Victory;
                }

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            if (screen == Screen.Main)
            {
                paddle.Draw(_spriteBatch);

                ball.Draw(_spriteBatch);

                foreach (Brick b in bricks)
                {
                    b.Draw(_spriteBatch);
                }

                _spriteBatch.DrawString(scoreFont, $"Points: {score}", new Vector2(25,10), Color.White);
                _spriteBatch.DrawString(scoreFont, (0 - time).ToString("0:00"), new Vector2(650, 10), Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
