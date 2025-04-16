using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace SpaceInvaders.Sprites
{
    internal class Sprite : ICloneable
    {
        private static readonly float SCALE = 3.5f;

        public Texture2D texture;
        public Vector2 position;
        
        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;

        public Sprite Parent;

        public float LifeSpan = 0f;

        public bool IsRemoved = false;

        public virtual Rectangle Rectangle
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


        public Sprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Rectangle, Color.White);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
