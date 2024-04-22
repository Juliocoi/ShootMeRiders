using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ShootMeRiders.Screens;
public class CreditsScreen
{
    private Texture2D backgroundTexture;
    private Rectangle backgroundRectangle;
    private SpriteFont font;

    private SpriteFont creditsFont;
    private string creditsText;
    private Viewport _viewport; // Variável de instância para o viewport
     private int screenWidth; // Adiciona a propriedade screenWidth
    private int screenHeight;

    public CreditsScreen(Texture2D backgroundTexture, SpriteFont creditsFont, int screenWidth, int screenHeight)
    {
        this.backgroundTexture = backgroundTexture;
        this.creditsFont = creditsFont;
        this.screenWidth = screenWidth;
        this.screenHeight = screenHeight;
        this.backgroundRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

        // Lista de nomes formatada para exibição
        creditsText = "Caliel, Ellen, Julio, Lilyan, Maisa, Ueslei";
    }

    public void Update(GameTime gameTime)
    {
        // Lógica de atualização, se necessário
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(backgroundTexture, backgroundRectangle, Color.White);
        
        // Centraliza o texto na tela usando _viewport
        Vector2 textSize = creditsFont.MeasureString(creditsText);
        Vector2 position = new Vector2((_viewport.Width - textSize.X) / 2, (_viewport.Height - textSize.Y) / 2);
        
        // spriteBatch.DrawString(font, creditsText, position, Color.White);
        spriteBatch.DrawString(creditsFont, "Caliel", new Vector2(20, 20), Color.White);
        
    }                                                                                                              
}
