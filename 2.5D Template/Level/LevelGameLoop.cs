﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

partial class Level : GameObjectLibrary
{
    public override void Update(GameTime gameTime)
    {
        for (int i = 0; i < RootList.Children.Count; i++)
        {
            if (RootList.Children[i] == "entities")
            {
                continue;
            }
            GetObject(RootList.Children[i]).Update(gameTime);
        }
    }

    //loops the level
    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        //skip entities
        foreach (string id in RootList.Children)
        {
            if (id == "entities")
            {
                continue;
            }
            GetObject(id).Draw(gameTime, spriteBatch);
        }
    }
}