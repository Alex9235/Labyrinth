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
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            map = new Map1(Content);
            Ball = new Ball(Content)
            {
                StartPosition = map.StartPositionBall,
            };

            
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
            Ball.Position += new Vector2(0.05f, -0.05f) * gameTime.ElapsedGameTime.Milliseconds;

            map.Update(gameTime,Ball);

            if (map.Hascollisions(Ball))
            {
                map.StartPositionObjectsofMap();
                Ball.Position = map.StartPositionBall;
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            map.Draw(spriteBatch);
            Ball.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}