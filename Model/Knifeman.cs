using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShootMeRiders.Engine;
using static System.Formats.Asn1.AsnWriter;

namespace ShootMeRiders.Model;

public class Knifeman
{

	List<Rectangle> _runAnimation;
	List<Rectangle> _deathAnimation;
    public List<Rectangle> CurrentAnimation { get; protected set; }
    private Texture2D _texture;
	private int _index;
	private float _xVelocity = 2;
    public Vector2 Position { get; set; }
    private Timer _timer;
    private int _layer = 3;
    private Vector2 _scale;
    private SpriteEffects _orientation;

    public bool IsEnable { get; protected set; } = true;

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
        //aumenta ou diminui o tamanho da imag de acordo com sua posição na tela.
        if(_layer == 0)
        {
            _scale = new Vector2(2);
        }
        else if(_layer == 1)
        {
            _scale = new Vector2(1.5f);
        }
        else
        {
            _scale = new Vector2(1);
        }

        Position += new Vector2(_xVelocity, 0);

        //inverte a direção horizontal da animação
        if (_xVelocity < 0)
        {
            _orientation = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _orientation = SpriteEffects.None;
        }
      
        //Atualiza a animação pelo click do mouse
        MouseState mouseState = Mouse.GetState();
        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            if (GetBounds().Contains(mouseState.Position))
            {
                _index = 0;
                CurrentAnimation = _deathAnimation;
                _xVelocity = 0;

                
            }
            
        }

        if(CurrentAnimation == _deathAnimation)
        {
            
            if(AnimationCompleted())
            {   
                
                IsEnable = false;
                

            }
            
        }

        _timer.Update(deltaTime);
       

    }

    public Rectangle GetBounds()
    {
        return new Rectangle((int)Position.X, (int)Position.Y, CurrentAnimation[_index].Width, CurrentAnimation[_index].Height);
    }

    private void IncrementIndex()
    {
        _index = (_index + 1) % CurrentAnimation.Count;
    }

    public bool AnimationCompleted()
    {
        
        return _index == CurrentAnimation.Count - 1;
    }

    public void SetEnemyPosition(float xPosition, int layer)
    {
        _xVelocity = xPosition;
        _layer = layer;
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, Position, CurrentAnimation[_index], Color.White,0, Vector2.Zero, _scale, _orientation,0);
    }

}
