using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.Enemies;
using SpaceInvaders.GamePlayer;
using SpaceInvaders.GameShield;
using SpaceInvaders.Sprites;
using System.Collections.Generic;
using System.Linq;

namespace SpaceInvaders
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private AnimationManager _animationManager;

        private List<Sprite> _sprites;
        private List<Alien> _squidAliens;
        private List<Alien> _crabAliens;
        private List<Alien> _octopusAliens;
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
            
            _squidAliens= new List<Alien>();
            _crabAliens = new List<Alien>();
            _octopusAliens = new List<Alien>();
            _shields = new List<Shield>();

            for (var i = 0; i < 11; i++)
            {
                _squidAliens.Add(new Alien(squidAlienTexture, new Vector2(275 + i * 
                    65, 150)));
                _crabAliens.Add(new Alien(crabAlienTexture, new Vector2(275 + i * 65, 200)));
                _crabAliens.Add(new Alien(crabAlienTexture, new Vector2(275 + i * 65, 250)));
                _octopusAliens.Add(new Alien(octopusAlienTexture, new Vector2(275 + i * 65, 300)));
                _octopusAliens.Add(new Alien(octopusAlienTexture, new Vector2(275 + i * 65, 350)));
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

            foreach (var alien in _octopusAliens.ToList())
            {
                foreach (var sprite in _sprites)
                {

                    if (sprite is Bullet bullet && bullet.Rectangle.Intersects(alien.Rectangle))
                    {
                        _octopusAliens.Remove(alien);
                        bullet.IsRemoved = true;
                        break;
                    }
                }
                alien.Update(gameTime);
            }
            
            foreach (var alien in _squidAliens.ToList())
            {
                foreach (var sprite in _sprites)
                {

                    if (sprite is Bullet bullet && bullet.Rectangle.Intersects(alien.Rectangle))
                    {
                        _squidAliens.Remove(alien);
                        bullet.IsRemoved = true;
                        break;
                    }
                }
                alien.Update(gameTime);
            }
            
            foreach (var alien in _crabAliens.ToList())
            {
                foreach (var sprite in _sprites)
                {

                    if (sprite is Bullet bullet && bullet.Rectangle.Intersects(alien.Rectangle))
                    {
                        _crabAliens.Remove(alien);
                        bullet.IsRemoved = true;
                        break;
                    }
                }
                alien.Update(gameTime);
            }

            base.Update(gameTime);
        }
        
        private void DrawRectangle(SpriteBatch spriteBatch, Rectangle rectangle,
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


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState : SamplerState.PointClamp);

            foreach (var sprite in _sprites)
                sprite.Draw(_spriteBatch);

            foreach(var alien in _squidAliens)
            {
                _spriteBatch.Draw(
                                alien.Texture,
                                alien.Rectangle,
                                _animationManager.GetFrame(),
                                Color.White
                                );

            }
            foreach(var crab in _crabAliens)
            {
                _spriteBatch.Draw(
                                crab.Texture,
                                crab.Rectangle,
                                _animationManager.GetFrame(),
                                Color.White
                                );
            }
            foreach(var octopus in _octopusAliens)
            {
                _spriteBatch.Draw(
                                octopus.Texture,
                                octopus.Rectangle,
                                _animationManager.GetFrame(),
                                Color.White
                                );

            }
            foreach (var shield in _shields)
            {
                shield.Draw(_spriteBatch);
            }
            // En el Draw()
            foreach (var bullet in _sprites.OfType<Bullet>())
            {
                var rect = bullet.Rectangle;
                DrawRectangle(_spriteBatch, rect, Color.Red);
            }
            foreach (var alien in _octopusAliens)
            {
                var rect = alien.Rectangle;
                DrawRectangle(_spriteBatch, rect, Color.Green);
            }
            
            foreach (var alien in _squidAliens)
            {
                var rect = alien.Rectangle;
                DrawRectangle(_spriteBatch, rect, Color.Green);
            }
            
            foreach (var alien in _crabAliens)
            {
                var rect = alien.Rectangle;
                DrawRectangle(_spriteBatch, rect, Color.Green);
            }
 
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
