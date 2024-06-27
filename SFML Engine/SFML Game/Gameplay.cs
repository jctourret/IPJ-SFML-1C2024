using SFML.Graphics;
using SFML.System;

namespace SFML_Game
{
    internal class Gameplay : Scene
    {
        Player pj;
        Hazard hazard;
        Interactable interactable;
        public Gameplay()
        {
            pj = new Player(500,500);
            hazard = new Hazard(100,100);
            interactable = new Interactable(400, 400);

            CollisionsHandler.AddObject(interactable);
            CollisionsHandler.AddObject(hazard);
            CollisionsHandler.AddObject(pj);

        }

        public override void Update(Time deltaTime)
        {
            pj.Update(deltaTime);
            hazard.Update(deltaTime, pj);
            interactable.Update(deltaTime, pj);
            CollisionsHandler.Update();
        }

        public override void Draw(RenderWindow window)
        {
            pj.Draw(window);
            hazard.Draw(window);
            interactable.Draw(window);
        }
    }
}
