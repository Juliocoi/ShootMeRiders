using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

public class Button
{
    private Texture2D _image;
    private Rectangle _bounds;
    private Action _onClick;

    public Button(Texture2D image, Rectangle bounds, Action onClick)
    {
        _image = image;
        _bounds = bounds;
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
        spriteBatch.Draw(_image, _bounds, Color.White);
    }
}
