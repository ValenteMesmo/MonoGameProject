using GameCore;
using System;

namespace MonoGameProject
{
    public class Player : Humanoid
    {
        //reduce idle duration when damage taken
        //reduce skull head border

        //poeira de fall damage

        //abertura do trailer igual looneytoones ( https://www.youtube.com/watch?v=yqg9mloJk04 )

        //tentar causar uma boa primeira impressao.... (fazer pensar que é um jogo bom, com trofeus? coroas? coroa de mato na cabeça?)

        //eyebeam aumentar a distancia... puxar de baixo para cima

        //edge crouch de costas

        //make seeker fireball collide with each other

        //background igual o liadst
        //flash on hit

        //youtube trailler... fundo vermelho no texto, para parecer uma live

        //floresta de bambus;;; nevoa com fantasmas nadando
        //corvos (itachi genjutsu)
        //baloons
        //chuva de dinheiro - sacos de dinheiro que podem se explodidos
        //chuva de cookies

        //congelar a tela com alguma anim~ção de vitória ao derrotar o boss?

            //GAMEOVER fechar que nem fim de cartoon circulo fechando.

        //  floorr    
        //chess 
        //candy
        //stone
        //wood
        //grass

        //cowboy nas costas do boss?

        //mover o quadril na animacao 
        //voar sangue quando hittar o boss.. (c sotn)

        //creeps
        //poo

        //virar caveira gargalhando quando morrer?

        //pennywise dance

        //permitir que outros players transpassem a porta do boss (de fora para dentro)

        //remake head/eye animation
        //-----para evitar que 1 dos 4 olhos suma

        //add thunder effect on whip attack

        //usar a tecnica de borda para criar arvores randomicas...
        //  uma arvore sobre a outra, sem borda

        //fireball trail (like dragron from ch)

        //State features
        //- os blocos aparecem quando player chega perto
        //- pulsar cor
        //- pulsar tamanho
        //- pulsar transparencia
        //- cobertura (grama) destruída quando pisa
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

        //Se move quando o player se move
        //se move da esquerda para direita sem parar
        //Se move quando o player se move (no chão) (sempre na direção dele) 
        //se move para longe do jogador

        //cara 
        //  de lobo, techugo, de urso, de boi, de cavalo, de porco, de aranha, de leão, de dragao, de caveira, cthulu, bills
        //testa
        //  chifre de boi, chifre de unicornio, coroa
        //pescoço
        //  juba, caveiras, colar do akuma
        //corpo
        //  lobo, cavalo, lagarto, chimera
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

        //plataforma "barco"... igual mario....
        //breakable blocks
        //traps
        //fire balls (vertical)
        private const int width = 1000;
        private const int height = 900;

        public Player(Game1 Game1, int index, Action<Thing> AddToWorld) : base(
            new GameInputs(
                new InputCheckerAggregation(
                        new GamePadChecker(index)
                    , new KeyboardChecker())
            ), Game1.Camera
            , Game1.VibrationCenter)
        {
            HitPoints = 2;
            PlayerIndex = index;

            AddUpdate(() =>
            {
                if (HitPoints == 0)
                    Inputs.Disabled = true;
                else
                    Inputs.Disabled = false;
            });

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