using GameCore;
using Microsoft.Xna.Framework;

namespace MonoGameProject
{
    public class Armor : Thing
    {
        public Armor()
        {
            var collider = new Collider();
            collider.Width = MapModule.CELL_SIZE;
            collider.Height = MapModule.CELL_SIZE;
            AddCollider(collider);

            var animation = GeneratedContent.Create_knight_block(0, 0, 0.49f, collider.Width, collider.Height);
            animation.Color = Color.LightGreen;
            AddAnimation(animation);

            AddUpdate(new MoveHorizontallyWithTheWorld(this));
            AddUpdate(new DestroyIfLeftBehind(this));
        }
    }
}
