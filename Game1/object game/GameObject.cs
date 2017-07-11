using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public abstract class GameObject
    {
        public abstract Vector2 Position { get; set; }
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract float Radius { get; }
        public virtual Vector2 StartPosition { get; set; }
        protected abstract Vector2 Origin { get;  }
    }
}
