using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public abstract class RoundObject: GameObject
    {
        public virtual Vector2 StartPosition { get; set; }
        public abstract float Radius { get; }
    }
}
