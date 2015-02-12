using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DikkiDinosaur;
using DikkiDinosaurDemo.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DikkiDinosaurDemo
{
    class AnimatedSprite : Sprite, IInputGamePadLeftStick, IInputGamePadButtons
    {
        Animation animation;
        public enum State
        {
            Waiting,
            walking,
            Jumping
        }

        public AnimatedSprite(Texture2D spriteTexture, Vector2 position) : base(spriteTexture, position)
        {
            // set sourcerectangle
            SourceRectangle = new Rectangle(0, 114, 72, 78);

            //instansiate animation and set frames
            animation = new Animation(this);
            animation.Frames.Add(new Rectangle(0,96,72,96));
            animation.Frames.Add(new Rectangle(72,96,72,96));
            animation.Frames.Add(new Rectangle(144,96,72,96));

            
        }

        public void LeftStickMove(Vector2 moveVector)
        {
            Position += moveVector;
        }

        public override void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
           
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Do we have a texture? If not then there is nothing to draw...
            if (SpriteTexture != null)
            {
                // Has a source rectangle been set?
                if (SourceRectangle.IsEmpty)
                {
                    // No, so draw the entire sprite texture
                    spriteBatch.Draw(SpriteTexture, Position, null, Color.White, Rotation, Origin, Scale, SpriteEffects.None, 0f);
                }
                else
                {
                    // Yes, so just draw the specified SourceRect
                    spriteBatch.Draw(SpriteTexture, Position, SourceRectangle, Color.White, Rotation, Origin, Scale, SpriteEffects.None, 0f);
                }
            }
        }

        class Animation : IUpdateable
        {
            private double _milisecondsSinceLastFrameUpdate = 0;
            private Sprite _sprite;
            private int _currentFrame = 0;
            private List<Rectangle> _frames = new List<Rectangle>();
            private bool _loop;
            private int _delay;

            public bool Loop
            {
                get { return _loop; }
                set { _loop = value; }
            }

            public int Delay
            {
                get { return _delay; }
                set { _delay = value; }
            }

            public List<Rectangle> Frames
            {
                get { return _frames; }
                set { _frames = value; }
            }

            public Animation(Sprite sprite)
            {
                _sprite = sprite;
                _delay = 200;
                _loop = true;
            }

            public void Update(GameTime gameTime)
            {
                if (gameTime.TotalGameTime.TotalMilliseconds > _milisecondsSinceLastFrameUpdate + Delay)
                {
                    _sprite.SourceRectangle = NextFrame();              
                    _milisecondsSinceLastFrameUpdate = gameTime.TotalGameTime.TotalMilliseconds;
                }
            }

            private Rectangle NextFrame()
            {
                if (_currentFrame == _frames.Count - 1 && _loop) _currentFrame = 0;
                else if (_currentFrame < _frames.Count - 1) _currentFrame++;
                return Frames[_currentFrame];
            }

            public bool Enabled { get; private set; }
            public int UpdateOrder { get; private set; }
            public event EventHandler<EventArgs> EnabledChanged;
            public event EventHandler<EventArgs> UpdateOrderChanged;
        }

        public void ButtonADown(InputController.ButtonStates buttonStates)
        {
            animation = new Animation(this);
            animation.Loop = false;
            animation.Frames.Add(new Rectangle(288, 96, 72, 96));
            animation.Frames.Add(new Rectangle(360, 96, 72, 96));
            animation.Frames.Add(new Rectangle(432, 96, 72, 96));

        }

        public void ButtonBDown(InputController.ButtonStates buttonStates)
        {
            throw new NotImplementedException();
        }

        public void ButtonXDown(InputController.ButtonStates buttonStates)
        {
            throw new NotImplementedException();
        }

        public void ButtonYDown(InputController.ButtonStates buttonStates)
        {
            throw new NotImplementedException();
        }

        public void ButtonLeftShoulderDown(InputController.ButtonStates buttonStates)
        {
            throw new NotImplementedException();
        }

        public void ButtonRightShoulderDown(InputController.ButtonStates buttonStates)
        {
            throw new NotImplementedException();
        }

        public void ButtonStartDown(InputController.ButtonStates buttonStates)
        {
            throw new NotImplementedException();
        }

        public void ButtonBackDown(InputController.ButtonStates buttonStates)
        {
            throw new NotImplementedException();
        }

        public void ButtonLeftStickDown(InputController.ButtonStates buttonStates)
        {
            throw new NotImplementedException();
        }

        public void ButtonRightStickDown(InputController.ButtonStates buttonStates)
        {
            throw new NotImplementedException();
        }
    }
}
