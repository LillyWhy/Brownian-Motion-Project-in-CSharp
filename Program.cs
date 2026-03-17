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

            while
        }
    }
}
