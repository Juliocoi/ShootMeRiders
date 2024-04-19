using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShootMeRiders.Engine;

namespace ShootMeRiders.Model;

public class Knifeman
{

	List<Rectangle> _runAnimation;
	List<Rectangle> _deathAnimation;
    public List<Rectangle> CurrentAnimation { get; protected set; }

    private Texture2D _texture;
	private int _index;
	private float _xVelocity = 2;
	private int _layer = 3;
    private Vector2 _position;
    private Timer _timer;

	public void LoadContent(ContentManager content)
	{
        _texture = content.Load<Texture2D>("Enemies/knifeman");
		_runAnimation = new List<Rectangle>();

		_runAnimation.Add(new Rectangle(320, 219, 46, 55));
        _runAnimation.Add(new Rectangle(497, 217, 56, 55));
        _runAnimation.Add(new Rectangle(656, 220, 31, 55));
        _runAnimation.Add(new Rectangle(384, 219, 46, 55));
        _runAnimation.Add(new Rectangle(584, 217, 42, 55));
        _runAnimation.Add(new Rectangle(656, 220, 31, 55));

        CurrentAnimation = _runAnimation;

        _deathAnimation = new List<Rectangle>();
        _deathAnimation.Add(new Rectangle(97, 127, 27, 58));
        _deathAnimation.Add(new Rectangle(32, 117, 48, 58));

    }

    public void Initialize()
    {
        _index = 0;
        _timer = new Timer();
        _timer.Start(IncrementIndex, 0.14f, true);
        
    }

    public void Update(float deltaTime)
    {
        _position += new Vector2(_xVelocity, 0);

        MouseState mouseState = Mouse.GetState();
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            Point mousePoint = new Point(mouseState.X, mouseState.Y);
            if (GetBounds().Contains(mousePoint))
            {
                _index = 0;
                CurrentAnimation = _deathAnimation;
                _xVelocity = 0;
            }
        }
        _timer.Update(deltaTime);
    }

    public Rectangle GetBounds()
    {
        return new Rectangle((int)_position.X, (int)_position.Y, CurrentAnimation[_index].Width, CurrentAnimation[_index].Height);
    }

    private void IncrementIndex()
    {
        _index = (_index + 1) % CurrentAnimation.Count;
    }

    private void SetEnemyPosition(float xPosition, int layer)
    {
        _xVelocity = xPosition;
        _layer = layer;
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        Console.WriteLine(_index);
        spriteBatch.Draw(_texture, _position, CurrentAnimation[_index], Color.White);
    }

}
