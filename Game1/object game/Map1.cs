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
            get { return new Vector2(28f, 204.5f); }
        }
        public float SpeedBall
        {
            get { return 0.05f; }//0.2f
        }
        private List<GameObject> StartFinish = new List<GameObject>();
        private List<GameObject> objects= new List<GameObject>();
        public Map1(ContentManager content)
        {
            objects.Add(new Wall(new InfoWall()
            {
                Texture = content.Load<Texture2D>("1"),
                WidthTexture = 8f,
                HeightTexture = 72f,
                Position = new Vector2(58f, 81f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                Texture = content.Load<Texture2D>("2"),
                WidthTexture = 8f,
                HeightTexture = 117f,
                Position = new Vector2(160f, 58f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                Texture = content.Load<Texture2D>("3"),
                WidthTexture = 168f,
                HeightTexture = 8f,
                Position = new Vector2(138f, 113f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                Texture = content.Load<Texture2D>("4"),
                WidthTexture = 8f,
                HeightTexture = 139f,
                Position = new Vector2(218f, 179f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                Texture = content.Load<Texture2D>("5"),
                WidthTexture = 164f,
                HeightTexture = 8f,
                Position = new Vector2(82f, 165f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                Texture = content.Load<Texture2D>("5"),
                WidthTexture = 164f,
                HeightTexture = 8f,
                Position = new Vector2(82f, 244f),
            }));
            StartFinish.Add(new Wall(new InfoWall()
            {
                Texture = content.Load<Texture2D>("6"),
                WidthTexture = 54f,
                HeightTexture = 71f,
                Position = StartPositionBall,
            }));

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
            foreach (GameObject obj in StartFinish)
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
                if (Math.Abs(Obj.Info.Position.Y - obj.Position.Y) <= Obj.RadiusHeight)
                {
                    if (Math.Abs(Obj.Info.Position.X - obj.Position.X) <= Obj.RadiusWidth + obj.Radius)
                        return true;
                }
                if (Math.Abs(Obj.Info.Position.Y - obj.Position.Y) <= Obj.RadiusHeight+obj.Radius)
                {
                    if (Math.Abs(Obj.Info.Position.X - obj.Position.X) <= Obj.RadiusWidth+
                        Math.Sqrt(obj.Radius*obj.Radius-Math.Pow(Math.Abs(Obj.Info.Position.Y - obj.Position.Y)-Obj.RadiusHeight,2.0)))
                        return true;
                }
                
            }
            return false;
        }
        
    }
}
