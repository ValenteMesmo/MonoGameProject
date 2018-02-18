using System;
using GameCore;

namespace MonoGameProject
{
    public class BossBattleTrigger : Thing
    {
        private readonly Boss boss;
        private int targetDelay = 0;
        private Player player;

        public BossBattleTrigger(Boss boss)
        {
            this.boss = boss;
            var trigger = new Collider
            {
                Width = 18 * MapModule.CELL_SIZE,
                Height = 10 * MapModule.CELL_SIZE
            };

            trigger.AddBotCollisionHandler(asdasd);
            trigger.AddLeftCollisionHandler(asdasd);
            trigger.AddTopCollisionHandler(asdasd);
            trigger.AddRightCollisionHandler(asdasd);
            AddCollider(trigger);

            AddAfterUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(Update);
        }

        private void Update()
        {
            if (targetDelay > 0)
            {
                targetDelay--;
                if (targetDelay == 0)
                {
                    boss.player = player;
                }
            }
        }

        private void asdasd(Collider source, Collider target)
        {
            if (target.Parent is Player)
            {
                source.Disabled = true;
                GameState.State.BossMode = true;
                player = target.Parent as Player;
                targetDelay = 200;
            }
        }
    }
}

