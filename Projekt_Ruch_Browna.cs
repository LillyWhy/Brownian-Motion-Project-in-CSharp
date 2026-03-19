using System;
using System.Collections.Generic;
using System.Numerics;
using System.IO;
using Raylib_cs;

namespace Brownian_motion
{
    public class GenereatedNew
    {
        public Vector2 Pozycja;

        public GenereatedNew(float x, float y)
        {
            Pozycja = new Vector2(x, y);
        }

        public void Aktualizuj(Random gen)
        {
            double fi = gen.NextDouble() * 2 * Math.PI;
            Pozycja.X += (float)Math.Cos(fi);
            Pozycja.Y += (float)Math.Sin(fi);
        }
    }

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
            int LiczbaRuchow = int.Parse(Console.ReadLine() ?? "");

            const int windowsWidth = 1024;
            const int windowsHeight = 768;
            Raylib.InitWindow(windowsWidth, windowsHeight, "Projekt Fizyka Marcin Bubalik - Ruch Browna");
            Raylib.SetTargetFPS(10);

            Random generowanie = new Random();
            float x = 0;
            float y = 0;

            List<Particle> czasteczki = new List<Particle>();
            czasteczki.Add(new Particle(x, y));

            List<GenereatedNew> chmura = new List<GenereatedNew>();
            for (int i = 0; i < 100; i++)
            {
                chmura.Add(new GenereatedNew(x, y));
            }

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

                    foreach (GenereatedNew p in chmura)
                    {
                        p.Aktualizuj(generowanie);
                    }

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

                foreach (GenereatedNew p in chmura)
                {
                    Vector2 pozycjaNaEkranie = srodekEkranu + (p.Pozycja * skala);
                    Raylib.DrawCircleV(pozycjaNaEkranie, 1.5f, new Color(100, 100, 100, 100));
                }

                for (int i = 0; i < czasteczki.Count - 1; i++)
                {
                    Vector2 p1 = srodekEkranu + (czasteczki[i].Pozycja * skala);
                    Vector2 p2 = srodekEkranu + (czasteczki[i + 1].Pozycja * skala);
                    Raylib.DrawLineV(p1, p2, Color.Blue);
                }

                if (czasteczki.Count > 0)
                {
                    Vector2 ostatniaPozycja = srodekEkranu + (czasteczki[czasteczki.Count - 1].Pozycja * skala);
                    Raylib.DrawCircleV(ostatniaPozycja, 4, Color.Red);
                }

                Raylib.DrawText($"Krok: {CurrentPosition} / {LiczbaRuchow}", 10, 10, 20, Color.Black);

                if (SimulationEnds)
                {
                    Raylib.DrawText("Symulacja zakonczona - Nacisnij ESC", 10, 40, 20, Color.Maroon);
                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
