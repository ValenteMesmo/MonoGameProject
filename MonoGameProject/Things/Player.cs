using GameCore;
using System;

namespace MonoGameProject
{
    public class Player : Humanoid
    {
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
        public int DamageDuration = 0;

        public Player(
            PlayerInputs InputRepository
            , Game1 Game1
            ) : base(
                InputRepository
                , Game1)
        {
            X = 1000;
            Y = 7000;

            var hitpoints = 2;
            Action<Collider, Collider> HandleFireball = (s, t) =>
            {
                if (t.Parent is FireBall && State != PlayerState.TakingDamage)
                {
                    if (State == PlayerState.TakingDamage)
                        return;

                    hitpoints--;
                    State = PlayerState.TakingDamage;
                    HorizontalSpeed = t.Parent.HorizontalSpeed;
                    VerticalSpeed = -50;

                    DamageDuration = 25;
                    t.Disabled = true;
                    t.Parent.Destroy();

                }
                if (t.Parent is Armor)
                {
                    if (hitpoints < 2)
                    {
                        hitpoints = 2;
                        t.Parent.Destroy();
                    }
                }
            };
            AddUpdate(() =>
            {
                if (State == PlayerState.TakingDamage)
                {
                    DamageDuration--;
                    if (DamageDuration <= 0)
                    {
                        DamageDuration = 0;
                        State = PlayerState.FallingRight;
                        if (hitpoints == 0)
                            Game1.Restart();
                    }
                }
            });

            //AddUpdate(() => Game.LOG += X);

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
