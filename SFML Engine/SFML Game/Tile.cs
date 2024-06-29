using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML_Game
{
    internal class Tile : GameObject
    {
        public Tile(Sprite sprite, Vector2f position)
        {
            _sprite = sprite;
            _sprite.Position = new Vector2f(position.X , position.Y );
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(_sprite);
        }


        public override void OnCollisionEnter(GameObject other)
        {
            throw new NotImplementedException();
        }

        public override void OnCollisionExit(GameObject other)
        {
            throw new NotImplementedException();
        }

        public override void OnCollisionStay(GameObject other)
        {
            throw new NotImplementedException();
        }
    }
}
