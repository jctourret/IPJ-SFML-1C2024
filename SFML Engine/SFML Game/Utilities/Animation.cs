using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SFML.Window.Mouse;

namespace SFML_Game
{
    internal class Animation
    {
        List<Sprite> _frames = new List<Sprite>();
        IntRect _rect;

        float _frameTime = 1;

        float _animationTime = 0;

        float _animationTimer = 0;

        int _currentFrame = 0;

        public Animation(Texture sheet,Vector2i frameSize,Vector2i frameOffset, Vector2i animFrames)
        {
            _rect = new IntRect();
            _rect.Width = frameSize.X;
            _rect.Height = frameSize.Y;

            for (int i = frameOffset.X; i < animFrames.X; i++)
            {
                for (int j = frameOffset.Y; j < animFrames.Y; j++)
                {
                    _rect.Left = j * frameSize.X;
                    _rect.Top = i * frameSize.Y;

                    Sprite newSprite = new Sprite(sheet,_rect);

                    _frames.Add(newSprite);
                }
            }
        }
        public Animation(Texture sheet, Vector2i frameSize, Vector2i frameOffset, Vector2i animFrames, float animationTime)
        {
            _frameTime = animationTime/(animFrames.X*animFrames.Y);

            for (int i = frameOffset.X; i < animFrames.X; i++)
            {
                for (int j = frameOffset.Y; j < animFrames.Y; j++)
                {
                    _rect = new IntRect();

                    _rect.Left = j * frameSize.X;
                    _rect.Top = i * frameSize.Y;

                    _rect.Width = frameSize.X;
                    _rect.Height = frameSize.Y;

                    Sprite newSprite = new Sprite(sheet, _rect);

                    _frames.Add(newSprite);
                }
            }
        }

        public void AddFrames(Texture sheet, Vector2i frameSize, Vector2i frameOffset, Vector2i animFrames)
        {
            for (int i = frameOffset.X; i < animFrames.X; i++)
            {
                for (int j = frameOffset.Y; j < animFrames.Y; j++)
                {
                    _rect.Left = j * frameSize.X;
                    _rect.Top = i * frameSize.Y;

                    Sprite newSprite = new Sprite(sheet, _rect);
                    _frames.Add(newSprite);
                }
            }
        }
        public Sprite Update(Time deltaTime)
        {
            _animationTimer += deltaTime.AsSeconds(); // 0.011f

            if (_animationTimer > _frameTime)
            {
                _animationTimer -= _frameTime;
                _currentFrame++;

                _currentFrame = _currentFrame % _frames.Count;
            }
            return _frames[_currentFrame];
        }
    }
}
