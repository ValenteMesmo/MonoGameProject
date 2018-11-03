using GameCore;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using OriginalGameClass = Microsoft.Xna.Framework.Game;

public class SoundWrapper
{
    private readonly SoundEffect actualSoundEffect;
    private SoundEffectInstance currentSound;
    private readonly Func<int> GetX;
    Random Random = new Random();
    private readonly Func<int> GetY;

    public SoundWrapper(SoundEffect actualSoundEffect, Func<int> GetX, Func<int> GetY)
    {
        this.actualSoundEffect = actualSoundEffect;
        this.GetX = GetX;
        this.GetY = GetY;
        currentSound = actualSoundEffect.CreateInstance();
    }

    public void Update()
    {
        //TODO: Y
        var pan = GetX() / 100000f;
        if (pan < -1f)
            pan = -1f;
        else if (pan > 1f)
            pan = 1f;

        var distance = Math.Abs(GetX() - 8000);
        var distance2 = Math.Abs(GetY() );
        
        

        var volume = 1000f / distance;
        if (volume < 0)
            volume = 0;
        else if (volume > 1f)
            volume = 1f;

        var volume2 = 1f;
        if(distance2 > 8000)
            volume =  0.05f ;
        else if (distance2 > 7000)
            volume = 0.1f;
        else if (distance2 > 6000)
            volume = 0.2f;
        else if (distance2 > 5000)
            volume = 0.3f;

        if (volume2 < volume)
            volume = volume2;

        var maxPitch = 0.2f;
        var pitch = (float)Random.NextDouble();
        if (pitch > maxPitch)
        {
            pitch = maxPitch;
        }
        else if (pitch < -maxPitch)
        {
            pitch = -maxPitch;
        }

        currentSound.Pan = pan;
        currentSound.Pitch = pitch;
        currentSound.Volume = volume;
    }

    public void Play()
    {
        try
        {
            currentSound = actualSoundEffect.CreateInstance();
            currentSound.Play();
        }
        catch 
        {
        }
    }
}

public class MusicController
{
    private readonly Func<string, SoundEffect> Sounds;

    public MusicController(Func<string, SoundEffect> Sounds)
    {
        this.Sounds = Sounds;
    }

    //public int NextBumbo;

    private const float bpm = 120;
    private const float crotchet = 60 / bpm;
    private float beatTime = 0;
    private int beatCell = START;

    private int beatBlock = 1;

    private const int START = 1;
    private const int END = 16;

    public void Update()
    {
        beatTime += crotchet;

        if (beatTime == 1)
        {
            beatTime = 0;
            beatCell++;
            if (beatCell >= END)
            {
                beatCell = START;

                beatBlock++;
                if (beatBlock > Musica.BlocksCount)
                    beatBlock = 1;
            }
        }
        //if (CanPlayTarol())
        //    Sounds("beat2").CreateInstance().Play();

        //if (CanPlayBumbo())
        {
            //NextBumbo = Musica.GetNextBumbo(beatBlock, beatCell);
        }
    }

    public SoundWrapper GetSoundEffect(string soundName, Thing parent, Func<int> GetX, Func<int> GetY)
    {
        var result = new SoundWrapper(Sounds(soundName), GetX, GetY);
        parent.AddUpdate(result.Update);
        return result;
    }

    Musica Musica = new Musica(
            new MusicBlock(
                new MusicBlockCell(true, false)
                , new MusicBlockCell(false, false)
                , new MusicBlockCell(false, false)
                , new MusicBlockCell(false, false)
            )
            , new MusicBlock(
                new MusicBlockCell(false, false)
                , new MusicBlockCell(false, false)
                , new MusicBlockCell(false, false)
                , new MusicBlockCell(false, false)
            )
             , new MusicBlock(
                new MusicBlockCell(true, false)
                , new MusicBlockCell(false, false)
                , new MusicBlockCell(false, false)
                , new MusicBlockCell(false, false)
            )
             , new MusicBlock(
                new MusicBlockCell(false, false)
                , new MusicBlockCell(false, false)
                , new MusicBlockCell(false, true)
                , new MusicBlockCell(false, true)
            )
          //----------------------------
          , new MusicBlock(
                new MusicBlockCell(true, false)
                , new MusicBlockCell(false, false)
                , new MusicBlockCell(false, false)
                , new MusicBlockCell(false, true)
            )
        , new MusicBlock(
                new MusicBlockCell(true, false)
                , new MusicBlockCell(false, false)
                , new MusicBlockCell(false, false)
                , new MusicBlockCell(false, true)
            )
        , new MusicBlock(
                new MusicBlockCell(true, false)
                , new MusicBlockCell(false, false)
                , new MusicBlockCell(false, false)
                , new MusicBlockCell(false, false)
            )
        , new MusicBlock(
                new MusicBlockCell(false, false)
                , new MusicBlockCell(false, false)
                , new MusicBlockCell(false, true)
                , new MusicBlockCell(false, true)
            )
        );

    public bool CanPlayBumbo()
    {
        if (beatTime == 0)
            return Musica.Block(beatBlock).CellBumbo(beatCell);

        return false;
    }

    public bool CanPlayTarol()
    {
        if (beatTime == 0)
            return Musica.Block(beatBlock).CellTarol(beatCell);

        return false;
    }

    public bool PrepareTarol()
    {
        var nextcell = beatCell + 1;
        var nextblock = beatBlock;

        if (nextcell >= END)
        {
            nextcell = START;

            nextblock++;
            if (nextblock > Musica.BlocksCount)
                nextblock = 1;
        }

        if (beatTime == 0)
            return Musica.Block(nextblock).CellTarol(nextcell);

        return false;
    }

    public bool AboutToPlayBumbo()
    {
        var nextcell = beatCell + 1;
        var nextblock = beatBlock;

        if (nextcell >= END)
        {
            nextcell = START;

            nextblock++;
            if (nextblock > Musica.BlocksCount)
                nextblock = 1;
        }

        if (beatTime == 0)
            return Musica.Block(nextblock).CellBumbo(nextcell);

        return false;
    }
}

public class Musica
{
    private readonly MusicBlock[] blocks;

    public int BlocksCount { get { return blocks.Length; } }

    public Musica(params MusicBlock[] blocks)
    {
        this.blocks = blocks;
    }

    public MusicBlock Block(int number)
    {
        return blocks[number - 1];
    }
}

public class MusicBlock
{
    private readonly MusicBlockCell one;
    private readonly MusicBlockCell two;
    private readonly MusicBlockCell three;
    private readonly MusicBlockCell four;

    public MusicBlock(MusicBlockCell one, MusicBlockCell two, MusicBlockCell three, MusicBlockCell four)
    {
        this.one = one;
        this.two = two;
        this.three = three;
        this.four = four;
    }

    public bool CellBumbo(int cellNumber)
    {
        if (cellNumber == 1)
            return one.Bumbo;

        if (cellNumber == 4)
            return two.Bumbo;

        if (cellNumber == 8)
            return three.Bumbo;

        if (cellNumber == 12)
            return four.Bumbo;

        return false;
    }

    public bool CellTarol(int cellNumber)
    {
        if (cellNumber == 1)
            return one.Tarol;

        if (cellNumber == 4)
            return two.Tarol;

        if (cellNumber == 8)
            return three.Tarol;

        if (cellNumber == 12)
            return four.Tarol;

        return false;
    }
}

public class MusicBlockCell
{
    public readonly bool Bumbo;
    public readonly bool Tarol;

    public MusicBlockCell(bool Bumbo, bool Tarol)
    {
        this.Bumbo = Bumbo;
        this.Tarol = Tarol;
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
        Camera.Zoom = 0.15f;

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

        this.IsFixedTimeStep = true;//false;
        //this.TargetElapsedTime = TimeSpan.FromSeconds(1d / 30d); //60);
        Graphics.PreparingDeviceSettings += (sender, e) =>
        {
            e.GraphicsDeviceInformation.PresentationParameters.PresentationInterval = PresentInterval.Immediate;
        };

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


        if (InputWrapper.KeyBoard.F8.Tapped)
        {
            Camera.Zoom = 0.15f;
        }
        if (InputWrapper.KeyBoard.F7.Tapped)
        {
            Camera.Zoom = 0.06f;
        }

        if (InputWrapper.KeyBoard.F9.Tapped)
            DisplayColliders = !DisplayColliders;
#endif
        if (state.IsKeyDown(Keys.Escape))
            Parent.Restart();

        InputWrapper.Update();
        MusicController.Update();
        World.Update();
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
