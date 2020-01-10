﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

//This is the Online Selection Screen. Here you can choose to play Online 
class ClientSelectionState : GameObjectLibrary
{
    protected Button startButton, returnButton;
    protected bool firstTime = true;
    public ClientSelectionState()
    {

        //Load all menu sprites (e.g. background images, overlay images, button sprites)
        SpriteGameObject titleScreen = new SpriteGameObject("Sprites/Overlay/Menu_BG_Grey", 100, "background");
        RootList.Add(titleScreen);
        //Ready Button
        startButton = new Button("Sprites/Menu/Ready_Button", 101);
        startButton.Position = new Vector2((GameEnvironment.Screen.X - startButton.Width) / 8 * 1, (GameEnvironment.Screen.Y - startButton.Height) / 6);
        RootList.Add(startButton);
        
        //Return Button
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
        if (startButton.Pressed)
        {
            
        }
        else if (returnButton.Pressed)
        {
            GameEnvironment.ScreenFade.TransitionToScene("portSelectionState", 5);
        }
    }

    public override void Reset()
    {
        firstTime = true;
    }

}
