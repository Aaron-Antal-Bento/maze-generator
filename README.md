<h1>Maze Generator & Solver</h1>
<p>
A C# desktop application that generates random mazes of any width and height, allowing users to visualize and compare solving algorithms such as Dijkstra’s Algorithm and Depth-First Search (DFS) in real time.
</p>

<h2>Features</h2>

<ul>
<li>Custom Maze Generation - Create mazes of any user-defined size with random or reproducible seeds.</li>
<li>Algorithm Comparison - Solve mazes using Dijkstra’s Algorithm or Depth-First Search, and compare their execution speeds.</li>
<li>Interactive Visualization - Real-time rendering of the generation and solving process.</li>
<li>User Controls - Adjust maze dimensions, entrance and exit positions, and other parameters independently.</li>
<li>Performance Metrics - Displays time taken and nodes visited by each algorithm for benchmarking.</li>
<li>Modular Object-Oriented Design – Maze structures and cells are built as separate classes, making the system easy to extend.</li>
</ul>

<h2>Demo</h2>

<div align="center" style="text-align:center;">
	<p align="center"><strong>8x8 Maze</strong></p>
<img src="./demo/Maze.gif" alt="Maze generation demo (GIF)" style="width:450px; height:450px; margin-bottom:30px;" />
	<h4 align="center">30x30 Maze - Solving with DFS (Left Hand Rule)</h4>
<img src="./demo/MazeDemo.gif" alt="Maze generation demo (GIF)" style="max-width:80%; height:auto;" />
	<p align="center"><strong>10x10 Maze - Solving with DFS and Dijkstra</strong></p>
<img src="./demo/MazeDemo2.gif" alt="Maze generation demo 2 (GIF)" style="max-width:80%; height:auto;" />
</div>

<h4 align="center">Rectangular Mazes | Maze Entrance and Exit</h4>
<p align="center">
  <img src="./demo/RectangularMazes.gif" alt="Rectangular Maze Demo" width="49%" />
  <img src="./demo/EntrancesExits.gif" alt="Entrances and Exits Demo" width="49%" />
</p>

<div style="display: flex; flex-wrap: wrap; justify-content: center; gap: 10px; margin: 1em 0;">
	<h4 align="center">Maze Variations</h4>
  <img src="./demo/Maze.png" alt="Maze screenshot (PNG)" style="width: 24%; height: auto; border-radius: 8px;" />
  <img src="./demo/Maze1.png" alt="Maze screenshot (PNG)" style="width: 24%; height: auto; border-radius: 8px;" />
  <img src="./demo/Maze2.png" alt="Maze screenshot (PNG)" style="width: 24%; height: auto; border-radius: 8px;" />
  <img src="./demo/Maze3.png" alt="Maze screenshot (PNG)" style="width: 24%; height: auto; border-radius: 8px;" />
</div>


<h2>How It Works</h2>

<p>The user specifies maze dimensions and clicks generate.</p>

<p>The program generates a grid of nodes with randomized paths using recursive backtracking.</p>

<p>The user can then choose which algorithms to solve with and compare which is quciker at finding a path from start to finish.</p>

<p>The visualization updates in real time for both generating and solving, allowing the user to see how the different algorithms work.</p>

<p>The user can also choose to export the maze saving it as a png.</p>


<h2>Technologies Used</h2>

<p>Built with C# (.NET 8, WinForms)</p>

<p>Algorithms: Dijkstra’s Algorithm, Depth-First Search (DFS), Recursive Backtracking</p>

<p>Object-oriented design separating the maze into modular classes, making the system easy to extend and maintain.</p>

<h2>Usage</h2>

<p>Clone the repository:</p>

<pre><code>git clone https://github.com/Aaron-Antal-Bento/maze-generator.git</code></pre>

<p>Then either:</p>
<ul>
<li>Open the solution in Visual Studio. Build and run the project.</li>
<li>Or navigate to "Maze Generator\bin\Debug\net8.0-windows7.0\Maze Generator.exe" and run from there</li>
</ul>
