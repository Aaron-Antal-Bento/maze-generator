using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Threading;

namespace Maze_Generator
{
    public partial class Form1 : Form
    {
        //amount of x and y nodes in current maze
        private int Xnodes;
        private int Ynodes;
        //list of all nodes
        private Node[,] nodes;
        //path of the project
        private string projectDirectory = Directory.GetCurrentDirectory();
        string projectFolderName = "Maze Generator";
        //ending of the path name for cell images
        private string borderEdgeImagePath = "\\Cells\\BorderEdge.png";
        private string borderCornerImagePath = "\\Cells\\BorderCorner.png";
        private string borderEntranceAndExitImagePath = "\\Cells\\BorderEntranceAndExit.png";

        //ending of the path name for cell images with removed walls
        private const string FourSidedCellPath = "\\Cells\\4Sides.png";
        private const string ThreeSidedCellPath = "\\Cells\\3Sides\\3Sides";
        private const string TwoSidedCellPath = "\\Cells\\2Sides\\2Sides";
        private const string TwoSidedCornerCellPath = "\\Cells\\2Sides\\2SidesCorner";
        private const string OneSidedCellPath = "\\Cells\\1Side\\1Side";
        private const string NoSidedCellPath = "\\Cells\\NoSides.png";

        private Bitmap[] images = new Bitmap[16];

        //point where first cell starts
        private Point firstCellStartingPos = new Point(86, 55);
        //entrance and exit cells refrence coordinates
        private int[] mazeEntranceCell = { 1, 1 };
        private int[] mazeExitCell = { 1, 1 };

        //all different types of image cell
        PictureBox topBorder = new PictureBox();
        PictureBox bottomBorder = new PictureBox();
        PictureBox leftBorder = new PictureBox();
        PictureBox rightBorder = new PictureBox();
        PictureBox[] borderCorners = new PictureBox[4];
        PictureBox entrance = new PictureBox();
        PictureBox exit = new PictureBox();

        //if cells should be propotional
        private bool proportionalCells;
        //reference to Loading class
        public Loading ProgressBar;
        //used to display on progress bar 
        int cellsCreated = 0;

        //image of entire maze for saving and printing
        private Bitmap MazeImage;
        //used to change the name of the current maze being saved
        private int ImageFilenameNumber = 1;

        //list of individual edges used to solve maze
        List<MazeCellPath> edgeList;

        //indexes used to identify the different walls on a cell
        private const int NorthLineIndex = 0;
        private const int EastLineIndex = 1;
        private const int SouthLineIndex = 2;
        private const int WestLineIndex = 3;

        //list of edges and verticies use to make a graph of the maze
        List<Vertex> vertices = new List<Vertex>();
        List<Edge> edges = new List<Edge>();

        //panel positions
        Point LHRSolveDataOriginalPosition = new Point();
        Point DijkstraSolveDataOriginalPosition = new Point();

        //solve lines and details
        List<Node> LHRSolveLine = new List<Node>();
        List<Node> LHRSolveLineWithDetail = new List<Node>();
        List<Node> DijkstraSolveLine = new List<Node>();
        List<Node> DijkstraSolveLineWithDetail = new List<Node>();

        //stops solve line from updating when not on solve screen
        bool suppressUpdate = true;

        public Form1()
        {
            InitializeComponent();

            //create refrence to loading bar
            ProgressBar = new Loading();

            //store original panel positions
            LHRSolveDataOriginalPosition = LHRSolveDataPanel.Location;
            DijkstraSolveDataOriginalPosition = DijkstraSolveDataPanel.Location;

            //getting the folder in which the project is stored
            projectDirectory = projectDirectory.Substring(0, projectDirectory.IndexOf(projectFolderName) + projectFolderName.Length);
            CreateImageList();
        }

        //===================================== SCREEN 1 ==========================================
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UpdateSliderTextBox();
            UpdateEntranceAndExitSelection();

            //unticks is square checkbox when values are different
            if (XValuesTrackBar.Value != YValuesTrackBar.Value)
            {
                IsSquareCheckBox.Checked = false;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if the maze should be square
            if (IsSquareCheckBox.Checked)
            {
                //set trackbar 2 to have the same value as trackbar 1
                YValuesTrackBar.Value = XValuesTrackBar.Value;

                UpdateSliderTextBox();
                UpdateEntranceAndExitSelection();
            }
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            UpdateSliderTextBox();
            UpdateEntranceAndExitSelection();

            //unticks is square checkbox when values are different
            if (XValuesTrackBar.Value != YValuesTrackBar.Value)
            {
                IsSquareCheckBox.Checked = false;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //store x and y values for number of nodes
            int Xnodes = XValuesTrackBar.Value;
            int Ynodes = YValuesTrackBar.Value;

            //Open Screen two to generate maze
            tabControl1.SelectedTab = GeneratingScreen;
            ScreenTwo(Xnodes, Ynodes);
        }
        private void UpdateSliderTextBox()
        {
            //update location and value of upper textbox
            label1.Text = Convert.ToString(XValuesTrackBar.Value);
            label1.Location = new Point((label3.Location.X) + ((label4.Location.X - label3.Location.X) / 28 * (XValuesTrackBar.Value - 1)), label1.Location.Y);

            //update location and value of the lower textbox
            label2.Text = Convert.ToString(YValuesTrackBar.Value);
            label2.Location = new Point((label5.Location.X) + ((label6.Location.X - label5.Location.X) / 28 * (YValuesTrackBar.Value - 1)), label2.Location.Y);
        }
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            //if checkbox is checked none of the cells in the maze should be stretched
            proportionalCells = checkBox1.Checked;
        }
        private void SelectAllInTextBox(object sender, EventArgs e)
        {
            //when clicked all current text in textbox should be selected
            var textBox = (TextBox)sender;
            textBox.SelectAll();
            textBox.Focus();
        }
        private void textBox1_Click_1(object sender, EventArgs e)
        {
            textBox1Update(sender);
        }
        private void textBox1Update(object sender)
        {
            TextBox t = (TextBox)sender;
            //if string is empty set back to default
            if (t.Text == "") { t.Text = "1"; return; }
            //check if input is a number
            if (!IsDigitsOnly(t.Text)) { t.Text = "1"; return; }
            //check if text is in the correct range
            if (!(Convert.ToInt32(t.Text) <= XValuesTrackBar.Value)) { t.Text = Convert.ToString(XValuesTrackBar.Value); return; }
            if (Convert.ToInt32(t.Text) <= 0) { t.Text = "1"; return; }
            //store entrance cell x coordinate
            mazeEntranceCell[0] = Convert.ToInt32(t.Text);
            //change text of y coordinate so that entrance is always at the edge of the maze
            if (Convert.ToInt32(textBox2.Text) != 1 && Convert.ToInt32(t.Text) != 1) { textBox2.Text = "1"; }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2Update(sender);
        }
        private void textBox2Update(object sender)
        {
            TextBox t = (TextBox)sender;
            //if string is empty set back to default
            if (t.Text == "") { t.Text = "1"; return; }
            //check if input is a number
            if (!IsDigitsOnly(t.Text)) { t.Text = "1"; return; }
            //check if text is in the correct range
            if (!(Convert.ToInt32(t.Text) <= YValuesTrackBar.Value)) { t.Text = Convert.ToString(YValuesTrackBar.Value); return; }
            if (Convert.ToInt32(t.Text) <= 0) { t.Text = "1"; return; }
            //store entrance cell y coordinate
            mazeEntranceCell[1] = Convert.ToInt32(t.Text);
            //change text of x coordinate so that entrance is always at the edge of the maze
            if (Convert.ToInt32(textBox1.Text) != 1 && Convert.ToInt32(t.Text) != 1) { textBox1.Text = "1"; }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3Update(sender);
        }
        private void textBox3Update(object sender)
        {
            TextBox t = (TextBox)sender;
            //if string is empty set back to default
            if (t.Text == "") { t.Text = Convert.ToString(XValuesTrackBar.Value); return; }
            //check if input is a number
            if (!IsDigitsOnly(t.Text)) { t.Text = Convert.ToString(XValuesTrackBar.Value); return; }
            //check if text is in the correct range
            if (!(Convert.ToInt32(t.Text) <= XValuesTrackBar.Value)) { t.Text = Convert.ToString(XValuesTrackBar.Value); return; }
            if (Convert.ToInt32(t.Text) <= 0) { t.Text = "1"; return; }
            //store exit cell x coordinate
            mazeExitCell[0] = Convert.ToInt32(t.Text);
            //change text of y coordinate so that exit is always at the edge of the maze
            if (Convert.ToInt32(textBox4.Text) != YValuesTrackBar.Value && Convert.ToInt32(t.Text) != XValuesTrackBar.Value) { textBox4.Text = Convert.ToString(YValuesTrackBar.Value); }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4Update(sender);
        }
        private void textBox4Update(object sender)
        {
            TextBox t = (TextBox)sender;
            //if string is empty set back to default
            if (t.Text == "") { t.Text = Convert.ToString(YValuesTrackBar.Value); return; }
            //check if input is a number
            if (!IsDigitsOnly(t.Text)) { t.Text = Convert.ToString(YValuesTrackBar.Value); return; }
            //check if text is in the correct range
            if (!(Convert.ToInt32(t.Text) <= YValuesTrackBar.Value)) { t.Text = Convert.ToString(YValuesTrackBar.Value); return; }
            if (Convert.ToInt32(t.Text) <= 0) { t.Text = "1"; return; }
            //store exit cell y coordinate
            mazeExitCell[1] = Convert.ToInt32(t.Text);
            //change text of x coordinate so that exit is always at the edge of the maze
            if (Convert.ToInt32(textBox3.Text) != XValuesTrackBar.Value && Convert.ToInt32(t.Text) != YValuesTrackBar.Value) { textBox3.Text = Convert.ToString(XValuesTrackBar.Value); }
        }
        private void UpdateEntranceAndExitSelection()
        {
            //only changes entrance cell coordinates when they are greater than the bounds of the maze
            if (Convert.ToInt32(textBox1.Text) > XValuesTrackBar.Value)
            {
                textBox1.Text = Convert.ToString(XValuesTrackBar.Value);
            }
            if (Convert.ToInt32(textBox2.Text) > YValuesTrackBar.Value)
            {
                textBox2.Text = Convert.ToString(YValuesTrackBar.Value);
            }

            //sets exit cell to be max whenever maze is resized
            textBox3.Text = Convert.ToString(XValuesTrackBar.Value);
            textBox4.Text = Convert.ToString(YValuesTrackBar.Value);
        }
        private bool IsDigitsOnly(string str)
        {
            //checks for anything other than numbers in a string
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }

        //===================================== SCREEN 2 ==========================================
        private void ScreenTwo(int Xnodes, int Ynodes)
        {
            //store x and y nodes in global variable
            this.Xnodes = Xnodes;
            this.Ynodes = Ynodes;

            GenerateMaze();
        }
        private void GenerateMaze()
        {
            //list of all nodes in the current maze
            nodes = new Node[Xnodes, Ynodes];

            //create cells with four sides
            PictureBox[,] cells = CreateCells();

            //shows progress bar
            ShowProgressBar(true);
            //restarts timer recording time since node creation started
            ProgressBar.ResetTimer();
            //used to time the time for one cell to create
            Stopwatch averageTimeTimer = Stopwatch.StartNew();

            cellsCreated = 0;
            //create nodes
            for (int i = 0; i < Xnodes; i++)
            {
                for (int j = 0; j < Ynodes; j++)
                {
                    //saves new node in nodes list with refrence to its coordinates and its cell image
                    nodes[i, j] = new Node(i, j, cells[i, j]);

                    cellsCreated++;
                    //calculates percetage of progress bar to be filled by dividing cells created by total cells
                    UpdateProgressBar((double)cellsCreated / (Xnodes * Ynodes) * 100);
                    //calculates average time for one cell to be created then uses this to calculate total estimated time
                    ProgressBar.SetEstimatedTime(GetTotalEstimatedTime(GetAverageTimeForOne(averageTimeTimer, cellsCreated), cellsCreated, Xnodes * Ynodes));
                    //Passes cells created and total nodes by multiplying amount of x and y nodes
                    ProgressBar.DisplayNodesComplete(cellsCreated, Xnodes * Ynodes);
                }
            }

            //store which wall connect to which cell
            WallConnections();

            //hide progress bar
            ShowProgressBar(false);

            CarveMaze();
        }
        private void CarveMaze()
        {
            //updates the inputs for entrance and exit to the maze
            textBox1Update(textBox1);
            textBox2Update(textBox2);
            textBox3Update(textBox3);
            textBox4Update(textBox4);

            int[] currentCell = new int[2];
            int[] firstCell = { mazeEntranceCell[0] - 1, mazeEntranceCell[1] - 1 };
            int[] lastCell = { mazeExitCell[0] - 1, mazeExitCell[1] - 1 };
            //previous cells x and y
            int[] previousCell = { -1, -1 };

            Node currentNode;

            //make entrance to maze
            OpenEntrance(firstCell);

            //set current cell to first cell
            OverwriteContents(ref currentCell, firstCell);

            do
            {
                currentNode = nodes[currentCell[0], currentCell[1]];
                //if current cell has not been visited
                if (!currentNode.GetVisited())
                {
                    //store last cell in node class
                    currentNode.SetLastCell(previousCell[0], previousCell[1]);
                }
                //set current node to visited and pick a random wall
                currentNode.SetVisited(true);
                int wallFace = PickRandomAvailableWall(currentNode);

                //if no possible cells to go to
                if (wallFace == -1)
                {
                    //check if -1 this would mean that current cell is the first cell
                    if (currentNode.GetLastCell()[0] == -1 && currentNode.GetLastCell()[1] == -1) { break; }
                    else
                    {
                        //back tracks to last cell
                        //gets last cell from node class
                        OverwriteContents(ref currentCell, currentNode.GetLastCell());
                    }
                }
                else
                {
                    //destroys random available wall
                    currentNode.RemoveWall(wallFace, images);
                    RemoveNextCellsWall(currentCell, wallFace);
                    //save current cell
                    OverwriteContents(ref previousCell, currentCell);
                    //sets next cell
                    currentCell = GetNewCell(wallFace, currentCell);
                }
            }
            //repeat until first cell is reached again
            while (true);

            //make exit to maze
            OpenExit(lastCell);

            //once done switch to next screen
            tabControl1.SelectedTab = MainScreen;

            //bring buttons infront of maze
            BringThisToFront(MainScreenButtonsContainer, true, null);
            DisplayMazeData();

            GC.Collect();
        }
        private void DisplayMazeData()
        {
            //diplays the maze dimentions and the total number of nodes
            MazeDataText.Text = String.Format("Maze Size: " + Xnodes + "x" + Ynodes + " (" + Xnodes * Ynodes + " node" + ManagePlural(Xnodes * Ynodes) + ")");
            BringThisToFront(MazeDataText, true, null);
        }
        private void OpenEntrance(int[] firstCell)
        {
            Node node = nodes[firstCell[0], firstCell[1]];
            //choose which wall to remove from start cell 
            if (mazeEntranceCell[0] > mazeEntranceCell[1])
            {
                node.RemoveWall(NorthLineIndex, images);
                node.SetWallAsEntrance(NorthLineIndex);
            }
            else
            {
                node.RemoveWall(WestLineIndex, images);
                node.SetWallAsEntrance(WestLineIndex);
            }
            //unhides border entrance cell
            entrance.Show();
        }
        private void OpenExit(int[] lastCell)
        {
            Node node = nodes[lastCell[0], lastCell[1]];
            //choose which wall to remove from end cell 
            if ((Xnodes - mazeExitCell[0]) <= (Ynodes - mazeExitCell[1]))
            {
                node.RemoveWall(EastLineIndex, images);
                node.SetWallAsExit(EastLineIndex);
            }
            else
            {
                node.RemoveWall(SouthLineIndex, images);
                node.SetWallAsExit(SouthLineIndex);
            }
            //unhides border exit cell
            exit.Show();
        }
        private void RemoveNextCellsWall(int[] currentCell, int wallFace)
        {
            //gets next cell and removes the wall connecting to the current cell
            Node node = nodes[currentCell[0], currentCell[1]];
            node = GetNewCell(wallFace, node);

            node.RemoveWall(GetReverseWall(wallFace, node.NumberOfWalls()), images);
        }
        private int PickRandomAvailableWall(Node node)
        {
            List<int> availableWallFaces = node.GetWalls();
            List<int> originalWallFaces = new List<int>();
            OverwriteContents(ref originalWallFaces, availableWallFaces);

            //makes list of avaiblable wall faces
            foreach (int wall in originalWallFaces)
            {
                if (node.GetLeadsOutOfMaze(wall) || GetNewCell(wall, node).GetVisited())
                {
                    availableWallFaces.Remove(wall);
                }
            }

            //checks if there are availible faces
            if (availableWallFaces.Count > 0)
            {
                //choose a random wall from those available
                Random random = new Random();
                int wall = random.Next(availableWallFaces.Count);
                return availableWallFaces[wall];
            }
            else
            {
                //returns -1 if no face are availible to destory
                return -1;
            }
        }
        private int[] GetNewCell(int wallFace, int[] currentCell)
        {
            //gets the coordinates of the cell that connects to the current cell via the wall "wallFace"
            int[] coordinates = new int[2];
            OverwriteContents(ref coordinates, currentCell);

            if (wallFace == NorthLineIndex)
            {
                //finds the cell above current cell
                coordinates[1] = currentCell[1] - 1;
            }
            else if (wallFace == EastLineIndex)
            {
                //finds the cell to the right of current cell
                coordinates[0] = currentCell[0] + 1;
            }
            else if (wallFace == SouthLineIndex)
            {
                //finds the cell below current cell
                coordinates[1] = currentCell[1] + 1;
            }
            else if (wallFace == WestLineIndex)
            {
                //finds the cell to the left of current cell
                coordinates[0] = currentCell[0] - 1;
            }

            return coordinates;
        }
        private Node GetNewCell(int wallFace, Node node)
        {
            //returns the nodes connected to the current node by the wall wallFace
            //if it leads out of the maze null is returned
            if (!node.GetLeadsOutOfMaze(wallFace))
            {
                return node.GetConnectingNode(wallFace);
            }
            else
            {
                return null;
            }
        }
        private Node CalculateConnectingCells(int wallFace, Node node)
        {
            //returns the nodes connected to the current node by the wall wallFace
            //if it leads out of the maze null is returned
            //used when wall class does not have definitions for connecting nodes yet
            if (!node.GetLeadsOutOfMaze(wallFace))
            {
                int[] coordinates = GetNewCell(wallFace, node.GetCoordinate());
                return nodes[coordinates[0], coordinates[1]];
            }
            else
            {
                return null;
            }
        }
        private PictureBox[,] CreateCells()
        {
            //availible space for maze
            int SpaceX = MazeBoundingBox1.Size.Width;
            int SpaceY = MazeBoundingBox1.Size.Height;
            //starting position of maze
            Point startingPos = firstCellStartingPos;
            PictureBox[,] cells = new PictureBox[Xnodes, Ynodes];

            for (int i = 0; i < Xnodes; i++)
            {
                for (int j = 0; j < Ynodes; j++)
                {
                    //create and add image
                    PictureBox p = new PictureBox();
                    Size cellSize;
                    Point cellPosition;

                    if (proportionalCells)
                    {
                        //number by which the size of all the cells is determined so that they remain proportional
                        int scaleMultiplier = CalculateScaleMultiplier();
                        //mid point of maze 
                        int midPointX = SpaceX / 2;
                        int midPointY = SpaceY / 2;
                        //size of all cells
                        cellSize = new Size(SpaceX / scaleMultiplier, SpaceY / scaleMultiplier);
                        if (Xnodes >= Ynodes)
                        {
                            //current cell position when there are more x nodes then y nodes
                            cellPosition = new Point(startingPos.X + cellSize.Width * i, startingPos.Y + midPointY - (cellSize.Height * Ynodes / 2) + cellSize.Height * j);
                        }
                        else
                        {
                            //current cell position when there are more y nodes then x nodes
                            cellPosition = new Point(startingPos.X + midPointX - (SpaceX / scaleMultiplier * Xnodes / 2) + SpaceX / scaleMultiplier * i, startingPos.Y + (SpaceY / scaleMultiplier) * j);
                        }
                    }
                    else
                    {
                        //size of all cells
                        cellSize = new Size(SpaceX / Xnodes, SpaceY / Ynodes);
                        //current cell position
                        cellPosition = new Point(startingPos.X + cellSize.Width * i, startingPos.Y + cellSize.Height * j);
                    }

                    //create current cell
                    p.Size = cellSize;
                    p.Image = images[0];
                    p.SizeMode = PictureBoxSizeMode.StretchImage;
                    p.Location = cellPosition;
                    Controls.Add(p);
                    p.BringToFront();

                    //store to a list of existing cells
                    cells[i, j] = p;
                    Application.DoEvents();
                }
            }

            //create border
            CreateBorder(SpaceX, SpaceY, startingPos, cells[0, 0]);
            //creates the entrance and exit to the cell
            CreateMazeEntranceAndExitOnBorder(SpaceX, SpaceY, startingPos, cells[0, 0]);

            //hides maze bounding box
            MazeBoundingBox1.Visible = false;
            return cells;
        }
        private void WallConnections()
        {
            //sets the connecting node to a wall of a maze
            //if the wall leads out of the maze it will not be given a node that it leads to but instead will set as leading out of the maze
            foreach (Node node in nodes)
            {
                for (int i = 0; i < node.NumberOfWalls(); i++)
                {
                    if (!OutOfBounds(i, node))
                    {
                        node.SetConnectingNode(i, CalculateConnectingCells(i, node));
                    }
                    else
                    {
                        node.SetLeadsOutOfMaze(i);
                    }
                }
            }
        }
        private bool OutOfBounds(int wallFace, Node node)
        {
            //calculates if the current nodes wall leads out of the maze
            int maxX = Xnodes - 1;
            int maxY = Ynodes - 1;

            int[] newNode = GetNewCell(wallFace, node.GetCoordinate());
            if (newNode[0] < 0 || newNode[0] > maxX)
            {
                return true;
            }
            if (newNode[1] < 0 || newNode[1] > maxY)
            {
                return true;
            }
            return false;
        }
        private void CreateBorder(int SpaceX, int SpaceY, Point startingPos, PictureBox firstCell)
        {
            //diplays a border around the maze once it has finished creating
            PictureBox topBorder = new PictureBox();
            PictureBox bottomBorder = new PictureBox();
            PictureBox leftBorder = new PictureBox();
            PictureBox rightBorder = new PictureBox();
            PictureBox[] borderCorners = new PictureBox[4];

            /////////////////////////////////////////// EDGES //////////////////////////////////////
            Size horizontalSize;
            Size verticalSize;

            Size cellSize;

            Point northBorderPosition;
            Point southBorderPosition;
            Point eastBorderPosition;
            Point westBorderPosition;

            if (proportionalCells)
            {
                int scaleMultiplier = CalculateScaleMultiplier();
                //size of cell
                cellSize = new Size(SpaceX / scaleMultiplier, SpaceY / scaleMultiplier);
                startingPos = new Point(firstCell.Location.X, firstCell.Location.Y);
            }
            else
            {
                //size of cell
                cellSize = new Size(SpaceX / Xnodes, SpaceY / Ynodes);
            }

            //find starting position of border
            startingPos.X -= cellSize.Width;
            startingPos.Y -= cellSize.Height;

            //calculate and store the position of each border piece
            northBorderPosition = new Point(startingPos.X + cellSize.Width, startingPos.Y);
            southBorderPosition = new Point(startingPos.X + cellSize.Width, startingPos.Y + cellSize.Height * (Ynodes + 1));
            eastBorderPosition = new Point(startingPos.X, startingPos.Y + cellSize.Height);
            westBorderPosition = new Point(startingPos.X + cellSize.Width * (Xnodes + 1), startingPos.Y + cellSize.Height);

            //size of the two horizontal borders and two vertical borders
            horizontalSize = new Size(cellSize.Width * Xnodes, cellSize.Height);
            verticalSize = new Size(cellSize.Width, cellSize.Height * Ynodes);

            //top edge creation
            CreateBorderEdge(topBorder,
                horizontalSize,
                northBorderPosition,
                RotateFlipType.RotateNoneFlipNone);
            //bottom edge creation
            CreateBorderEdge(bottomBorder,
                horizontalSize,
                southBorderPosition,
                RotateFlipType.Rotate180FlipNone);
            //left edge creation
            CreateBorderEdge(leftBorder,
                verticalSize,
                eastBorderPosition,
                RotateFlipType.Rotate270FlipNone);
            //right edge creation
            CreateBorderEdge(rightBorder,
                verticalSize,
                westBorderPosition,
                RotateFlipType.Rotate90FlipNone);

            /////////////////////////////////////////// CORNERS //////////////////////////////////
            //count which corner is currently being created
            int cornerNumber = 0;
            //store the order in which each corner should be flipped
            RotateFlipType[] rotations = { RotateFlipType.RotateNoneFlipNone, RotateFlipType.Rotate270FlipNone, RotateFlipType.Rotate90FlipNone, RotateFlipType.Rotate180FlipNone };
            //loop through 4 times using two for loops so that position of current corner can be calculated
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    //create temporary picture box
                    PictureBox p = new PictureBox();
                    //assign corner image
                    p.Image = new Bitmap(projectDirectory + borderCornerImagePath);
                    //set size to be the same as all other cells
                    p.Size = cellSize;
                    p.SizeMode = PictureBoxSizeMode.StretchImage;
                    //set location dependant apon two for loops 
                    //if i is 0 the x coordinate will be starting position if it is 1 then width of the maze will be added on
                    //same for j with the y coordinate
                    p.Location = new Point(startingPos.X + cellSize.Width * (Xnodes + 1) * i, startingPos.Y + cellSize.Height * (Ynodes + 1) * j);
                    //rotates dependent on which corner is currently being created
                    p.Image.RotateFlip(rotations[cornerNumber]);
                    Controls.Add(p);
                    p.BringToFront();

                    //add to corners list
                    borderCorners[cornerNumber] = p;
                    cornerNumber++;
                }
            }

            //save all as global variables so the can be deleted later
            this.topBorder = topBorder;
            this.bottomBorder = bottomBorder;
            this.leftBorder = leftBorder;
            this.rightBorder = rightBorder;
            this.borderCorners = borderCorners;

            Application.DoEvents();
        }
        private void CreateBorderEdge(PictureBox edge, Size size, Point pos, RotateFlipType rotation)
        {
            //stretch by inputed values
            edge.Size = size;
            //assign edge image
            edge.Image = new Bitmap(projectDirectory + borderEdgeImagePath);
            edge.SizeMode = PictureBoxSizeMode.StretchImage;
            //position from input X and Y coordinates
            edge.Location = pos;
            //rotation
            edge.Image.RotateFlip(rotation);
            Controls.Add(edge);
            edge.BringToFront();
        }
        private void CreateBorderEntranceOrExit(PictureBox edge, Size size, Point pos, RotateFlipType rotation)
        {
            //stretch by inputed values
            edge.Size = size;
            //assign edge image
            edge.Image = new Bitmap(projectDirectory + borderEntranceAndExitImagePath);
            edge.SizeMode = PictureBoxSizeMode.StretchImage;
            //position from input X and Y coordinates
            edge.Location = pos;
            //rotation
            edge.Image.RotateFlip(rotation);
            Controls.Add(edge);
            edge.BringToFront();
        }
        private void CreateMazeEntranceAndExitOnBorder(int SpaceX, int SpaceY, Point startingPos, PictureBox firstCell)
        {
            //creates the entrance and exit graphic to the maze on the border
            //this is hidden until it need to be displayed
            Size cellSize;

            Point entrancePosition;
            Point exitPosition;

            if (proportionalCells)
            {
                int scaleMultiplier = CalculateScaleMultiplier();
                //size of cell
                cellSize = new Size(SpaceX / scaleMultiplier, SpaceY / scaleMultiplier);
                //first cell position when all cells are proportional
                startingPos = new Point(firstCell.Location.X, firstCell.Location.Y);
            }
            else
            {
                //size of cell
                cellSize = new Size(SpaceX / Xnodes, SpaceY / Ynodes);
            }

            //calculate position
            entrancePosition = MazeEntrancePos(startingPos, cellSize);
            exitPosition = MazeExitPos(startingPos, cellSize);

            PictureBox entrance = new PictureBox();
            PictureBox exit = new PictureBox();

            //create entrance
            CreateBorderEntranceOrExit(entrance,
                cellSize,
                entrancePosition,
                RotateFlipType.Rotate270FlipNone);
            entrance.Hide();
            if (mazeEntranceCell[0] > mazeEntranceCell[1]) { entrance.Image.RotateFlip(RotateFlipType.Rotate90FlipNone); }

            //create exit
            CreateBorderEntranceOrExit(exit,
                cellSize,
                exitPosition,
                RotateFlipType.Rotate180FlipNone);
            exit.Hide();
            if ((Xnodes - mazeExitCell[0]) <= (Ynodes - mazeExitCell[1])) { exit.Image.RotateFlip(RotateFlipType.Rotate270FlipNone); }

            //store as global variables
            this.entrance = entrance;
            this.exit = exit;
        }
        private Point MazeEntrancePos(Point startingPos, Size cellSize)
        {
            //used to calculate where the entrance should be to the maze on the border
            if (mazeEntranceCell[0] > mazeEntranceCell[1])
            {
                //if x coordinate of entrance cell if greater than the y coordinate then maze entrance should be on the top
                return new Point(startingPos.X + (mazeEntranceCell[0] - 1) * cellSize.Width, startingPos.Y - cellSize.Height);
            }
            else
            {
                //if y coordinate of entrance cell if greater than the x coordinate then maze entrance should be on the left
                return new Point(startingPos.X - cellSize.Width, startingPos.Y + (mazeEntranceCell[1] - 1) * cellSize.Height);
            }
        }
        private Point MazeExitPos(Point startingPos, Size cellSize)
        {
            //used to calculate where the exit should be to the maze on the border
            if ((Xnodes - mazeExitCell[0]) <= (Ynodes - mazeExitCell[1]))
            {
                //if y coordinate of exit cell if greater than the x coordinate then maze exit should be on the right
                return new Point(startingPos.X + cellSize.Width * Xnodes, startingPos.Y + (mazeExitCell[1] - 1) * cellSize.Height);
            }
            else
            {
                //if x coordinate of exit cell if greater than the y coordinate then maze exit should be on the bottom
                return new Point(startingPos.X + (mazeExitCell[0] - 1) * cellSize.Width, startingPos.Y + cellSize.Height * Ynodes);
            }
        }
        private void DeleteBorder()
        {
            //delete all borders, corners, entrances and exits
            topBorder.Dispose();
            bottomBorder.Dispose();
            leftBorder.Dispose();
            rightBorder.Dispose();

            entrance.Dispose();
            exit.Dispose();

            foreach (PictureBox pictureBox in borderCorners)
            {
                pictureBox.Dispose();
            }
            Application.DoEvents();
        }
        private int CalculateScaleMultiplier()
        {
            //creates a scale multiplier used when creating a maze with the proportional cells setting
            //the axis with the greatest amount of nodes is selected 
            //this ensures that the maximum width/height is used make sure the maze stays on the screen space
            if (Xnodes >= Ynodes)
            {
                return Xnodes;
            }
            else
            {
                return Ynodes;
            }
        }
        private void ShowProgressBar(bool start)
        {
            //shows and hides the progress bar form (Loading)
            if (start)
            {
                ProgressBar.Show();
            }
            else
            {
                ProgressBar.Hide();
            }
        }
        private void UpdateProgressBar(double value)
        {
            //passes the value for the progress bar fullness calculated from the nodes calculated divided by total nodes
            ProgressBar.SetProgressBar(value);
            Application.DoEvents();
        }
        private TimeSpan GetAverageTimeForOne(Stopwatch timer, int amountCompleted)
        {
            //divides by total complete to get a more accurate average each time
            return timer.Elapsed / amountCompleted;
        }
        private TimeSpan GetTotalEstimatedTime(TimeSpan averageForOne, int amountCompleted, int totalAmount)
        {
            //finds to total time for all to complete and subtracts time for the total amount already completed
            return (averageForOne * totalAmount) - (averageForOne * amountCompleted);
        }

        //===================================== SCREEN 3 ==========================================
        private void button5_Click(object sender, EventArgs e)
        {
            //create new maze
            SetupNewMaze();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            //solve screen
            SolveMaze();
            Application.DoEvents();

            //bring solve screen buttons infront of maze
            BringThisToFront(SolveScreenPanel, true, null);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            //bring export screen buttons infront of maze
            BringThisToFront(ExportScreenPanel, true, null);
        }

        //===================================== SOLVE SCREEN ==========================================
        private void button9_Click(object sender, EventArgs e)
        {
            //create new maze
            suppressUpdate = true;
            ResetStatistics();
            SetupNewMaze();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            //back button
            suppressUpdate = true;
            ResetStatistics();
            DeleteSolvedMaze();

            BringThisToFront(MainScreenButtonsContainer, true, null);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            //export screen
            //set button on export screen to reflect the current state of the maze
            SolveFromExportButton.Text = "Unsolve";
            suppressUpdate = true;

            //bring export screen buttons infront of maze
            BringThisToFront(ExportScreenPanel, true, null);
        }
        private void SolveLHR_CheckedChanged(object sender, EventArgs e)
        {
            //selets if the maze should be solve with Left Hand Rule or not
            if (SolveLHR.Checked)
            {
                //if both checked tick the "both" checkbox
                if (SolveDijkstra.Checked)
                {
                    SolveBoth.Checked = true;
                }
            }
            else
            {
                //make sure at least one solve method is seleted
                SolveDijkstra.Checked = true;
                SolveBoth.Checked = false;
            }
        }
        private void SolveDijkstra_CheckedChanged(object sender, EventArgs e)
        {
            //selets if the maze should be solve with Dijkstra or not
            if (SolveDijkstra.Checked)
            {
                //if both checked tick the "both" checkbox
                if (SolveLHR.Checked)
                {
                    SolveBoth.Checked = true;
                }
            }
            else
            {
                //make sure at least one solve method is seleted
                SolveLHR.Checked = true;
                SolveBoth.Checked = false;
            }
        }
        private void SolveBoth_CheckedChanged(object sender, EventArgs e)
        {
            //tick both checkboxes
            if (SolveBoth.Checked)
            {
                SolveLHR.Checked = true;
                SolveDijkstra.Checked = true;
            }
        }
        private void DisplaySolvedLHR_CheckedChanged(object sender, EventArgs e)
        {
            //does nothing if suppressUpdate is true
            if (suppressUpdate) { return; }
            if (DisplaySolvedLHR.Checked)
            {
                //unchecks Display Dijkstra so only one solve method is displayed at a time
                DisplaySolvedDijkstra.Checked = false;
            }
            else
            {
                //displays Dijkstra solve line (and details if selected)
                if (DisplaySolveDetails.Checked)
                {
                    DeleteSolvedMaze();
                    ShowDijkstraStoredDetails();
                }
                else
                {
                    ShowDijkstraStoredSolveLine();
                }
                DisplaySolvedDijkstra.Checked = true;
            }
        }
        private void DisplaySolvedDijkstra_CheckedChanged(object sender, EventArgs e)
        {
            //does nothing if suppressUpdate is true
            if (suppressUpdate) { return; }
            if (DisplaySolvedDijkstra.Checked)
            {
                //unchecks Display Dijkstra so only one solve method is displayed at a time
                DisplaySolvedLHR.Checked = false;
            }
            else
            {
                //displays Dijkstra solve line (and details if selected)
                if (DisplaySolveDetails.Checked)
                {
                    DeleteSolvedMaze();
                    ShowLHRStoredDetails();
                }
                else
                {
                    ShowLHRStoredSolveLine();
                }
                DisplaySolvedLHR.Checked = true;
            }
        }
        private void DisplaySolveDetails_CheckedChanged(object sender, EventArgs e)
        {
            //does nothing if suppressUpdate is true
            if (suppressUpdate) { return; }
            if (DisplaySolveDetails.Checked)
            {
                //displays the details for the currently displayed solve method
                if (DisplaySolvedLHR.Checked)
                {
                    ShowLHRStoredDetails();
                }
                else
                {
                    ShowDijkstraStoredDetails();
                }
            }
            else
            {
                //shows just solve line if unselected
                if (DisplaySolvedLHR.Checked)
                {
                    ShowLHRStoredSolveLine();
                }
                else
                {
                    ShowDijkstraStoredSolveLine();
                }
            }
        }
        //---------------------Main-----------------------
        private void SolveMaze()
        {
            //chooses solve method based on which checkboxes are ticked
            if (SolveLHR.Checked)
            {
                SolveFollowingLeftWall();
            }
            if (SolveBoth.Checked)
            {
                //if both are check wait a second before clearing and displaying the second maze
                Thread.Sleep(1000);
                DeleteSolvedMaze();
            }
            if (SolveDijkstra.Checked)
            {
                SolveUsingDijkstra();
            }
            AdjustSolveDataPanels();
            suppressUpdate = false;
            //ShowAllPaths();
        }
        private void DeleteSolvedMaze()
        {
            //delete solve lines
            for (int i = 0; i < Xnodes; i++)
            {
                for (int j = 0; j < Ynodes; j++)
                {
                    nodes[i, j].DeleteMazePath();
                }
            }
            //reset variables in node class
            UnsolveMaze();
        }
        private void ShowAllPaths()
        {
            //show all possible lines
            for (int i = 0; i < Xnodes; i++)
            {
                for (int j = 0; j < Ynodes; j++)
                {
                    nodes[i, j].ShowFullMazePath(Color.Red);
                }
            }
        }
        private void UnsolveMaze()
        {
            //loop through all nodes in maze
            for (int i = 0; i < Xnodes; i++)
            {
                for (int j = 0; j < Ynodes; j++)
                {
                    //returns variables in node class to default value so they can be used when solving again
                    nodes[i, j].SetPartOfEdge(false);
                    nodes[i, j].SetAsJunction(false);
                }
            }
        }
        //---------------------Left Hand Rule-----------------------
        private void ShowLHRStoredSolveLine()
        {
            //shows the just the solve line for Left Hand Rule solve method that has been stored in LHRSolveLine
            DeleteSolvedMaze();
            Application.DoEvents();

            foreach (Node n in LHRSolveLine)
            {
                n.ShowFullMazePath(Color.Red);
            }
            Application.DoEvents();
        }
        private void ShowLHRStoredDetails()
        {
            //shows the the solve line and details for Left Hand Rule solve method that has been stored in LHRSolveLineWithDetail
            Application.DoEvents();

            int i = 0;
            foreach (Node n in LHRSolveLineWithDetail)
            {
                if (LHRSolveLine.Contains(n))
                {
                    n.ShowFullMazePath(Color.Red);
                }
                else
                {
                    if (n != null)
                    {
                        n.ShowFullMazePath(Color.LightCoral);
                    }
                }
                i++;
            }
            Application.DoEvents();
        }
        private void SolveFollowingLeftWall()
        {
            //starts time to record the time it take to solve the maze
            Stopwatch solveTimer = new Stopwatch();
            solveTimer.Start();

            int[] firstCell = new int[2];
            OverwriteContents(ref firstCell, mazeEntranceCell);

            //create path connecting entrance to exit
            CreateMazeGraph(firstCell, Color.Red);

            //remove all dead ends
            ClearDeadEnds();
            Application.DoEvents();
            solveTimer.Stop();

            SaveSolveLineAndDetails();

            //clean up exits that are not connected to a path
            UpdateSolveLinesOnJunction(Color.Red);

            //clean up end node
            UpdateSolveLinesOnExitCell(Color.Red);

            //display solve data
            DisplaySolveTime(solveTimer, solveTimeText);
            //displays line length, junction number and the amount of bends
            DisplaySolveLineStatistics(pathLengthText, numOfJunctionsText, numOfBendsText, null);
            DisplaySolveEfficiency(efficiencyRatingText, null);
            DisplayNodesCalculatedLHR(NodesCalculatedText);
        }
        private void SaveSolveLineAndDetails()
        {
            //stores the solve line and its details to be displayed later
            foreach (MazeCellPath path in edgeList)
            {
                foreach (Node n in path.GetFullEdge())
                {
                    if (!LHRSolveLineWithDetail.Contains(n))
                    {
                        LHRSolveLineWithDetail.Add(n);
                        if (!path.IsDeadEnd())
                        {
                            if (!LHRSolveLine.Contains(n))
                            {
                                LHRSolveLine.Add(n);
                            }
                        }
                    }
                }
            }
        }
        private void ClearDeadEnds()
        {
            //loop through all edges that make up the path from the entrance to the exit of the maze
            foreach (MazeCellPath edge in edgeList)
            {
                if (edge.IsDeadEnd())
                {
                    //delete the sole line for all nodes in the edge if it is marked as a dead end
                    edge.ClearEdge();
                    Application.DoEvents();
                }
            }
        }
        private void UpdateSolveLinesOnJunction(Color colour)
        {
            //loop through every cell in the maze
            for (int i = 0; i < Xnodes; i++)
            {
                for (int j = 0; j < Ynodes; j++)
                {
                    if (nodes[i, j].GetIsJunction())
                    {
                        //if it is marked as a junction delete the solve line
                        nodes[i, j].DeleteMazePath();
                        Application.DoEvents();
                        if (nodes[i, j].GetPartOfEdge())
                        {
                            //if it is still meant to be part of an edge that solves the maze 
                            //show the solve path of for exits of the junction that connect the entrance to the exit of the maze
                            ShowConnectedMazePath(nodes[i, j], colour);
                            Application.DoEvents();
                        }
                    }
                }
            }
        }
        private void UpdateSolveLinesOnExitCell(Color colour)
        {
            //clear solve path from end cell
            nodes[mazeExitCell[0] - 1, mazeExitCell[1] - 1].DeleteMazePath();
            Application.DoEvents();
            //shows solve path that connects to other solve paths in surrounding cells
            //shows path that connects to the outside of the maze at the exit 
            ShowConnectedMazePath(nodes[mazeExitCell[0] - 1, mazeExitCell[1] - 1], colour);
            Application.DoEvents();
        }
        private void CreateMazeGraph(int[] firstCell, Color colour)
        {
            List<MazeCellPath> edgeList = new List<MazeCellPath>();
            Color deadEndColour = ControlPaint.Dark(colour);

            int[] currentCell = { firstCell[0] - 1, firstCell[1] - 1 };
            int[] finalCell = new int[2];
            OverwriteContents(ref finalCell, mazeExitCell);
            //refrence to current node's class
            Node currentNode;

            currentNode = nodes[currentCell[0], currentCell[1]];

            MazeCellPath edge = new MazeCellPath(currentNode);
            edgeList.Add(edge);

            bool graphDone = false;
            while (!graphDone)
            {
                bool edgeDone = false;
                while (!edgeDone)
                {
                    if ((currentNode.GetCoordinate()[0] == (finalCell[0] - 1)) && (currentNode.GetCoordinate()[1] == (finalCell[1] - 1)))
                    {
                        //graph done
                        edge.AddEndNode(currentNode);
                        edge.SetCalculated(true);
                        edge.AddNodesToEdge(currentNode);
                        currentNode.ShowFullMazePath(colour);
                        currentNode.SetPartOfEdge(true);
                        if (currentNode.GetNumberOfActiveFaces() == 1 || currentNode.GetNumberOfActiveFaces() == 0) //Junction
                        { currentNode.SetAsJunction(true); }
                        edgeDone = true;
                        graphDone = true;
                    }
                    else
                    {
                        if (currentNode.GetNumberOfActiveFaces() == 3) //Dead End
                        {
                            Node currentJunction = null;

                            edge.SetDeadEnd(true);
                            edge.SetCalculated(true);
                            edge.AddNodesToEdge(currentNode);
                            currentNode.ShowFullMazePath(deadEndColour);
                            currentNode.SetPartOfEdge(true);

                            //check if all exits to junction have been visited
                            while (true)
                            {
                                //go back to last junction
                                currentJunction = edge.GetFirstCell();
                                //find next exit to junction
                                OverwriteContents(ref currentCell, GetNewCell(GetMissingWallFollowingLeftHandWall(currentJunction.GetCoordinate(), edge.GetEdgeSection(0).GetCoordinate()), currentJunction).GetCoordinate());
                                currentNode = nodes[currentCell[0], currentCell[1]];

                                if (currentNode.GetPartOfEdge())
                                {
                                    foreach (MazeCellPath edgeFromList in edgeList)
                                    {
                                        if (edgeFromList.GetLastCell() == currentJunction)
                                        {
                                            edge = edgeFromList;
                                            edge.SetDeadEnd(true);
                                        }
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            edge = new MazeCellPath(currentJunction);
                            edgeList.Add(edge);

                            edgeDone = true;
                        }
                        else if (currentNode.GetNumberOfActiveFaces() == 2) //Continue Path
                        {
                            edge.AddNodesToEdge(currentNode);
                            currentNode.ShowFullMazePath(colour);
                            currentNode.SetPartOfEdge(true);
                            //next node
                            OverwriteContents(ref currentCell, GetNewCell(GetMissingWallFollowingPath(currentCell), currentCell));
                            currentNode = nodes[currentCell[0], currentCell[1]];
                        }
                        else if (currentNode.GetNumberOfActiveFaces() == 1 || currentNode.GetNumberOfActiveFaces() == 0) //Junction
                        {
                            edge.SetCalculated(true);
                            edge.AddEndNode(currentNode);
                            currentNode.ShowFullMazePath(colour);
                            currentNode.SetPartOfEdge(true);
                            currentNode.SetAsJunction(true);
                            //new edge
                            edge = new MazeCellPath(currentNode);
                            edgeList.Add(edge);
                            //next node
                            OverwriteContents(ref currentCell, GetNewCell(GetMissingWallFollowingLeftHandWall(currentCell, currentNode.GetLastCell()), currentCell));
                            currentNode = nodes[currentCell[0], currentCell[1]];

                            edgeDone = true;
                        }
                    }
                    Application.DoEvents();
                }
            }
            this.edgeList = edgeList;
        }
        private void ShowConnectedMazePath(Node node, Color colour)
        {
            //show the solve line for only paths that connect to exit
            for (int i = 0; i < node.NumberOfWalls(); i++)
            {
                if (!node.GetWallActive(i))
                {
                    if (!node.GetLeadsOutOfMaze(i))
                    {
                        if (node.GetConnectingNode(i).GetPartOfEdge())
                        {
                            //if next node is part of an edge that connects the entrance and exit of the maze then show solve line to connect to it
                            node.ShowLine(colour, i);
                        }
                    }
                    else
                    {
                        //if not inside bounds of maze but there is a wall missing node must be and entrance or exit
                        node.ShowLine(colour, i);
                    }
                }
                Application.DoEvents();
            }
        }
        private int GetMissingWallFollowingPath(int[] currentCell)
        {
            Node currentNode = nodes[currentCell[0], currentCell[1]];
            //returns missing walls for current cell (should be a max of 2)
            List<int> missingWalls = currentNode.GetMissingWallsInClockwiseOrder();

            //get next cell for each and check if it was last cell to make sure its not back tracking on its self
            //check 1st element of missing walls list
            int[] newNode = GetNewCell(missingWalls[0], currentCell);
            int[] lastCell = currentNode.GetLastCell();
            if ((newNode[0] != lastCell[0]) || (newNode[1] != lastCell[1]))
            {
                if (!OutOfMaze(currentCell, missingWalls[0]))
                {
                    return missingWalls[0];
                }
            }
            //check 2nd element of missing walls list
            newNode = GetNewCell(missingWalls[1], currentNode).GetLastCell();
            lastCell = currentNode.GetLastCell();
            if ((newNode[0] != lastCell[0]) || (newNode[1] != lastCell[1]))
            {
                if (!OutOfMaze(currentCell, missingWalls[1]))
                {
                    return missingWalls[1];
                }
            }
            return -1;
        }
        private int GetMissingWallFollowingLeftHandWall(int[] currentCell, int[] previousCell)
        {
            //gets the next missing wall starting with the left hand wall and moveing in a clockwise direction  
            Node currentNode = nodes[currentCell[0], currentCell[1]];
            //the missing walls in clockwise order of the current cell
            List<int> missingWalls = currentNode.GetMissingWallsInClockwiseOrder();
            int junctionEntranceWallIndex = 0;

            //gets which wall is the current entrance to the junction and stores the point that it appears in the missing walls list
            //this is used to know which the next missing walls is to the left (in clockwise order)
            //loops through all missing walls for current cell
            for (int i = 0; i < missingWalls.Count; i++)
            {
                //gets the new cell following the current missing wall being checked (i) and compares this to see if it is the same as the previous cell
                //if true this means the entrance to the current entrance to the junction has been found
                int[] newNode = GetNewCell(missingWalls[i], currentCell);
                if ((newNode[0] == previousCell[0]) && (newNode[1] == previousCell[1]))
                {
                    junctionEntranceWallIndex = i;
                }
            }

            //return the next left wall
            if (junctionEntranceWallIndex < missingWalls.Count - 1)
            {
                return missingWalls[junctionEntranceWallIndex + 1];
            }
            else
            {
                //if the index overflows the list length go back to begining and return the first element
                return missingWalls[junctionEntranceWallIndex + 1 - missingWalls.Count];
            }
        }
        private bool OutOfMaze(int[] currentCell, int missingWall)
        {
            //returns true if next cell would be outside the bounds of the maze
            Node node = nodes[currentCell[0], currentCell[1]];
            if (node.GetLeadsOutOfMaze(missingWall))
            {
                return true;
            }
            return false;
        }
        //---------------------Dijkstra-----------------------
        private void SolveUsingDijkstra()
        {
            Vertex endVertex = null;
            List<Vertex> visitedNodesQue = new List<Vertex>();

            //create graph used to solve with Dijkstra
            MapEntireMaze();
            Application.DoEvents();

            //start timer to record the time for Dijkstra to solve
            Stopwatch solveTimer = new Stopwatch();
            solveTimer.Start();

            Dijkstra(ref endVertex, ref visitedNodesQue);

            Application.DoEvents();
            DijkstraSolveLine = AllNodesInDijkstraSolveLine(endVertex);

            Application.DoEvents();
            solveTimer.Stop();

            //remove edges that do not lead directly to end
            foreach (Edge edge in edges)
            {
                foreach (Node node in edge.GetAllNodesInEdge())
                {
                    if (!DijkstraSolveLine.Contains(node))
                    {
                        node.DeleteMazePath();
                    }
                }
            }

            //clean up junctions
            foreach (Vertex v in vertices)
            {
                Node node = v.GetNode();
                if (DijkstraSolveLine.Contains(node))
                {
                    node.DeleteMazePath();
                    Application.DoEvents();
                    ShowConnectedMazePathDijkstra(node, Color.Blue, endVertex);
                }
            }

            //display solve data
            DisplaySolveTime(solveTimer, solveTimeText2);
            //displays line length, junction number and the amount of bends
            DisplaySolveLineStatistics(pathLengthText, numOfJunctionsText, numOfBendsText, endVertex);
            DisplaySolveEfficiency(efficiencyRatingText, endVertex);
            DisplayNodesCalculatedDijkstra(NodesCalculatedText2, visitedNodesQue);
        }
        private void Dijkstra(ref Vertex endVertex, ref List<Vertex> visitedNodesQue)
        {
            List<Vertex> nodesQue = new List<Vertex>();
            Vertex currentVertex = null;
            Vertex startVertex = null;

            //add each vertex to nodes queue and set its distance to infinity (99999)
            foreach (Vertex vertex in vertices)
            {
                vertex.SetDistance(99999);
                nodesQue.Add(vertex);
                if (vertex.GetIsStart()) { currentVertex = vertex; }
                if (vertex.GetIsEnd()) { endVertex = vertex; }
            }
            //set up start vertex to be used if the entrance cell is the same node as the exit cell
            startVertex = currentVertex;
            currentVertex.SetDistance(0);

            do
            {
                //get vertex with the smallest distance from start (first loop it will be the start node
                currentVertex = GetSmallestDist(nodesQue, visitedNodesQue);
                //set as visited
                visitedNodesQue.Add(currentVertex);
                nodesQue.Remove(currentVertex);
                //loop through each edge that is connected to the current vertex
                foreach (Edge edge in GetEdgesThatConnectToVertex(currentVertex, edges))
                {
                    //get the other end of the edge (effectively the next connected to to the current node)
                    Vertex v = GetOppositeVertexOfEdge(edge, currentVertex);
                    int distanceFromSourceThroughNode = currentVertex.GetDistance() + edge.Weight();
                    int currentDistanceFromSource = v.GetDistance();
                    //compare the currently stored distance that v is from the start with what the new calculated value is
                    //if it new value is less than: replace the new value with the old value
                    //otherwise continue to next connected edge
                    if (distanceFromSourceThroughNode < currentDistanceFromSource)
                    {
                        v.SetDistance(distanceFromSourceThroughNode);
                        //store the path of edges from the start so it can be hidden and displayed later
                        v.ClearEdgesFromSource();
                        v.SetEdgesFromSource(currentVertex.GetEdgesFromSource());
                        v.SetEdgesFromSource(edge);

                        edge.SolveEdge(Color.Blue);
                        //save the solve line and the calculation details to be displayed later
                        SaveDijkstraSolveDetails(edge.GetAllNodesInEdge());
                    }
                }
            }
            while (nodesQue.Count > 0 && currentVertex != endVertex);
            //correct error of not being able to calculate path when the entrance and exit are on the same node
            if (startVertex == endVertex)
            {
                endVertex.SetEdgesFromSource(edges[0]);
            }
        }
        private void ShowDijkstraStoredSolveLine()
        {
            //shows the just the solve line for Dijkstra solve method that has been stored in DijkstraSolveLine
            DeleteSolvedMaze();
            Application.DoEvents();

            foreach (Node n in DijkstraSolveLine)
            {
                n.ShowFullMazePath(Color.Blue);
            }
            Application.DoEvents();
        }
        private void ShowDijkstraStoredDetails()
        {
            //shows the the solve line and details for Dijkstra solve method that has been stored in DijkstraSolveLineWithDetail
            Application.DoEvents();

            int i = 0;
            foreach (Node n in DijkstraSolveLineWithDetail)
            {
                if (DijkstraSolveLine.Contains(n))
                {
                    n.ShowFullMazePath(Color.Blue);
                }
                else
                {
                    if (n != null)
                    {
                        n.ShowFullMazePath(Color.LightBlue);
                    }
                }
                i++;
            }
            Application.DoEvents();
        }
        private void SaveDijkstraSolveDetails(List<Node> nodesToAdd)
        {
            //stores Dijkstra solve line and details to be used later when the user wants to display them
            foreach (Node n in nodesToAdd)
            {
                if (!DijkstraSolveLineWithDetail.Contains(n))
                {
                    DijkstraSolveLineWithDetail.Add(n);
                }
            }
        }
        private Vertex GetSmallestDist(List<Vertex> vertices, List<Vertex> visitedVertices)
        {
            //bubble sort to get the Vertex with the lowest distance value
            foreach (Vertex vertex in vertices)
            {
                if (visitedVertices.Contains(vertex))
                {
                    vertices.Remove(vertex);
                }
            }

            //if no values are swapped in a full loop the program will continue (swapped will be false)
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                //loop through all vertices
                for (int j = 0; j < vertices.Count - 1; j++)
                {
                    //get distance for 2 consecutive vertices
                    int distance1 = vertices[j].GetDistance();
                    int distance2 = vertices[j + 1].GetDistance();
                    if (distance1 > distance2)
                    {
                        //swap values to be in order of lowest distance
                        Vertex temp = vertices[j];
                        vertices[j] = vertices[j + 1];
                        vertices[j + 1] = temp;
                        swapped = true;
                    }
                }
            }
            //return Vertex with the smallest distance
            return vertices[0];
        }
        private void MapEntireMaze()
        {
            //find all junctions and dead ends
            GetAllVertices();
            //find all edges seperated by vertices (junctions and dead ends)
            CalculateEdges();
        }
        private void GetAllVertices()
        {
            //loops through all nodes in maze
            for (int i = 0; i < Xnodes; i++)
            {
                for (int j = 0; j < Ynodes; j++)
                {
                    bool isStart = nodes[i, j].GetCoordinate()[0] == (mazeEntranceCell[0] - 1) && nodes[i, j].GetCoordinate()[1] == (mazeEntranceCell[1] - 1);
                    bool isEnd = nodes[i, j].GetCoordinate()[0] == (mazeExitCell[0] - 1) && nodes[i, j].GetCoordinate()[1] == (mazeExitCell[1] - 1);

                    if (isStart || isEnd)
                    {
                        //if the current node is a start or end node
                        Vertex newVertex = new Vertex(nodes[i, j], nodes[i, j].GetMissingWallsInClockwiseOrder(), false);
                        vertices.Add(newVertex);
                        newVertex.SetIsStart(isStart);
                        newVertex.SetIsEnd(isEnd);
                    }
                    else if (nodes[i, j].GetNumberOfInactiveFaces() > 2)
                    {
                        //if the current node is a junction
                        Vertex newVertex = new Vertex(nodes[i, j], nodes[i, j].GetMissingWallsInClockwiseOrder(), false);
                        vertices.Add(newVertex);
                    }
                    else if (nodes[i, j].GetNumberOfInactiveFaces() == 1)
                    {
                        //if the current node is a dead end
                        Vertex newVertex = new Vertex(nodes[i, j], nodes[i, j].GetMissingWallsInClockwiseOrder(), true);
                        vertices.Add(newVertex);
                    }
                }
            }
        }
        private void CalculateEdges()
        {
            Vertex startNode = null;
            Vertex endNode = null;
            Vertex startVertex = null;
            Vertex endVertex = null;
            Node currentNode = null;
            List<Node> nodesContainedInEdge = new List<Node>();
            int currentCellEntanceWall = -1;
            int currentCellExitWall = -1;

            //loops though all the vertices
            foreach (Vertex v in vertices)
            {
                //checks if current vertex is a start or an end
                if (v.GetIsStart())
                {
                    //if start: set the current node to the start vertex's node
                    //store the start node
                    currentNode = v.GetNode();
                    startNode = v;
                    startVertex = v;
                    //set the entrance to the maze as visited
                    foreach (int exit in startNode.GetExits())
                    {
                        if (startNode.GetNode().GetIsEntrance(exit))
                        {
                            startNode.AddToVisitedExits(exit);
                        }
                    }
                }
                if (v.GetIsEnd())
                {
                    //if end: store the end vertex
                    endVertex = v;
                    //set the exit to the maze as visited
                    foreach (int exit in v.GetExits())
                    {
                        if (v.GetNode().GetIsExit(exit))
                        {
                            v.AddToVisitedExits(exit);
                        }
                    }
                }
            }

            //check if there are still unvisited exits
            while (GetVertexWithUnvisitedExits(vertices) != null)
            {
                //loops though current nodes exits
                foreach (int exit in startNode.GetExits())
                {
                    //if if the exit is unvisited and does not lead out of maze
                    if (!startNode.GetVisitedExits().Contains(exit) && !currentNode.GetLeadsOutOfMaze(exit))
                    {
                        //set start node to visited and current node to the node leading out of start node at the specific exit
                        startNode.AddToVisitedExits(exit);
                        currentNode = GetNewCell(exit, startNode.GetNode());
                        nodesContainedInEdge.Add(currentNode);
                        currentCellExitWall = exit;
                        break;
                    }
                }
                //loop until another vertex is reached
                while (!ConvertVerticiesToNodes(vertices).Contains(currentNode))
                {
                    //continue following the current path adding nodes to nodesContainedInEdge ad it goes
                    currentCellEntanceWall = GetReverseWall(currentCellExitWall, 4);
                    currentCellExitWall = GetDifferentMissingWall(currentNode.GetCoordinate(), currentCellEntanceWall);
                    currentNode = GetNewCell(currentCellExitWall, currentNode);
                    nodesContainedInEdge.Add(currentNode);
                }
                //stored end node for current edge and remove it from nodesContainedInEdge
                endNode = vertices[ConvertVerticiesToNodes(vertices).IndexOf(currentNode)];
                endNode.AddToVisitedExits(GetReverseWall(currentCellExitWall, 4));
                endNode.GetNode().DeleteMazePath();
                nodesContainedInEdge.Remove(nodesContainedInEdge[nodesContainedInEdge.Count - 1]);
                //create the edge class and store it's start, end and nodes inbetween
                //store this edge in edges list
                edges.Add(new Edge(startNode, endNode, nodesContainedInEdge));
                //reset values so process can loop back again
                endNode = null;
                nodesContainedInEdge.Clear();
                //get new start node
                startNode = GetVertexWithUnvisitedExits(vertices);
                if (startNode != null)
                {
                    //store in current node
                    currentNode = startNode.GetNode();
                }
            }
            //if the entrance and exit are on the same cell adjust graph:
            if (startVertex == endVertex)
            {
                List<Node> l = new List<Node>();
                edges.Add(new Edge(startVertex, endVertex, l));
            }
        }
        private List<Node> AllNodesInDijkstraSolveLine(Vertex endVertex)
        {
            //returns all nodes in the Dijkstra solve line
            //makes sure there are no duplicates
            List<Node> nodesInSolveLine = new List<Node>();
            foreach (Edge edge in endVertex.GetEdgesFromSource())
            {
                foreach (Node node in edge.GetAllNodesInEdge())
                {
                    if (!nodesInSolveLine.Contains(node))
                    {
                        nodesInSolveLine.Add(node);
                    }
                }
            }
            return nodesInSolveLine;
        }
        private void ShowConnectedMazePathDijkstra(Node node, Color colour, Vertex endVertex)
        {
            //only displays the solve line for paths that are part of the main solve path to the end node
            List<Node> nodesInSolveLine = AllNodesInDijkstraSolveLine(endVertex);

            for (int i = 0; i < node.NumberOfWalls(); i++)
            {
                if (!node.GetWallActive(i))
                {
                    if (!node.GetLeadsOutOfMaze(i))
                    {
                        if (nodesInSolveLine.Contains(node.GetConnectingNode(i)))
                        {
                            //if next node is part of an edge that connects the entrance and exit of the maze then show solve line to connect to it
                            node.ShowLine(colour, i);
                        }
                    }
                    else
                    {
                        //if not inside bounds of maze but there is a wall missing node must be and entrance or exit
                        node.ShowLine(colour, i);
                    }
                }
            }
        }
        private Vertex GetOppositeVertexOfEdge(Edge edge, Vertex vertex)
        {
            //gets the other end to the edge
            if (edge.GetStart() == vertex)
            {
                return edge.GetEnd();
            }
            else if (edge.GetEnd() == vertex)
            {
                return edge.GetStart();
            }
            return null;
        }
        private List<Edge> GetEdgesThatConnectToVertex(Vertex vertex, List<Edge> edges)
        {
            //lists all edges that come from the curret nodes exits
            List<Edge> connectedToVertex = new List<Edge>();
            foreach (Edge edge in edges)
            {
                //if this vertex is either the start or end of the edge
                if (edge.GetStart() == vertex || edge.GetEnd() == vertex)
                {
                    connectedToVertex.Add(edge);
                }
            }
            return connectedToVertex;
        }
        private Vertex GetVertexWithUnvisitedExits(List<Vertex> vertices)
        {
            //gets a vertex with availible exits that have not been visited
            //returns null if there are none

            //loops though all vertices
            foreach (Vertex vertex in vertices)
            {
                if (vertex.GetVisitedExits().Count < vertex.GetExits().Count && !vertex.GetIsDeadEnd())
                {
                    return vertex;
                }
            }

            return null;
        }
        private List<Node> ConvertVerticiesToNodes(List<Vertex> vertices)
        {
            //gets a list of node that have been converted from their corresponding Vertex
            List<Node> nodeList = new List<Node>();
            foreach (Vertex vertex in vertices)
            {
                nodeList.Add(vertex.GetNode());
            }
            return nodeList;
        }
        private int GetDifferentMissingWall(int[] currentCell, int otherWall)
        {
            //returns the other missing wall to the current cell
            //this should only be called when the current cell has two exits
            Node currentNode = nodes[currentCell[0], currentCell[1]];
            //returns missing walls for current cell (should be a max of 2)
            List<int> missingWalls = currentNode.GetMissingWallsInClockwiseOrder();

            for (int i = 0; i < missingWalls.Count; i++)
            {
                if (otherWall != missingWalls[i])
                {
                    return missingWalls[i];
                }
            }
            return -1;
        }
        //---------------------Solve Data-----------------------
        private void AdjustSolveDataPanels()
        {
            //changes the position of the two solve data panels
            //if only one data panel is showing it should be centered in the space if has
            //otherwise the two panels should be in their original position
            int x = LHRSolveDataOriginalPosition.X + (LHRSolveDataOriginalPosition.X - DijkstraSolveDataOriginalPosition.X) / 2;
            int y = LHRSolveDataOriginalPosition.Y - (LHRSolveDataOriginalPosition.Y - DijkstraSolveDataOriginalPosition.Y) / 2;
            Point centered = new Point(x, y);

            DisplaySolvedLHR.Checked = true;
            DisplaySolvedDijkstra.Checked = true;

            if (SolveBoth.Checked)
            {
                LHRSolveDataPanel.Visible = true;
                LHRSolveDataPanel.Location = LHRSolveDataOriginalPosition;
                DijkstraSolveDataPanel.Visible = true;
                DijkstraSolveDataPanel.Location = DijkstraSolveDataOriginalPosition;

                DisplaySolvedLHR.Visible = true;
                DisplaySolvedLHR.Checked = false;
                DisplaySolvedDijkstra.Checked = true;
                DisplaySolvedDijkstra.Visible = true;
            }
            else if (SolveLHR.Checked)
            {
                LHRSolveDataPanel.Visible = true;
                DijkstraSolveDataPanel.Visible = false;
                LHRSolveDataPanel.Location = centered;

                DisplaySolvedLHR.Checked = true;
                DisplaySolvedDijkstra.Checked = false;
                DisplaySolvedLHR.Visible = false;
            }
            else if (SolveDijkstra.Checked)
            {
                DijkstraSolveDataPanel.Visible = true;
                LHRSolveDataPanel.Visible = false;
                DijkstraSolveDataPanel.Location = centered;

                DisplaySolvedLHR.Checked = false;
                DisplaySolvedDijkstra.Checked = true;
                DisplaySolvedDijkstra.Visible = false;
            }
            Application.DoEvents();
        }
        private void DisplayNodesCalculatedDijkstra(TextBox nCt, List<Vertex> visitedNodesQue)
        {
            //displays the amount of nodes that where proccesed when calculating the solve line for Dijkstra
            int nodesCount = 0;
            List<Node> nodesInSolveLineCalculation = new List<Node>();
            foreach (Vertex vertex in visitedNodesQue)
            {
                foreach (Edge edge in vertex.GetEdgesFromSource())
                {
                    foreach (Node node in edge.GetAllNodesInEdge())
                    {
                        if (!nodesInSolveLineCalculation.Contains(node))
                        {
                            nodesInSolveLineCalculation.Add(node);
                            nodesCount++;
                        }
                    }
                }
            }
            nCt.Text = "Nodes Calculated: " + nodesCount.ToString() + " node" + ManagePlural(nodesCount);
        }
        private void ResetStatistics()
        {
            //resets the solve data textboxes so they dont show incorrect values
            //called when leaving solve screen
            solveTimeText.Text = "";
            solveTimeText2.Text = "";

            NodesCalculatedText.Text = "";
            NodesCalculatedText2.Text = "";

            pathLengthText.Text = "";
            numOfJunctionsText.Text = "";
            numOfBendsText.Text = "";
            efficiencyRatingText.Text = "";

            DisplaySolvedLHR.Checked = true;
            DisplaySolvedDijkstra.Checked = true;
            DisplaySolveDetails.Checked = false;
        }
        private void DisplaySolveTime(Stopwatch stopwatch, TextBox t)
        {
            t.Text = "Solve Time: " + stopwatch.Elapsed.ToString().Substring(6, 6) + " seconds";
        }
        private void DisplaySolveLineStatistics(TextBox pLt, TextBox noJt, TextBox noBt, Vertex endVertex)
        {
            //shows the path length, number of junctions and number of bends in the maze
            int pathLength = 0;
            int JunctionNum = 0;
            int BendsNum = 0;

            List<Node> nodesInSolveLine = new List<Node>();
            if (endVertex != null)
            {
                nodesInSolveLine = AllNodesInDijkstraSolveLine(endVertex);
                foreach (Node node in nodesInSolveLine)
                {
                    pathLength++;
                    if (node.GetNumberOfActiveFaces() == 1 || node.GetNumberOfActiveFaces() == 0)
                    {
                        JunctionNum++;
                    }
                    if (node.IsBend())
                    {
                        BendsNum++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < Xnodes; i++)
                {
                    for (int j = 0; j < Ynodes; j++)
                    {
                        if (nodes[i, j].GetPartOfEdge())
                        {
                            pathLength++;
                            if (nodes[i, j].GetIsJunction())
                            {
                                JunctionNum++;
                            }
                            if (nodes[i, j].IsBend())
                            {
                                BendsNum++;
                            }
                        }
                    }
                }
            }

            pLt.Text = "Path Length: " + pathLength.ToString() + " node" + ManagePlural(pathLength);
            noJt.Text = "No. of Junctions: " + JunctionNum.ToString();
            noBt.Text = "No. of Bends: " + BendsNum.ToString();
        }
        private void DisplaySolveEfficiency(TextBox eft, Vertex endVertex)
        {
            //displays the percentage of the maze that is filled by the solve path
            List<Node> nodesInSolveLine = new List<Node>();
            if (endVertex != null) { nodesInSolveLine = AllNodesInDijkstraSolveLine(endVertex); }

            int pathLength = 0;
            for (int i = 0; i < Xnodes; i++)
            {
                for (int j = 0; j < Ynodes; j++)
                {
                    if (nodes[i, j].GetPartOfEdge() || nodesInSolveLine.Contains(nodes[i, j]))
                    {
                        pathLength++;
                    }
                }
            }
            double efficiency = pathLength / (double)(Xnodes * Ynodes) * 100;
            try { eft.Text = "Path Percentage: " + efficiency.ToString().Substring(0, 4) + "%"; }
            catch { eft.Text = "Path Percentage: " + efficiency.ToString() + "%"; }
        }
        private void DisplayNodesCalculatedLHR(TextBox nCt)
        {
            //displays the amount of nodes that where proccesed when calculating the solve line for left hand rule
            int nodesCount = 0;

            for (int i = 0; i < Xnodes; i++)
            {
                for (int j = 0; j < Ynodes; j++)
                {
                    if (IsPartOfSolveCalculation(nodes[i, j], edgeList))
                    {
                        nodesCount++;
                    }
                }
            }
            nCt.Text = "Nodes Calculated: " + nodesCount.ToString() + " node" + ManagePlural(nodesCount);
        }
        private bool IsPartOfSolveCalculation(Node node, List<MazeCellPath> list)
        {
            //returns if the current node is part of the main solve line connecting the start node to the end
            foreach (MazeCellPath edge in list)
            {
                foreach (Node edgeNode in edge.GetNodesList())
                {
                    if (edgeNode == node)
                    {
                        return true;
                    }
                }
                if (edge.GetFirstCell() == node)
                {
                    return true;
                }
            }
            return false;
        }

        //===================================== EXPORT SCREEN ==========================================
        private void button19_Click(object sender, EventArgs e)
        {
            //create new maze
            ResetStatistics();
            SetupNewMaze();
        }
        private void button15_Click(object sender, EventArgs e)
        {
            //back
            ResetStatistics();
            DeleteSolvedMaze();

            SolveFromExportButton.Text = "Solve";

            BringThisToFront(MainScreenButtonsContainer, true, null);
        }
        private void button16_Click(object sender, EventArgs e)
        {
            //solve button click
            //solves with Left Hand Rule from export screen
            //change text to unsolve after solving
            if (SolveFromExportButton.Text == "Solve")
            {
                SolveFromExportButton.Enabled = false;
                SolveFollowingLeftWall();
                Application.DoEvents();
                SolveFromExportButton.Text = "Unsolve";
                SolveFromExportButton.Enabled = true;
            }
            else
            {
                SolveFromExportButton.Enabled = false;
                ResetStatistics();
                DeleteSolvedMaze();
                Application.DoEvents();
                SolveFromExportButton.Text = "Solve";
                SolveFromExportButton.Enabled = true;
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //save
            //take screen shot of maze
            GetMazeImage(MazeImagespacePanel);

            //open dialog to choose location
            saveFileDialog1.ShowDialog();
            try
            {
                //try to save it in chosen location
                MazeImage.Save(saveFileDialog1.FileName);

                //add image filename number so that multiple mazes can be saved with ease
                saveFileDialog1.FileName = "Maze" + ImageFilenameNumber + ".png";
                ImageFilenameNumber++;
            }
            //if there is an error make save button red
            catch { SaveButton.BackColor = Color.Red; }
        }
        private void PrintButton_Click(object sender, EventArgs e)
        {
            //print
            //take screen shot of maze
            GetMazeImage(MazeImagespacePanel);

            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            //add maze image onto a document so it can be printed
            doc.PrintPage += Page;
            pd.Document = doc;
            //open print dialog
            if (pd.ShowDialog() == DialogResult.OK)
            {
                //print
                doc.Print();
            }
        }
        private void Page(object sender, PrintPageEventArgs e)
        {
            //turn maze image into a document
            e.Graphics.DrawImage(MazeImage, 0, 0);
        }

        //===================================== All ==========================================
        private void BringThisToFront(TextBox textBox, bool bringToFront, Panel parent)
        {
            //brings a textbox to the front of the page
            //or returns it to its parent panel
            if (bringToFront)
            {
                Controls.Add(textBox);
                textBox.BringToFront();
                textBox.Visible = true;
            }
            else
            {
                textBox.Parent = parent;
            }
        }
        private void BringThisToFront(Panel panel, bool bringToFront, TabPage parent)
        {
            //brings a panel to the front of the page
            //or returns it to its parent tabpage
            if (bringToFront)
            {
                Controls.Add(panel);
                panel.BringToFront();
                panel.Visible = true;
            }
            else
            {
                panel.Parent = parent;
            }
        }
        private void BringThisToFront(Panel panel, bool bringToFront, Panel parent)
        {
            //brings a panel to the front of the page
            //or returns it to its parent panel
            if (bringToFront)
            {
                Controls.Add(panel);
                panel.BringToFront();
                panel.Visible = true;
            }
            else
            {
                panel.Parent = parent;
            }
        }
        private void CloseMaze()
        {
            //delete entire maze
            for (int i = 0; i < Xnodes; i++)
            {
                for (int j = 0; j < Ynodes; j++)
                {
                    nodes[i, j].CloseNode();
                    nodes[i, j] = null;
                }
            }
        }
        private void PutAllBackInOriginalContainers()
        {
            //put all main panels back into main screen
            BringThisToFront(ExportScreenPanel, false, MainScreenPanel);
            BringThisToFront(SolveScreenPanel, false, MainScreenPanel);
            BringThisToFront(MainScreenButtonsContainer, false, MainScreenPanel);
            //put maze data text back
            BringThisToFront(MazeDataText, false, MainScreenPanel);
        }
        private void GetMazeImage(Panel ImageBounds)
        {
            //screen shots maze within the space of imageBounds
            MazeImage = new Bitmap(ImageBounds.Width,
                               ImageBounds.Height,
                               PixelFormat.Format32bppArgb);

            Rectangle r = ImageBounds.Bounds;
            Graphics g = Graphics.FromImage(MazeImage);
            g.CopyFromScreen(RectangleToScreen(r).Left, RectangleToScreen(r).Top, 0, 0, RectangleToScreen(r).Size);
        }
        private void SetupNewMaze()
        {
            //discard current maze
            DeleteBorder();
            CloseMaze();

            //put back into parent
            PutAllBackInOriginalContainers();

            //hide panels
            ExportScreenPanel.Visible = false;
            SolveScreenPanel.Visible = false;

            //go back to create maze screen
            tabControl1.SelectedTab = NewMazeScreen;

            GC.Collect();
        }
        public void OverwriteContents(ref int[] list, int[] data)
        {
            //copies all contents from one array to another
            list = new int[data.Length];
            data.CopyTo(list, 0);
        }
        public void OverwriteContents(ref List<int> list, List<int> data)
        {
            //copies all contents from one list to another
            list.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                list.Add(data[i]);
            }
        }
        private string ManagePlural(int input)
        {
            //adds and s to plural lines of text
            if (input == 1)
            {
                return "";
            }
            return "s";
        }
        private int GetReverseWall(int wall, int wallCount)
        {
            //returns the wall opposite to the input wall
            int x = wall + 2;
            if (x > (wallCount - 1))
            {
                return x - wallCount;
            }
            else
            {
                return x;
            }
        }
        private void CreateImageList()
        {
            images[0] = new Bitmap(projectDirectory + FourSidedCellPath);

            images[1] = new Bitmap(projectDirectory + ThreeSidedCellPath + "0.png");
            images[2] = new Bitmap(projectDirectory + ThreeSidedCellPath + "90.png");
            images[3] = new Bitmap(projectDirectory + ThreeSidedCellPath + "180.png");
            images[4] = new Bitmap(projectDirectory + ThreeSidedCellPath + "270.png");

            images[5] = new Bitmap(projectDirectory + TwoSidedCellPath + "0.png");
            images[6] = new Bitmap(projectDirectory + TwoSidedCellPath + "90.png");

            images[7] = new Bitmap(projectDirectory + TwoSidedCornerCellPath + "0.png");
            images[8] = new Bitmap(projectDirectory + TwoSidedCornerCellPath + "90.png");
            images[9] = new Bitmap(projectDirectory + TwoSidedCornerCellPath + "180.png");
            images[10] = new Bitmap(projectDirectory + TwoSidedCornerCellPath + "270.png");

            images[11] = new Bitmap(projectDirectory + OneSidedCellPath + "0.png");
            images[12] = new Bitmap(projectDirectory + OneSidedCellPath + "90.png");
            images[13] = new Bitmap(projectDirectory + OneSidedCellPath + "180.png");
            images[14] = new Bitmap(projectDirectory + OneSidedCellPath + "270.png");

            images[15] = new Bitmap(projectDirectory + NoSidedCellPath);
        }
    }
}