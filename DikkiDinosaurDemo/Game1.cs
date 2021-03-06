﻿#region Using Statements
using System;
using System.Collections.Generic;
using DikkiDinosaur;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace DikkiDinosaurDemo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D dikkiDinosaurTexture2D;
        private Vector2 dikkiDinosaurPosition = new Vector2(200, 80);

        private Sprite _cloud;

        private Cloud _cloud2;

        Dinosaur dikki;

        private InputController inputController;

        private AnimatedSprite animatedSprite;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            inputController = new InputController(PlayerIndex.One);


            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D cloudTexture = Content.Load<Texture2D>("cloud.png");
            _cloud = new Sprite(cloudTexture, new Vector2(50, 10));
            _cloud.Scale = 1.2f;

            _cloud2 = new Cloud(cloudTexture, new Vector2(600,30));

            dikkiDinosaurTexture2D = Content.Load<Texture2D>("dikkiDinosaur.png");  
            
            dikki = new Dinosaur(dikkiDinosaurTexture2D,new Vector2(100,100));
            //inputController.InputGamePadLeftStickListeners.Add(dikki);

            Texture2D animationTexture = Content.Load<Texture2D>("p3_spritesheet.png");
            animatedSprite = new AnimatedSprite(animationTexture, new Vector2(100,100));
            inputController.InputGamePadLeftStickListeners.Add(animatedSprite);
            inputController.InputGamePadButtonListeners.Add(animatedSprite);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _cloud2.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            inputController.Update(gameTime);
            
            animatedSprite.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            _cloud.Draw(gameTime, spriteBatch);
            _cloud2.Draw(gameTime, spriteBatch);
            dikki.Draw(gameTime, spriteBatch);
            animatedSprite.Draw(gameTime, spriteBatch);

            spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
