using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Sprites;
using System.Collections.Generic;

namespace SpaceInvaders.GamePlayer
{
    internal class Bullet: Sprite
    {
        private float _timer;

        public Bullet(Texture2D texture, Vector2 position) : base(texture, position)
        {
            position = base.position;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            //To count every second the game is updating, use the _timer
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds; 

            if(_timer > LifeSpan)
                IsRemoved = true;

            position.Y -= 6;
            
        }

    }
}
