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
        public override Vector2 Position { get; set; }
        public InfoWall Info;
        public override float Radius
        {
            get { return Info.HeightTexture / 2; }
        }
        public override Vector2 PositionCenter
        {
            get { return Position+Origin; }
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
            spriteBatch.Draw(Info.Texture, Position, null, Color.White, Info.Rotation, Origin, Info.Scale, SpriteEffects.None, 0f);
        }
    }
}
