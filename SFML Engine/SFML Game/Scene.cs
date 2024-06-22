using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML_Game
{
    abstract class Scene
    {
        public abstract void Update(Time deltaTime);
        public abstract void Draw(RenderWindow playerWindow);
    }
}
