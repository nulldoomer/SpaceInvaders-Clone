using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace SpaceInvaders.Sprites
{
    internal class Sprite : ICloneable
    {
        private const float Scale = 3.5f;

        public readonly Texture2D Texture;
        public Vector2 Position;
        
        protected KeyboardState CurrentKey;
        protected KeyboardState PreviousKey;

        public Sprite Parent;

        public float LifeSpan = 0f;

        public bool IsRemoved = false;

        public virtual Rectangle Rectangle =>
            new(
                (int)Position.X,
                (int)Position.Y,
                Texture.Width * (int)Scale,
                Texture.Height * (int)Scale

            );


        protected Sprite(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, Color.White);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
