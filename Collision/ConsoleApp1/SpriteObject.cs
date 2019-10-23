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
        public Texture2D texture = new Texture2D();
       
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

            //DrawCircle((int)projectileCollider.center.x, (int)projectileCollider.center.y, (int)projectileCollider.radius, Color.BLACK);

            // debug gizmos
            //DrawCircle((int)globalTransform.m7, (int)globalTransform.m8, 5.0f, Color.MAGENTA);
            //DrawLine((int)globalTransform.m7, (int)globalTransform.m8, (int)(globalTransform.m7 + globalTransform.m1 * 100), (int)(globalTransform.m8 + globalTransform.m2 * 100), Color.GREEN);

        }
       
    }
    class Projectile : SpriteObject
    {
        MathHelpers.Vector3 direction = new MathHelpers.Vector3(0, 0, 0);
        public Sphere projectileCollider = new Sphere(new MathHelpers.Vector3(0, 0, 0), 0);

        float lifetime = 5;
        float speed = 100f;
        public Projectile(MathHelpers.Vector3 d)
        {
            direction = d;
        }
        public Projectile(float x, float y)
        {
            direction.x = x;
            direction.y = y;
            //texture = LoadTexture("TankGameShell.png");

        }
        public override void OnUpdate(float deltaTime)
        {
            lifetime -= 1 * deltaTime;
            if (lifetime <= 0)
            {
                proDel = true;
            }
            projectileCollider.Resize(new MathHelpers.Vector3(GlobalTransform.m7, GlobalTransform.m8, 0), 6);

            MathHelpers.Vector3 facing = new MathHelpers.Vector3(direction.x, direction.y, 1) * deltaTime * speed;
            Translate(facing.x, facing.y);

        }
        public override void OnDraw()
        {
            //DrawTextureEx(Shell, ((int)projectileCollider.x,(int)projectileCollider.y) )

            DrawCircle((int)projectileCollider.center.x, (int)projectileCollider.center.y, (int)projectileCollider.radius, Color.BLACK);
            //Console.WriteLine("Shell Shot");

            //Todo: comment this out and scale the missile
        }
    }
}
