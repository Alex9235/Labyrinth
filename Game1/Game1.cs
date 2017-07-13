using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameObject Ball;
        private Map1 map;
        private float Speed;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.Title = string.Format("{0} * {1}", Window.ClientBounds.Width, Window.ClientBounds.Height);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            map = new Map1(Content);
            Ball = new Ball(Content, map.StartPositionBall);
            Speed = map.SpeedBall;
            
            // TODO: use this.Content to load your game content here
        }
        protected override void UnloadContent()
        {
            
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            map.Update(gameTime);
            if (!map.CollisionsWithFinish(Ball))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    Ball.Position += new Vector2(0, Speed) * gameTime.ElapsedGameTime.Milliseconds;
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    Ball.Position += new Vector2(0, -Speed) * gameTime.ElapsedGameTime.Milliseconds;
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    Ball.Position += new Vector2(-Speed, 0) * gameTime.ElapsedGameTime.Milliseconds;
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    Ball.Position += new Vector2(Speed, 0) * gameTime.ElapsedGameTime.Milliseconds;
                if (true)
                {
                    if (map.Hascollisions(Ball))
                    {
                        map.StartPositionObjectsofMap();
                        Ball.Position = map.StartPositionBall;
                    }
                }
            }    
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0,163,232));
            spriteBatch.Begin();
            map.Draw(spriteBatch);
            Ball.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}