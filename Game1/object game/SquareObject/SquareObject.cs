using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Labyrinth
{
    abstract class SquareObject : GameObject
    {
        public virtual InfoWall IW { get; }
        public virtual InfoKey IK { get; }
        public abstract float RadiusWidth { get; }
        public abstract float RadiusHeight { get; }
    }
}
