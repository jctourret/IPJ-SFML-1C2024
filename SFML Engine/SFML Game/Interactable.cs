using SFML.Graphics;
using SFML.System;

namespace SFML_Game
{
    internal class Interactable : GameObject
    {
        public Interactable(float PosX, float PosY)
        {
            _texture = new Texture("Assets/Rock.png");
            _sprite = new Sprite(_texture);
            physicsOn = true;

            _sprite.Position = new Vector2f(PosX, PosY);
        }
        public override void OnCollision(GameObject other)
        {
            Console.WriteLine("Interactable is Colliding");
            if (other is Player)
            {
                _sprite.Color = Color.Blue;
            }
        }

        public void Update(Time deltaTime, Player player)
        {

        }

        public void Draw(RenderWindow window)
        {
            window.Draw(_sprite);
        }
    }
}
