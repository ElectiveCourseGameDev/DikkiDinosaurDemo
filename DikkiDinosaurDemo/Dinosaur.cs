using DikkiDinosaur;
using DikkiDinosaurDemo.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DikkiDinosaurDemo
{
    public class Dinosaur : Sprite, IInputGamePadLeftStick
    {
        public Dinosaur(Texture2D spriteTexture, Vector2 position) : base(spriteTexture, position)
        {
        }


        public void LeftStickMove(Vector2 moveVector)
        {
            Position += moveVector;
        }
    }
}