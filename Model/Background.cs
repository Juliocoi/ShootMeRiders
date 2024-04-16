using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShootMeRiders.Model;

public class Background
{
	private Texture2D _texture;

	public Background(Game game)
	{
		_texture = game.Content.Load<Texture2D>("Background/stage");
	}

	public void Draw(SpriteBatch spriteBatch)
	{
		spriteBatch.Draw(_texture, new Vector2(80, 15), new Rectangle(20, 23, 320, 224), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
	}

}
