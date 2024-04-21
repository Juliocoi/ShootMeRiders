using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootMeRiders.Screens;
public class MenuScreen
{
    private Texture2D backgroundTexture;
    private Button button1;
    private Button button2;
    private Button button3;

    public MenuScreen(Texture2D backgroundTexture, Texture2D buttonTexture, Action action1, Action action2, Action action3, Vector2 position)
    {
        this.backgroundTexture = backgroundTexture;
        button1 = new Button(buttonTexture, position, action1);
        button2 = new Button(buttonTexture, position + new Vector2(0, 50), action2);
        button3 = new Button(buttonTexture, position + new Vector2(0, 100), action3);
    }

    public void Update(GameTime gameTime)
    {
        button1.Update(gameTime);
        button2.Update(gameTime);
        button3.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(backgroundTexture, Vector2.Zero, Color.White);

        button1.Draw(spriteBatch);
        button2.Draw(spriteBatch);
        button3.Draw(spriteBatch);
    }
}


