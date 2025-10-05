# 🌀 Maze Generator & Solver

A C# desktop application that generates random mazes of any width and height, allowing users to visualize and compare solving algorithms such as Dijkstra’s Algorithm and Depth-First Search (DFS) in real time.

🎯 Features

Custom Maze Generation — Create mazes of any user-defined size with random or reproducible seeds.

Algorithm Comparison — Solve mazes using Dijkstra’s Algorithm or Depth-First Search, and compare their execution speeds.

Interactive Visualization — Real-time rendering of the generation and solving process.

User Controls — Adjust maze dimensions, entrance and exit positions, and other parameters independently.

Performance Metrics — Displays time taken and nodes visited by each algorithm for benchmarking.

🧠 Technologies Used

Built with C# (.NET 8, WinForms)

Algorithms: Dijkstra’s Algorithm, Depth-First Search (DFS)

🎥 Demo
...
	

⚙️ How It Works

The user specifies maze dimensions and clicks generate.

The program generates a grid of nodes with randomized paths using recursive backtracking.

The user can then choose which algorithms to solve with and compare which is quciker at finding a path from start to finish.

The visualization updates in real time for both generating and solving, allowing the user to see how the different algorithms work.

The user can also choose to export the maze saving it as a png.

🖥️ Usage

Clone the repository:

`git clone https://github.com/Aaron-Antal-Bento/maze-generator.git`

Then either:
- Open the solution in Visual Studio. Build and run the project.
- Or navigate to "Maze Generator\bin\Debug\net8.0-windows7.0\Maze Generator.exe" and run from there
