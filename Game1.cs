using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShootMeRiders.Model;

namespace ShootMeRiders;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Background _backgroundTexture;
    private Knifeman _knifeman;
    Viewport _viewport;
    List<Knifeman> _enemies = new List<Knifeman>();

    private Button _exitButton;

    Vector2[] _layerPositions = new Vector2[3]
    {
        new Vector2(0, 350), // mais próxima da tela
        new Vector2(0, 320),
        new Vector2(0, 300)  // mais longe da tela
    };

    Random _random = new Random();
    bool _rightToLeft = false; // define se o inimigo aparecerá da direita p esquerda
    int _elapsedTime = 0; // tempo decorrido de jogo
    int _spawTime = 1000; // tempo de spaw p novos inimigos


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
        _knifeman.Initialize();

        _exitButton.Position = new Point(350, 250);
   
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        _backgroundTexture = new Background(this);
        _knifeman = new Knifeman();
        _knifeman.LoadContent(Content);
        _viewport = GraphicsDevice.Viewport;

        Texture2D exitImage = Content.Load<Texture2D>("exit_button");
        _exitButton = new Button(exitImage, Exit);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _elapsedTime += gameTime.ElapsedGameTime.Milliseconds;  

        if(_elapsedTime > _spawTime)
        {
            _elapsedTime = 0;
            Knifeman newKnifeman = new Knifeman();
            newKnifeman.Initialize();
            newKnifeman.LoadContent(Content);
            int _layer = _random.Next(0, 3); 
            Vector2 _position = _layerPositions[_layer];
            float _xVelocity = _random.Next(2, 9);// velocidade "aleatória" p cada inimigo

            _rightToLeft = _random.Next(0, 10) > 5; //define "aleatoriamente" de q lado vem o inimigo
            if(_rightToLeft)
            {
                _position.X = _viewport.Width;
                _xVelocity *= -1;
            }

            newKnifeman.SetEnemyPosition(_xVelocity, _layer);
            newKnifeman.Position = _position;

            _enemies.Add(newKnifeman);
        }

        for(int i = 0;  i < _enemies.Count; i++)
        {
            _enemies[i].Update(deltaTime);

            if (_enemies[i].IsEnable == false
                || _enemies[i].Position.X < _viewport.X
                || _enemies[i].Position.X > _viewport.Width)
            {
                _enemies.RemoveAt(i);
            }
        }

        _exitButton.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
     
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _backgroundTexture.Draw(_spriteBatch);

        for (int i = 0; i < _enemies.Count; i++)
        {
            _enemies[i].Draw(_spriteBatch);
        }

        _spriteBatch.End();
        base.Draw(gameTime);

        _exitButton.Draw(_spriteBatch);
    }
}
