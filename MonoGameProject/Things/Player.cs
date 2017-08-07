using GameCore;
using System;

namespace MonoGameProject
{
    public class HitEffect : Thing
    {
        public HitEffect()
        {
            var animation = GeneratedContent.Create_knight_hit_effect(-400, -400, 0);
            animation.LoopDisabled = true;
            animation.ScaleX = animation.ScaleY = 10;
            //animation.Color = new Microsoft.Xna.Framework.Color(1, 1, 1, 0.5f);
            animation.FrameDuration = 2;
            AddAnimation(animation);

            var duration = 100;
            AddUpdate(() =>
            {
                duration--;
                if (duration <= 0)
                    Destroy();
            });
            AddUpdate(new MoveHorizontallyWithTheWorld(this));
        }
    }

    public class TakesDamage : UpdateHandler
    {
        private readonly Humanoid Parent;
        private readonly Game1 Game1;
        private int DamageDuration;
        private readonly Action<Thing> AddToTheWorld;

        public TakesDamage(Humanoid Parent, Game1 Game1, Action<Thing> AddToTheWorld)
        {
            this.Parent = Parent;
            this.Game1 = Game1;
            this.AddToTheWorld = AddToTheWorld;
            Parent.MainCollider.AddBotCollisionHandler(HandleFireball);
            Parent.MainCollider.AddTopCollisionHandler(HandleFireball);
            Parent.MainCollider.AddLeftCollisionHandler(HandleFireball);
            Parent.MainCollider.AddRightCollisionHandler(HandleFireball);
        }

        public void HandleFireball(Collider source, Collider target)
        {
            if (target.Parent is FireBall)
            {
                if (Parent.LegState == LegState.TakingDamage)
                    return;

                NewMethod(source);

                Parent.HitPoints--;
                Parent.LegState = LegState.TakingDamage;
                Parent.HorizontalSpeed = target.Parent.HorizontalSpeed / 2;
                Parent.VerticalSpeed = -50;

                DamageDuration = 25;
                target.Disabled = true;
                target.Parent.Destroy();
                if (Parent is Player)
                {
                    Game1.Sleep();
                    Game1.Camera.ShakeUp(20);
                }
            }
            else if (target is AttackCollider)
            {
                if (Parent.LegState == LegState.TakingDamage)
                    return;

                NewMethod(source);

                Parent.HitPoints--;
                Parent.LegState = LegState.TakingDamage;
                Parent.HorizontalSpeed = target.Parent.HorizontalSpeed / 2;
                Parent.VerticalSpeed = -50;

                DamageDuration = 25;
                if (target.Parent is Player)
                {
                    Game1.Sleep();
                    Game1.Camera.ShakeUp(20);
                }

                if (Parent.HitPoints < 0 && target.Parent is Player)
                {
                    if ((target.Parent as Player).TorsoState == TorsoState.Attack
                        || (target.Parent as Player).TorsoState == TorsoState.AttackCrouching)
                    {
                        if ((target.Parent as Player).FacingRight)
                            Parent.HorizontalSpeed = +100;
                        else
                            Parent.HorizontalSpeed = -100;
                    }

                    source.Disabled = true;
                }
            }
        }

        private void NewMethod(Collider source)
        {
            AddToTheWorld(new HitEffect() { X = source.X, Y = source.Y });
        }

        public void Update()
        {
            if (Parent.LegState == LegState.TakingDamage)
            {
                DamageDuration--;
                if (DamageDuration <= 0)
                {
                    DamageDuration = 0;
                    Parent.LegState = LegState.Falling;
                    if (Parent.HitPoints <= 0)
                    {
                        if (Parent is Player)
                            Game1.Restart();
                        else
                            Parent.Destroy();
                    }
                }
            }
        }
    }

    public class Player : Humanoid
    {
        /* criar um modulo assim (obrigar a usar walljump)
              __________
              __        |
                |>      | 
                |      <|
                |>      |___
                |        ___
                |^^^^^^^|
        */

        //evitar que player ande sobre o teto, no estilo mario bros
        //gradiente no fundo

        //animação de morte igual as da abertura de onepunch
        //      (com uma bela antecipação)
        //
        //mudar/tocar musica quando um baú aparecer na tela
        //      Ele deve brilhar também
        //animacao de beirada (quase caindo)
        //incluir misc stuff ... coisas que da para quebrar! caso voce erre um ataque, por exemplo.

        //spawn de zumbis
        //3 i/o   (2 é pouco)

        //vilarejo em chamas... pessoas sendo atacaDas?
        //arvore seca, cheia de criaturas voadoras que parecem passaros... faz barulho perto, que elas voam
        //monstro que vira criaturas voadoras quando apanhas
        //modulos de transicao... tipo castlevania entrando no castelo
        //ficar espada na parede, enquanto faz o slide.... isso vai servir para matar boss no estilo shadow of collosus
        //bad status... slow
        //plataforma "barco"... igual mario....
        //breakable blocks
        //traps
        // fire balls (vertical)
        private const int width = 1000;
        private const int height = 900;

        public Player(Game1 Game1, Action<Thing> AddToWorld) : base(
                new GameInputs(
                    new InputCheckerAggregation(
                         new GamePadChecker(0)
                        , new KeyboardChecker())
                ), Game1.Camera)
        {
            X = 1000;
            Y = 7000;
            HitPoints = 2;

            AddUpdate(new TakesDamage(this, Game1, AddToWorld));

            Action<Collider, Collider> HandleFireball = (s, t) =>
           {
               if (t.Parent is Armor)
               {
                   if (HitPoints < 2)
                   {
                       HitPoints = 2;
                       t.Parent.Destroy();
                   }
               }
           };
            //AddUpdate(() =>
            //{
            //    if (Inputs.ClickedAction1)
            //    {
            //        Game1.Sleep();
            //        Game1.Camera.ShakeUp(20);
            //    }
            //});

            MainCollider.AddBotCollisionHandler(HandleFireball);
            MainCollider.AddTopCollisionHandler(HandleFireball);
            MainCollider.AddLeftCollisionHandler(HandleFireball);
            MainCollider.AddRightCollisionHandler(HandleFireball);

            MainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot);
            MainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left);
            MainCollider.AddRightCollisionHandler(StopsWhenHitting.Right);
            MainCollider.AddTopCollisionHandler(StopsWhenHitting.Top);

            new HumanoidAnimatorFactory()
                .CreateAnimator(width, height, this);
        }

    }
}
