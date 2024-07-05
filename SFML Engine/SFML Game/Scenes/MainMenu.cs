
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_Game
{
    internal class MainMenu : Scene
    {
        Text _title;
        Text _startOption;
        Text _exitOption;
        Font _sampleFont;
        public MainMenu(RenderWindow window)
        {
            _sampleFont = new Font("Assets/DTMM.otf");
            _title = new Text("MY GAME", _sampleFont);
            _title.CharacterSize = 70;
            FloatRect auxRect = _title.GetLocalBounds();
            _title.Origin = new Vector2f(auxRect.Width / 2, auxRect.Height / 2);
            _title.Position = new Vector2f(window.Size.X / 2, 100);
            _title.Color = Color.Yellow;

            _sampleFont = new Font("Assets/DTMM.otf");
            _startOption = new Text("Press Enter to Play", _sampleFont);
            _startOption.CharacterSize = 30;
            auxRect = _startOption.GetLocalBounds();
            _startOption.Origin = new Vector2f(auxRect.Width / 2, auxRect.Height / 2);
            _startOption.Position = new Vector2f(window.Size.X / 2, 200);
            _startOption.Color = Color.Green;

            _sampleFont = new Font("Assets/DTMM.otf");
            _exitOption = new Text("Press Esc to Exit", _sampleFont);
            _exitOption.CharacterSize = 30;
            auxRect = _exitOption.GetLocalBounds();
            _exitOption.Origin = new Vector2f(auxRect.Width / 2, auxRect.Height / 2);
            _exitOption.Position = new Vector2f(window.Size.X / 2, 300);
            _exitOption.Color = Color.Red;
        }

        public override void Update(Time deltaTime)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
            {
                Game.gameState = GameState.Gameplay;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                Game.gameState = GameState.None;
            }
        }

        public override void Draw(RenderWindow playerWindow)
        {
            playerWindow.Draw(_title);
            playerWindow.Draw(_exitOption);
            playerWindow.Draw(_startOption);
        }


    }
}
