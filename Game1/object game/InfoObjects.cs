using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class InfoBall
    {
        public Texture2D Texture { get; set; }
        public float scale { get; set; }
        public float HeightTexture {get; set;}
        public float WidthTexture { get; set;}
    }
    class InfoWall
    {
        public Texture2D Texture { get; set; }
        public float HeightTexture { get; set; }
        public float WidthTexture { get; set; }
        public float Rotation { get; set; }
    }
}
