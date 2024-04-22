using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using ShootMeRiders.Model;

namespace ShootMeRiders.Screens
{
    public class GameScreen
    {
        private ContentManager content;
        private Background _backgroundTexture;
        private Knifeman _knifeman;
        private Viewport _viewport;
        private List<Knifeman> _enemies = new List<Knifeman>();
        private Vector2[] _layerPositions = new Vector2[3]
        {
            new Vector2(0, 350), // mais próxima da tela
            new Vector2(0, 320),
            new Vector2(0, 300)  // mais longe da tela
        };
        private Random _random = new Random();
        private bool _rightToLeft = false; // define se o inimigo aparecerá da direita p esquerda
        private int _elapsedTime = 0; // tempo decorrido de jogo
        private int _spawTime = 1000; // tempo de spaw p novos inimigos

        public GameScreen(GraphicsDeviceManager graphics, ContentManager content, Game game)
        {
            this.content = content;
            _backgroundTexture = new Background(game);
            _knifeman = new Knifeman();
            _knifeman.LoadContent(content);
            _viewport = graphics.GraphicsDevice.Viewport;
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _elapsedTime += gameTime.ElapsedGameTime.Milliseconds;

            if (_elapsedTime > _spawTime)
            {
                _elapsedTime = 0;
                Knifeman newKnifeman = new Knifeman();
                newKnifeman.Initialize();
                newKnifeman.LoadContent(content);
                int _layer = _random.Next(0, 3);
                Vector2 _position = _layerPositions[_layer];
                float _xVelocity = _random.Next(2, 9);// velocidade "aleatória" p cada inimigo

                _rightToLeft = _random.Next(0, 10) > 5; //define "aleatoriamente" de q lado vem o inimigo
                if (_rightToLeft)
                {
                    _position.X = _viewport.Width;
                    _xVelocity *= -1;
                }

                newKnifeman.SetEnemyPosition(_xVelocity, _layer);
                newKnifeman.Position = _position;

                _enemies.Add(newKnifeman);
            }

            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].Update(deltaTime);

                if (_enemies[i].IsEnable == false
                    || _enemies[i].Position.X < _viewport.X
                    || _enemies[i].Position.X > _viewport.Width)
                {
                    _enemies.RemoveAt(i);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _backgroundTexture.Draw(spriteBatch);

            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].Draw(spriteBatch);
            }
        }
    }
}
