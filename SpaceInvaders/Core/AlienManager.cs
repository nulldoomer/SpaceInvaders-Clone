using Microsoft.Xna.Framework;

namespace SpaceInvaders.Core;

public class AlienManager: AnimationManager
{
    public AlienManager(int numFrames, int numColumns, Vector2 size) : base(numFrames, numColumns, size)
    {
    }
}