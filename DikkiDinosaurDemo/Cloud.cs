using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DikkiDinosaur;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DikkiDinosaurDemo
{
    class Cloud : Sprite
    {
        public Cloud(Texture2D spriteTexture, Vector2 position) : base(spriteTexture, position)
        {
        }

        public override void Update(GameTime gameTime)
        {
            //move slowly be decreasing positionX
            PositionX--;

            // if sky moves out of the window move it back into position
            if (PositionX < -200) PositionX = 900;
        }
    }
}
