using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.Core;
using SpaceInvaders.Entities;
using System.Collections.Generic;
using System.Linq;
using SpaceInvaders.Factories;
using SpaceInvaders.Utils;
using SpaceInvaders.Utils.Enumerations;

namespace SpaceInvaders
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private AnimationManager _animationManager;
        private CollisionRectangle  _collisionRectangle;
        
        private List<Alien>  _aliens;
        private List<Sprite> _sprites;
        private List<Shield> _shields;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
        
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            var playerTexture = Content.Load<Texture2D>("PlayerSprites/Player-1");
            var squidAlienTexture = Content.Load<Texture2D>
                ("Enemies/CalamarAlien/calamar_moving");
            var crabAlienTexture = Content.Load<Texture2D>("Enemies/CrabAlien/cangrejo_moving");
            var octopusAlienTexture = Content.Load<Texture2D>("Enemies/OctopusAlien/pulpo_moving");
            var shieldTexture = Content.Load<Texture2D>("Shield Image");
            
            _aliens = new List<Alien>();
            _shields = new List<Shield>();

            for (var i = 0; i < 11; i++)
            {
                _aliens.Add(AlienFactory.CreateAlien(AlienType.Squid,new Vector2(275 + i * 65, 150),squidAlienTexture));
                _aliens.Add(AlienFactory.CreateAlien(AlienType.Crab, new Vector2(275 + i * 65, 200),crabAlienTexture));
                _aliens.Add(AlienFactory.CreateAlien(AlienType.Crab, new Vector2(275 + i * 65, 250),crabAlienTexture));
                _aliens.Add(AlienFactory.CreateAlien(AlienType.Octopus, new Vector2(275 + i * 65, 300),octopusAlienTexture));
                _aliens.Add(AlienFactory.CreateAlien(AlienType.Octopus, new Vector2(275 + i * 65, 350),octopusAlienTexture));
            }
            for(var i = 0; i< 4; i++)
            {
                _shields.Add(new Shield(shieldTexture, new Vector2(275 + i * 180, 600)));
            }
            
            var playerPosition = new Vector2(600, 770);
            _sprites = new List<Sprite>()
            {
                new Player(playerTexture, playerPosition)
                {
                    Bullet = new Bullet(Content.Load<Texture2D>("PlayerSprites/Player Shot Sprite")
                    , playerPosition)
                }
            };
            _animationManager = new AnimationManager(2, 2, new Vector2(16, 8));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            //Changing the resolution
            _graphics.PreferredBackBufferWidth = 1280; 
            _graphics.PreferredBackBufferHeight = 900; 
            _graphics.ApplyChanges();

            foreach (var sprite in _sprites.ToArray())
            {
                sprite.Update(gameTime, _sprites);
            }
            for( var i = 0; i<_sprites.Count; i++)
            {
                if (!_sprites[i].IsRemoved) continue;
                _sprites.RemoveAt(i);
                i--;
            }
            
            foreach(var shield in _shields)
            {
                shield.Update(gameTime);
            }
            _animationManager.Update();

            foreach (var alien in _aliens.ToList())
            {
                foreach (var sprite in _sprites)
                {

                    if (sprite is Bullet bullet && bullet.Rectangle.Intersects(alien.Rectangle))
                    {
                        _aliens.Remove(alien);
                        bullet.IsRemoved = true;
                        break;
                    }
                }
                alien.Update(gameTime);
            }
            

            base.Update(gameTime);
        }
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState : SamplerState.PointClamp);

            foreach (var sprite in _sprites)
                sprite.Draw(_spriteBatch);

            foreach (var alien in _aliens)
            {
                _spriteBatch.Draw(
                    alien.Texture,
                    alien.Rectangle, 
                    _animationManager.GetFrame(),
                    Color.White
                    );

                _collisionRectangle= new CollisionRectangle(_spriteBatch, alien.Rectangle, Color.Azure);
            }

            foreach (var shield in _shields)
            {
                shield.Draw(_spriteBatch);
            }
            // En el Draw()
            foreach (var bullet in _sprites.OfType<Bullet>())
            {
                var rect = bullet.Rectangle;
                _collisionRectangle = new CollisionRectangle(_spriteBatch, rect, Color.Red);
            }
 
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
