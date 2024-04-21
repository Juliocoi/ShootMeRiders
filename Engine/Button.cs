using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

public class Button
{
    private Texture2D _image;
    private Vector2 _position;
    private Rectangle _bounds;
    private Action _onClick;

    public Button(Texture2D image, Vector2 position, Action onClick)
    {
        _image = image;
        _position = position;
        _bounds = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
        _onClick = onClick;
    }

    public void Update(GameTime gameTime)
    {
        MouseState mouseState = Mouse.GetState();
        if (mouseState.LeftButton == ButtonState.Pressed &&
            _bounds.Contains(mouseState.Position))
        {
            _onClick?.Invoke();
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_image, _position, Color.White);
    }
}
