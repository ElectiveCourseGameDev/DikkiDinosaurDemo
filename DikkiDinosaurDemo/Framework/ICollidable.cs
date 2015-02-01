using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DikkiDinosaur;
using Microsoft.Xna.Framework;

namespace DikkiDinosaurDemo.Framework
{
    interface ICollidable
    {
        void CollideWith(Sprite other);

        Rectangle BoundingBox { get; }
    }
}
