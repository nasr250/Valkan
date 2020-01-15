﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

//This is the Selection Screen for Offline or Online mode.
//If Offline is Selected, the screen will change options accordingly
class HostClientSelectionState : GameObjectLibrary
{
    protected Button startButton, settingsButton, returnButton;
    protected bool firstTime = true;
    public HostClientSelectionState()
    {
        //Load all menu sprites (e.g. background images, overlay images, button sprites)
        SpriteGameObject titleScreen = new SpriteGameObject("Sprites/Overlay/Menu_BG_Grey", 100, "background");
        RootList.Add(titleScreen);
        //Create Game button
        startButton = new Button("Sprites/Menu/CreateGame_Button", 101);
        startButton.Sprite.Size = new Vector2(2f, 3f);
        startButton.Position = new Vector2(GameEnvironment.Screen.X / 2 - startButton.BoundingBox.Width / 2, (GameEnvironment.Screen.Y - startButton.BoundingBox.Height) / 4);
        RootList.Add(startButton);
        //Join Game button
        settingsButton = new Button("Sprites/Menu/JoinGame_Button", 101);
        settingsButton.Sprite.Size = new Vector2(2f, 3f);
        settingsButton.Position = new Vector2(GameEnvironment.Screen.X / 2 - settingsButton.BoundingBox.Width / 2, (GameEnvironment.Screen.Y - settingsButton.BoundingBox.Height) / 2);
        RootList.Add(settingsButton);
        //Return button
        returnButton = new Button("Sprites/Menu/Return_Button", 101);
        returnButton.Position = new Vector2(GameEnvironment.Screen.X / 2 - returnButton.Width / 2, (GameEnvironment.Screen.Y - returnButton.Height) / 8 * 7);
        RootList.Add(returnButton);
    }

    public override void Update(GameTime gameTime)
    {
        if (firstTime)
        {
            firstTime = false;
        }
        base.Update(gameTime);
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        if (startButton.Pressed) //create host connection
        {
            GameEnvironment.ScreenFade.TransitionToScene("hostSelectionState", 5);
        }
        else if (settingsButton.Pressed) //create client connection
        {
            MultiplayerManager.Connect(1000);
            GameEnvironment.ScreenFade.TransitionToScene("portSelectionState", 5);
        }
        else if (returnButton.Pressed)
        {
            GameEnvironment.ScreenFade.TransitionToScene("modeSelectionState", 5);
        }
    }

    public override void Reset()
    {
        firstTime = true;
    }

}
