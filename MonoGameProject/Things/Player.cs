using GameCore;
using Microsoft.Xna.Framework;
using System;

namespace MonoGameProject
{
    public class HitEffect : Thing
    {
        public Color Color = Color.White;
        public HitEffect()
        {
            var animation = GeneratedContent.Create_knight_hit_effect(-400, -400);
            animation.LoopDisabled = true;
            animation.ScaleX = animation.ScaleY = 10;
            animation.ColorGetter = () => Color;
            animation.FrameDuration = 2;
            animation.RenderingLayer = 0f;
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
            else if (target is AttackCollider ||
                target.Parent is Spikes)
            {
                if (Parent.LegState == LegState.TakingDamage)
                    return;

                NewMethod(source);

                Parent.HitPoints--;
                Parent.LegState = LegState.TakingDamage;
                Parent.HorizontalSpeed = target.Parent.HorizontalSpeed / 2;
                Parent.VerticalSpeed = Jump.maxJumpSpeed;

                DamageDuration = 25;
               // if (target.Parent is Player)
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
        /*MUST
         * 1 boss
         * animacao de dano
         * animacao de morte
         * 2 players
         * 2 tipos de monstros
         * bloquear teto
         * attack anticipation (boss)
         */
        /* criar um modulo assim (obrigar a usar walljump)
              __________
              __        |
                |>      | 
                |      <|
                |>      |___
                |        ___
                |^^^^^^^|

                ________
              __| <-X-> |___
              ____     _____
                |^^^^^^^| 

                ________
              __|vvvvvvv___
              ____ ___ _____
                |^^^^^^^| 

            dragao que dispara em 3 direcoes
                /
            D --
             \
        */
        //main menu
        //  5... 4... 3... 2... (estilo old movies?)
        //

        //Enemy Posturing
        //  The boss leaves itself open to attack when it takes time out of the battle just to taunt you.
        //Shielded Core Boss
        //  A boss whose weak point is protected by some kind of protrusion which needs to be destroyed before it takes damage
        //Smashed Eggs Hatching
        //  A boss's smashed eggs contain enemy monsters.
        //Teleport Spam
        //  A boss that teleports all over the place.
        //Tennis Boss
        //  You have to reflect his attacks back onto him to defeat him.
        //Whack-a-Monster 
        //  Fighting a Boss(or other critter) that is only vulnerable when it temporarily appears.
        //Wolfpack Boss
        //    A boss consisting of several Mooks who wouldn't be difficult by themselves, but when acting together provide a significant challenge.

        //Se move quando o player se move
        //se move da esquerda para direita sem parar
        //Se move quando o player se move (no chão) (sempre na direção dele) 
        //se move para longe do jogador

        //textura de intestino grosso, em uma dungeon
        //textura igual ao cenario do ricknmorty s3e4... (inferno)

        //mudar/tocar musica quando um baú aparecer na tela
        //      Ele deve brilhar também
        //animacao de beirada (quase caindo)
        //incluir misc stuff ... coisas que da para quebrar! caso voce erre um ataque, por exemplo.
        //quebrar misc stuff afeta o random dos baús (gera um novo)

        //spawn de zumbis

        //arvore seca, cheia de criaturas voadoras que parecem passaros... faz barulho perto, que elas voam
        //monstro que vira criaturas voadoras quando apanhas
        //modulos de transicao... tipo castlevania entrando no castelo

        //ficar espada na parede, enquanto faz o slide.... isso vai servir para matar boss no estilo shadow of collosus
        //bad status... slow
        //plataforma "barco"... igual mario....
        //breakable blocks
        //traps
        //fire balls (vertical)
        private const int width = 1000;
        private const int height = 900;

        public Player(Game1 Game1, Action<Thing> AddToWorld) : base(
                new GameInputs(
                    new InputCheckerAggregation(
                         new GamePadChecker(0)
                        , new KeyboardChecker())
                ), Game1.Camera)
        {
            HitPoints = 2;

            AddUpdate(new TakesDamage(this, Game1, AddToWorld));

            Action<Collider, Collider> HandleFireball = (s, t) =>
           {
               if (t.Parent is Armor)
               {
                   if (HitPoints < 2)
                   {
                       HitPoints = 2;
                       ArmorColor = (t.Parent as Armor).Color;
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
                .CreateAnimator(this);
        }

    }
}
