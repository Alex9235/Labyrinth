using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Ball : RoundObject
    {
        public override Vector2 Position { get; set; }
        protected override Vector2 Origin
        {
            get { return new Vector2(Radius, Radius); }
        }
        public override Vector2 StartPosition { get; set; } 
        public override Vector2 PositionCenter
        {
            get { return Position+Origin; }
        }

        InfoBall Info;

        public override float Radius
        {
            get { return Info.WidthTexture * Info.scale / 2;}
        }


        public Ball(ContentManager Content)
        {
            Info = new InfoBall
            {
                Texture = Content.Load<Texture2D>("redball"),
                WidthTexture = 512f,
                HeightTexture = 512f,
                scale = 0.08f,
            };
            Position = StartPosition; 
        }
        public void Update(GameTime gameTime)
        {
            
        }
        public override void Draw(SpriteBatch spriteBatch )
        {
            spriteBatch.Draw(Info.Texture, Position, null, Color.White, 0f, Origin, Info.scale, SpriteEffects.None, 0f);
        }
    }
}
