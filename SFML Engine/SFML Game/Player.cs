using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace SFML_Game
{
    internal class Player : GameObject
    {
        enum State
        {
            Idle,
            Down,
            Left,
            Right,
            Up,
        }
        public RectangleShape _body;

        List<Animation> animations = new List<Animation>();

        State currentState = State.Down;

        Texture _texture;

        //Sprite _sprite;
        IntRect _rect;

        float speed = 1000;
        public Player(float posX, float posY)
        {
            _texture = new Texture("Assets/CharacterSheet.png");
            _sprite = new Sprite(_texture);
            
            animations.Add(new Animation(_texture, new Vector2i(432, 720), new Vector2i(0, 10), new Vector2i(1, 11)));
            animations.Add(new Animation(_texture, new Vector2i(432, 720), new Vector2i(0, 0), new Vector2i(1, 12),1));
            animations.Add(new Animation(_texture, new Vector2i(432, 720), new Vector2i(1, 0), new Vector2i(2, 12)));
            animations.Add(new Animation(_texture, new Vector2i(432, 720), new Vector2i(2, 0), new Vector2i(3, 12)));
            animations.Add(new Animation(_texture, new Vector2i(432, 720), new Vector2i(3, 0), new Vector2i(4, 12)));

            _sprite.Origin = new Vector2f (_texture.Size.X /2, _texture.Size.Y/2);

            _body = new RectangleShape(new Vector2f(_texture.Size.X, _texture.Size.Y));
            _body.Origin = new Vector2f(_body.Size.X / 2, _body.Size.Y / 2);
            _body.Position = new Vector2f(posX, posY);

            _sprite.Position = _body.Position;
            physicsOn = true;

        }

        public RectangleShape GetBody()
        {
            return _body;
        }

        public override void OnCollision(GameObject other)
        {
            Console.WriteLine("Player is Colliding");
        }

        public void Update(Time deltaTime)
        {
            Vector2f direction = new Vector2f();
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                direction.Y = -1;
                currentState = State.Up;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                direction.Y = 1;
                currentState = State.Down;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                direction.X = -1;
                currentState = State.Left;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                direction.X = 1;
                currentState = State.Right;
            }
            float dirMag = MathF.Sqrt(direction.X * direction.X + direction.Y * direction.Y);

            if (dirMag > 0) 
            {
                Vector2f dirNormalized = direction / dirMag;
                _body.Position += dirNormalized * speed * deltaTime.AsSeconds();
            }
            else
            {
                currentState = State.Idle;
            }
            _sprite.Scale = new Vector2f(0.2f, 0.2f);
            _sprite.Position = _body.Position;
            _sprite = animations[(int)currentState].Update(deltaTime);
        }
        public void Draw(RenderWindow playerWindow)
        {
            //Dibujamos nuestro Player
            //playerWindow.Draw(_body);
            playerWindow.Draw(_sprite);
        }
    }
}
