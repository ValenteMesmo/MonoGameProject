using GameCore;
using System;

namespace MonoGameProject
{
    public class Player : Humanoid
    {
        //usar a tecnica de borda para criar arvores randomicas...
        //  uma arvore sobre a outra, sem borda

        /*MUST
         * animacao de morte
         * 2 players
         * 2 tipos de monstros
         * attack anticipation (boss)
         * vincular abilidade do boss a aparencia
         * -corpo de lobo segue o player?
         * -corpo de diarreia de divide quando apanha?
         * -corpo de aranha só anda pulando?
         * -cara de dragao cospe fogo
         * -cara de aranha cospe ovos no chao
         */

            // ciclo lunar

        //State features
        //- os blocos aparecem quando player chega perto
        //- pulsar cor
        //- pulsar tamanho
        //- pulsar transparencia
        //- separar borda do miolo, para poder fazer o miolo transparente?

        //fazer uns tiles com olhos e bocas, que abrem quando player da as costas

        //rocks, trees, bushes, mushrooms, algo similar a um cacho de uva,abacaxi
        //criar os etc seguindo o padrão   pmggmppmmmgmppp (nao pula do p para g)
        //criar particulas para renderizar uma em cima da outra... sobre chao e sobre parede (vai ser mais randomizavel assim!)
        //  quadrado, triangulo, bola, x, redemoinho, costura
        // Janela em forma de fechadura...  aparece um olho de vez em quando?
        //macarrão de espinhos (planta)

        //eyes: crystal
        //background: pizza... fish
        

        //bau virar um player?

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

             |vvvvvvvvvvvv|__
             |         ______
            _|    --      |
            ____^^^^^^^^^^|

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

        //cara (2 layers... duas cores! uma para fuça...)
        //  de lobo, techugo, de urso, de boi, de cavalo, de porco, de aranha, de leão, de dragao, de caveira, cthulu, bills
        //olhos
        //  1, 2, 4, 6
        //testa
        //  chifre de boi, chifre de unicornio, coroa
        //pescoço
        //  juba, caveiras, colar do akuma
        //corpo (2 layers... duas cores! uma para barriga...)
        //  lobo,   cavalo, lagarto, chimera
        //costas
        //  asa (anjo e capeta), pentagrama, chifres, casco, capa, sela, asa de mosca
        // rabo
        //  lobo, leao, demonio, escorpião

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

        //ficar espada na parede, enquanto faz o slide.... isso vai servir para matar boss no estilo shadow of collosus
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