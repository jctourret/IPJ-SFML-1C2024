using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML_Game
{
    internal abstract class GameObject
    {

        protected Texture _texture;
        protected Sprite _sprite;
        protected bool physicsOn;

        public Sprite GetSprite()
        {
            return _sprite;
        }

        public bool IsPhysicsOn() 
        { 
            return physicsOn;
        }
        public bool isColliding(GameObject other)
        {
            FloatRect thisBounds = _sprite.GetGlobalBounds();
            FloatRect otherBounds= other.GetSprite().GetGlobalBounds();

            return thisBounds.Intersects(otherBounds);
        }

        public abstract void OnCollision(GameObject other);


    }
}
