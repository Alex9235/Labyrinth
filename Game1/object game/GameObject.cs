using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Labyrinth
{
    public abstract class GameObject
    {
        public virtual Vector2 Position { get; set; }
        public abstract void Draw(SpriteBatch spriteBatch);
        protected abstract Vector2 Origin { get;  }
    }
}
