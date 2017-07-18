using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private GameObject Ball;
        private Maps map;
        private float Speed;
        StartMenu Start;
        SpriteFont StringWin;
        SpriteFont StringEsc;
        SpriteFont Date;
        TimeSpan TotalTime;
        SoundEffect SoundKik;
        SoundEffect SoundKey;
        SoundEffect LevelEnd;

        int Kik = 0;
        bool Level = true;
        bool StartPlay = false ;
        bool soundEnd = true;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.Title = string.Format("{0} * {1}", Window.ClientBounds.Width, Window.ClientBounds.Height);
            base.Initialize();
            IsMouseVisible = true;
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            map = new Map1(Content);
            Ball = new Ball(Content, map.StartPositionBall, 0.08f);
            Speed = map.SpeedBall;
            StringWin = Content.Load<SpriteFont>("WIN");
            StringEsc = Content.Load<SpriteFont>("ESC");
            Date = Content.Load<SpriteFont>("Date");
            SoundKik = Content.Load<SoundEffect>("sound_kik");
            SoundKey = Content.Load<SoundEffect>("sound_key");
            LevelEnd = Content.Load<SoundEffect>("End_level");
            Start = new StartMenu(Content);

            // TODO: use this.Content to load your game content here
        }
        protected override void UnloadContent()
        {

            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (StartPlay)
            {
                map.Update(gameTime);
                if (Level)
                {
                    if (gameTime.TotalGameTime.Seconds >= 2)
                        Level = false;
                }

                int NumberKey = CollisionsWithKey(Ball, map.Keys);
                if (NumberKey != 0)
                {
                    SoundKey.Play();
                    map.DeliteKey(NumberKey);
                }

                if (!(CollisionsWithFinish(Ball, map) && map.Keys.Count == 0))
                {
                    TotalTime = gameTime.TotalGameTime;
                    if (Keyboard.GetState().IsKeyDown(Keys.Down))
                        Ball.Position += new Vector2(0, Speed) * gameTime.ElapsedGameTime.Milliseconds;
                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                        Ball.Position += new Vector2(0, -Speed) * gameTime.ElapsedGameTime.Milliseconds;
                    if (Keyboard.GetState().IsKeyDown(Keys.Left))
                        Ball.Position += new Vector2(-Speed, 0) * gameTime.ElapsedGameTime.Milliseconds;
                    if (Keyboard.GetState().IsKeyDown(Keys.Right))
                        Ball.Position += new Vector2(Speed, 0) * gameTime.ElapsedGameTime.Milliseconds;
                    if (false)
                    {
                        if (CollisionsWithStaticObjects(Ball, map))
                        {
                            SoundKik.Play();
                            map.StartPositionObjectsofMap();
                            Ball.Position = map.StartPositionBall;
                            Kik++;
                        }
                    }
                }
                else
                {
                    if (soundEnd)
                    {
                        LevelEnd.Play();
                        soundEnd = false;
                    }
                }      

                
                
                base.Update(gameTime);
            }
            else StartPlay = Start.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0, 163, 232));
            spriteBatch.Begin();
            Start.Draw(spriteBatch);
            if (StartPlay)
            {
                map.Draw(spriteBatch);
                Ball.Draw(spriteBatch);
                if (Level)
                {
                    spriteBatch.DrawString(StringWin, "Level 1!!!", new Vector2(100, 100), Color.Red);
                }
                if (CollisionsWithFinish(Ball, map) && map.Keys.Count == 0)
                {
                    spriteBatch.DrawString(StringWin, "YOUWIN!!!", new Vector2(100, 100), Color.Red);
                    spriteBatch.DrawString(StringEsc, "Please, push 'Esc' for Exit", new Vector2(320, 440), Color.Red);
                    spriteBatch.DrawString(Date, "Time: " + TotalTime.ToString("hh\\:mm\\:ss"), new Vector2(200, 265), Color.Red);
                    spriteBatch.DrawString(Date, "Count Kik: " + Kik, new Vector2(470, 265), Color.Red);
                }
                else
                {
                    spriteBatch.DrawString(Date, "Time: " + TotalTime.ToString("hh\\:mm\\:ss"), new Vector2(85, 430), Color.Red);
                    spriteBatch.DrawString(Date, "Count kik: " + Kik, new Vector2(380, 430), Color.Red);
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public bool CollisionsWithStaticObjects(GameObject obj, Maps Map)
        {
            List<GameObject> objects = Map.objects;
            if (obj is RoundObject)
            {
                if (CollisionsWithObjects((RoundObject)obj, objects))
                    return true;
                if (CollisionsWithBondary((RoundObject)obj,Map))
                    return true;
            }
            return false;
        }
        public bool CollisionsWithObjects(RoundObject obj, List<GameObject> objects)
        {
            foreach (RoundObject Obj in objects.OfType<RoundObject>())
            {
                if (obj != Obj)
                {
                    if (Vector2.Distance(Obj.Position, obj.Position) < (Obj.Radius + obj.Radius))
                        return true;
                }
            }
            foreach (SquareObject Obj in objects.OfType<SquareObject>())
            {
                if (Math.Abs(Obj.IW.Position.Y - obj.Position.Y) <= Obj.RadiusHeight)
                {
                    if (Math.Abs(Obj.IW.Position.X - obj.Position.X) <= Obj.RadiusWidth + obj.Radius)
                        return true;
                }
                if (Math.Abs(Obj.IW.Position.Y - obj.Position.Y) <= Obj.RadiusHeight + obj.Radius)
                {
                    if (Math.Abs(Obj.IW.Position.X - obj.Position.X) <= Obj.RadiusWidth +
                        Math.Sqrt(obj.Radius * obj.Radius - Math.Pow(Math.Abs(Obj.IW.Position.Y - obj.Position.Y) - Obj.RadiusHeight, 2.0)))
                        return true;
                }
            }
            return false;
        }
        public int CollisionsWithKey(GameObject obj, List<GameObject> key)
        {
            var Obj = (RoundObject)obj;
            int NumberKey=0;
      
            for (int i=0; i<key.Count; i++)
            {
                var keyj = (SquareObject)key[i];
                float Sc = keyj.IK.Scale;

                if (Math.Abs(keyj.Position.Y - Obj.Position.Y) <= keyj.RadiusHeight*Sc)
                {
                    if (Math.Abs(keyj.Position.X - Obj.Position.X) <= keyj.RadiusWidth* Sc + Obj.Radius)
                        return NumberKey=i+1;
                }
                if (Math.Abs(keyj.Position.Y - Obj.Position.Y) <= keyj.RadiusHeight*Sc + Obj.Radius)
                {
                    if (Math.Abs(keyj.Position.X - Obj.Position.X) <= keyj.RadiusWidth*Sc +
                        Math.Sqrt(Obj.Radius * Obj.Radius - Math.Pow(Math.Abs(keyj.Position.Y - Obj.Position.Y) - keyj.RadiusHeight* Sc, 2.0)))
                        return NumberKey=i+1;
                }
            }
            return NumberKey;
        }
        public bool CollisionsWithBondary(RoundObject obj,Maps Map)
        {
            if (obj.Position.X - obj.Radius <= 0 ||
                obj.Position.Y - obj.Radius <= 0 ||
                obj.Position.X + obj.Radius >= Map.Info.WidthTexture ||
                obj.Position.Y + obj.Radius >= Map.Info.HeightTexture) return true;
            return false;
        }
        public bool CollisionsWithFinish(GameObject obj, Maps Map)
        {
            SquareObject Obj = (SquareObject)Map.Finish;
            if (Math.Abs(Obj.IW.Position.X - obj.Position.X) <= Obj.RadiusWidth &&
                Math.Abs(Obj.IW.Position.Y - obj.Position.Y) <= Obj.RadiusHeight)
                return true;
            return false;
        }
    }
}