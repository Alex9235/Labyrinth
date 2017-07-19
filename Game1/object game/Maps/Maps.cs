using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public class Maps
    {
        public List<GameObject> Keys = new List<GameObject>();
        public GameObject Finish;
        public List<GameObject> objects = new List<GameObject>();
        public virtual InfoMap Info { get; }

        public Maps(ContentManager content)
        {
            Info = new InfoMap();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Info.Texture, Info.Position, null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            foreach (GameObject obj in Keys)
                obj.Draw(spriteBatch);
        }

        public void DeliteKey(int NumberKey)
        {
            Keys.RemoveAt(NumberKey - 1);
        }

        public void StartPositionObjectsofMap()
        {
            foreach (RoundObject obj in objects.OfType<RoundObject>())
                obj.Position = obj.StartPosition;
        }

        public virtual float SpeedBall{ get; }
        public virtual void Update(GameTime gameTime){ }
        protected virtual void AddObjects() { }
        public virtual Vector2 StartPositionBall { get; }
    }
}
