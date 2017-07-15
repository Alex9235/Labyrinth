using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
   public class InfoMap
    {
        public Texture2D Texture { get; set; }
        public float HeightTexture { get; set; }
        public float WidthTexture { get; set; }
        public Vector2 Position { get; set; }
    }
    class InfoBall
    {
        public Texture2D Texture { get; set; }
        public float Scale { get; set; }
        public float HeightTexture {get; set;}
        public float WidthTexture { get; set;}
    }
    class InfoWall
    {
        public float HeightTexture { get; set; }
        public float WidthTexture { get; set; }
        public Vector2 Position { get; set; }
    }
    class InfoKey
    {
        public Texture2D Texture { get; set; }
        public float HeightTexture { get; set; }
        public float WidthTexture { get; set; }
        public float Scale { get; set; }
    }
}
