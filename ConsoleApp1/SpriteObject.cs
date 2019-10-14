﻿using System;
using MathHelpers;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;
using static Raylib.Raylib;
using System.Diagnostics;

namespace ConsoleApp1
{
    class SpriteObject : SceneObject
    {
        Texture2D texture = new Texture2D();
        Image image = new Image();

        public float Width
        {
            get { return texture.width; }

        }

        public float Height
        {
            get { return texture.height; }
        }

        public SpriteObject()
        {

        }

        public void Load(string filename)
        {
            Image img = LoadImage(filename);
            texture = LoadTextureFromImage(img);

        }
        public override void OnDraw()
        {
            float rotation = (float)Math.Atan2(globalTransform.m[0], globalTransform.m[1]);
            
            DrawTextureEx(texture, new Vector2(globalTransform.m[6], globalTransform.m[7]),
                rotation * (float)(180.0f / Math.PI), 1, Color.WHITE);
        }
    }
}
