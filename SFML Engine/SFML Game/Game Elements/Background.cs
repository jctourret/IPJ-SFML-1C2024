using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML_Game
{
    internal class Background : GameObject
    {
        public Background(float PosX, float PosY, int SizeX, int SizeY)
        {
            _texture = new Texture("Assets/Grass.png");
            _sprite = new Sprite(_texture);
            _sprite.Position = new Vector2f(PosX, PosY);

            _sprite.TextureRect = new IntRect((int)_sprite.Position.X,(int)_sprite.Position.Y, SizeX, SizeY);
            _texture.Repeated = true;
        }

        public override void OnCollisionStay(GameObject other){}

        public void Update(){}

        public void Draw(RenderWindow window)
        {
            window.Draw(_sprite);
        }

        public override void OnCollisionEnter(GameObject other){}

        public override void OnCollisionExit(GameObject other){}
    }
}
