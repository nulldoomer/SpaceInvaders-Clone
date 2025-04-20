using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.Core;
using System.Collections.Generic;

namespace SpaceInvaders.Entities
{
    internal class Player : Sprite, ICloneable
    {
        public Bullet Bullet;

        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D) || 
                Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Position.X += 6;
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.A) || 
                Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Position.X -= 6;
            }
            base.Update(gameTime);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            PreviousKey = CurrentKey;
            CurrentKey = Keyboard.GetState();

            if(CurrentKey.IsKeyDown(Keys.D)||CurrentKey.IsKeyDown(Keys.Right))
                Position.X += 6;
            else if (CurrentKey.IsKeyDown(Keys.A)|| CurrentKey.IsKeyDown
                (Keys.Left))
                Position.X -= 6;

            if(CurrentKey.IsKeyDown(Keys.W) && PreviousKey.IsKeyUp(Keys.W)
               || CurrentKey.IsKeyDown(Keys.Up) && PreviousKey.IsKeyUp(Keys.Up))
            {
                AddBullet(sprites);
            }
        }

        private void AddBullet(List<Sprite> sprites)
        {
            if (Bullet.Clone() is not Bullet bullet) return;
            bullet.LifeSpan = 2f;
            bullet.Position= Position;
            bullet.Position.X += 23;
            bullet.Parent = this;

            sprites.Add(bullet);
        }
    }
}
