using GameCore;
using System;

namespace MonoGameProject
{
    public class TakesDamage : UpdateHandler
    {
        private readonly Humanoid Parent;
        private readonly Game1 Game1;
        private int DamageDuration;

        public TakesDamage(Humanoid Parent, Game1 Game1)
        {
            this.Parent = Parent;
            this.Game1 = Game1;
            Parent.MainCollider.AddBotCollisionHandler(HandleFireball);
            Parent.MainCollider.AddTopCollisionHandler(HandleFireball);
            Parent.MainCollider.AddLeftCollisionHandler(HandleFireball);
            Parent.MainCollider.AddRightCollisionHandler(HandleFireball);
        }

        public void HandleFireball(Collider s, Collider t)
        {
            if (t.Parent is FireBall)
            {
                if (Parent.LegState == LegState.TakingDamage)
                    return;

                Parent.HitPoints--;
                Parent.LegState = LegState.TakingDamage;
                Parent.HorizontalSpeed = t.Parent.HorizontalSpeed / 2;
                Parent.VerticalSpeed = -50;

                DamageDuration = 25;
                t.Disabled = true;
                t.Parent.Destroy();
                Game1.Sleep();
                Game1.Camera.ShakeUp(20);
            }
            else if (t is AttackCollider)
            {
                if (Parent.LegState == LegState.TakingDamage)
                    return;

                Parent.HitPoints--;
                Parent.LegState = LegState.TakingDamage;
                Parent.HorizontalSpeed = t.Parent.HorizontalSpeed / 2;
                Parent.VerticalSpeed = -50;

                DamageDuration = 25;
                Game1.Sleep();
                Game1.Camera.ShakeUp(20);

                if (Parent.HitPoints < 0 && t.Parent is Player)
                {
                    Parent.HorizontalSpeed = t.Parent.HorizontalSpeed;
                    //Parent.VerticalSpeed = -50;

                    s.Disabled = true;
                }
            }
        }

        public void Update()
        {
            if (Parent.LegState == LegState.TakingDamage)
            {
                DamageDuration--;
                if (DamageDuration <= 0)
                {
                    DamageDuration = 0;
                    Parent.LegState = LegState.FallingRight;
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

        public Player(Game1 Game1) : base(
                new GameInputs(
                    new InputCheckerAggregation(
                         new GamePadChecker(0)
                        , new KeyboardChecker())
                ), Game1.Camera)
        {
            X = 1000;
            Y = 7000;
            HitPoints = 2;

            AddUpdate(new TakesDamage(this, Game1));

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
