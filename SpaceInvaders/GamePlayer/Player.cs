using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.Sprites;
using System.Collections.Generic;

namespace SpaceInvaders.GamePlayer
{
    internal class Player : Sprite
    {

        public Bullet Bullet;

        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 6;
            }

            base.Update(gameTime);
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();

            if(_currentKey.IsKeyDown(Keys.D)||_currentKey.IsKeyDown(Keys.Right))
                position.X += 6;
            else if (_currentKey.IsKeyDown(Keys.A)||_currentKey.IsKeyDown
                (Keys.Left))
                position.X -= 6;

            if(_currentKey.IsKeyDown(Keys.W) && _previousKey.IsKeyUp(Keys.W))
            {
                AddBullet(sprites);
            }

        }

        private void AddBullet(List<Sprite> sprites)
        {
            var bullet = Bullet.Clone() as Bullet;
            bullet.LifeSpan = 2f;
            bullet.position = this.position;
            bullet.position.X += 23;
            bullet.Parent = this;

            sprites.Add(bullet);
        }
    }
}
