using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvaders.Utils;

public class CollisionRectangle:Game
{
    
    public CollisionRectangle(SpriteBatch spriteBatch, Rectangle rectangle,
        Color color)
    {
        var pixel = new Texture2D(GraphicsDevice, 1, 1);
        pixel.SetData(new[] { Color.White });

        // Top
        spriteBatch.Draw(pixel, new Rectangle(rectangle.X, rectangle.Y,
            rectangle.Width, 1), color);
        // Bottom
        spriteBatch.Draw(pixel, new Rectangle(rectangle.X, 
            rectangle.Y + rectangle.Height - 1, rectangle.Width, 1), color);
        // Left
        spriteBatch.Draw(pixel, new Rectangle(rectangle.X, rectangle.Y,
            1, rectangle.Height), color);
        // Right
        spriteBatch.Draw(pixel, new Rectangle(rectangle.X + rectangle.Width - 1, rectangle.Y,
            1, rectangle.Height), color);
    }
}