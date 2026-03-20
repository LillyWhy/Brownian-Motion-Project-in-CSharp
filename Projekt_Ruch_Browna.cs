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
        public GenereatedNew(float x, float y) => Pozycja = new Vector2(x, y);

        public void Aktualizuj(Random gen, float limX, float limY)
        {
            double fi = gen.NextDouble() * 2 * Math.PI;
            float nx = Pozycja.X + (float)Math.Cos(fi);
            float ny = Pozycja.Y + (float)Math.Sin(fi);

            if (Math.Abs(nx) > limX) nx = 0;
            if (Math.Abs(ny) > limY) ny = 0;

            Pozycja = new Vector2(nx, ny);
        }
    }

    public class Particle
    {
        public Vector2 Pozycja;
        public Particle(float x, float y) => Pozycja = new Vector2(x, y);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbe ruchow:");
            string input = Console.ReadLine() ?? "1000";
            if (!int.TryParse(input, out int LiczbaRuchow)) LiczbaRuchow = 1000;

            const int windowWidth = 1024;
            const int windowHeight = 768;

            Raylib.SetConfigFlags(ConfigFlags.VSyncHint | ConfigFlags.Msaa4xHint | ConfigFlags.HighDpiWindow);
            Raylib.InitWindow(windowWidth, windowHeight, "Projekt Fizyka - Ruchy Browna");
            Raylib.SetTargetFPS(30);

            Random generowanie = new Random();
            float x = 0, y = 0, skala = 15.0f;

            List<Particle> trasa = new List<Particle>();
            trasa.Add(new Particle(x, y));

            List<GenereatedNew> chmura = new List<GenereatedNew>();
            for (int i = 0; i < 500; i++) chmura.Add(new GenereatedNew(0, 0));

            using StreamWriter plik = new StreamWriter("wyniki_symulacji.xls");
            plik.WriteLine("Krok;X;Y");
            plik.WriteLine("0;0,000;0,000");

            int CurrentPosition = 0;
            bool SimulationEnds = false;

            while (!Raylib.WindowShouldClose() && !Raylib.IsKeyDown(KeyboardKey.Escape))
            {
                float limitX = (Raylib.GetScreenWidth() / 2.0f - 20) / skala;
                float limitY = (Raylib.GetScreenHeight() / 2.0f - 20) / skala;

                if (CurrentPosition < LiczbaRuchow)
                {
                    double fi = generowanie.NextDouble() * 2 * Math.PI;
                    float krokX = (float)Math.Cos(fi);
                    float krokY = (float)Math.Sin(fi);

                    if (Math.Abs(x + krokX) > limitX) krokX = -krokX;
                    if (Math.Abs(y + krokY) > limitY) krokY = -krokY;

                    x += krokX;
                    y += krokY;

                    trasa.Add(new Particle(x, y));
                    foreach (var p in chmura) p.Aktualizuj(generowanie, limitX, limitY);

                    CurrentPosition++;

                    string xStr = x.ToString("F3").Replace('.', ',');
                    string yStr = y.ToString("F3").Replace('.', ',');
                    plik.WriteLine($"{CurrentPosition};{xStr};{yStr}");
                }
                else if (!SimulationEnds)
                {
                    double s = Math.Sqrt(x * x + y * y);
                    Console.WriteLine("Symulacja zakonczona");
                    Console.WriteLine($"Odleglosc: {s:F2}");
                    SimulationEnds = true;
                }

                float wheel = Raylib.GetMouseWheelMove();
                if (wheel != 0)
                {
                    skala += wheel * 2.0f;
                    if (skala < 1.0f) skala = 1.0f;
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RayWhite);

                Vector2 srodek = new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);

                Raylib.DrawRectangleLinesEx(
                    new Rectangle(srodek.X - limitX * skala, srodek.Y - limitY * skala, limitX * 2 * skala, limitY * 2 * skala),
                    2.0f, Color.LightGray
                );

                foreach (var p in chmura)
                {
                    Vector2 pos = srodek + (p.Pozycja * skala);
                    Raylib.DrawCircleV(pos, 1.2f, new Color(200, 0, 255, 200));
                }

                for (int i = 0; i < trasa.Count - 1; i++)
                {
                    Vector2 p1 = srodek + (trasa[i].Pozycja * skala);
                    Vector2 p2 = srodek + (trasa[i + 1].Pozycja * skala);
                    Raylib.DrawLineV(p1, p2, Color.SkyBlue);
                }

                Vector2 currentPos = srodek + (new Vector2(x, y) * skala);
                Raylib.DrawCircleV(currentPos, 5, Color.Red);
                Raylib.DrawCircleLines((int)currentPos.X, (int)currentPos.Y, 5, Color.Maroon);

                Raylib.DrawText($"Krok: {CurrentPosition} / {LiczbaRuchow}", 20, 20, 20, Color.Black);
                if (SimulationEnds) Raylib.DrawText("ZAKONCZONO - ESC", 20, 50, 20, Color.Maroon);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
