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
        private List<GameObject> objects = new List<GameObject>();
        private List<Vector2> StartPositions = new List<Vector2>();
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
            var Ballinfo = new InfoBall
            {
                Texture = Content.Load<Texture2D>("redball"),
                scale = 0.08f,
                HeightTexture = 512,
                WidthTexture = 512,
            };
            StartPositions.Add(new Vector2(50, 50));
            StartPositions.Add(new Vector2(50, 200));
            objects.Add(new Balls(Ballinfo)
            {
                Position = StartPositions[0],
            });
            objects.Add(new Balls(Ballinfo)
            {
                Position = StartPositions[1],
            });
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
            
            objects[0].Position += new Vector2(0.05f, 0) * gameTime.ElapsedGameTime.Milliseconds;
            objects[1].Position += new Vector2(0.05f, -0.05f) * gameTime.ElapsedGameTime.Milliseconds;

            if (Hascollisions(objects[0]))
            {
                objects[0].Position = StartPositions[0];
                objects[1].Position = StartPositions[1];
            }


            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            objects[0].Draw(spriteBatch);
            objects[1].Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        public bool Hascollisions(GameObject obj)
        {
            if (obj is RoundObject)
                if(Hascollisions((RoundObject)obj))
                    return true;
            return false;
        }
        public bool Hascollisions(RoundObject obj)
        {
            foreach (RoundObject Obj in objects.OfType<RoundObject>())
            {
                if (obj != Obj)
                {
                    double a = Math.Sqrt((Obj.PositionCenter.X - obj.PositionCenter.X) * (Obj.PositionCenter.X - obj.PositionCenter.X) +
                    (Obj.PositionCenter.Y - obj.PositionCenter.Y) * (Obj.PositionCenter.Y - obj.PositionCenter.Y));
                    if (a < (Obj.Radius + obj.Radius))
                        return true;
                }
            }
            return false;
        }
    }
}