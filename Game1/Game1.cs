using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private List<GameObject> objects = new List<GameObject>();
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
                WidthTexture =512,
            };
            
            objects.Add(new Balls(Ballinfo)
            {
                Position = new Vector2(50, 50),
            });
            objects.Add(new Balls(Ballinfo)
            {
                Position = new Vector2(50, 200),
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
            objects[0].Position += new Vector2(0.1f, 0) * gameTime.ElapsedGameTime.Milliseconds;
            objects[1].Position += new Vector2(0.1f, -0.05f) * gameTime.ElapsedGameTime.Milliseconds;

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
        public bool Hascollisions(GameObject gameObject)
        {
            return true;
        }
    }
}
