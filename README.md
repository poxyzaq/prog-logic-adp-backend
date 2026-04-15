# csharp-logic-proj

Projects developed during the Academia do Programador (ADP) back-end course — a programming training program covering fundamentals all the way to professional practice.

## 📁 Projects

Each project contains its own `README.md` with more detailed information.

### 🧮 tabajara-calculator.ConsoleApp

A console-based calculator application.

### 🔤 hangman-game.ConsoleApp

A console-based Hangman game featuring a rich vocabulary of exotic Brazilian fruits.

### 🎮 guessing-game.ConsoleApp

A console-based number guessing game.

### 🎲 dice-race-game.ConsoleApp

A console-based turn-based dice racing game against the CPU.

## 🗂️ Solution

The projects are organized under a single solution file:

- `prog_logic.slnx` — the main solution file that groups all projects together.

## 🌿 Branches

| Branch | Description |
|--------|-------------|
| `main` | Stable, production-ready code |
| `v0` | Initial version / early experiments |
| `v1` | First iteration of features |
| `v2` | Second iteration of features |
| `v3` | Ongoing development |

## 🚀 Getting Started

### Prerequisites

- .NET SDK 10.0

### Running a project

```bash
# Clone the repository
git clone https://github.com/poxyzaq/csharp-logic-proj.git
cd csharp-logic-proj

# Restore dependencies
dotnet restore

# Run a project
dotnet run --project tabajara-calculator.ConsoleApp
dotnet run --project guessing-game.ConsoleApp
dotnet run --project dice-race-game.ConsoleApp
dotnet run --project hangman-game.ConsoleApp
