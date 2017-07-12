using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Map1
    {
        public Vector2 StartPositionBall
        {
            get { return new Vector2(50f, 150f); }
        }
        public float SpeedBall
        {
            get { return 0.2f; }
        }
        InfoWall infoWallR0;
        InfoWall infoWallR90;
        private List<GameObject> objects= new List<GameObject>();
        public Map1(ContentManager content)
        {
            infoWallR0 = new InfoWall()
            {
                Texture = content.Load<Texture2D>("Wall_256"),
                HeightTexture = 8f,
                WidthTexture = 256f,
                Rotation = 0f,
            };
            infoWallR90 = new InfoWall()
            {
                Texture = content.Load<Texture2D>("Wall_128"),
                HeightTexture = 8f,
                WidthTexture = 128f,
                Rotation = 1.57f,
            };
            objects.Add(new Wall(infoWallR0)
            {
                Position = new Vector2(128f, 100f),
            });
            objects.Add(new Wall(infoWallR0)
            {
                Position = new Vector2(384f, 100f),
            });
            objects.Add(new Wall(infoWallR90)
            {
                Position = new Vector2(516f, 160f),
            });
            objects.Add(new Wall(infoWallR0)
            {
                Position = new Vector2(128f, 200f),
            });
            objects.Add(new Wall(infoWallR0)
            {
                Position = new Vector2(128f, 200f),
            });
        }
        public void Update(GameTime gameTime)
        {
            //objects[0].Position += new Vector2(0.05f, 0) * gameTime.ElapsedGameTime.Milliseconds;
        }
        public void StartPositionObjectsofMap()
        {
            foreach (RoundObject obj in objects.OfType<RoundObject>())
                obj.Position = obj.StartPosition;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GameObject obj in objects)
                obj.Draw(spriteBatch);
        }
        public bool Hascollisions(GameObject obj)
        {
            if (obj is RoundObject)
                if (Hascollisions((RoundObject)obj))
                    return true;
            if (obj is SquareObject)
                if (Hascollisions((SquareObject)obj))
                    return true;
            return false;
        }
        public bool Hascollisions(RoundObject obj)
        {
            foreach (RoundObject Obj in objects.OfType<RoundObject>())
            {
                if (obj != Obj)
                {
                    if (Vector2.Distance(Obj.Position, obj.Position) < (Obj.Radius + obj.Radius))
                        return true;
                }
            }
            foreach(SquareObject Obj in objects.OfType<SquareObject>())
            {
                if (Math.Abs(Obj.Info.Position.Y - obj.Position.Y) <= Obj.RadiusHeight + obj.Radius)
                {
                    if (Math.Abs(Obj.Info.Position.X - obj.Position.X) <= Obj.RadiusWidth + obj.Radius)
                        return true;
                }
            }
            return false;
        }
        
    }
}
