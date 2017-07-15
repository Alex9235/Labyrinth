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
    public class Map1:Maps
    {
        public override InfoMap Info { get; }
        public Map1(ContentManager content) : base(content)
        {
            Info = new InfoMap()
            {
                Texture = content.Load<Texture2D>("map1"),
                HeightTexture = 400f,
                WidthTexture = 800f,
                Position = new Vector2(0, 0),
            };
            AddObjects();
            Finish = new Wall(new InfoWall()
            {
                WidthTexture = 35f,
                HeightTexture = 48f,
                Position = new Vector2(782.5f, 376f),
            });
            Keys.Add(new Key(content, 111.5f, 65.5f));
            Keys.Add(new Key(content, 537f, 88f));
            Keys.Add(new Key(content, 216.5f, 353f));
        }

        //........................
        public override Vector2 StartPositionBall
        {
            get { return new Vector2(28f, 204.5f); }
        }
        public override float SpeedBall
        {
            get { return 0.1f; }//0.2f
        }
        public override void Update(GameTime gameTime)
        {

        }
        protected override void AddObjects()
        {
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
                WidthTexture = 99f,
                HeightTexture = 8f,
                Position = new Vector2(552.5f, 239f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 8f,
                HeightTexture = 197f,
                Position = new Vector2(507f, 144.5f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 8f,
                HeightTexture = 197f,
                Position = new Vector2(672f, 144.5f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 174f,
                HeightTexture = 8f,
                Position = new Vector2(661f, 167f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 73f,
                HeightTexture = 8f,
                Position = new Vector2(763.5f, 98f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 132f,
                HeightTexture = 8f,
                Position = new Vector2(734f, 296f),
            }));
            objects.Add(new Wall(new InfoWall()
            {
                WidthTexture = 474f,
                HeightTexture = 8f,
                Position = new Vector2(563f, 348f),
            }));
        }
        
    }
}
