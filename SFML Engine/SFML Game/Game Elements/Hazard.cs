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

            _body = new RectangleShape(new Vector2f(28, 28));
            _body.Position = _sprite.Position;

            _physType = CollisionsHandler.PhysicsType.None;
            physicsOn = false;
        }

        public override void OnCollisionStay(GameObject other)
        {
            Console.WriteLine("Hazard is Colliding");
            if (other is Player)
            {
                _sprite.Color = Color.Red;
            }
        }

        public void Update(Time deltaTime)
        {
            _sprite.Position = _body.Position;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(_body);
            window.Draw(_sprite);
        }

        public override void OnCollisionEnter(GameObject other)
        {
        }

        public override void OnCollisionExit(GameObject other)
        {

        }
    }
}
