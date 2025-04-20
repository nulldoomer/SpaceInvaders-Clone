using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.Entities;

namespace SpaceInvaders.Factories;

public class AlienFactory
{
    public static Alien CreateAlien(string type, Vector2 position,
        Texture2D texture)
    {
        switch (type)
        {
            case "Squid":
                return new Alien(texture, position);
            case "Crab":
                return new Alien(texture, position);
            case "Octopus":
                return new Alien(texture, position);
            default:
                throw new ArgumentException("Unknown alien type: " + type);
        }
    }
}