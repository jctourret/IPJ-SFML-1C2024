using SFML.Graphics;
using SFML.System;
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
        protected RectangleShape _body;
        protected CollisionsHandler.PhysicsType _physType;
        protected bool physicsOn;

        public Sprite GetSprite()
        {
            return _sprite;
        }

        public RectangleShape GetBody()
        {
            return _body;
        }

        public CollisionsHandler.PhysicsType GetPhysType()
        {
            return _physType;
        }

        public bool IsPhysicsOn() 
        { 
            return physicsOn;
        }
        public bool isColliding(GameObject other)
        {
            FloatRect thisBounds = _body.GetGlobalBounds();
            FloatRect otherBounds = other._body.GetGlobalBounds();

            return thisBounds.Intersects(otherBounds);
        }

        public Vector2f GetCenteredPosition()
        {
            FloatRect auxRect = _body.GetGlobalBounds();
            Vector2f pos;

            pos = new Vector2f()
            {
                X = _body.Position.X + auxRect.Width/2,
                Y = _body.Position.Y + auxRect.Height/2
            };

            return pos;
        }

        public abstract void OnCollisionEnter(GameObject other);
        public abstract void OnCollisionStay(GameObject other);
        public abstract void OnCollisionExit(GameObject other);

        public void ApplyPhysics(Vector2f correction)
        {
            _body.Position += correction;
        }
    }
}
