using System;
using GameCore;
using Microsoft.Xna.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MonoGameProject
{
    public class PlayerSlot
    {
        public PlayerSlot(int Index, Player Player, GameInputs AssociatedInput)
        {
            this.Index = Index;
            this.Player = Player;
            this.AssociatedInput = AssociatedInput;
        }

        public int Index { get; set; }
        public Player Player { get; set; }
        public int DeathCooldown { get; set; }
        public GameInputs AssociatedInput { get; set; }
    }

    public class Game1 : Game
    {
        public Game1(bool RuningOnAndroid = false) : base(new GeneratedContent(), RuningOnAndroid) { }

        public ScreenFlasher ScreenFader;
        public ScreenFader2 ScreenFader2;
        public List<PlayerSlot> PlayersSlots = new List<PlayerSlot>();
        public IEnumerable<Player> Players { get { return PlayersSlots.Where(f => f.Player != null).Select(f => f.Player); } }

        private List<GameInputs> allControllers;

        public bool GameStarted = false;
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
            var Keyboard_PlayerInputs = new GameInputs(new KeyboardChecker());
            var TouchControler_PlayerInputs = new GameInputs(new TouchScreenChecker(this, (x, y, w, h) => GeneratedContent.Create_knight_movementInput(x, y, w, h), (x, y, w, h) => GeneratedContent.Create_knight_actionsInput(x, y, w, h), () => GameStarted));
            var Controller1_PlayerInputs = new GameInputs(new GamePadChecker(0));
            var Controller2_PlayerInputs = new GameInputs(new GamePadChecker(1));
            var Controller3_PlayerInputs = new GameInputs(new GamePadChecker(2));
            var Controller4_PlayerInputs = new GameInputs(new GamePadChecker(3));

            var inputUpdater = new Thing();
            inputUpdater.AddUpdate(Keyboard_PlayerInputs);
            inputUpdater.AddUpdate(TouchControler_PlayerInputs);
            inputUpdater.AddUpdate(Controller1_PlayerInputs);
            inputUpdater.AddUpdate(Controller2_PlayerInputs);
            inputUpdater.AddUpdate(Controller3_PlayerInputs);
            inputUpdater.AddUpdate(Controller4_PlayerInputs);
            AddThing(inputUpdater);

            allControllers = new List<GameInputs> {
                Keyboard_PlayerInputs
                , TouchControler_PlayerInputs
                , Controller1_PlayerInputs
                , Controller2_PlayerInputs
                , Controller3_PlayerInputs
                , Controller4_PlayerInputs
            };
        }

        private void StartGame(GameInputs player1Inputs)
        {
            GameStarted = true;
            allControllers.Remove(player1Inputs);

            var camerawall = new Thing();
            camerawall.AddCollider(new SolidCollider(MapModule.CELL_SIZE, MapModule.HEIGHT * 2) { OffsetX = -MapModule.CELL_SIZE / 2 });
            camerawall.AddCollider(new SolidCollider(MapModule.CELL_SIZE, MapModule.HEIGHT * 2) { OffsetX = (int)(MapModule.CELL_SIZE * 19.5f) });
            AddThing(camerawall);

            //GameState.Load();

            //AddThing(new Enemy(this) { X = 4000, Y = 4000 });

            PlayersSlots.Clear();

            var PlayerStatue = new Thing();

            var player1 = new Player(this, 0, player1Inputs, AddThing);
            player1.Y = (8 * MapModule.CELL_SIZE) + Humanoid.height + 200;
            player1.X = (4 * MapModule.CELL_SIZE);
            player1.FacingRight = true;
            PlayersSlots.Add(new PlayerSlot(0, player1, player1Inputs));
            PlayersSlots.Add(new PlayerSlot(1, null, null));
            PlayersSlots.Add(new PlayerSlot(2, null, null));
            PlayersSlots.Add(new PlayerSlot(3, null, null));
            AddThing(player1);

            PlayerStatue.AddUpdate(() =>
            {
                var mainSlot = PlayersSlots.FirstOrDefault(f => f.Player != null);

                foreach (var slot in PlayersSlots)
                {
                    if (slot.DeathCooldown > 0)
                        slot.DeathCooldown--;

                    if (slot.Player != null || slot.DeathCooldown > 0)
                        continue;

                    if (slot.AssociatedInput == null)
                    {
                        foreach (var input in allControllers.ToList())
                        {
                            if (input.ClickedAction1)
                            {
                                slot.AssociatedInput = input;

                                allControllers.Remove(input);

                                AddPlayer(mainSlot.Player, slot);
                            }
                        }
                    }
                    else if (slot.AssociatedInput.ClickedAction1)
                    {
                        AddPlayer(mainSlot.Player, slot);
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

#if DEBUG
            var cheats = new Thing();
            cheats.AddUpdate(() =>
            {
                var kb = Microsoft.Xna.Framework.Input.Keyboard.GetState();
                if (kb.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F1))
                {
                    player1.HitPoints++;
                }
                if (kb.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F2))
                {
                    player1.HitPoints=1;
                }
                if (kb.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F5))
                {
                    player1.SetWeaponType(WeaponType.Sword);
                }
                if (kb.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F6))
                {
                    player1.SetWeaponType(WeaponType.Whip);
                }
                if (kb.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F7))
                {
                    player1.SetWeaponType(WeaponType.Wand);
                }
            });
            AddThing(cheats);
#endif
        }

        private void AddPlayer(Player player1, PlayerSlot slot)
        {
            var player = new Player(this, slot.Index, slot.AssociatedInput, AddThing);

            player.Y = player1.Y;
            player.X = player1.X;
            player.VerticalSpeed = player1.VerticalSpeed;
            player.HorizontalSpeed = player1.HorizontalSpeed;
            player.HeadState = player1.HeadState;
            player.TorsoState = player1.TorsoState;
            player.LegState = player1.LegState;
            player.FacingRight = player1.FacingRight;

            AddThing(player);
            slot.Player = player;
        }

        private void MainMenu()
        {
            GameStarted = false;
            ScreenFader2.FadeOut(() => { });

            GameState.Load();

            var thing = new Thing();

            var knightMary = GeneratedContent.Create_knight_KnightMary(700, 2200);
            knightMary.RenderingLayer = 0.001f;
            knightMary.ScaleX = 10;
            knightMary.ScaleY = 10;
            thing.AddAnimation(knightMary);

            var pressAlpha = 0;
            var pressSpeed = 5;

            var pressToStart = GeneratedContent.Create_knight_PressToStart(1000, 6000);
            pressToStart.RenderingLayer = 0.001f;
            pressToStart.ScaleX = 6;
            pressToStart.ScaleY = 6;
            pressToStart.ColorGetter = () => new Color(pressAlpha, pressAlpha, pressAlpha, pressAlpha);
            thing.AddAnimation(pressToStart);

            thing.AddUpdate(() =>
            {
                pressAlpha += pressSpeed;
                if (pressAlpha >= 255)
                {
                    pressAlpha = 255;
                    pressSpeed = -2;
                }
                if (pressAlpha <= 0)
                {
                    pressAlpha = 0;
                    pressSpeed = 5;
                }
            });

            AddThing(thing);

            var backgorung = new Animation(new AnimationFrame("pixel", 0, 0, 15000, 15000));
            backgorung.RenderingLayer = 1;
            //backgorung.ScaleX = 15;
            //backgorung.ScaleY = 15;
            backgorung.ColorGetter = () => Color.White;
            thing.AddAnimation(backgorung);

            CreateAnimationPart(thing, GeneratedContent.Create_knight_head_hair, HumanoidAnimatorFactory.HAIR_Z);
            CreateAnimationPart(thing, GeneratedContent.Create_knight_head_hair_bonus, HumanoidAnimatorFactory.HAIR_BONUS_Z);
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
            bbb.LoopDisabled = true;
            thing.AddAnimation(bbb);
        }

        internal void GameOver()
        {
            ScreenFader2.FadeIn(Restart);
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


        public void FadeIn(Action Callback = null)
        {
            this.Callback = Callback ?? (() => { });
            FadinMode = 1;
            Value = 0;
        }

        public void FadeOut(Action Callback = null)
        {
            this.Callback = Callback ?? (() => { });
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
