# Brownian Motion Project in C#

Aplikacja zaliczeniowa – projekt z fizyki.

**Autor projektu:** Marcin Bubalik  
**GitHub:** [https://github.com/LillyWhy/Brownian_motion](https://github.com/LillyWhy/Brownian_motion)

## Opis Projektu

Projekt przedstawia ruch Browna, czyli proces losowy, wręcz chaotyczny, w którym cząsteczka porusza się po płaszczyźnie.

![brownian_motion](https://github.com/user-attachments/assets/151bafb3-9606-4711-b9e5-3f6abfaf4bf3)

Aplikacja została napisana w języku C# przy użyciu IDE ZED. Generuje ruch za pomocą wydajnego silnika graficznego Raylib-cs.
Symulacja pozwala na działanie w przedziale od 1 do 240 FPS (klatek na sekundę). 

**Ważne:** Zbyt duża ilość FPS może wpłynąć negatywnie na stabilność symulacji (powyżej 241 FPS). Aby nie obciążać procesora, zaleca się nie przekraczać stabilnych wartości renderowania w silniku Raylib-cs.

Każdy ruch cząsteczki jest na bieżąco zapisywany do zewnętrznego pliku arkusza kalkulacyjnego w celu późniejszej analizy.

![resoults](https://github.com/user-attachments/assets/c8dfafd4-9d50-4180-84e3-87aa9d25e1a3)

## Wymagania sprzętowe

- Środowisko programistyczne z obsługą .NET: Visual Studio, JetBrains Rider, Visual Studio Code lub ZED
- System operacyjny: Windows, macOS, Linux
- Pakiet Microsoft .NET SDK w wersji 10.0+
- Biblioteka Raylib-cs (https://github.com/ChrisDill/Raylib-cs)
- Program do obsługi plików CSV/XLS (Microsoft Office Excel, LibreOffice Calc, OpenOffice)

## Platforma testowa

**MacBook Pro 15-inch, 2018**
- Procesor: Intel Core i7
- Pamięć: 16GB RAM
- Karta graficzna: Intel UHD Graphics 630
- System operacyjny: macOS Sequoia 15.7.4

## Instrukcja instalacji i uruchomienia

### 1. Instalacja silnika Raylib
Projekt korzysta z wrapper'a **Raylib-cs**. Aby silnik graficzny działał poprawnie, należy upewnić się, że w systemie znajdują się pliki binarne biblioteki Raylib.
- **Windows:** Pliki `.dll` są zazwyczaj dołączane automatycznie przy instalacji pakietu NuGet.
- **macOS:** Należy zainstalować Raylib za pomocą Homebrew:  
  `brew install raylib` lub `dotnet add package Raylib-cs`
- **Linux:** Należy zainstalować pakiet odpowiedni dla dystrybucji, np. Debian (APT):  
  `sudo apt install libraylib-dev`

### 2. Pobranie i uruchomienie projektu
1. Sklonuj repozytorium projektu: 
   ```bash
   git clone [https://github.com/LillyWhy/Brownian_motion.git](https://github.com/LillyWhy/Brownian_motion.git)
2. Uruchom Projekt dotnet run [Nazwa Projektu.cs]
