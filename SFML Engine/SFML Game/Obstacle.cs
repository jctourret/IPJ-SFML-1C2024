using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML_Game
{
    internal class Obstacle : GameObject
    {

        public Obstacle(float PosX, float PosY)
        {
            _texture = new Texture("Assets/Rock.png");
            _sprite = new Sprite(_texture);
            _sprite.Position = new Vector2f(PosX, PosY);

            _body = new RectangleShape(new Vector2f(50, 50));
            _body.Position = _sprite.Position;

            _physType = CollisionsHandler.PhysicsType.Dynamic;
            physicsOn = false;
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
        public override void OnCollisionStay(GameObject other)
        {
        }

        public override void OnCollisionExit(GameObject other)
        {

        }
    }
}
