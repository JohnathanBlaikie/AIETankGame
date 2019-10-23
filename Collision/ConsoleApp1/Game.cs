using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using Raylib;
using static Raylib.Raylib;

namespace ConsoleApp1
{
    class Game
    {
        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime = 0.005f;
        SceneObject tankObject = new SceneObject();
        SceneObject turretObject = new SceneObject();
        SceneObject missileObject = new SceneObject();

        SpriteObject tankSprite = new SpriteObject();
        SpriteObject turretSprite = new SpriteObject();
        SpriteObject missileSprite = new SpriteObject();

        Timer bruh = new Timer();

        MathHelpers.AABB playerCollider = new MathHelpers.AABB(new MathHelpers.Vector3(0,0,0), new MathHelpers.Vector3(0,0,0));
        SceneObject[] playerCorners = new SceneObject[4]
        {
            new SceneObject(), new SceneObject(), new SceneObject(), new SceneObject()
        };
        MathHelpers.Vector3[] pCA = new MathHelpers.Vector3[4];

        Color boxColor = Color.GREEN;
        MathHelpers.AABB boxCollider = new MathHelpers.AABB(new MathHelpers.Vector3(120, 120, 0), new MathHelpers.Vector3(200, 200, 0));

        public void Init()
        {
            SetTargetFPS(60);

            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            tankSprite.Load("tankblue_outline.png");
            //tankSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            //tankSprite.SetPosition(-tankSprite.Width / 2.0f, tankSprite.Height / 2.0f);

            turretSprite.Load("barrelBlue.png");
            turretSprite.SetPosition(0, 0);
            //turretSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            //turretSprite.SetPosition(turretSprite.Width / 2.0f, 0);
            turretSprite.SetPosition(25, 0);


            turretObject.AddChild(turretSprite);
            tankObject.AddChild(tankSprite);
            tankObject.AddChild(turretObject); // TODO: put this back

            tankObject.SetPosition(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f);

        }

        public void Shutdown() { }

        public void Update()
        {
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            Timer coolDown = new Timer();

            timer += deltaTime;
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }

            frames++;
            #region Movement
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                tankObject.Rotate(-deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                tankObject.Rotate(deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                //MathHelpers.Vector3 facing = new MathHelpers.Vector3(
                //    tankObject.LocalTransform.m[0],
                //    tankObject.LocalTransform.m[1], 1) * deltaTime * 100;
                //tankObject.Translate(facing.x, facing.y);
                MathHelpers.Vector3 facing = new MathHelpers.Vector3(
                    tankObject.LocalTransform.m1,
                    tankObject.LocalTransform.m2, 1) * deltaTime * 100;
                tankObject.Translate(facing.x, facing.y);

            }
            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                //MathHelpers.Vector3 facing = new MathHelpers.Vector3(
                //tankObject.LocalTransform.m[0],
                //tankObject.LocalTransform.m[1], 1) * deltaTime * -100;
                //tankObject.Translate(facing.x, facing.y);
                MathHelpers.Vector3 facing = new MathHelpers.Vector3(
                    tankObject.LocalTransform.m1,
                    tankObject.LocalTransform.m2, 1) * deltaTime * -100;
                tankObject.Translate(facing.x, facing.y);


            }
            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                turretObject.Rotate(-deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                turretObject.Rotate(deltaTime);
            }
            if (IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                MathHelpers.Vector3 facing = new MathHelpers.Vector3 (
                    tankObject.LocalTransform.m1,
                    tankObject.LocalTransform.m2, 1) *deltaTime * -1000;
                tankObject.Translate(facing.x, facing.y);
            }
            
            tankObject.UpdateTransform();
            tankObject.Update(deltaTime);
            #endregion Movement

            playerCollider.Resize(new MathHelpers.Vector3(tankObject.GlobalTransform.m7 - (tankSprite.Width / 2), tankObject.GlobalTransform.m8 - (tankSprite.Height / 2), 0),
                                  new MathHelpers.Vector3(tankObject.GlobalTransform.m7 + (tankSprite.Width / 2), tankObject.GlobalTransform.m8 + (tankSprite.Height / 2), 0));
            //DrawRectangle(90, 90, 90, 10, Color.RED);
            Vector2 v2 = new Vector2(900, 24);
            //DrawLineStrip(ref v2, 255, Color.VIOLET);


            lastTime = currentTime;
        }


        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);
            DrawText(fps.ToString(), 10, 10, 12, Color.RED);

            tankObject.Draw();
            EndDrawing();
        }
    }
}
