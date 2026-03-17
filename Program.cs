using System;
using System.Numerics;
using System.Runtime.InteropServices;
using System.IO;

using Raylib_cs;
using System.Security;

namespace Brownian_motion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbę ruchów /n");
            int LiczbaRuchow = int.Parse(Console.ReadLine());
            const int windowsWidth = 800;
            const int windowsHeight = 600;
            Raylib.InitWindow(windowsWidth, windowsHeight, "Projekt Fizyka Marcin Bubalik - Ruch Browna");
            Raylib.SetTargetFPS(60); //Zwiększenie klatek na sekunde wypłynie na szybkość ruchu cząsteczki

            Random generowanie = new Random();
            float x = 0;
            float y = 0;

            List<Particle> czasteczki = new List<Particle>();
            czasteczki.Add(new Particle(x, y));

            using StreamWriter plik = new StreamWriter("czasteczki.csv");
            plik.WriteLine("x,y");
            plik.WriteLine($"{x},{y}");

            int CurrentPostion = 0;
            bool SymulationEnds = false;

            while (!Raylib.WindowShouldClose())
            {
                if (CurrentPostion < n)
                {
                    double fi = generowanie.NextDouble() * 2 * Math.PI;

                    x = x + (float)Math.Cos(fi);
                    y = y + (float)Math.Sin(fi);

                    czasteczki.Add(new Particle(x, y));
                    CurrentPostion++

                    plik.WriteLine($"CurrentPostion,{x},{y}");

                }
                else if (!SymulationEnds)
                {
                    double s = Math.Sqrt(x * x + y * y);
                    Console.WriteLine($"Symulacja zakończona");
                    Console.WriteLine($"Końcowe położenie x={x}, y={y}");
                    Console.WriteLine($"Odległość od początku: {s}");
                    SymulationEnds = true;
                }
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib.Color.White);


            }
        }
    }
}
