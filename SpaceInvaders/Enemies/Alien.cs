using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Sprites;

namespace SpaceInvaders.Enemies
{
    internal class Alien : Sprite
    {
        private static readonly float SCALE = 2f;


        public override Rectangle Rectangle 
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    texture.Width * (int)SCALE,
                    texture.Height * (int)SCALE

                    );
            }

        }

        public Alien(Texture2D texture, Vector2 position) : base(texture, position)
        {


        }

        public override void Update(GameTime gameTime)
        {
            Displacement();
            
            base.Update(gameTime);
        }

        // TODO: Implement the displacement with collisions 
        public void Displacement()
        {
            position.X += 0.4f;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {

            base.Draw(spriteBatch);
        }

    }
}
