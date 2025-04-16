using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Sprites;

namespace SpaceInvaders.Enemies
{
    internal class Alien : Sprite
    {
        private const float Scale= 2f;

        public override Rectangle Rectangle =>
                new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    Texture.Width * (int)Scale,
                    Texture.Height * (int)Scale

                    );

        public Alien(Texture2D texture, Vector2 position) : base(texture, position)
        {


        }

        public override void Update(GameTime gameTime)
        {
            Displacement();
            
            base.Update(gameTime);
        }

        // TODO: Implement the displacement with collisions 
        private void Displacement()
        {
            Position.X += 0.4f;
        }
    }
}
