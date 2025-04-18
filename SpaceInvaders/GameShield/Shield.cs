﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Sprites;

namespace SpaceInvaders.GameShield
{
    internal class Shield : Sprite
    {
        private const float Scale = 4f;


        public override Rectangle Rectangle =>
            new(
                (int)Position.X,
                (int)Position.Y,
                Texture.Width * (int)Scale,
                Texture.Height * (int)Scale

            );

        public Shield(Texture2D texture, Vector2 position) : base(texture, position) { }

    }
}
