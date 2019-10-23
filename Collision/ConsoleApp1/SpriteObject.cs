using System;
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
        
        // TODO: add member for configurable origin/pivot point

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
            //float rotation = (float)Math.Atan2(globalTransform.m[0], globalTransform.m[1]);

            //DrawTextureEx(texture, new Vector2(globalTransform.m[6], globalTransform.m[7]),
            //    rotation * (float)(180.0f / Math.PI), 1, Color.WHITE);

            float rotation = (float)Math.Atan2(globalTransform.m1, globalTransform.m2)
                * (float)(180.0f / Math.PI);

            //rotation = 0;

            //DrawTextureEx(texture, new Raylib.Vector2(globalTransform.m7, globalTransform.m8),
            //    rotation * (float)(180.0f / Math.PI), 1, Color.WHITE);

            DrawTexturePro(texture,
                           new Rectangle(0, 0, Width, Height),
                           new Rectangle(globalTransform.m7, globalTransform.m8, Width, Height),
                           new Raylib.Vector2(Width / 2.0f, Height / 2.0f),
                           -rotation, Color.WHITE);

            // debug gizmos
            //DrawCircle((int)globalTransform.m7, (int)globalTransform.m8, 5.0f, Color.MAGENTA);
            //DrawLine((int)globalTransform.m7, (int)globalTransform.m8, (int)(globalTransform.m7 + globalTransform.m1 * 100), (int)(globalTransform.m8 + globalTransform.m2 * 100), Color.GREEN);

        }
       
    }
}
