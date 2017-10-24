using GameCore;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using OriginalGameClass = Microsoft.Xna.Framework.Game;

public class MusicController
{
    private readonly Func<string, SoundEffect> Sounds;

    public MusicController(Func<string, SoundEffect> Sounds)
    {
        this.Sounds = Sounds;
    }

    int duration = 0;
    internal void Play()
    {
        return;

        duration++;

        var interval = 15;
        var zzz = true;
        if (duration % interval == 0)
        {
            if (queued != "")
            {
                Sounds(queued).CreateInstance().Play();
                queued = "";
                zzz = false;
            }
            else //if(player)
            {
                //Sounds("clap").CreateInstance().Play();
            }
        }
        if (zzz)
        {

            if (duration == interval * 2)
            {
                Playe("beat");
            }
            if (duration == interval * 3)
            {
                //Playe("pom");
            }
            if (duration == interval * 4)
            {
                //Playe("pata");
            }
            //if (duration == interval * 6)
            //{
            //    Playe("pata");
            //}
            //if (duration == interval * 8)
            //{
            //    Playe("pom");
            //}
        }

        if (duration == interval * 8)
            duration = 0;
    }

    private void Playe(string soundName)
    {
        //if (queued != "")
        //{
        //    Sounds(queued).CreateInstance().Play();
        //    queued = "";
        //}
        //else
        Sounds(soundName).CreateInstance().Play();
    }

    string queued = "";

    public void Queue(string v)
    {
        queued = v;
    }
}

internal class BaseGame : OriginalGameClass
{
    internal GraphicsDeviceManager Graphics;
    private SpriteBatch SpriteBatch;
    public readonly Camera2d Camera;
    private readonly ILoadContents ContentLoader;
    private Dictionary<string, SoundEffect> Sounds;
    private Dictionary<string, Texture2D> Textures;
    private readonly Game Parent;
    SpriteFont SpriteFont;
    public World World { get; }

    //Effect effect;

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

    public VibrationCenter VibrationCenter { get; set; }
    public readonly MusicController MusicController;

    public BaseGame(ILoadContents ContentLoader, Game Parent)
    {
        MusicController = new MusicController(n=> Sounds[n]);
        this.VibrationCenter = new VibrationCenter();
        this.Parent = Parent;
        this.ContentLoader = ContentLoader;
#if DEBUG
        IsMouseVisible = true;
#endif
        Graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";
        IsFixedTimeStep = true;
        Graphics.SynchronizeWithVerticalRetrace = true;

        Graphics.ApplyChanges();
        Camera = new Camera2d();

        World = new World(Camera);
    }

    protected override void Initialize()
    {
        //TODO: fullscreen on alt+enter
#if RELEASE
        //Graphics.IsFullScreen = true;
        Graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
        Graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
#else
        Graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width / 2;
        Graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height / 2;
        //Graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
        //Graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
#endif
        //Graphics.IsFullScreen = true;

        Graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        Parent.Start();
        SpriteBatch = new SpriteBatch(GraphicsDevice);
        Textures = new Dictionary<string, Texture2D>();
        Sounds = new Dictionary<string, SoundEffect>();
        SpriteFont = Content.Load<SpriteFont>("SpriteFont");
        //effect = Content.Load<Effect>("ColorChanger");

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
        Camera.Update();
        VibrationCenter.Update();
        MusicController.Play();

        var state = Keyboard.GetState();
#if DEBUG
        if (!state.NumLock)
            Camera.Zoom = 0.06f;
        else
            Camera.Zoom = 0.15f;

        DisplayColliders = state.CapsLock;

        if (state.IsKeyDown(Keys.Escape))
            Parent.Restart();
#endif
        World.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        //LOL darkblue affected performance... keep it black
        GraphicsDevice.Clear(Color.Black);

        SpriteBatch.Begin(SpriteSortMode.BackToFront,
                   BlendState.AlphaBlend,
                   null,
                   null,
                   null,
                   null,
                   Camera.GetTransformation(GraphicsDevice));


        //var renderables = new[]
        //        {
        //            new {
        //                Frame= default(AnimationFrame),
        //                Animation = default(IHandleAnimation),
        //                Thing = default(Thing)
        //            }
        //        }.ToList();

        //renderables.Clear();

        //foreach (var thing in World.Things)
        //{
        //    foreach (var animation in thing.Animations)
        //    {
        //        var frame = animation.GetCurretFrame();

        //        renderables.Add(
        //            new
        //            {
        //                Frame = frame,
        //                Animation = animation,
        //                Thing = thing
        //            }
        //        );
        //    }
        //}

        //var previousColor = "";

        //foreach (var item in renderables.OrderByDescending(f => f.Animation.RenderingLayer))
        //{
        //    var current = item.Animation.ColorRed.ToString()
        //        + item.Animation.ColorGreen.ToString()
        //        + item.Animation.ColorBlue.ToString()
        //        + item.Animation.ColorYellow.ToString()
        //        + item.Animation.ColorCyan.ToString()
        //        + item.Animation.ColorMagenta.ToString();

        //    if (current != previousColor)
        //    {
        //        SpriteBatch.End();
        //        SpriteBatch.Begin(SpriteSortMode.Immediate,
        //                   BlendState.AlphaBlend,
        //                   null,
        //                   null,
        //                   null,
        //                   null,
        //                   Camera.GetTransformation(GraphicsDevice));
        //        //effect.Parameters["redColor"].SetValue(item.Animation.ColorRed.ToVector4());
        //        //effect.Parameters["greenColor"].SetValue(item.Animation.ColorGreen.ToVector4());
        //        //effect.Parameters["blueColor"].SetValue(item.Animation.ColorBlue.ToVector4());
        //        //effect.Parameters["yellowColor"].SetValue(item.Animation.ColorYellow.ToVector4());
        //        //effect.Parameters["cyanColor"].SetValue(item.Animation.ColorCyan.ToVector4());
        //        //effect.Parameters["magentaColor"].SetValue(item.Animation.ColorMagenta.ToVector4());
        //        //effect.CurrentTechnique.Passes[0].Apply();

        //        previousColor = current;
        //    }


        //    SpriteBatch.Draw(
        //                Textures[item.Frame.Name]
        //                , new Rectangle(
        //                    item.Thing.X + item.Frame.X,
        //                    item.Thing.Y + item.Frame.Y,
        //                    item.Frame.Width * (item.Animation.ScaleX > 0 ? item.Animation.ScaleX : 1),
        //                    item.Frame.Height * (item.Animation.ScaleY > 0 ? item.Animation.ScaleY : 1))
        //                , item.Frame.PositionOnSpriteSheet
        //                , Color.White
        //                , 0
        //                , Vector2.Zero
        //                , item.Frame.Flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None
        //                , item.Animation.RenderingLayer
        //        );
        //}

        Parent.FrameCounter.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
#if DEBUG

        World.Things.ForEach(RenderThing);

        var fps = string.Format("FPS: {0}", Parent.FrameCounter.AverageFramesPerSecond);

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
        Game.LOG = "";
#endif
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
                    collider.Disabled ? Color.Red : Color.Green
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
                30,
                Color.Blue
            )
        );

        thing.Animations.ForEach(animation =>
        {
            foreach (var frame in animation.GetCurretFrame())
            {
                //var frame = animation.GetCurretFrame();
                var x = thing.X + frame.X;
                var width = frame.Width * (animation.ScaleX > 0 ? animation.ScaleX : 1);
                if (x < 14000 && x + width > 0)

                    SpriteBatch.Draw(
                            Textures[frame.Name]
                            , new Rectangle(
                                thing.X + frame.X,
                                thing.Y + frame.Y,
                                frame.Width * (animation.ScaleX > 0 ? animation.ScaleX : 1),
                                frame.Height * (animation.ScaleY > 0 ? animation.ScaleY : 1))
                            , frame.PositionOnSpriteSheet
                            , animation.GetColor()
                            , 0
                            , Vector2.Zero
                            , frame.Flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None
                            , animation.RenderingLayer
                    );
            }
        });
    }

    private void DrawBorder(Rectangle rectangleToDraw, int thicknessOfBorder, Color borderColor)
    {
        var pixel = Textures["pixel"];
        SpriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, rectangleToDraw.Width, thicknessOfBorder), null, borderColor, 0, Vector2.Zero, SpriteEffects.None, 0);
        SpriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), null, borderColor, 0, Vector2.Zero, SpriteEffects.None, 0);
        SpriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder), rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), null, borderColor, 0, Vector2.Zero, SpriteEffects.None, 0);
        SpriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder, rectangleToDraw.Width, thicknessOfBorder), null, borderColor, 0, Vector2.Zero, SpriteEffects.None, 0);
    }
}
