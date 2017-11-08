using System;
using GameCore;
using Microsoft.Xna.Framework;
using System.Collections;
using System.Collections.Generic;

namespace MonoGameProject
{
    public class Game1 : Game
    {
        public Game1() : base(new GeneratedContent()) { }

        public ScreenFlasher ScreenFader;
        public ScreenFader2 ScreenFader2;
        public List<Player> Players = new List<Player>();
        private List<GameInputs> allControllers;

        protected override void OnStart()
        {
            Camera.Clear();
            Camera.Pos = new Vector2(5000f, 4500f);

            ScreenFader = new ScreenFlasher();
            AddToWorld(ScreenFader);

            ScreenFader2 = new ScreenFader2();
            AddToWorld(ScreenFader2);

            CreateGameInputs();

            MainMenu();
        }

        private void CreateGameInputs()
        {
            var Keyboard_PlayerInputs = new GameInputs(new KeyboardChecker(0));
            //var TouchControler_PlayerInputs = new GameInputs(new KeyboardChecker(0));
            var Controller1_PlayerInputs = new GameInputs(new GamePadChecker(0));
            var Controller2_PlayerInputs = new GameInputs(new GamePadChecker(1));
            var Controller3_PlayerInputs = new GameInputs(new GamePadChecker(2));
            var Controller4_PlayerInputs = new GameInputs(new GamePadChecker(3));

            var inputUpdater = new Thing();
            inputUpdater.AddUpdate(Keyboard_PlayerInputs);
            inputUpdater.AddUpdate(Controller1_PlayerInputs);
            inputUpdater.AddUpdate(Controller2_PlayerInputs);
            inputUpdater.AddUpdate(Controller3_PlayerInputs);
            inputUpdater.AddUpdate(Controller4_PlayerInputs);
            AddThing(inputUpdater);

            allControllers = new List<GameInputs> {
                Keyboard_PlayerInputs
                , Controller1_PlayerInputs
                , Controller2_PlayerInputs
                , Controller3_PlayerInputs
                , Controller4_PlayerInputs
            };
        }


        //int selectedLine = 0;
        //int inputCooldown = 0;
        //private void MainScreen()
        //{
        //    line = 0;
        //    var MainManeu = new Thing();
        //    MainManeu.X = (int)((MapModule.CELL_SIZE * MapModule.CELL_NUMBER) / 2.4f);
        //    MainManeu.Y = (int)((MapModule.CELL_SIZE * MapModule.CELL_NUMBER) / 2.2f);

        //    MainManeu.AddUpdate(() =>
        //    {
        //        if (inputCooldown > 0)
        //            inputCooldown--;

        //        if (inputCooldown > 0)
        //            return;

        //        var keyboard = Microsoft.Xna.Framework.Input.Keyboard.GetState();

        //        if (keyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down))
        //        {
        //            inputCooldown = 10;
        //            selectedLine++;
        //        }
        //        if (keyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up))
        //        {
        //            inputCooldown = 10;
        //            selectedLine--;
        //        }
        //        if (keyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
        //        {
        //            MainManeu.Destroy();
        //            StartGame();
        //        }

        //        if (selectedLine > 2)
        //            selectedLine = 0;
        //        if (selectedLine < 0)
        //            selectedLine = 2;
        //    });

        //    //MainManeu.AddAnimation(GeneratedContent.Create_knight_head_face(-2000,-2000,8000,8000));
        //    //MainManeu.AddAnimation(GeneratedContent.Create_knight_head_eyes(-2000,-2000,8000,8000));
        //    //MainManeu.AddAnimation(GeneratedContent.Create_knight_head_hair(-2000,-2000,8000,8000));

        //    //play sound... lower going down

        //    NewMethod(MainManeu, "New Game");
        //    NewMethod(MainManeu, "Continue");
        //    NewMethod(MainManeu, "Options");
        //    AddThing(MainManeu);
        //}

        //int line = 0;
        //private void NewMethod(Thing start, string text)
        //{
        //    var thisLine = line;
        //    for (int i = 0; i < text.Length; i++)
        //    {
        //        if (text[i] == ' ')
        //            continue;

        //        var animation = GeneratedContent.Create_knight_number0(
        //                i * MapModule.CELL_SIZE,
        //                (int)((line * 1.25f) * MapModule.CELL_SIZE),
        //                MapModule.CELL_SIZE,
        //                MapModule.CELL_SIZE
        //        );

        //        animation.ColorGetter = () => selectedLine == thisLine ? Color.Red : Color.White;

        //        start.AddAnimation(animation);
        //    }

        //    line++;
        //}

        private void StartGame(GameInputs player1Inputs)
        {
            allControllers.Remove(player1Inputs);

            var camerawall = new Thing();
            camerawall.AddCollider(new SolidCollider(MapModule.CELL_SIZE, MapModule.HEIGHT * 2) { OffsetX = -MapModule.CELL_SIZE / 2 });
            camerawall.AddCollider(new SolidCollider(MapModule.CELL_SIZE, MapModule.HEIGHT * 2) { OffsetX = (int)(MapModule.CELL_SIZE * 19.5f) });
            AddThing(camerawall);

            GameState.Load();

            AddThing(new Enemy(this) { X = 4000, Y = 4000 });

            Players.Clear();

            var PlayerStatue = new Thing();
            var playerIndex = 0;

            var player1 = new Player(this, playerIndex, player1Inputs, AddThing);
            player1.Y = (8 * MapModule.CELL_SIZE) + Humanoid.height + 200;
            player1.X = 0;
            Players.Add(player1);
            AddThing(player1);
            playerIndex++;

            PlayerStatue.AddUpdate(() =>
            {
                if (playerIndex > 3)
                {
                    PlayerStatue.Destroy();
                    return;
                }

                foreach (var input in allControllers.ToArray())
                {
                    if (input.ClickedAction1)
                    {
                        var player = new Player(this, playerIndex, input, AddThing);

                        player.Y = player1.Y;
                        player.X = player1.X;

                        AddThing(player);
                        Players.Add(player);

                        allControllers.Remove(input);
                        playerIndex++;
                    }
                }
            });

            AddThing(PlayerStatue);

            var WorldMover = new WorldMover(this);
            AddThing(WorldMover);
            AddThing(new PlatformCreator(WorldMover, AddThing, this));

            var roof = new Thing();
            roof.AddAfterUpdate(new MoveHorizontallyWithTheWorld(roof, 1, true));
            roof.AddCollider(new SolidCollider
            {
                OffsetY = -MapModule.CELL_SIZE,
                Height = 4 * MapModule.CELL_SIZE,
                Width = 16 * 2 * MapModule.CELL_SIZE
            });
            AddThing(roof);

            {
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, width, height) => GeneratedContent.Create_knight_dead_tree(x, y), 3, 0.91f));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, width, height) => GeneratedContent.Create_knight_dead_tree(x, y), 2, 0.90f));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, width, height) => GeneratedContent.Create_knight_dead_tree(x, y, 500, 400), 1, 0.01f));
            }

            ScreenFader2.FadeOut(() => { });
        }

        private void MainMenu()
        {
            var thing = new Thing();
            var aaa = GeneratedContent.Create_knight_KnightMary(700, 2200);
            aaa.RenderingLayer = 0;
            aaa.ScaleX = 10;
            aaa.ScaleY = 10;
            thing.AddAnimation(aaa);

            AddThing(thing);

            var backgorung = new Animation(new AnimationFrame("pixel", 0, 0, 15000, 15000));
            backgorung.RenderingLayer = 1;
            //backgorung.ScaleX = 15;
            //backgorung.ScaleY = 15;
            backgorung.ColorGetter = () => Color.White;
            thing.AddAnimation(backgorung);

            CreateAnimationPart(thing, GeneratedContent.Create_knight_head_hair, HumanoidAnimatorFactory.HAIR_Z);
            CreateAnimationPart(thing, GeneratedContent.Create_knight_head_eyes, HumanoidAnimatorFactory.EYE_Z);
            CreateAnimationPart(thing, GeneratedContent.Create_knight_head_face, HumanoidAnimatorFactory.FACE_Z);
            CreateAnimationPart(thing, GeneratedContent.Create_knight_torso_walking_armored, HumanoidAnimatorFactory.TORSO_Z);
            CreateAnimationPart(thing, GeneratedContent.Create_knight_Arm_Idle_armored, HumanoidAnimatorFactory.WEAPON_Z);
            CreateAnimationPart(thing, GeneratedContent.Create_knight_Arm_Idle_armored, HumanoidAnimatorFactory.BACK_ARM_Z, 700, 0, true);
            //CreateAnimationPart(thing, GeneratedContent.Create_knight_Leg_wall_front_armored, HumanoidAnimatorFactory.FRONT_LEG_Z);
            CreateAnimationPart(thing, GeneratedContent.Create_knight_Leg_Fall_back_armored, HumanoidAnimatorFactory.BACK_LEG_Z, -750);
            CreateAnimationPart(thing, GeneratedContent.Create_knight_head_armor1, HumanoidAnimatorFactory.FRONT_ARM_Z, 800, 1900);

            var waitingInput = true;
            thing.AddUpdate(() =>
            {
                foreach (var input in allControllers)
                {
                    if (waitingInput && input.ClickedAction1)
                    {
                        waitingInput = false;
                        ScreenFader2.FadeIn(() =>
                        {
                            StartGame(input);
                            thing.Destroy();
                        });

                        break;
                    }
                }
            });
        }

        private static void CreateAnimationPart(
            Thing thing
            , Func<int, int, int?, int?, bool, Animation> createAnimation
            , float z
            , int xBonus = 0
            , int yBonus = 0
            , bool flipped = false)
        {
            var bbb = createAnimation(5000 + xBonus, 2200 + yBonus, null, null, flipped);
            bbb.RenderingLayer = z;
            bbb.ScaleX = 20;
            bbb.ScaleY = 20;
            bbb.ColorGetter = () => Color.White;

            thing.AddAnimation(bbb);
        }
    }

    public class ScreenFader2 : Thing
    {
        private int Value;
        private int FadinMode = 0;
        private Action Callback;

        public ScreenFader2()
        {
            var fadeAnimation = new Animation(new AnimationFrame("pixel", 0, 0, 15000, 15000));
            fadeAnimation.ColorGetter = () => new Color(Value, Value, Value, Value);
            fadeAnimation.RenderingLayer = 0f;
            AddAnimation(fadeAnimation);

            AddUpdate(() =>
            {
                if (FadinMode == 1)
                {
                    if (Value < 255)
                        Value += 5;
                    else
                    {
                        FadinMode = 0;
                        Callback();
                    }

                }
                else if (FadinMode == 2)
                {
                    if (Value > 0)
                        Value -= 5;
                    else
                    {
                        FadinMode = 0;
                        Callback();
                    }
                }
            });
        }


        public void FadeIn(Action Callback)
        {
            this.Callback = Callback;
            FadinMode = 1;
            Value = 0;
        }

        public void FadeOut(Action Callback)
        {
            this.Callback = Callback;
            FadinMode = 2;
            Value = 255;
        }
    }

    public class ScreenFlasher : Thing
    {
        private int Red;
        private int Green;
        private int Blue;
        private int Alpha;
        private const int Speed = 100;
        private int duration;

        public ScreenFlasher()
        {
            var flashAnimation = GeneratedContent.Create_knight_Flash(-20000, -20000, 40000, 40000);
            flashAnimation.ColorGetter = () => new Color(Red, Green, Blue, Alpha);
            flashAnimation.RenderingLayer = 0f;
            AddAnimation(flashAnimation);

            AddUpdate(() =>
            {
                duration++;
                if (duration > 20)
                    duration = 20;

                Red = UpdateValue(Red, 0);
                Green = UpdateValue(Green, 0);
                Blue = UpdateValue(Blue, 0);
                Alpha = UpdateValue(Alpha, 0);
            });
        }

        private int UpdateValue(int value, int limit)
        {
            if (value > limit)
            {
                value -= (duration * 100) / Speed;
                if (value < limit)
                    value = limit;
            }
            else if (value < limit)
            {
                value += (duration * 100) / Speed;
                if (value > limit)
                    value = limit;
            }

            return value;
        }

        public void Flash(int red, int green, int blue, int x, int y)
        {
            duration = 0;
            X = x;
            Y = y;
            Alpha = 200;

            Red = red;
            Green = green;
            Blue = blue;
        }

        public void Flash(int x, int y)
        {
            Flash(200, 200, 200, x, y);
        }
    }
}
