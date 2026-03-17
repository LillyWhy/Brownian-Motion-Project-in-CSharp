# Brownian Motion Project in C#

Aplikacja zaliczeniowa [Fizyka]

Autor projektu: Marcin Bubalik

Github: https://github.com/LillyWhy/Brownian_motion

Opis Projektu:

Projekt przedstawiajacy Ruch browna czyli proces losowy wręcz chaoryczny, w którym cząsteczka porusza się po płaszczyźnie.

Projekt został napisany w języku C# za pomocą IDE ZED, oraz generuje ruch za pomocą prostego silnika graficznego Raylib-cs.

Praca działa w przedziale od 1 do 240 FPS (klatki na sekundę)

zbyt duza ilość FPS może wpłynąć negatwynie na stabilność symulacji,

aby nie obciążać procesora zaleca się ustawieniu stabilnych FPS (1-240) w silniku graficznym Raylib-cs.

Każdy ruch cząsteczki jest zapisywany do pliku csv.

Wymagania sprzętowe:

- Środowisko programistyczne z obsługą .NET: Visual Studio, JetBrains Rider, Visual Studio Code, ZED
- System operacyjny: Windows, macOS, Linux
- Pakiet Microsoft .NET w wersji 10.0+
- Biblioteka Raylib-cs (https://github.com/ChrisDill/Raylib-cs)
- Program do obsługi plików csv

Platforma testowa:

Macbook Pro 15-inch, 2018
- Intel Core i7
- 16GB RAM
- GPU: Intel UHD Graphics 630
- MacOS Sequoia 15.7.4

Instrukcja instalacji Silnika Graficznego Raylib-cs:

1. Sklonuj repozytorium projektu: `git clone https://github.com/LillyWhy/Brownian_motion.git`
2. Otwórz projekt w swoim IDE (Visual Studio, JetBrains Rider, Visual Studio Code)
3. Zainstaluj Raylib-cs jako pakiet NuGet w swoim projekcie za pomocą komendy w terminalu `dotnet add package Raylib-cs`
4. Uruchom projekt

Historia zmian:

16.03.2026 v0.1

Stworzenie formatu, szablonu projektu.

17.03.2026 v0.2

Dodanie silnika graficznego (Raylib-cs) w celu poprawnej kompilacji na urządzeniach opartych na systemie MacOS

17.03.2026 v0.3

Implementacja zapisywania ruchu cząsteczki do pliku csv, poprawa jakości kodu.

17.03.2026 v0.4

Implementacja silnika graficznego Raylib-cs poprawa obługi plików csv.

Testy kompilacji poprawa jakości kodu w zakresie 1-240 FPS.

Niestabilność symulacji powyzej 241 FPS.

17.03.2026 v0.5

Ustawienie stabilnych 15 FPS w silniku graficznym Raylib-cs.

Wynik symulacji zaspisuje sie do pliku xls.

Wyniki są zapisywanie po przecinku { , }
