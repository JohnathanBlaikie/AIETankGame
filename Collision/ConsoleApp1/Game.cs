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

        List<SceneObject> Hierarchy = new List<SceneObject>();

        SceneObject tankObject = new SceneObject();
        SceneObject turretObject = new SceneObject();
        SceneObject shellObject = new SceneObject();

        SpriteObject tankSprite = new SpriteObject();
        SpriteObject turretSprite = new SpriteObject();
        SpriteObject shellSprite = new SpriteObject();

        Timer bruh = new Timer();

        MathHelpers.AABB playerCollider = new MathHelpers.AABB(new MathHelpers.Vector3(0,0,0), new MathHelpers.Vector3(0,0,0));
        SceneObject[] playerCorners = new SceneObject[4]
        {
            new SceneObject(), new SceneObject(), new SceneObject(), new SceneObject()
        };
        MathHelpers.Vector3[] pCA = new MathHelpers.Vector3[4];

        Color boxColor = Color.GREEN;
        MathHelpers.AABB boxCollider = new MathHelpers.AABB(new MathHelpers.Vector3(300, 300, 0), new MathHelpers.Vector3(400, 400, 0));

        public void Init()
        {
            SetTargetFPS(60);
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            Hierarchy.Add(shellObject);
            Hierarchy.Add(tankObject);


            tankSprite.Load("tankblue_outline.png");
            //tankSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            //tankSprite.SetPosition(-tankSprite.Width / 2.0f, tankSprite.Height / 2.0f);

            turretSprite.Load("barrelBlue.png");
            turretSprite.SetPosition(0, 0);
            //turretSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            //turretSprite.SetPosition(turretSprite.Width / 2.0f, 0);
            turretSprite.SetPosition(25, 0);

            shellSprite.Load("TankGameshell.png");


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
            #endregion Movement

            if (IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                Projectile shell = new Projectile(turretObject.GlobalTransform.m5, -turretObject.GlobalTransform.m4);
                shell.SetPosition(turretObject.GlobalTransform.m7, turretObject.GlobalTransform.m8);
                shellObject.AddChild(shell);


                //MathHelpers.Vector3 facing = new MathHelpers.Vector3 (
                //    tankObject.LocalTransform.m1,
                //    tankObject.LocalTransform.m2, 1) *deltaTime * -1000;
                //tankObject.Translate(facing.x, facing.y);
            }

            if (boxCollider.Overlaps(playerCollider))
                boxColor = Color.DARKGREEN;
            else
                boxColor = Color.GREEN;

            for (int i = 0; i < shellObject.GetChildCount(); i++)
            {
                if(shellObject.GetChild(i).proDel)
                {
                    shellObject.RemoveChild(shellObject.GetChild(i));

                }
            }
            for (int i = 0; i < shellObject.GetChildCount(); i++)
            {
                Projectile tShell = (Projectile)shellObject.GetChild(i);
                if (!boxCollider.Overlaps(playerCollider))
                {
                    if(tShell.projectileCollider.Overlaps(boxCollider))
                    {
                        boxColor = Color.RED;
                        break;
                    }
                    else
                    {
                        boxColor = Color.GREEN;
                    }
                }
            }

            tankObject.UpdateTransform();
            //tankObject.Update(deltaTime);

            

            playerCollider.Resize(new MathHelpers.Vector3(tankObject.GlobalTransform.m7 - (tankSprite.Width / 2), tankObject.GlobalTransform.m8 - (tankSprite.Height / 2), 0),
                                  new MathHelpers.Vector3(tankObject.GlobalTransform.m7 + (tankSprite.Width / 2), tankObject.GlobalTransform.m8 + (tankSprite.Height / 2), 0));
            //DrawRectangle(90, 90, 90, 10, Color.RED);
            Vector2 v2 = new Vector2(900, 24);
            //DrawLineStrip(ref v2, 255, Color.VIOLET);
            lastTime = currentTime;

            foreach (SceneObject i in Hierarchy)
            {
                i.Update(deltaTime);
            }

        }


        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);
            DrawText(fps.ToString(), 10, 10, 12, Color.RED);

            //MathHelpers.AABB boxCollider = new MathHelpers.AABB(new MathHelpers.Vector3(120, 120, 0), new MathHelpers.Vector3(200, 200, 0));
            //boxCollider.Corners();

            DrawRectangle(300, 300, 100, 100, boxColor);


            foreach (SceneObject i in Hierarchy)
            {
                i.Draw();
            }

            //tankObject.Draw();
            EndDrawing();
        }
    }
}
