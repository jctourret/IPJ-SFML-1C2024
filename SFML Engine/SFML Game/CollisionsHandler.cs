using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;


namespace SFML_Game
{
    internal static class CollisionsHandler
    {
        public static List<GameObject> collisionables = new List<GameObject>();

        public static void AddObject(GameObject obj)
        {
            if(!collisionables.Contains(obj))
            {
                collisionables.Add(obj);
            }
        }

        public static void RemoveObject(GameObject obj)
        {
            if (collisionables.Contains(obj))
            {
                collisionables.Remove(obj);
            }
        }


        public static void SolvePhysics(GameObject first, GameObject second)
        {
            //Calculo de físicas
        }

        public static void SolveCollisions(GameObject first, GameObject second)
        {
            first.OnCollision(second);
            second.OnCollision(first);

            if(first.IsPhysicsOn() || second.IsPhysicsOn())
            {
                SolvePhysics(first, second);
            }
        }


        public static void Update()
        {
            for (int i = 0; i < collisionables.Count; i++)
            {
                for(int j = i + 1; j < collisionables.Count; j++)
                {
                    if (collisionables[i].isColliding(collisionables[j]))
                    {
                        SolveCollisions(collisionables[i], collisionables[j]);
                    }
                }
            }

        }
    }
}
