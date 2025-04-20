using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Sprites;

namespace SpaceInvaders.Enemies
{
    public class Alien : Sprite
    {
        private const float Scale= 2f;
        private int Hp { get; set; }

        public override Rectangle Rectangle =>
                new Rectangle(
                    (int)Position.X + 6,
                    (int)Position.Y,
                    (Texture.Width * (int)Scale) - 12,
                    (Texture.Height * (int)Scale)
                    );

        public Alien(Texture2D texture, Vector2 position) : base(texture,
            position)
        {
            Hp = 1;
        }

        public void TakeDamage(int damage)
        {
            Hp -= damage;
        }

        public override void Update(GameTime gameTime)
        {
            Displacement();
            base.Update(gameTime);
        }

        // TODO: Implement the displacement with collisions, every time the
        // animation occurs it have to displace
        private void Displacement()
        {
            Position.X += 0.4f;
        }
        
    }
}
