using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs;

namespace Brownian_motion
{
    class Program
    {
        static void Main(string[] args)
        {
            const int windowsWidth = 800;
            const int windowsHeight = 600;

            Raylib.InitWindow(windowsWidth, windowsHeight, "Projekt Fizyka Marcin Bubalik - Ruch Browna");
            Raylib.SetTargetFPS(60);

            Random random = new Random();
            Particle particle = new Particle(random);
            PointPosition position = new PointPosition(windowsWidth / 2, windowsHeight / 2);
            particle.Position = position;
            particle.Update();


            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);
                particle.Draw();
                particle.Update();
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
