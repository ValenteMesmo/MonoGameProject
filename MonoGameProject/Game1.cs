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

        public ScreenFader ScreenFader;

        protected override void OnStart()
        {
            Camera.Clear();
            Camera.Pos = new Vector2(5000f, 4500f);
            Camera.Zoom =
                 0.1f;

            MainScreen();

            //StartGame();
        }

        public List<Player> Players = new List<Player>();
        int selectedLine = 0;
        int inputCooldown = 0;
        private void MainScreen()
        {
            line = 0;
            var MainManeu = new Thing();
            MainManeu.X = (int)((MapModule.CELL_SIZE * MapModule.CELL_NUMBER) / 2.4f);
            MainManeu.Y = (int)((MapModule.CELL_SIZE * MapModule.CELL_NUMBER) / 2.2f);

            MainManeu.AddUpdate(() =>
            {
                if (inputCooldown > 0)
                    inputCooldown--;

                if (inputCooldown > 0)
                    return;

                var keyboard = Microsoft.Xna.Framework.Input.Keyboard.GetState();

                if (keyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down))
                {
                    inputCooldown = 10;
                    selectedLine++;
                }
                if (keyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up))
                {
                    inputCooldown = 10;
                    selectedLine--;
                }
                if (keyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    MainManeu.Destroy();
                    StartGame();
                }

                if (selectedLine > 2)
                    selectedLine = 0;
                if (selectedLine < 0)
                    selectedLine = 2;
            });

            //MainManeu.AddAnimation(GeneratedContent.Create_knight_head_face(-2000,-2000,8000,8000));
            //MainManeu.AddAnimation(GeneratedContent.Create_knight_head_eyes(-2000,-2000,8000,8000));
            //MainManeu.AddAnimation(GeneratedContent.Create_knight_head_hair(-2000,-2000,8000,8000));

            //play sound... lower going down

            NewMethod(MainManeu, "New Game");
            NewMethod(MainManeu, "Continue");
            NewMethod(MainManeu, "Options");
            AddThing(MainManeu);
        }

        int line = 0;
        private void NewMethod(Thing start, string text)
        {
            var thisLine = line;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                    continue;

                var animation = GeneratedContent.Create_knight_number0(
                        i * MapModule.CELL_SIZE,
                        (int)((line * 1.25f) * MapModule.CELL_SIZE),
                        MapModule.CELL_SIZE,
                        MapModule.CELL_SIZE
                );

                animation.ColorGetter = () => selectedLine == thisLine ? Color.Red : Color.White;

                start.AddAnimation(animation);
            }

            line++;
        }

        private void StartGame()
        {
            var camerawall = new Thing();
            camerawall.AddCollider(new SolidCollider(MapModule.CELL_SIZE, MapModule.CELL_SIZE * 14) { OffsetX = -MapModule.CELL_SIZE / 2 });
            camerawall.AddCollider(new SolidCollider(MapModule.CELL_SIZE, MapModule.CELL_SIZE * 14) { OffsetX = (int)(MapModule.CELL_SIZE * 19.5f) });
            AddThing(camerawall);

            GameState.Load();

            ScreenFader = new ScreenFader();
            AddToWorld(ScreenFader);

            AddThing(new Enemy(AddToWorld) { X = 4000, Y = 4000 });

            var player = new Player(this, 0, AddThing);
            player.X = 1000;
            AddThing(player);

            var player2 = new Player(this, 1, AddThing);
            player2.X = 3000;
            AddThing(player2);

            if (GameState.State.BotExit)
                player.Y = (14 * MapModule.CELL_SIZE) + 1000;
            else if (GameState.State.MidExit)
                player.Y = (8 * MapModule.CELL_SIZE) + 1000;
            else
                player.Y = 2 * MapModule.CELL_SIZE + 1000;

            player2.Y = player.Y;

            //for (var i = 1; i < 7; i++)
            //{
            //    var player2 = new Player(this, 0, AddThing);
            //    player2.X = player.X + 200 * i;
            //    player2.Y = player.Y;
            //    AddThing(player2);
            //}
            Players.Clear();
            Players.Add(player);
            Players.Add(player2);
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
        }
    }

    public class ScreenFader : Thing
    {
        private int Red;
        private int Green;
        private int Blue;
        private int Alpha;
        private const int Speed = 100;
        private int duration;

        public ScreenFader()
        {
            var faderAnimation = GeneratedContent.Create_knight_Flash(-20000, -20000, 40000, 40000);
            faderAnimation.ColorGetter = () => new Color(Red, Green, Blue, Alpha);
            faderAnimation.RenderingLayer = 0f;
            AddAnimation(faderAnimation);

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
