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
        float WindowHeight = 480;
        float WindowWidth = 800;
        Texture2D TextureMap;
        Vector2 PositionMap;
        Vector2 OriginMap;
        public Vector2 StartPositionBall
        {
            get { return new Vector2(28f, 204.5f); }
        }
        public float SpeedBall
        {
            get { return 0.05f; }//0.2f
        }
        private List<GameObject> Keys = new List<GameObject>();
        private List<GameObject> StartFinish = new List<GameObject>();
        private List<GameObject> objects= new List<GameObject>();
        public Map1(ContentManager content)
        {
            TextureMap = content.Load<Texture2D>("map1");
            PositionMap = new Vector2(WindowWidth/2f,WindowHeight/2f);
            OriginMap = new Vector2(WindowWidth / 2f,WindowHeight / 2f);
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 8f,
                HeightTexture = 72f,
                Position = new Vector2(58f, 81f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 8f,
                HeightTexture = 117f,
                Position = new Vector2(160f, 58f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 168f,
                HeightTexture = 8f,
                Position = new Vector2(138f, 113f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 8f,
                HeightTexture = 139f,
                Position = new Vector2(218f, 179f),
            }));
            objects.Add(new Wall(new InfoWall()
            { 
                WidthTexture = 164f,
                HeightTexture = 8f,
                Position = new Vector2(82f, 165f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 164f,
                HeightTexture = 8f,
                Position = new Vector2(82f, 244f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 557f,
                HeightTexture = 8f,
                Position = new Vector2(343.5f, 296f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 8f,
                HeightTexture = 108f,
                Position = new Vector2(159f, 346f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 171f,
                HeightTexture = 8f,
                Position = new Vector2(355.5f, 113f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 411f,
                HeightTexture = 8f,
                Position = new Vector2(539.5f, 50f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 117f,
                HeightTexture = 8f,
                Position = new Vector2(114f, 561.5f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 149f,
                HeightTexture = 8f,
                Position = new Vector2(436.5f, 198f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 411f,
                HeightTexture = 8f,
                Position = new Vector2(539.5f, 50f),
            }));
            StartFinish.Add(new Wall(new InfoWall()
            {
                WidthTexture = 54f,
                HeightTexture = 71f,
                Position = StartPositionBall,
            }));
            Keys.Add(new Key(content,111.5f,65.5f));
        }
        public void Update(GameTime gameTime)
        {
        }
        public void StartPositionObjectsofMap()
        {
            foreach (RoundObject obj in objects.OfType<RoundObject>())
                obj.Position = obj.StartPosition;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureMap, PositionMap, null, Color.White, 0f, OriginMap, 1f, SpriteEffects.None, 0f);
            foreach (GameObject obj in Keys)
                obj.Draw(spriteBatch);
        }
        public bool Hascollisions(GameObject obj)
        {
            if (obj is RoundObject)
                if (Hascollisions((RoundObject)obj))
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
                if (Math.Abs(Obj.IW.Position.Y - obj.Position.Y) <= Obj.RadiusHeight)
                {
                    if (Math.Abs(Obj.IW.Position.X - obj.Position.X) <= Obj.RadiusWidth + obj.Radius)
                        return true;
                }
                if (Math.Abs(Obj.IW.Position.Y - obj.Position.Y) <= Obj.RadiusHeight+obj.Radius)
                {
                    if (Math.Abs(Obj.IW.Position.X - obj.Position.X) <= Obj.RadiusWidth+
                        Math.Sqrt(obj.Radius*obj.Radius-Math.Pow(Math.Abs(Obj.IW.Position.Y - obj.Position.Y)-Obj.RadiusHeight,2.0)))
                        return true;
                }
            }
            if (obj.Position.X-obj.Radius <= 0 || 
                obj.Position.Y- obj.Radius <= 0 || 
                obj.Position.X + obj.Radius >= WindowWidth || 
                obj.Position.Y + obj.Radius >= WindowHeight) return true;
            return false;
        }
        
    }
}
