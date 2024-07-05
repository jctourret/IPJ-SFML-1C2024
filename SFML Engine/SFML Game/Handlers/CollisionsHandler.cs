using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;


namespace SFML_Game
{
    internal static class CollisionsHandler
    {
        public enum PhysicsType
        {
            None,
            Static,
            Dynamic
        }

        public static List<GameObject> collisionables = new List<GameObject>();

        static List<KeyValuePair<GameObject,GameObject>> collitionRegistry = new List<KeyValuePair<GameObject,GameObject>>();


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
            FloatRect firstBounds = first.GetBody().GetGlobalBounds();
            FloatRect secondBounds = second.GetBody().GetGlobalBounds();

            //Ubicamos el medio de las posiciones
            Vector2f firstPos = new Vector2f(firstBounds.Left + firstBounds.Width / 2f,
                                             firstBounds.Top + firstBounds.Height / 2f);

            Vector2f secondPos = new Vector2f(secondBounds.Left + secondBounds.Width / 2f,
                                              secondBounds.Top + secondBounds.Height / 2f);


            //Detecion de colision
            float minHorDistance = firstBounds.Width / 2f + secondBounds.Width / 2f;
            float minVerDistance = firstBounds.Height / 2f + secondBounds.Height / 2f;

            Vector2f diff = firstPos - secondPos;

            //Detecta la penetracion de los objetos entre si
            float horPenetration = minHorDistance - Math.Abs(diff.X);
            float verPenetration = minVerDistance - Math.Abs(diff.Y);


            Vector2f firstSeparation;
            Vector2f secondSeparation;
            float firstDisplacement;
            float secondDisplacement;
            float firstDisplacementSign;
            float secondDisplacementSign;
            bool isPositiveDiff;

            if (horPenetration > verPenetration)
            {
                // Se desplazan verticalmente
                isPositiveDiff = (diff.Y > 0f);
                firstDisplacementSign = (isPositiveDiff) ? 1f : -1f;
                secondDisplacementSign = (!isPositiveDiff) ? 1f : -1f;

                firstDisplacement = verPenetration * 0.5f * firstDisplacementSign;
                secondDisplacement = verPenetration * 0.5f * secondDisplacementSign;

                firstSeparation = new Vector2f(0f, firstDisplacement);
                secondSeparation = new Vector2f(0f, secondDisplacement);
            }
            else
            {
                // Se desplazan horizontalmente
                isPositiveDiff = (diff.X > 0f);
                firstDisplacementSign = (isPositiveDiff) ? 1f : -1f;
                secondDisplacementSign = (!isPositiveDiff) ? 1f : -1f;

                firstDisplacement = horPenetration * 0.5f * firstDisplacementSign;
                secondDisplacement = horPenetration * 0.5f * secondDisplacementSign;

                firstSeparation = new Vector2f(firstDisplacement, 0f);
                secondSeparation = new Vector2f(secondDisplacement, 0f);
            }

            if(first.GetPhysType() == PhysicsType.Dynamic)
            {
                first.ApplyPhysics(firstSeparation);
            }
            if (second.GetPhysType() == PhysicsType.Dynamic)
            {
                second.ApplyPhysics(secondSeparation);
            }
        }

        public static void SolveCollisions(GameObject first, GameObject second)
        {
            if(first.GetPhysType() != PhysicsType.None && second.GetPhysType() != PhysicsType.None)
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
                    KeyValuePair<GameObject, GameObject> registryEntry = new KeyValuePair<GameObject, GameObject>(collisionables[i], collisionables[j]);

                    if (collisionables[i].isColliding(collisionables[j]))
                    {
                        //Collision enter y collision stay

                        SolveCollisions(collisionables[i], collisionables[j]);

                        if (!collitionRegistry.Contains(registryEntry)) //Esta colision, no esta ya en mi libro de colisiones?
                        {
                            //Enter
                            collisionables[i].OnCollisionEnter(collisionables[j]);
                            collisionables[j].OnCollisionEnter(collisionables[i]);
                            collitionRegistry.Add(registryEntry);
                        }
                        else
                        {
                            collisionables[i].OnCollisionStay(collisionables[j]);
                            collisionables[j].OnCollisionStay(collisionables[i]);
                        }
                    }
                    else
                    {
                        //Collision exit
                        if (collitionRegistry.Contains(registryEntry)) //Esta colision, esta ya en mi libro de colisiones?
                        {
                            //Exit
                            collisionables[i].OnCollisionExit(collisionables[j]);
                            collisionables[j].OnCollisionExit(collisionables[i]);
                            collitionRegistry.Remove(registryEntry);
                        }
                    }
                }
            }

        }
    }
}
