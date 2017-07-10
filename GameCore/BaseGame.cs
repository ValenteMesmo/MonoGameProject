using GameCore;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;
using OriginalGameClass = Microsoft.Xna.Framework.Game;

internal class BaseGame : OriginalGameClass
{
    FrameCounter FrameCounter = new FrameCounter();
    internal GraphicsDeviceManager Graphics;
    private SpriteBatch SpriteBatch;
    public readonly Camera2d Camera;
    private readonly ILoadContents ContentLoader;
    private Dictionary<string, SoundEffect> Sounds;
    private Dictionary<string, Texture2D> Textures;
    private readonly Game Parent;
    SpriteFont SpriteFont;
    public const float TIME_TO_NEXT_UPDATE = 1.0f / 60.0f;
#if DEBUG
    private bool DisplayColliders;
#endif

    public bool FullScreen
    {
        get
        {
            return Graphics.IsFullScreen;
        }
        set
        {
            Graphics.IsFullScreen = value;
        }
    }

    public World World { get; }

    public BaseGame(ILoadContents ContentLoader, Game Parent)
    {
        this.Parent = Parent;
        this.ContentLoader = ContentLoader;
#if DEBUG
        IsMouseVisible = true;
#endif
        Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        //IsFixedTimeStep = false;
        //Graphics.SynchronizeWithVerticalRetrace = false;
        IsFixedTimeStep = true;
        Graphics.SynchronizeWithVerticalRetrace = true;


        Camera = new Camera2d();
        Camera.Pos = new Vector2(7000f, 5500f);
        Camera.Zoom =
             0.1f;
        /*
        0.02f;
         */

        World = new World(Camera);
    }

    protected override void Initialize()
    {
        Graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
        Graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
        //TODO: fullscreen on alt+enter
        //Graphics.IsFullScreen = true;
        Graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        Parent.OnStart();
        SpriteBatch = new SpriteBatch(GraphicsDevice);
        Textures = new Dictionary<string, Texture2D>();
        Sounds = new Dictionary<string, SoundEffect>();
        SpriteFont = Content.Load<SpriteFont>("SpriteFont");

        {
            var pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });
            Textures.Add("pixel", pixel);
        }

        foreach (var textureName in ContentLoader.GetTextureNames())
        {
            Textures.Add(textureName, Content.Load<Texture2D>(textureName));
        }

        foreach (var soundName in ContentLoader.GetSoundNames())
        {
            Sounds.Add(soundName, Content.Load<SoundEffect>(soundName));
        }
    }



    protected override void Update(GameTime gameTime)
    {
        //if (timeSinceLastUpdate >= TIME_TO_NEXT_UPDATE)
        {

            var state = Keyboard.GetState();
#if DEBUG
            if (state.CapsLock)
                Camera.Zoom = 0.02f;
            else
                Camera.Zoom = 0.1f;

            DisplayColliders = state.NumLock;

            if (state.IsKeyDown(Keys.Escape))
                Parent.Restart();
#endif
            var controller = GamePad.GetState(0);
            World.PlayerInputs.SetState(state, controller);

            World.PlayerInputs.SetState(
                TouchPanel.GetState(),
                Mouse.GetState());

            World.Update();

        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        SpriteBatch.Begin(SpriteSortMode.BackToFront,
                   BlendState.AlphaBlend,
                   null,
                   null,
                   null,
                   null,
                   Camera.GetTransformation(GraphicsDevice));
        ;

#if DEBUG
        FrameCounter.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        
        var fps = string.Format("FPS: {0}", FrameCounter.AverageFramesPerSecond)
            .Replace("∞", "");
        SpriteBatch.DrawString(
            SpriteFont
            , fps
            , new Vector2(300, 1800)
            , Color.Black
            , 0
            , Vector2.Zero
            , 25
            , SpriteEffects.None
            , 0);

        SpriteBatch.DrawString(
            SpriteFont
            , Game.LOG
            , new Vector2(300, 2800)
            , Color.Black
            , 0
            , Vector2.Zero
            , 25
            , SpriteEffects.None
            , 0);
#endif

        World.Things.ForEach(RenderThing);

        SpriteBatch.End();

        base.Draw(gameTime);

    }

    private void RenderThing(Thing thing)
    {
#if DEBUG
        if (DisplayColliders)
            thing.Colliders.ForEach(collider =>
                DrawBorder(
                    new Rectangle(
                        thing.X + collider.OffsetX,
                        thing.Y + collider.OffsetY,
                        collider.Width,
                        collider.Height),
                    20,
                    Color.Red
                )
            );
#endif
        thing.Touchables.ForEach(touchable =>
            DrawBorder(
                new Rectangle(
                    thing.X + touchable.OffsetX,
                    thing.Y + touchable.OffsetY,
                    touchable.Width,
                    touchable.Height),
                20,
                Color.Blue
            )
        );


        thing.Animations.ForEach(animation =>
        {
            var frame = animation.GetCurretFrame();
            SpriteBatch.Draw(
                    Textures[frame.Name]
                    , new Rectangle(
                        thing.X + frame.X,
                        thing.Y + frame.Y,
                        frame.Width,
                        frame.Height)
                    , frame.PositionOnSpriteSheet
                    , animation.Color
                    , 0
                    , Vector2.Zero
                    , frame.Flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None
                    , frame.RenderingLayer
            );
        });
    }

    //private void RenderAnimations()
    //{
    //    var animations = World.GetAnimations();

    //    foreach (var item in animations)
    //    {
    //        int bonusX = 0;
    //        int bonusY = 0;


    //        var textures = item.As<Animation>().GetTextures();

    //        foreach (var texture in textures)
    //        {
    //            spriteBatch.Draw(
    //                    GeneratedContent.Textures[texture.Name]
    //                    , new Rectangle(
    //                       bonusX + texture.X,
    //                    bonusY + texture.Y,
    //                    texture.Width,
    //                    texture.Height)
    //                    , texture.PositionOnSpriteSheet
    //                    , texture.Color
    //                    , 0
    //                    , Vector2.Zero
    //                    , texture.Flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None
    //                    , texture.ZIndex
    //            );
    //        }
    //    }

    //}

    //private void PlayAudios()
    //{
    //    var Sounds = World.GetSoundNamesToBePlayed();

    //    foreach (var soundName in Sounds)
    //    {
    //        this.Sounds[soundName].Play();
    //    }
    //}

    //private void RenderColliders()
    //{
    //    if (true)
    //    {
    //        World.GetColliders()
    //            .ForEach(item =>
    //                DrawBorder(
    //                    new Rectangle(
    //                        item.RenderX,
    //                        item.RenderY,
    //                        item.Width,
    //                        item.Height),
    //                    20,
    //                    Color.Red)
    //            );
    //    }
    //}

    private void DrawBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
    {
        var pixel = Textures["pixel"];
        SpriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), null, borderColor, 0, Vector2.Zero, SpriteEffects.None, 0);
        SpriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), null, borderColor, 0, Vector2.Zero, SpriteEffects.None, 0);
        SpriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder), rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), null, borderColor, 0, Vector2.Zero, SpriteEffects.None, 0);
        SpriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder, rectangleToDraw.Width, thicknessOfBorder), null, borderColor, 0, Vector2.Zero, SpriteEffects.None, 0);
    }
}
