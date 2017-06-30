using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;

namespace GameCore
{
    //deixar de usar duas threads

    public abstract class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public World World { get; }
        private GameRunner gameloop;
        private readonly Camera2d cam;

        public bool FullScreen { get { return graphics.IsFullScreen; } set { graphics.IsFullScreen = value; } }

        private readonly ILoadContents ContentLoader;
        private Dictionary<string, SoundEffect> Sounds;
        private Dictionary<string, Texture2D> Textures;

        public Game1(ILoadContents ContentLoader)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsFixedTimeStep = false;
            graphics.SynchronizeWithVerticalRetrace = false;
            //TODO: fullscreen on alt+enter
            //graphics.IsFullScreen = true;

            cam = new Camera2d();
            cam.Pos = new Vector2(7000f, 5500f);
            cam.Zoom = 0.1f;

            World = new World(cam);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Textures = ContentLoader.LoadTextures();
            Sounds = ContentLoader.LoadSoundEffects();

            gameloop = new GameRunner(World.Update);
            gameloop.Start();
            StartGame();
        }

        protected abstract void OnStart();

        private void StartGame()
        {
            OnStart();
        }

        protected override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Escape))
                Exit();

            var controller = GamePad.GetState(0);
            World.PlayerInputs.SetState(state, controller);

            if (AndroidStuff.RunningOnAndroid)
            {
                TouchCollection touchCollection = TouchPanel.GetState();
                World.PlayerInputs.SetState(touchCollection);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(158, 165, 178));
            spriteBatch.Begin(SpriteSortMode.BackToFront,
                       BlendState.AlphaBlend,
                       null,
                       null,
                       null,
                       null,
                       cam.GetTransformation(GraphicsDevice));

            RenderColliders();
            RenderAnimations();

            spriteBatch.End();
            base.Draw(gameTime);

            PlayAudios();
        }

        private void RenderAnimations()
        {
            var animations = World.GetAnimations();
        }

        private void PlayAudios()
        {
            var audios = World.GetAudios();

            //    if (item is SomethingWithAudio)
            //    {
            //        foreach (var audioName in item.As<SomethingWithAudio>().GetAudiosToPlay())
            //        {
            //            //TODO:
            //            if (audioName == null)
            //                return;

            //            Audios[audioName].Play();
            //        }
            //    }

        }

        private void RenderColliders()
        {
            if (true)
            {
                var colliders = World.GetColliders();
                foreach (var item in colliders)
                {
                    DrawBorder(
                        new Rectangle(
                            item.RenderX,
                            item.RenderY,
                            item.Width,
                            item.Height),
                        20,
                        Color.Red);
                }
            }
        }

        private void DrawBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
        {
            var pixel = Textures["pixel"];
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), null, borderColor, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), null, borderColor, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder), rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), null, borderColor, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder, rectangleToDraw.Width, thicknessOfBorder), null, borderColor, 0, Vector2.Zero, SpriteEffects.None, 0);
        }

        public void UnPause()
        {
            if (gameloop != null)
                gameloop.Start();
        }

        public void Pause()
        {
            if (gameloop != null)
                gameloop.Stop();
        }

        public void Restart()
        {
            World.Clear();
            StartGame();
        }

        protected override void EndRun()
        {
            World.Stopped = true;
            base.EndRun();
        }
    }
}
