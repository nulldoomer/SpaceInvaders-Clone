using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.Enemies;
using SpaceInvaders.GamePlayer;
using SpaceInvaders.GameProtection;
using SpaceInvaders.Sprites;
using System.Collections.Generic;

namespace SpaceInvaders
{
    public class Game1 : Game
    {
        
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private AnimationManager _animationManager;
        

        private List<Sprite> _sprites;
        private List<Alien> _calamarAliens;
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
            var calamarAlienTexture = Content.Load<Texture2D>("Enemies/CalamarAlien/calamar_moving");
            var crabAlienTexture = Content.Load<Texture2D>("Enemies/CrabAlien/cangrejo_moving");
            var octopusAlienTexture = Content.Load<Texture2D>("Enemies/OctopusAlien/pulpo_moving");
            var shieldTexture = Content.Load<Texture2D>("Shield Image");
            
            
            _calamarAliens = new();
            _crabAliens = new();
            _octopusAliens = new();
            _shields = new();
            


            for (int i = 0; i < 11; i++)
            {
                _calamarAliens.Add(new Alien(calamarAlienTexture, new Vector2(275 + i * 60, 150)));
                _crabAliens.Add(new Alien(crabAlienTexture, new Vector2(275 + i * 60, 200)));
                _crabAliens.Add(new Alien(crabAlienTexture, new Vector2(275 + i * 60, 250)));
                _octopusAliens.Add(new Alien(octopusAlienTexture, new Vector2(275 + i * 60, 300)));
                _octopusAliens.Add(new Alien(octopusAlienTexture, new Vector2(275 + i * 60, 350)));
            }
            for(int i = 0; i< 4; i++)
            {

                _shields.Add(new Shield(shieldTexture, new Vector2(275 + i * 180, 600)));
            }
            

            var playerPosition = new Vector2(600, 770);
            _sprites = new()
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

            for( int i = 0; i<_sprites.Count; i++)
            {
                if (_sprites[i].IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }
            }
            foreach(var shield in _shields)
            {
                shield.Update(gameTime);
            }
            _animationManager.Update();

            foreach (var alien in _octopusAliens)
            {
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

            foreach(var alien in _calamarAliens)
            {
                _spriteBatch.Draw(
                                alien.texture,
                                alien.Rectangle,
                                _animationManager.GetFrame(),
                                Color.White
                                );

            }
            foreach(var crab in _crabAliens)
            {
                _spriteBatch.Draw(
                                crab.texture,
                                crab.Rectangle,
                                _animationManager.GetFrame(),
                                Color.White
                                );
            }
            foreach(var octopus in _octopusAliens)
            {
                _spriteBatch.Draw(
                                octopus.texture,
                                octopus.Rectangle,
                                _animationManager.GetFrame(),
                                Color.White
                                );

            }
            foreach (var shield in _shields)
            {
                shield.Draw(_spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
