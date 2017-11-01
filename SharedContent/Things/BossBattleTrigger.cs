using GameCore;

namespace MonoGameProject
{
    public class BossBattleTrigger : Thing
    {
        public BossBattleTrigger()
        {
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
        }

        private void asdasd(Collider source, Collider target)
        {
            if (target.Parent is Player)
            {
                source.Disabled = true;
                GameState.State.BossMode = true;
            }
        }
    }
}

