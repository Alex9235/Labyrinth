using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Labyrinth
{
    class Wall : SquareObject
    {
        
        public override InfoWall IW { get; }

        public override float RadiusWidth 
        {
            get { return IW.WidthTexture / 2f; }
        }

        public override float RadiusHeight
        {
            get { return IW.HeightTexture / 2f; }
        }

        protected override Vector2 Origin
        {
            get { return new Vector2(IW.WidthTexture / 2f, IW.HeightTexture / 2f); }
        }

        public Wall(InfoWall Info)
        {
            IW = Info;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
