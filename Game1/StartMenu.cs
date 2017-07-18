using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class StartMenu
    {
        SpriteFont Labyrinth;
        GameObject Ball;
        SpriteFont Enter;
        public StartMenu(ContentManager content)
        {
            Labyrinth = content.Load<SpriteFont>("Labyrinth");
            Enter = content.Load<SpriteFont>("Enter");
            Ball = new Ball(content, new Vector2(400,200), 0.9f);
        }
        public bool Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                return true;
            return false;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Ball.Draw(spriteBatch);
            spriteBatch.DrawString(Labyrinth, "Labyrinth",new Vector2 (250,100), Color.Orange);
            spriteBatch.DrawString(Enter, "Press 'Enter' for start game\n      Press 'Esc' for Exit", new Vector2(170, 300), Color.Orange);

        }
    }

}
