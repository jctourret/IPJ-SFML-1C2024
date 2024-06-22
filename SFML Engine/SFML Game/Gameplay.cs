using SFML.Graphics;
using SFML.System;

namespace SFML_Game
{
    internal class Gameplay : Scene
    {
        Player pj;
        public Gameplay()
        {
            pj = new Player(500,500);
        }

        public override void Update(Time deltaTime)
        {
            pj.Update(deltaTime);
        }

        public override void Draw(RenderWindow window)
        {
            pj.Draw(window);
        }
    }
}
