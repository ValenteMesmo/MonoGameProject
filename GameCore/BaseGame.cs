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
    private GraphicsDeviceManager Graphics;
    private SpriteBatch SpriteBatch;
    public World World { get; }
    private readonly Camera2d Camera;
    private readonly ILoadContents ContentLoader;
    private Dictionary<string, SoundEffect> Sounds;
    private Dictionary<string, Texture2D> Textures;

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

    private readonly Game Parent;

    public BaseGame(ILoadContents ContentLoader, Game Parent)
    {
        this.Parent = Parent;
        this.ContentLoader = ContentLoader;

        Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsFixedTimeStep = false;
        Graphics.SynchronizeWithVerticalRetrace = false;
        //TODO: fullscreen on alt+enter
        //graphics.IsFullScreen = true;

        Camera = new Camera2d();
        Camera.Pos = new Vector2(7000f, 5500f);
        Camera.Zoom = 0.1f;

        World = new World(Camera);
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        Parent.OnStart();
        SpriteBatch = new SpriteBatch(GraphicsDevice);
        Textures = new Dictionary<string, Texture2D>();
        Sounds = new Dictionary<string, SoundEffect>();

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

    private const float TIME_TO_NEXT_UPDATE = 1.0f / 120.0f;
    private float timeSinceLastUpdate;

    protected override void Update(GameTime gameTime)
    {
        timeSinceLastUpdate += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (timeSinceLastUpdate >= TIME_TO_NEXT_UPDATE)
        {
            var state = Keyboard.GetState();

            var controller = GamePad.GetState(0);
            World.PlayerInputs.SetState(state, controller);

            if (AndroidStuff.RunningOnAndroid)
            {
                TouchCollection touchCollection = TouchPanel.GetState();
                World.PlayerInputs.SetState(touchCollection);
            }
            World.Update();
            timeSinceLastUpdate = 0;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(158, 165, 178));
        SpriteBatch.Begin(SpriteSortMode.BackToFront,
                   BlendState.AlphaBlend,
                   null,
                   null,
                   null,
                   null,
                   Camera.GetTransformation(GraphicsDevice));

        RenderColliders();
        RenderAnimations();

        SpriteBatch.End();
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
            World.GetColliders()
                .ForEach(item =>
                    DrawBorder(
                        new Rectangle(
                            item.RenderX,
                            item.RenderY,
                            item.Width,
                            item.Height),
                        20,
                        Color.Red)
                );
        }
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
