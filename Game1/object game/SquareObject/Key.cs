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
    class Key : SquareObject
    {

        public override InfoKey IK { get; }
        public override Vector2 Position { get; set; }

        public Key(ContentManager Content, float X, float Y)
        {
            IK = new InfoKey()
            {
                Texture = Content.Load<Texture2D>("Key"),
                WidthTexture = 171f,
                HeightTexture = 363f,
                Scale = 0.1f,
            };
            Position = new Vector2(X, Y);
        }

        public override float RadiusWidth
        {
            get { return IK.WidthTexture / 2f; }
        }

        public override float RadiusHeight
        {
            get { return IK.HeightTexture / 2f; }
        }

        protected override Vector2 Origin
        {
            get { return new Vector2(IK.WidthTexture / 2f, IK.HeightTexture / 2f); }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(IK.Texture, Position, null, Color.White, 0f, Origin, IK.Scale, SpriteEffects.None, 0f);
        }
    }
}
