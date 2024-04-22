using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShootMeRiders.Screens;
using System;

namespace ShootMeRiders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameScreen _gameScreen;
        private MenuScreen _menuScreen;
        private bool _isInGame = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Inicializa as telas do jogo e do menu
            _gameScreen = new GameScreen(_graphics, Content, this);
            InitializeMenuScreen();

            // inicializa a screen creditos


            base.Initialize();
        }

        // Método para inicializar o MenuScreen
        private void InitializeMenuScreen()
        {
            Texture2D backgroundTexture = Content.Load<Texture2D>("Background/Shot-Me-Riders");

            Texture2D buttonTexturePlay = Content.Load<Texture2D>("Buttons/jogar-texture");
            Texture2D buttonTextureCredits = Content.Load<Texture2D>("Buttons/creditos-texture");
            Texture2D buttonTextureExit = Content.Load<Texture2D>("Buttons/sair-texture");

            // Definir ações para os botões
            Action actionPlay = () =>
            {
                _isInGame = true;
            };
            Action actionCredits = () => Console.WriteLine("Botão Créditos pressionado");
            Action actionExit = () => Exit();

            _menuScreen = new MenuScreen(backgroundTexture, buttonTexturePlay, buttonTextureCredits, buttonTextureExit, actionPlay, actionCredits, actionExit, GraphicsDevice.Viewport);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                _isInGame = false;

            // Atualiza a tela correspondente com base no estado
            if (_isInGame)
            {
                _gameScreen.Update(gameTime);
            }
            else
            {
                _menuScreen.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            if (_isInGame)
            {
                _gameScreen.Draw(_spriteBatch);
            }
            else
            {
                _menuScreen.Draw(_spriteBatch);
            }

            _spriteBatch.End();
        }
    }
}