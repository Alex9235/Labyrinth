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
    class Balls : RoundObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }


        public override float Radius
        {
            get { return info.WidthTexture * info.scale / 2;}
        }

        public override Vector2 PositionCenter
        {
            get { return Position; }
        }


        //private float speed;
        InfoBall info;
        
        public Balls(InfoBall info)
        {
            this.info = info;
            Origin = new Vector2(info.WidthTexture / 2f, info.WidthTexture / 2f);
        }
        public void Update(GameTime gameTime)
        {
            
        }
        public void Draw(SpriteBatch spriteBatch )
        {
            spriteBatch.Draw(info.Texture,Position, null, Color.White, 0f, Origin, info.scale, SpriteEffects.None, 0f);
        }
    }
}
