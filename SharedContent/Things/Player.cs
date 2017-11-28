using GameCore;
using Microsoft.Xna.Framework.Audio;
using MonoGameProject.Things;
using System;
using System.Linq;

namespace MonoGameProject
{
    public class Player : Humanoid
    {
        //planning:
        //fireball direcionada
        //fireball em espiral (ch boat)
        //criar atalhos nas teclas de funções para desabilitar fundo paralax, paredes, fireball trails, etc

        //informar collision point parar os handlers ( para criar particulas de collisao no lugar certo)
        //animação de mastigar depois de matar um player? no inimigo normal
        //FIREBALL: criar um collider menor para causar dano e um maior para sofrer dano

        //checkpoints... easy 2(10)... normal 1(100)... hard 0(1000)...

        //fireballtypes
        //  moves only if target is moving
        //  moves only if player facing back

        //animacao de fireball sem borda... para criar um trail maneiro

        //simular touch com o mouse só em DEBUG
        //mapear start para enter
        //usar start para iniciar o jogo tbm
        //z2 enemy with shield
        //handle damage even when on cooldown...(if last damage < current damage... )

        //long sleep on player/boss death

        //animação de inicio do boss... começa na cor da parede... acende os olhos e depois o resto

        //flash sky when raining

        //inimigos invulneráveis patrulhando pequenas plataformas

        //ventania carregando folhas das arvores:
        //https://youtu.be/K-JlevnccDk?t=48

        //baixar mais a tela! (pra melhorar jogabilidade mobile)
        //matar player que ficar parado muito tempo

        //stagios organigos, com olhos e bocas
        //  quando voce bate neles todo o estagio se contrai

        //add ground collider to the itemchest
        //  make stage with stacked itemchests

        //janemba stage

        //boss no tema de gelo fazem 3 blocos assim "/" que vão na direção do player e podem esmaga-lo
        //priorizar movimento para direita? arrastando os outros players?
        //boss dispara na direção do player! um lazer... que tal?
        //boss dispara para cima na direção do player... quando chega mais ou menos no x do player... começa a cair devagar
        //boss cria bolas de fogo que não se movem... igual os gremilins do castlevania
        //boss manda uma shockwave no chao
        //boss fireball top mid bot.... (skull head.... moves far from normal point)

        //must increase dificult with level
        //  boss speed, boss health? boss stage harder? (sem chão nas beradas?)
        // boss solta bomba que explode (tem que se esconder do outro lado do mapa)

        //flyibg boss pattern: left and right... dive when above player.
        //hurt faces for bosses?

        //players death animation

        //Main Screen
        //  new game, continue, options
        //Char Select Screen
        //  apertar qualquer botão para entrar na partida
        //      apertar start ou enter para iniciar
        //Options
        //  resolution default
        //  fullscreen enabled
        //  sound volume 100%
        //  background 1 enabled
        //  background 2 enabled
        //  background 3 enabled


        // mover a cabeça com analogico esquerdo
        // remove or add background according to map type
        //  cooler dying animation (longer) boss
        // dying animation player
        //  reduce idle duration when damage taken
        //permitir que o player desvie to attack melee abaixando (boss)

        //nightelf color pattern

        //level themes,   change color patterns to fixed pairs
        //-lava
        //  chão que quebra
        //  chão que esquenta? chão que sobe e desce da lava?
        //  labaredas (contra 3)
        //-snow
        //  diminuir visibilidade?
        //  moving platforms horizontal... over spikes


        //"barra de life" ser o torso... casco quebrando... pelos caindo... ferida abrindo?
        //um boss que nao sai do lugar
        //um boss que se move seguindo o player (x e y) em alta velocidade
        //boss humanoid só pode usar spells de longe .. tá injusto
        //amiibos easter eggs (marios mustache?)

        //epic sax guy
        //dimitri hands

        //boss voador +cara de coelho + 4 olhos, está muito fraco
        //     O que fazer? mudar padrao de voo? fazer 

        //HEALTH nos projéteis??? yes
        //barulho de btn no touch

        //LIGAR O BOSS MAIS CEDO. ta mto apelao, principalemtne o lobo

        //shoulders and triggers to make sounds

        //jogar contra 3 de super nintendo. inspiração platformer

        //espada
        //foice
        //hammer

        //staff
        //wand
        //lampada

        //pause game

        //pedras voando no estilo dbz
        //onda de lava passando... pra ter que pular
        //musica em quanto houver fireball

        //reduzir o playerfinder do wolfboss
        // "it" like gauthled II  (uma chapeu de burro? ou uma coroa? pomba! libelula, mosquito [fazendo barulho])
        //turn into a controllable ghost after death
        // comes back to life on checkpoint

        //grunidos no timing certo da musica
        //  quando atacar, pular, apanhar, pegar item, matar
        //      , quebrar, sweetdreams, headbump
        //  monstros falarem "tutum" e "ó" no ritmo da musica?

        //break spikes on hit
        //stalagmite, roots, cipós
        //frog eyes?
        //star iris eye (cp hd)
        //leave breakable skulls when enemy killed
        //reduce skull head border

        //animar frames do braço parado

        //poeira de fall damage

        //abertura do trailer igual looneytoones ( https://www.youtube.com/watch?v=yqg9mloJk04 )

        //eyebeam aumentar a distancia... puxar de baixo para cima

        //edge crouch de costas

        //make seeker fireball collide with each other

        //background igual o liadst

        //youtube thumbnail... fundo vermelho no texto, para parecer uma live

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

        //poo

        //virar caveira gargalhando quando morrer?

        //pennywise dance

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

        //simons quest...   moving single cell platforms (up and down)
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

        //head 
        //  cara  de lobo, Mosca (mão tbm), bulldog, tengu, dolly grn, creeper, slender, preguiça, de urso, de boi, de cavalo, de porco, de aranha, de leão, de dragao, de caveira, cthulu, bills
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
        //fireballs vertical lenta...
        private const int width = 1000;
        private readonly Game1 Game1;

        public Player(
            Game1 Game1
            , int index
            , GameInputs GameInputs
            , Action<Thing> AddToWorld
            ) : base(
                GameInputs
                , Game1
                , index)
        {
            this.Game1 = Game1;
            HitPoints = 2;

            new CrushedByCollision(this);

            AddUpdate(new TakesDamage(this, Game1, AddToWorld));

            Action<Collider, Collider> PickupArmor = (s, t) =>
            {
                if (t.Parent is Armor)
                {
                    var armorColor = (t.Parent as Armor).Color;
                    HitPoints = 2;
                    SetArmorColor(armorColor);
                    t.Disabled = true;
                    t.Parent.Destroy();
                    Game1.ScreenFader.Flash(armorColor.R, armorColor.G, armorColor.B, X, Y);
                    Game1.VibrationCenter.Vibrate(Inputs, 5, 0.25f);
                    Game1.MusicController.Queue("tumtum");
                }
                else if (t.Parent is Weapon)
                {
                    var weapon = t.Parent as Weapon;

                    if (weapon.Type == WeaponType.Sword)
                        ChangeToSword();
                    else if (weapon.Type == WeaponType.Whip)
                        ChangeToWhip();
                    else if (weapon.Type == WeaponType.Wand)
                        ChangeToWand();

                    t.Parent.Destroy();
                    t.Disabled = true;
                    Game1.ScreenFader.Flash(weapon.Color.R, weapon.Color.G, weapon.Color.B, X, Y);
                    Game1.VibrationCenter.Vibrate(Inputs, 5, 0.25f);
                    Game1.MusicController.Queue("tumtum");
                }
            };

            MainCollider.AddBotCollisionHandler(PickupArmor);
            MainCollider.AddTopCollisionHandler(PickupArmor);
            MainCollider.AddLeftCollisionHandler(PickupArmor);
            MainCollider.AddRightCollisionHandler(PickupArmor);

            MainCollider.AddBotCollisionHandler(StopsWhenHitting.Bot<BlockVerticalMovement>());
            MainCollider.AddLeftCollisionHandler(StopsWhenHitting.Left<BlockHorizontalMovement>());
            MainCollider.AddRightCollisionHandler(StopsWhenHitting.Right<BlockHorizontalMovement>());
            MainCollider.AddTopCollisionHandler(StopsWhenHitting.Top<BlockVerticalMovement>());
            MainCollider.AddLeftCollisionHandler(HandleLeftBossLock);

            var factory = new HumanoidAnimatorFactory();
            factory.CreateAnimator(this, index);
            factory.CreateHairBonus(this, AddToWorld);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            if (Game1.Players.Count() > 1)
            {
                foreach (var slot in Game1.PlayersSlots)
                {
                    if (slot.Player == this)
                    {
                        slot.Player = null;
                        slot.DeathCooldown = 500;
                    }
                }

                return;
            }

            Game1.Restart();
        }

        private void HandleLeftBossLock(Collider source, Collider target)
        {
            if (target is GroundFromLeftToRightCollider)
            {
                if (HorizontalSpeed < 0)
                    HorizontalSpeed = 0;

                X = target.Right() - source.OffsetX + StopsWhenHitting.KNOCKBACK;
            }
        }
    }

    class CrushedByCollision
    {
        private readonly Humanoid parent;
        private bool TopCollison;
        private bool BotCollison;
        private bool LeftCollision;
        private bool RightCollision;


        public CrushedByCollision(Humanoid parent)
        {
            this.parent = parent;
            parent.MainCollider.AddTopCollisionHandler(HandleTopCollision);
            parent.MainCollider.AddBotCollisionHandler(HandleBotCollision);
            parent.MainCollider.AddLeftCollisionHandler(HandleLeftCollision);
            parent.MainCollider.AddRightCollisionHandler(HandleRightCollision);
            parent.AddUpdate(Update);
        }

        private void HandleRightCollision(Collider source, Collider target)
        {
            if (target is BlockHorizontalMovement)
            {
                RightCollision = true;
                if (LeftCollision)
                    parent.Destroy();
            }
        }

        private void HandleLeftCollision(Collider source, Collider target)
        {
            if (target is BlockHorizontalMovement)
            {
                LeftCollision = true;
                if (RightCollision)
                    parent.Destroy();
            }
        }

        private void Update()
        {
            TopCollison = false;
            BotCollison = false;
            LeftCollision = false;
            RightCollision = false;
        }

        private void HandleTopCollision(Collider source, Collider target)
        {
            if (target is BlockVerticalMovement)
            {
                TopCollison = true;
                if (BotCollison)
                    parent.Destroy();
            }
        }

        private void HandleBotCollision(Collider source, Collider target)
        {
            if (target is BlockVerticalMovement)
            {
                BotCollison = true;
                if (TopCollison)
                    parent.Destroy();
            }
        }
    }
}