# Brownian_motion

Aplikacja zaliczeniowa [Fizyka]

Autor projektu: Marcin Bubalik

Github: 'https://github.com/LillyWhy/Brownian_motion'

Opis:
Projekt przedstawiajacy Ruch browna czyli proces losowy wręcz chaoryczny, w którym cząsteczka porusza się losowo po płaszczyźnie.
Projekt został napisany w języku C# za pomocą IDE ZED, oraz z dodatakiem prostego silnika graficznego Raylib-cs.
Praca działa w 60 FPS (klatki na sekundę), aby nie obciążać procesora, zwiekszenie FPS może wpłynąć na jakość ruchu, a także szybkość poruszania się cząsteczki.
Każdy ruch cząsteczki jest zapisywany do pliku csv.

Wymagania sprzętowe:

- Środowisko programistyczne z obsługą .NET: Visual Studio, JetBrains Rider, Visual Studio Code, ZED
- System operacyjny: Windows, macOS, Linux
- Pakiet Microsoft .NET w wersji 10.0+
- Biblioteka Raylib-cs (https://github.com/ChrisDill/Raylib-cs)
- Program do obsługi plików csv

Instrukcja instalacji Silnika Graficznego Raylib-cs:

1. Sklonuj repozytorium projektu: `git clone https://github.com/LillyWhy/Brownian_motion.git`
2. Otwórz projekt w swoim IDE (Visual Studio, JetBrains Rider, Visual Studio Code)
3. Zainstaluj Raylib-cs jako pakiet NuGet w swoim projekcie za pomocą komendy w terminalu `dotnet add package Raylib-cs`
4. Uruchom projekt

Historia zmian:

16.03.2026 v0.1
Stworzenie formatu, szablonu projektu.

17.03.2026 v0.2
Dodanie dodanie silnika graficznego (Raylib-cs) w celu poprawnej kompilacji na urządzeniach opartych na systemie MacOS

17.03.2026 v0.3
Dodanie zapisywania ruchu cząsteczki do pliku csv, poprawa jakości kodu.
