using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Entities;
using SpaceInvaders.Utils.Enumerations;

namespace SpaceInvaders.Factories;

public class AlienFactory
{
    public static Alien CreateAlien(AlienType type, Vector2 position,
        Texture2D texture)
    {
        return type switch
        {
            AlienType.Squid => new Alien(texture, position),
            AlienType.Crab => new Alien(texture, position),
            AlienType.Octopus => new Alien(texture, position),
            _ => throw new ArgumentException("Unknown alien type: " + type)
        };
    }
    
    
}