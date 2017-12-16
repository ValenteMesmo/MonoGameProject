using GameCore;
using Microsoft.Xna.Framework;
using SharedContent.Things;
using System;
using System.Linq;

namespace MonoGameProject
{
    public class MapModule : Thing
    {
        public const int SCALE = 5;
        public const int CELL_SIZE = 500;
        public const int CELL_NUMBER = 16;
        public const int WIDTH = CELL_SIZE * CELL_NUMBER;
        public const int HEIGHT = CELL_SIZE * CELL_NUMBER;

        public readonly MapModuleInfo Info;

        public MapModule(int X, int Y, BackBlocker Blocker, MapModuleInfo Info, Game1 Game1)
        {
            this.X = X;
            this.Y = Y;
            this.Info = Info;

            AddStageNumber();

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));

            AddUpdate(() =>
            {
                if (this.X <= -WIDTH * 2)
                {
                    Blocker.X = this.X + WIDTH - BackBlocker.WIDTH;
                    Destroy();
                }
            });

            var tiles = new TilesFromStrings().Create(Info.Tiles);
            foreach (var tile in tiles.Where(f => f.Type == '1' || f.Type == '2'))
            {
                AddCollider(new GroundCollider
                {
                    OffsetX = (tile.X - 1) * CELL_SIZE,
                    OffsetY = (tile.Y - 1) * CELL_SIZE,
                    Width = tile.Width * CELL_SIZE,
                    Height = tile.Height * CELL_SIZE
                });
            }
            foreach (var tile in tiles.Where(f => f.Type == '^'))
            {
                Game1.AddToWorld(new Spikes(
                    Game1
                    , Color.Red,
                    tile.Width,
                    tile.Height)
                {
                    X = X + ((tile.X - 1) * CELL_SIZE),
                    Y = Y + ((tile.Y - 1) * CELL_SIZE)
                });
            }

            {
                var sky = new Animation(new AnimationFrame("pixel",
                                  0
                                 , 0
                                 , CELL_SIZE * CELL_NUMBER
                                 , (CELL_SIZE * CELL_NUMBER)));

                var color = ColorsOfTheStage.Sky();
                sky.ColorGetter = () => color;
                sky.RenderingLayer = 1f;
                AddAnimation(sky);
            }

            for (int i = 0; i < CELL_NUMBER; i++)
            {
                for (int j = 0; j < CELL_NUMBER; j++)
                {
                    var type = Info.Tiles[i][j];
                    if (type == '1' || type == '2')
                    {
                        var z = GameState.State.CaveMode ? 0.22f : 0.21f;

                        var color = GameState.GetColor();
                        if (type == '2')
                            CreateBlockTop(i, j, z - 0.01f, ColorsOfTheStage.Sub(), GeneratedContent.Create_knight_ground_top);

                        CreateBlock(
                            i
                            , j
                            , z
                            ,
                           ColorsOfTheStage.Main()
                            , GetGroundAnimation());
                    }

                    if (type == '=')
                    {
                        CreateBackground(i, j);
                    }

                    if (type == 'j')
                    {
                        Game1.AddToWorld(new MovingPlatform()
                        {
                            X = X + j * CELL_SIZE,
                            Y = Y + i * CELL_SIZE
                        });
                    }

                    if (type == 'k')
                    {
                        Game1.AddToWorld(new ElevatorPlatform()
                        {
                            X = X + j * CELL_SIZE,
                            Y = Y + i * CELL_SIZE
                        });
                    }

                    if (type == 'r')
                    {
                        Game1.AddToWorld(new LeftFireBallTrap(Game1, i % 2 == 0 ? 50 : 0)
                        {
                            X = X + j * CELL_SIZE,
                            Y = Y + i * CELL_SIZE
                        });
                        CreateBackground(i, j);
                    }
                    if (type == '@')
                    {
                        Game1.AddToWorld(new BossBattleTrigger
                        {
                            X = X + j * CELL_SIZE,
                            Y = Y + i * CELL_SIZE
                        });

                        CreateBackground(i, j);
                    }
                    if (type == 'x')
                    {
                        var camlocker = new Thing();
                        camlocker.X = X + j * CELL_SIZE;
                        camlocker.Y = (Y + i * CELL_SIZE);
                        camlocker.AddAfterUpdate(new MoveHorizontallyWithTheWorld(camlocker));
                        Game1.AddToWorld(camlocker);
                        Blocker
                            .WorldMover.camlocker = camlocker;

                        CreateBackground(i, j);
                    }
                    if (type == 'y' || type == 'z')
                    {
                        var locker = new Thing();
                        locker.X = X + j * CELL_SIZE;
                        locker.Y = (Y + i * CELL_SIZE);

                        var animation = GeneratedContent.Create_knight_ground_2(
                                -5
                               , -5
                               , MapModule.CELL_SIZE + 10
                               , (MapModule.CELL_SIZE + 10) * 2);
                        animation.RenderingLayer = 0.5f;
                        var color = GameState.GetColor();
                        animation.ColorGetter = () => color;
                        locker.AddAnimation(animation);

                        var animationborder = GeneratedContent.Create_knight_ground_2(
                               -25
                               , -25
                               , MapModule.CELL_SIZE + 50
                               , (MapModule.CELL_SIZE + 50) * 2);
                        animationborder.RenderingLayer = 0.51f;
                        animationborder.ColorGetter = () => Color.Black;//Colors[ColorIndex];
                        locker.AddAnimation(animationborder);

                        locker.AddAfterUpdate(new MoveHorizontallyWithTheWorld(locker));
                        Game1.AddToWorld(locker);
                        //var originalY = locker.Y;

                        Collider collider;
                        if (type == 'z')
                        {
                            collider = new GroundCollider();
                        }
                        else
                        {
                            collider = new GroundFromLeftToRightCollider();
                        }


                        collider.OffsetX = 0;
                        collider.OffsetY = 0;
                        collider.Width = CELL_SIZE;
                        collider.Height = CELL_SIZE * 2;

                        locker.AddCollider(collider);

                        locker.AddUpdate(() =>
                        {
                            collider.Disabled = !GameState.State.BossMode;
                        });


                        CreateBackground(i, j);
                    }
                    if (type == 'l')
                    {
                        Game1.AddToWorld(new RightFireBallTrap(Game1, i % 2 == 0 ? 50 : 0)
                        {
                            X = X + j * CELL_SIZE,
                            Y = Y + i * CELL_SIZE
                        });
                        CreateBackground(i, j);
                    }
                    if (type == 'm')
                    {
                        Game1.AddToWorld(new Boss(Game1)
                        {
                            X = X + j * CELL_SIZE,
                            Y = Y + i * CELL_SIZE
                        });
                        CreateBackground(i, j);
                    }
                    if (type == 'a')
                    {
                        Game1.AddToWorld(new ItemChest(Game1)
                        {
                            X = X + j * CELL_SIZE,
                            Y = Y + i * CELL_SIZE
                        });
                        //CreateBackground(i, j);
                    }
                    if (type == '!')
                    {
                        Thing flag;
                        if (GameState.PreSaved)
                            flag = new CheckPoint_Unchecked(Game1.AddToWorld);
                        else
                            flag = new CheckPoint_Checked(new Color(186, 120, 168));

                        flag.X = X + j * CELL_SIZE;
                        flag.Y = Y + i * CELL_SIZE;

                        Game1.AddToWorld(flag);
                    }
                }
            }
        }

        private static Func<int, int, int?, int?, bool, Animation> GetGroundAnimation()
        {
            Func<int, int, int?, int?, bool, Animation> animation = null;
            if (GameState.State.CaveMode)
                animation = GeneratedContent.Create_knight_ground_2;
            else
                animation = GeneratedContent.Create_knight_ground_1;
            return animation;
        }

        MyRandom MyRandom = new MyRandom();
        private void CreateBlock(int i, int j, float z, Color color, Func<int, int, int?, int?, bool, Animation> CreateAnimation, Color? borderColor = null)
        {
            if (borderColor == null)
                borderColor = Color.Black;

            var bonusx = 25;
            var bonusy = 20;

            var offsetx = j * CELL_SIZE - bonusx;
            var offsety = i * CELL_SIZE - bonusy;
            var width = CELL_SIZE + bonusx * 2;
            var height = CELL_SIZE + bonusy * 2;

            var flipped = false;//MyRandom.Next(0, 1).ToBool();

            var animation_ground = CreateAnimation(
                offsetx
                , offsety
                , width
                , height
                , flipped);
            animation_ground.RenderingLayer = z;//+ 0.001f;
            //var groundcolor = GameState.GetComplimentColor2();
            animation_ground.ColorGetter = () => color;
            AddAnimation(animation_ground);

            var animation_ground_border = CreateAnimation(
                offsetx - bonusx
                , offsety - bonusy
                , width + bonusx * 2
                , height + bonusy * 2,
                flipped);
            animation_ground_border.RenderingLayer = z + 0.001f;
            animation_ground_border.ColorGetter = () => borderColor.Value;
            AddAnimation(animation_ground_border);
        }

        private void CreateBlockTop(int i, int j, float z, Color color, Func<int, int, int?, int?, bool, Animation> CreateAnimation, Color? borderColor = null)
        {
            if (borderColor == null)
                borderColor = Color.Black;

            var bonusx = 16;
            var bonusy = 20;

            var offsetx = j * CELL_SIZE - bonusx;
            var offsety = i * CELL_SIZE - bonusy;
            var width = CELL_SIZE + bonusx * 2;
            var height = CELL_SIZE / 2 + bonusy * 2;

            var flipped = false;//MyRandom.Next(0, 1).ToBool();

            var animation_ground = CreateAnimation(
                offsetx
                , offsety
                , width
                , height
                , flipped);
            animation_ground.RenderingLayer = z;//+ 0.001f;
            //var groundcolor = GameState.GetComplimentColor2();
            animation_ground.ColorGetter = () => color;
            AddAnimation(animation_ground);

            var animation_ground_border = CreateAnimation(
                offsetx - bonusx
                , offsety - bonusy
                , width + bonusx * 2
                , height + bonusy * 2,
                flipped);
            animation_ground_border.RenderingLayer = z + 0.001f;
            animation_ground_border.ColorGetter = () => borderColor.Value;
            AddAnimation(animation_ground_border);
        }

        private void AddStageNumber()
        {
            if (GameState.State.ShowStageNumber == false)
                return;

            GameState.State.ShowStageNumber = false;

            var number = GameState.State.StageNumber.ToString();
            var i = 1;

            foreach (var n in number)
            {
                Func<int, int, int?, int?, bool, Animation> create = null;

                if (n == '0')
                    create = GeneratedContent.Create_knight_number0;
                else if (n == '1')
                    create = GeneratedContent.Create_knight_number1;
                else if (n == '2')
                    create = GeneratedContent.Create_knight_number2;
                else if (n == '3')
                    create = GeneratedContent.Create_knight_number3;
                else if (n == '4')
                    create = GeneratedContent.Create_knight_number4;
                else if (n == '5')
                    create = GeneratedContent.Create_knight_number5;
                else if (n == '6')
                    create = GeneratedContent.Create_knight_number6;
                else if (n == '7')
                    create = GeneratedContent.Create_knight_number7;
                else if (n == '8')
                    create = GeneratedContent.Create_knight_number8;
                else if (n == '9')
                    create = GeneratedContent.Create_knight_number9;
                else
                    return;

                var stageNumber = create(
                                            CELL_SIZE * i
                                            , CELL_SIZE
                                            , CELL_SIZE
                                            , CELL_SIZE
                                            , false);
                stageNumber.RenderingLayer = 0f;
                stageNumber.ColorGetter = () => new Color(0, 0, 0, 0.5f);
                AddAnimation(stageNumber);

                i++;
            }

        }

        private void CreateBackground(int i, int j)
        {
            CreateBlock(i, j, 0.52f, ColorsOfTheStage.Background(), GetGroundAnimation(), new Color(80, 80, 80));
        }
    }

    public class CheckPoint_Unchecked : Thing
    {
        public CheckPoint_Unchecked(Action<Thing> AddToWorld)
        {
            var animationPole = GeneratedContent.Create_knight_Checkpoint(150, -20);
            animationPole.ScaleX = animationPole.ScaleY = 4;
            animationPole.RenderingLayer = 0.01f;
            animationPole.ColorGetter = () => new Color(238, 204, 0);
            AddAnimation(animationPole);


            var collider = new Collider(MapModule.CELL_SIZE, MapModule.CELL_SIZE);

            collider.AddHandler((s, t) =>
            {
                if (t.Parent is Player)
                {
                    var player = t.Parent as Player;
                    //add hit effect
                    AddToWorld(new CheckPoint_Checked(player.GetHairColor()) { X = X, Y = Y });
                    GameState.Save();
                    s.Disabled = true;
                    Destroy();
                }
            });
            AddCollider(collider);

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
        }
    }

    public class CheckPoint_Checked : Thing
    {
        public CheckPoint_Checked(Color Color)
        {
            var animationPole = GeneratedContent.Create_knight_Checkpoint(150, -20);
            animationPole.ScaleX = animationPole.ScaleY = 4;
            animationPole.RenderingLayer = 0.01f;
            animationPole.ColorGetter = () => new Color(238, 204, 0);
            AddAnimation(animationPole);

            var animation = GeneratedContent.Create_knight_CheckpointFlag(280, 100);
            animation.ScaleX = animation.ScaleY = 4;
            animation.RenderingLayer = 0.02f;
            animation.ColorGetter = () => Color;
            AddAnimation(animation);

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
        }
    }

    public class MovingPlatform : Thing
    {
        public MovingPlatform()
        {
            var animation = GeneratedContent.Create_knight_ground_2(
                             -5
                            , -5
                            , MapModule.CELL_SIZE + 10
                            , (MapModule.CELL_SIZE + 10));
            animation.RenderingLayer = 0.5f;
            var color = GameState.GetColor();
            animation.ColorGetter = () => color;
            AddAnimation(animation);

            var animationborder = GeneratedContent.Create_knight_ground_2(
                   -25
                   , -25
                   , MapModule.CELL_SIZE + 50
                   , (MapModule.CELL_SIZE + 50));
            animationborder.RenderingLayer = 0.51f;
            animationborder.ColorGetter = () => Color.Black;//Colors[ColorIndex];
            AddAnimation(animationborder);

            var collider = new SolidCollider(MapModule.CELL_SIZE, MapModule.CELL_SIZE);
            AddCollider(collider);

            var speed = 30;
            var tick = 0;
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(() =>
            {
                tick++;
                if (tick == 50)
                {
                    tick = 0;
                    speed *= -1;
                }
                HorizontalSpeed = speed;
            });
        }
    }

    public class ElevatorPlatform : Thing
    {
        public ElevatorPlatform()
        {
            var animation = GeneratedContent.Create_knight_ground_2(
                               -5
                              , -5
                              , MapModule.CELL_SIZE + 10
                              , (MapModule.CELL_SIZE + 10));
            animation.RenderingLayer = 0.5f;
            var color = GameState.GetColor();
            animation.ColorGetter = () => color;
            AddAnimation(animation);

            var animationborder = GeneratedContent.Create_knight_ground_2(
                   -25
                   , -25
                   , MapModule.CELL_SIZE + 50
                   , (MapModule.CELL_SIZE + 50));
            animationborder.RenderingLayer = 0.51f;
            animationborder.ColorGetter = () => Color.Black;//Colors[ColorIndex];
            AddAnimation(animationborder);

            var collider = new SolidCollider(MapModule.CELL_SIZE, MapModule.CELL_SIZE);
            AddCollider(collider);

            var speed = 30;
            var tick = 0;
            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(() =>
            {
                tick++;
                if (tick == 50)
                {
                    tick = 0;
                    speed *= -1;
                }
                VerticalSpeed = speed;
            });
        }
    }
}