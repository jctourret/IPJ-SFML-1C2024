using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SFML_Game
{
    enum GameState
    {
        None,
        MainMenu,
        Gameplay,
        Credits
    }

    internal class Game
    {
        bool gameOn;

        static int states = Enum.GetNames(typeof(GameState)).Length;

        Scene[] scenes = new Scene[states];

        Clock deltaClock;
        Time deltaTime;

        RenderWindow window;
        VideoMode videoMode;

        static uint screenWidth = 800;
        static uint screenHeight = 600;

        GameState gameState;
        public Game()
        {
            gameState= GameState.Gameplay;

            scenes[(int)GameState.MainMenu] = new MainMenu();
            scenes[(int)GameState.Gameplay] = new Gameplay();
            scenes[(int)GameState.Credits] = new Credits();

            videoMode = new VideoMode(screenWidth, screenHeight);
            window = new RenderWindow(videoMode, "AGUAVSFUEGO");

            deltaClock = new Clock();
            deltaTime = new Time();

            window.Closed += Window_Closed;
        }

        public void Run()
        {
            while (window.IsOpen)
            {
                window.DispatchEvents();
                Update();
                Draw();
            }
        }

        public void Update()
        {
            deltaTime = deltaClock.Restart();
            switch (gameState)
            {
                case GameState.None:
                    break;
                case GameState.MainMenu:
                    break;
                case GameState.Gameplay:
                    scenes[(int)GameState.Gameplay].Update(deltaTime);
                    break;
                case GameState.Credits:
                    break;
            }
        }

        public void Draw()
        {
            window.Clear();
            switch (gameState)
            {
                case GameState.None:
                    break;
                case GameState.MainMenu:
                    break;
                case GameState.Gameplay:
                    scenes[(int)GameState.Gameplay].Draw(window);
                    break;
                case GameState.Credits:
                    break;
            }
            window.Display();
        }

        private void Window_Closed(object? sender, EventArgs e)
        {
            window.Close();
        }
    }
}
