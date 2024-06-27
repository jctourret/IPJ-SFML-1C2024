using SFML.Graphics;
using SFML.System;

namespace SFML_Game
{
    internal class Hazard : GameObject
    {
        public Hazard(float PosX, float PosY)
        {
            _texture = new Texture("Assets/Rock.png");
            _sprite = new Sprite(_texture);
            _sprite.Position = new Vector2f(PosX, PosY);

            physicsOn = false;
        }

        public override void OnCollision(GameObject other)
        {
            Console.WriteLine("Hazard is Colliding");
            if (other is Player)
            {
                _sprite.Color = Color.Red;
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
