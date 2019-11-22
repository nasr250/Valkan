﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class GameStart : GameEnvironment
{

    protected TextGameObject framecounter, physicscounter;
    protected int frames = 0;
    protected int physics = 0;
    protected double time = 0;
    protected double time2 = 0;


    static void Main()
    {
        GameStart game = new GameStart();
        game.Run();
    }

    public GameStart()
    {
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
    }

    protected override void LoadContent()
    {
        base.LoadContent();
        screen = new Point(1920, 1080);
        windowSize = new Point(1280, 720);
        FullScreen = false;

        gameStateManager.AddGameState("playingState", new PlayingState(Content));
        gameStateManager.SwitchTo("playingState");

        framecounter = new TextGameObject("Fonts/Hud");
        physicscounter = new TextGameObject("Fonts/Hud");
        physicscounter.Position = new Vector2(0, 30);
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        physics++;
        if (time2 <= 0)
        {
            time2 = 1;
            physicscounter.Text = physics.ToString();
            physics = 0;
        }
        else
        {
            time2 -= gameTime.ElapsedGameTime.TotalSeconds;
        }
    }

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        spriteBatch.Begin();
        framecounter.Draw(gameTime, spriteBatch);
        physicscounter.Draw(gameTime, spriteBatch);
        spriteBatch.End();

        frames++;
        if (time <= 0)
        {
            time = 1;
            framecounter.Text = frames.ToString();
            frames = 0;
        }
        else
        {
            time -= gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
