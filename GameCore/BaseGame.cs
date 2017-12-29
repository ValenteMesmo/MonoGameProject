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

    private const float bpm = 120;
    private const float crotchet = 60 / bpm;
    private float beatTime = 0;
    public int currentBeat = 1;
    private bool canPlay = false;

    private const int one = 4 * (4 * 1);
    private const int two = 4 * (4 * 2);
    private const int three = 4 * (4 * 3);
    private const int four = 4 * (4 * 4);
    private bool odd = true;

    public void Update()
    {
        beatTime += crotchet;

        canPlay = false;

        if ((beatTime % 1) == 0)
        {

            beatTime = 0;
            currentBeat++;
            if (currentBeat > four)
            {
                currentBeat = 4;
                odd = !odd;
            }

            canPlay = true;
        }
    }

    public void Force(string v)
    {
        Playe(v);
    }


    //todo: inverter a logica...nao bater no prato... bater no kick
    private bool Timing64()
    {
        return
             currentBeat == 52
            || currentBeat == 53
            || currentBeat == 54
            || currentBeat == 55
            || currentBeat == 56
            || currentBeat == 57
            || currentBeat == 58
            || currentBeat == 59
            || currentBeat == 60
            || currentBeat == 61
            || currentBeat == 62
            || currentBeat == 63
            //|| currentBeat == 64
            //|| currentBeat == 4
            //|| currentBeat == 5
            //|| currentBeat == 6
            ;
    }

    private bool Timing32()
    {
        return
            currentBeat == 20
            || currentBeat == 21
            || currentBeat == 22
            || currentBeat == 23
            || currentBeat == 24
            || currentBeat == 25
            || currentBeat == 26
            || currentBeat == 27
            || currentBeat == 28
            || currentBeat == 29
            || currentBeat == 30
            || currentBeat == 31
            //|| currentBeat == 32
            ;
    }

    private bool Timing16()
    {
        return
             currentBeat == 10
            || currentBeat == 11
            || currentBeat == 12
            || currentBeat == 13
            || currentBeat == 14
            || currentBeat == 15
            || currentBeat == 16
            || currentBeat == 17
            || currentBeat == 18
            ;
    }

    private bool Timing48()
    {
        return
             currentBeat == 42
            || currentBeat == 43
            || currentBeat == 44
            || currentBeat == 45
            || currentBeat == 46
            || currentBeat == 47
            || currentBeat == 48
            || currentBeat == 49
            || currentBeat == 50
            ;
    }

    internal void Play()
    {
        Game.LOG += $@"
{(mainTime() ? 1 : 0)} - {currentBeat}
";

        if (canPlay)
        {
            if (queued != "")
            {
                Sounds(queued).CreateInstance().Play();
                queued = "";
            }

            if (currentBeat == 64)
                Playe(GetBeatName());
        }
    }

    int GetBeatNameCallsCount;
    private string GetBeatName()
    {
        GetBeatNameCallsCount++;
        if (GetBeatNameCallsCount == 4)
        {
            GetBeatNameCallsCount = 0;
            return "beat147";
        }
        else
            return "beat146";
    }

    private void Playe(string soundName)
    {
        Sounds(soundName).CreateInstance().Play();
    }

    string queued = "";

    private bool mainTime()
    {
        return
         !Timing64()
        && !Timing32()
        //|| Timing16()
        //|| Timing48()
        ;
    }

    public bool Queue(string v)
    {
        var result = mainTime()
            //&& GetBeatNameCallsCount != 3
            ;

        if (result)
            queued = v;

        return result;
    }
}

public class BaseGame : OriginalGameClass
{
    internal GraphicsDeviceManager Graphics;
    private SpriteBatch SpriteBatch;
    public readonly Camera2d Camera;
    private readonly ILoadContents ContentLoader;
    private Dictionary<string, SoundEffect> Sounds;
    private Dictionary<string, Texture2D> Textures;
    private readonly Game Parent;
    SpriteFont SpriteFont;
    internal World World { get; }
#if DEBUG
    private static bool DisplayColliders;
#endif
    public VibrationCenter VibrationCenter { get; set; }
    public readonly MusicController MusicController;
    public bool RuningOnAndroid;

    public BaseGame(ILoadContents ContentLoader, Game Parent)
    {
        MusicController = new MusicController(n => Sounds[n]);
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
        Graphics.PreferredBackBufferWidth = 1366;
        Graphics.PreferredBackBufferHeight = 768;
        //Graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
        //Graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
#if DEBUG
        Graphics.IsFullScreen = false;
#else
        Graphics.IsFullScreen = true;
#endif
        if (RuningOnAndroid)
        {
            Graphics.IsFullScreen = true;
            Graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            Graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
        }

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


        var state = Keyboard.GetState();
#if DEBUG

        //Camera.Zoom = 0.06f;
        Camera.Zoom = 0.15f;

        if (InputWrapper.KeyBoard.F9.Tapped)
            DisplayColliders = !DisplayColliders;

        if (state.IsKeyDown(Keys.Escape))
            Parent.Restart();
#else
        Camera.Zoom = 0.15f;
#endif
        InputWrapper.Update();
        MusicController.Update();
        World.Update();
        MusicController.Play();
        VibrationCenter.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        //LOL darkblue affected performance... keep it black
        GraphicsDevice.Clear(Color.White);

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


        World.Things.ForEach(RenderThing);
#if DEBUG      
        var fps = string.Format("FPS: {0}", Parent.FrameCounter.AverageFramesPerSecond);

        SpriteBatch.DrawString(
            SpriteFont
            , fps
            , new Vector2(500, 2000)
                , Color.Black
                , 0
                , Vector2.Zero
                , 25
                , SpriteEffects.None
                , 0);

        SpriteBatch.DrawString(
            SpriteFont
            , Game.LOG
            , new Vector2(500, 3000)
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
        {
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

            thing.TouchAreas.ForEach(touchable =>
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
        }
#endif

        thing.Animations.ForEach(animation =>
        {
            foreach (var frame in animation.GetCurretFrame())
            {
                //var frame = animation.GetCurretFrame();
                var x = thing.X + frame.X;
                var width = frame.Width * (animation.ScaleX > 0 ? animation.ScaleX : 1);
                if (
                    x < 9500
                    && x + width > 500
                   )
                {
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
