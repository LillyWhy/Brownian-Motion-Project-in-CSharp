### POLISH
# Brownian Motion Project in C#

Aplikacja zaliczeniowa – projekt z fizyki.

**Autor projektu:** Marcin Bubalik  
**GitHub:** [https://github.com/LillyWhy/Brownian_motion](https://github.com/LillyWhy/Brownian_motion)

## Opis Projektu

Projekt przedstawia ruch Browna, czyli proces losowy, wręcz chaotyczny, w którym cząsteczka porusza się po płaszczyźnie.

<img width="1026" height="570" alt="gif_new" src="https://github.com/user-attachments/assets/6c38cdd3-a671-4127-9ee2-e79759584ae6" />9b1b-1fee4fe7012d)

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

### See [LICENSE](LICENSE) for details.

### ENGLISH

# Brownian Motion Project in C#

Academic Project – Physics Simulation.

**Project Author:** Marcin Bubalik  
**GitHub:** [https://github.com/LillyWhy/Brownian_motion](https://github.com/LillyWhy/Brownian_motion)

## Project Description

This project simulates Brownian motion—a random, almost chaotic process in which a particle moves across a 2D plane.

![new_gif](https://github.com/user-attachments/assets/ee7bef67-1c92-4333-9cb2-f602c6c9cb89)


The application was developed in C# using the ZED IDE and utilizes the **Raylib-cs** graphics engine for rendering. 
The simulation supports a range of 1 to 240 FPS (frames per second).

**Important:** Excessive frame rates (above 241 FPS) may negatively impact simulation stability. To avoid unnecessary CPU load, it is recommended to remain within the stable 1-240 FPS range.

Every movement of the particle is recorded in real-time to an external spreadsheet file for further analysis.

![results](https://github.com/user-attachments/assets/c8dfafd4-9d50-4180-84e3-87aa9d25e1a3)

## System Requirements

- **Development Environment:** Visual Studio, JetBrains Rider, VS Code, or ZED.
- **Operating System:** Windows, macOS, or Linux.
- **SDK:** Microsoft .NET SDK 10.0+
- **Graphics Library:** Raylib-cs ([GitHub Link](https://github.com/ChrisDill/Raylib-cs))
- **Spreadsheet Software:** Microsoft Excel, LibreOffice Calc, or OpenOffice.

## Test Platform

**MacBook Pro 15-inch, 2018**
- **Processor:** Intel Core i7
- **RAM:** 16GB
- **GPU:** Intel UHD Graphics 630
- **OS:** macOS Sequoia 15.7.4

## Installation and Setup

### 1. Raylib Engine Installation
This project uses the **Raylib-cs** wrapper. To ensure the graphics engine runs correctly, make sure the Raylib binaries are installed on your system:
- **Windows:** `.dll` files are usually handled automatically via the NuGet package.
- **macOS:** Install via Homebrew:  
  `brew install raylib`
- **Linux:** Install the development package for your distribution, e.g., Debian/Ubuntu:  
  `sudo apt install libraylib-dev`

### 2. Downloading and Running
1. Clone the repository:
   ```bash
   git clone [https://github.com/LillyWhy/Brownian_motion.git](https://github.com/LillyWhy/Brownian_motion.git)

### See [LICENSE](LICENSE) for details.
