using SFML.Graphics;
using SFML.System;
using System.Security.AccessControl;

namespace SFML_Game
{
    internal class Gameplay : Scene
    {
        Player pj;
        Hazard hazard;
        Interactable interactable;
        Obstacle obstacle;

        Tilemap tilemap;

        public Gameplay()
        {
            pj = new Player(500,500);
            hazard = new Hazard(100,100);
            interactable = new Interactable(400, 400);
            obstacle = new Obstacle(300, 100);
            tilemap = new Tilemap("KenneyRPG.png",  "Map.csv"  , new Vector2i(16, 16), 12);
            
            CollisionsHandler.AddObject(interactable);
            CollisionsHandler.AddObject(hazard);
            CollisionsHandler.AddObject(pj);
            CollisionsHandler.AddObject(obstacle);
        }

        public override void Update(Time deltaTime)
        {
            pj.Update(deltaTime);
            hazard.Update(deltaTime);
            interactable.Update(deltaTime);
            obstacle.Update(deltaTime);


            CollisionsHandler.Update();
        }

        public override void Draw(RenderWindow window)
        {
            tilemap.Draw(window);
            pj.Draw(window);
            hazard.Draw(window);
            interactable.Draw(window);
            obstacle.Draw(window);
        }
    }
}
