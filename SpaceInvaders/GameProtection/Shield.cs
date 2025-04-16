using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Sprites;

namespace SpaceInvaders.GameProtection
{
    internal class Shield : Sprite
    {
        private static readonly float SCALE = 4f;


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
        public Shield(Texture2D texture, Vector2 position) : base(texture, position) { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
