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
            get { return new Vector2(Info.WidthTexture/2f, Info.HeightTexture/2f); }
        }
        public override Vector2 StartPosition { get; set; } 
        InfoBall Info;

        public override float Radius
        {
            get { return Info.WidthTexture * Info.scale / 2f;}
        }


        public Ball(ContentManager Content, Vector2 StartPosition)
        {
            Info = new InfoBall
            {
                Texture = Content.Load<Texture2D>("redball"),
                WidthTexture = 512f,
                HeightTexture = 512f,
                scale = 0.08f,
            };
            this.StartPosition = StartPosition;
            Position = this.StartPosition; 
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
