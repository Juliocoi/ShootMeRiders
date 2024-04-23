using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ShootMeRiders.Screens;
public class CreditsScreen
{
    private Texture2D backgroundTexture;
    private Rectangle backgroundRectangle;
    private SpriteFont font;

   
    // private string creditsText;

    public CreditsScreen(Texture2D backgroundTexture, SpriteFont font, int screenWidth, int screenHeight)
    {
        this.backgroundTexture = backgroundTexture;
        this.font = font;
        this.backgroundRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

        // Lista de nomes formatada para exibição
        // creditsText = "Caliel, Ellen, Julio, Lilyan, Maisa, Ueslei";
    }

    public void Update(GameTime gameTime)
    {
        // Lógica de atualização, se necessário
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(backgroundTexture, backgroundRectangle, Color.White);
        
        
        // spriteBatch.DrawString(font, creditsText, position, Color.White);
        spriteBatch.DrawString(font, "Ellen Virginia Albuquerque da Silva 01570521", new Vector2(240, 120), Color.White);
        spriteBatch.DrawString(font, "Julio Cesar Amorim de Souza 01024947", new Vector2(240, 140), Color.White);
        spriteBatch.DrawString(font, "Lilyan Gabryella Guedes da Silva 01565435", new Vector2(240, 160), Color.White);
        spriteBatch.DrawString(font, "Maisa Souza dos Santos 01508744", new Vector2(240, 180), Color.White);
        spriteBatch.DrawString(font, "Ueslei cristiano nogueira da Silva 01565666", new Vector2(240, 200), Color.White);
        spriteBatch.DrawString(font, "Vinicius Caliel Nunes passos 01554544", new Vector2(240, 220), Color.White);
        
    }                                                                                                              
}
