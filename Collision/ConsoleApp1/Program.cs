using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            Game game = new Game();
            
            int screenWidth = 640;

            int screenHeight = 480;

            rl.InitWindow(screenWidth, screenHeight, "Tanks for Everything!");

            //rl.SetTargetFPS(60);
            //--------------------------------------------------------------------------------------
            game.Init();
            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                game.Update();
                game.Draw();
                
                //rl.BeginDrawing();

                //rl.ClearBackground(Color.RAYWHITE);
                
                //----------------------------------------------------------------------------------
            }
            game.Shutdown();

            // De-Initialization
            //--------------------------------------------------------------------------------------
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

        }
    }
}
