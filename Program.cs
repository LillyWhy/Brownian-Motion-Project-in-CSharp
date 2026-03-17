using System;
using System.Collections.Generic;
using System.Numerics;
using System.IO;
using Raylib_cs;

namespace Brownian_motion
{
    public class Particle
    {
        public Vector2 Pozycja;

        public Particle(float x, float y)
        {
            Pozycja = new Vector2(x, y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbe ruchow:");
            int LiczbaRuchow = int.Parse(Console.ReadLine());

            const int windowsWidth = 800;
            const int windowsHeight = 600;
            Raylib.InitWindow(windowsWidth, windowsHeight, "Projekt Fizyka Marcin Bubalik - Ruch Browna");
            Raylib.SetTargetFPS(20);

            Random generowanie = new Random();
            float x = 0;
            float y = 0;

            List<Particle> czasteczki = new List<Particle>();
            czasteczki.Add(new Particle(x, y));

            using StreamWriter plik = new StreamWriter("wyniki_symulacji.xls");
            plik.WriteLine("Krok;X;Y");
            plik.WriteLine($"0;{x};{y}");

            int CurrentPosition = 0;
            bool SimulationEnds = false;

            while (!Raylib.WindowShouldClose() && !Raylib.IsKeyDown(KeyboardKey.Escape))
            {
                if (CurrentPosition < LiczbaRuchow)
                {
                    double fi = generowanie.NextDouble() * 2 * Math.PI;

                    x = x + (float)Math.Cos(fi);
                    y = y + (float)Math.Sin(fi);

                    czasteczki.Add(new Particle(x, y));
                    CurrentPosition++;

                    string xString = x.ToString().Replace('.', ',');
                    string yString = y.ToString().Replace('.', ',');
                    plik.WriteLine($"{CurrentPosition};{xString};{yString}");
                }
                else if (!SimulationEnds)
                {
                    double s = Math.Sqrt(x * x + y * y);
                    Console.WriteLine("Symulacja zakonczona");
                    Console.WriteLine($"Koncowe polozenie x={x}, y={y}");
                    Console.WriteLine($"Odleglosc od poczatku: {s}");
                    SimulationEnds = true;
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RayWhite);

                Vector2 srodekEkranu = new Vector2(windowsWidth / 2, windowsHeight / 2);
                float skala = 15.0f;

                for (int i = 0; i < czasteczki.Count - 1; i++)
                {
                    Vector2 p1 = srodekEkranu + (czasteczki[i].Pozycja * skala);
                    Vector2 p2 = srodekEkranu + (czasteczki[i + 1].Pozycja * skala);
                    Raylib.DrawLineV(p1, p2, Color.Blue);
                }

                if (czasteczki.Count > 0)
                {
                    Vector2 ostatniaPozycja = srodekEkranu + (czasteczki[czasteczki.Count - 1].Pozycja * skala);
                    Raylib.DrawCircleV(ostatniaPozycja, 5, Color.Red);
                }

                Raylib.DrawText($"Krok: {CurrentPosition} / {LiczbaRuchow}", 10, 10, 20, Color.Black);
                if (SimulationEnds)
                {
                    Raylib.DrawText("Symulacja zakonczona, wcisnij ESC aby wyjsc", 10, 40, 20, Color.Maroon);
                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
