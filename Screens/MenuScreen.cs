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
    private Rectangle backgroundRectangle;

    public MenuScreen(Texture2D backgroundTexture, Texture2D buttonTexturePlay, Texture2D buttonTextureCredits, Texture2D buttonTextureExit, Action actionPlay, Action actionCredits, Action actionExit, Viewport viewport)
    {
        this.backgroundTexture = backgroundTexture;
        this.backgroundRectangle = new Rectangle(0, 0, viewport.Width, viewport.Height);

        button1 = new Button(buttonTexturePlay, new Rectangle(310, 200, 200, 50), actionPlay);
        button2 = new Button(buttonTextureCredits, new Rectangle(310, 270, 200, 50), actionCredits);
        button3 = new Button(buttonTextureExit, new Rectangle(310, 340, 200, 50), actionExit);
    }

    public void Update(GameTime gameTime)
    {
        button1.Update(gameTime);
        button2.Update(gameTime);
        button3.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(backgroundTexture, backgroundRectangle, Color.White);

        button1.Draw(spriteBatch);
        button2.Draw(spriteBatch);
        button3.Draw(spriteBatch);
    }
}


