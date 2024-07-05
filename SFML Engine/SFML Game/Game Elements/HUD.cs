using SFML.Graphics;
using SFML.System;


namespace SFML_Game
{
    internal class HUD
    {
        Font sampleFont = new Font("Assets/DTMM.otf");
        Text playerHealth;
        Text playerScore;
        public HUD(RenderWindow window) 
        { 
            playerHealth = new Text(" ", sampleFont);
            playerScore = new Text(" ", sampleFont);

            playerHealth.Color = Color.Red;
            playerHealth.CharacterSize = 30;
            playerScore.Color = Color.Yellow;
            playerScore.CharacterSize = 30;

            playerHealth.Position = new Vector2f(5, 5);
            FloatRect auxRect = playerScore.GetGlobalBounds();
            playerScore.Position = new Vector2f(window.Size.X - auxRect.Width, 5);
        }

        public void Update(Player player) 
        {
            playerHealth.DisplayedString = $"HP: {player.GetHP()}";
            playerScore.DisplayedString = $"Score: {player.GetScore()}";
        }

        public void Draw(RenderWindow window) 
        { 
            window.Draw(playerHealth);
            window.Draw(playerScore);
        }
    }
}
