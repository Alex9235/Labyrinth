using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game1
{
    class Wall : SquareObject
    {
        
        public override InfoWall Info { get; }
        public override float RadiusWidth 
        {
            get { return Info.WidthTexture / 2f; }
        }
        public override float RadiusHeight
        {
            get { return Info.HeightTexture / 2f; }
        }
        protected override Vector2 Origin
        {
            get { return new Vector2(Info.WidthTexture / 2f, Info.HeightTexture / 2f); }
        }

        public Wall(InfoWall Info)
        {
            this.Info = Info;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Info.Texture, Info.Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
