using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Core;

namespace SpaceInvaders.Entities
{
    public class Alien : Sprite
    {
        private const float Scale= 2f;

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
