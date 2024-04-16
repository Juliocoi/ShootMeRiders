using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ShootMeRiders.Engine;

namespace ShootMeRiders.Model;

public class Knifeman
{

	List<Rectangle> _runAnimation;
	private List<Rectangle> _deathAnimation;
	private Texture2D _texture;
	private int _index;
	private float _xVelocity = 2;
	private int _layer = 3;
    private Rectangle _position;
    private Timer _timer;

	public void LoadContent(ContentManager content)
	{
        _texture = content.Load<Texture2D>("Enemies/knifeman");
		_runAnimation = new List<Rectangle>();

		_runAnimation.Add(new Rectangle(320, 219, 46, 53));
        _runAnimation.Add(new Rectangle(497, 217, 56, 55));
        _runAnimation.Add(new Rectangle(656, 220, 31, 52));
        _runAnimation.Add(new Rectangle(384, 219, 46, 53));
        _runAnimation.Add(new Rectangle(584, 217, 42, 55));
        _runAnimation.Add(new Rectangle(656, 220, 31, 52));

    }

    public void Initialize()
    {
        _index = 0;
        _position = new Rectangle(0, 100, _runAnimation[0].Width, _runAnimation[0].Height);
        _timer = new Timer();
        _timer.Start(IncrementIndex, 0.14f, true);
        
    }

    public void Update(float deltaTime)
    {
        _timer.Update(deltaTime);
    }


    private void IncrementIndex()
    {
        _index++;
        if(_index > 5)
        {
            _index = 0;
        }
    }

    private void SetEnemyPosition(float xPosition, int layer)
    {
        _xVelocity = xPosition;
        _layer = layer;
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, _runAnimation[_index], Color.White);
    }

}
