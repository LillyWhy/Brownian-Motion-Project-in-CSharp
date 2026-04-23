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
            const int windowWidth = 1024;
            const int windowHeight = 768;

            Raylib.SetConfigFlags(ConfigFlags.VSyncHint | ConfigFlags.Msaa4xHint | ConfigFlags.HighDpiWindow);
            Raylib.InitWindow(windowWidth, windowHeight, "Project Brownian Motion");
            Raylib.SetTargetFPS(60);

            string nInput = "";
            bool inputMode = true;
            int LiczbaRuchow = 0;

            Random generowanie = new Random();
            float x = 0, y = 0, skala = 15.0f;
            int CurrentPosition = 0;
            bool SimulationEnds = false;

            double lastStepTime = 0;
            double stepInterval = 0.05;

            List<Particle> trasa = new List<Particle>();
            List<GenereatedNew> chmura = new List<GenereatedNew>();
            StreamWriter? plik = null;

            while (!Raylib.WindowShouldClose())
            {
                if (inputMode)
                {
                    int key = Raylib.GetCharPressed();
                    while (key > 0)
                    {
                        if ((key >= 48) && (key <= 57) && (nInput.Length < 7)) nInput += (char)key;
                        key = Raylib.GetCharPressed();
                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.Backspace) && nInput.Length > 0)
                        nInput = nInput.Substring(0, nInput.Length - 1);

                    if (Raylib.IsKeyPressed(KeyboardKey.Enter) && nInput.Length > 0)
                    {
                        LiczbaRuchow = int.Parse(nInput);
                        trasa.Add(new Particle(0, 0));
                        for (int i = 0; i < 500; i++) chmura.Add(new GenereatedNew(0, 0));
                        plik = new StreamWriter("Symulation_results.xls");
                        plik.WriteLine("Step;X;Y");
                        plik.WriteLine("0;0,000;0,000");
                        inputMode = false;
                        lastStepTime = Raylib.GetTime();
                    }
                }
                else
                {
                    float limitX = (Raylib.GetScreenWidth() / 2.0f - 20) / skala;
                    float limitY = (Raylib.GetScreenHeight() / 2.0f - 20) / skala;

                    if (Raylib.IsKeyDown(KeyboardKey.Equal) || Raylib.IsKeyDown(KeyboardKey.KpAdd))
                        stepInterval = Math.Max(0.001, stepInterval - 0.002);

                    if (Raylib.IsKeyDown(KeyboardKey.Minus) || Raylib.IsKeyDown(KeyboardKey.KpSubtract))
                        stepInterval = Math.Min(1.0, stepInterval + 0.002);

                    if (CurrentPosition < LiczbaRuchow && Raylib.GetTime() >= lastStepTime + stepInterval)
                    {
                        double fi = generowanie.NextDouble() * 2 * Math.PI;
                        float kX = (float)Math.Cos(fi);
                        float kY = (float)Math.Sin(fi);

                        if (Math.Abs(x + kX) > limitX) kX = -kX;
                        if (Math.Abs(y + kY) > limitY) kY = -kY;

                        x += kX; y += kY;
                        trasa.Add(new Particle(x, y));
                        foreach (var p in chmura) p.Aktualizuj(generowanie, limitX, limitY);

                        CurrentPosition++;
                        lastStepTime = Raylib.GetTime();

                        if (plik != null) plik.WriteLine($"{CurrentPosition};{x:F3};{y:F3}".Replace('.', ','));
                    }
                    else if (CurrentPosition >= LiczbaRuchow && !SimulationEnds)
                    {
                        SimulationEnds = true;
                        if (plik != null) { plik.Close(); plik = null; }
                    }

                    float wheel = Raylib.GetMouseWheelMove();
                    if (wheel != 0) { skala += wheel * 2.0f; if (skala < 1.0f) skala = 1.0f; }
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RayWhite);

                if (inputMode)
                {
                    Raylib.DrawText("Project Brownian Motion", 250, 200, 30, Color.DarkBlue);
                    Raylib.DrawText("Input number of steps and press ENTER:", 250, 280, 20, Color.Black);
                    Raylib.DrawRectangle(250, 320, 300, 50, Color.LightGray);
                    Raylib.DrawText(nInput, 260, 330, 30, Color.Red);
                }
                else
                {
                    Vector2 srodek = new Vector2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2);
                    float lX = (Raylib.GetScreenWidth() / 2.0f - 20) / skala;
                    float lY = (Raylib.GetScreenHeight() / 2.0f - 20) / skala;
                    float LineThic = 3.0f;

                    Raylib.DrawRectangleLinesEx(new Rectangle(srodek.X - lX * skala, srodek.Y - lY * skala, lX * 2 * skala, lY * 2 * skala), 2.0f, Color.LightGray);
                    foreach (var p in chmura) Raylib.DrawCircleV(srodek + (p.Pozycja * skala), 1.2f, new Color(200, 0, 200, 200));
                    for (int i = 0; i < trasa.Count - 1; i++) Raylib.DrawLineEx(srodek + (trasa[i].Pozycja * skala), srodek + (trasa[i + 1].Pozycja * skala), LineThic, Color.SkyBlue);

                    Vector2 cur = srodek + (new Vector2(x, y) * skala);
                    Raylib.DrawCircleV(cur, 10, Color.Red);

                    Raylib.DrawText($"Step: {CurrentPosition} / {LiczbaRuchow}", 20, 20, 20, Color.Black);
                    Raylib.DrawText($"Speed: {1.0 / stepInterval:F1} steps/sec (+/- to change)", 20, 45, 15, Color.Gray);

                    if (SimulationEnds) Raylib.DrawText("Symulation Complete - ESC to exit", 20, 70, 20, Color.Maroon);
                }

                Raylib.EndDrawing();
            }
            if (plik != null) plik.Close();
            Raylib.CloseWindow();
        }
    }
}