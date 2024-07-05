using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML_Game
{
    internal static class CameraHandler
    {
        static View _defaultView;
        static View _camera;
        static HUD _screenData;
        static RenderWindow _playerWindow;
        static uint minWindowX;
        static uint maxWindowX = 2000;
        static uint minWindowY;
        static uint maxWindowY = 2000;


        static public void SetCameraHandler(RenderWindow playerWindow)
        {
            _playerWindow = playerWindow;
            _defaultView = new View();
            _camera = new View(_playerWindow.GetView());
            _screenData = new HUD(playerWindow);
            minWindowX = _playerWindow.Size.X / 2;
            minWindowY = _playerWindow.Size.Y / 2;
        }

        static public void Update(GameObject followTarget)
        {
            Vector2f targetPosition = followTarget.GetCenteredPosition();

            _camera.Center = new Vector2f()
            {
                X = Math.Clamp(targetPosition.X, minWindowX, maxWindowX - minWindowX),
                Y = Math.Clamp(targetPosition.Y, minWindowY, maxWindowY - minWindowY),
            };
            _screenData.Update((Player)followTarget);
            _playerWindow.SetView(_camera);
        }

        static public void Draw(RenderWindow window)
        {
            _playerWindow.SetView(_defaultView);
            _screenData.Draw(window);
        }
    }
}
