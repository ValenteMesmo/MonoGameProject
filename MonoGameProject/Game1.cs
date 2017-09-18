using GameCore;
using Microsoft.Xna.Framework;
using MonoGameProject.Things;

namespace MonoGameProject
{
    public class Game1 : Game
    {
        public Game1() : base(new GeneratedContent()) { }

        protected override void OnStart()
        {
            GameState.Load();
            var player = new Player(this, AddThing);
            player.X = 1000;
            if (GameState.State.BotExit)
                player.Y = (14 * MapModule.CELL_SIZE) + 1000;
            else if (GameState.State.MidExit)
                player.Y = (8 * MapModule.CELL_SIZE) + 1000;
            else
                player.Y = 2 * MapModule.CELL_SIZE + 1000;

            var WorldMover = new WorldMover(Camera);
            AddThing(WorldMover);
            AddThing(player);
            AddThing(new PlatformCreator(WorldMover, AddThing, this));

            var roof = new Thing();
            roof.AddCollider(new SolidCollider { OffsetY = -MapModule.CELL_SIZE, Height = 4 * MapModule.CELL_SIZE, Width = 16 * 2 * MapModule.CELL_SIZE });
            AddThing(roof);
            var runningOnGoodPc = false;
            {
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, width, height) => GeneratedContent.Create_knight_dead_tree(x, y), 3, 0.91f));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, width, height) => GeneratedContent.Create_knight_dead_tree(x, y), 2, 0.90f));
                AddThing(new ParalaxBackgroundCreator(WorldMover, AddThing, this, (x, y, width, height) => GeneratedContent.Create_knight_dead_tree(x, y, 500, 400), 1, 0.01f));
            }

            var rotatingBall = new Thing();
            var ballAnimation = GeneratedContent.Create_knight_ground(0, 0, 1000, 1000);
            ballAnimation.RenderingLayer = 0;
            rotatingBall.AddAnimation(ballAnimation);
            rotatingBall.X = player.X;
            rotatingBall.Y = player.Y;

            var max = 2000;
            var speed = 100;

            var horizontalSpeed = max;
            var verticalSpeed = 0;
            var velocityVertical = speed;
            var velocityHorizontal = -speed;

            //rotatingBall.AddUpdate(new MoveHorizontallyWithTheWorld(rotatingBall));
            rotatingBall.AddUpdate(() =>
            {
                if (horizontalSpeed < -max)
                    velocityHorizontal = speed;
                if (horizontalSpeed > max)
                    velocityHorizontal = -speed;

                if (verticalSpeed < -max)
                    velocityVertical = speed;
                if (verticalSpeed > max)
                    velocityVertical = -speed;

                horizontalSpeed += velocityHorizontal;
                verticalSpeed += velocityVertical;

                rotatingBall.X = horizontalSpeed + player.X;
                rotatingBall.Y = verticalSpeed + player.Y;
                //+ (player.groundChecker.Colliding<SomeKindOfGround>() ? 0 : player.VerticalSpeed);
            });
            AddThing(rotatingBall);
        }
    }
}
