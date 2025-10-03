using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Maze_Generator
{
    public class Node
    {
        //variables
        int XCoordinate;
        int YCoordinate;
        int LastCellX = -1;
        int LastCellY = -1;

        private PictureBox cell;

        bool visited;
        private List<Wall> walls = new List<Wall>();

        //wall indexes
        private const int NorthLineIndex = 0;
        private const int EastLineIndex = 1;
        private const int SouthLineIndex = 2;
        private const int WestLineIndex = 3;

        private bool partOfEdge = false;
        private bool isJunction = false;

        public Node(int XCoordinate, int YCoordinate, PictureBox cell)
        {
            visited = false;

            this.XCoordinate = XCoordinate;
            this.YCoordinate = YCoordinate;
            this.cell = cell;

            SetUpWalls(4);
        }

        private void SetUpWalls(int NumOfWalls)
        {
            //creates and stores a reference to all of this cells walls
            for (int i = 0; i < NumOfWalls; i++)
            {
                walls.Add(new Wall(i, cell));
                walls[i].SetWallActive(true);
            }
        }
        public List<int> GetWalls()
        {
            List<int> list = new List<int>();

            for (int i = 0; i < NumberOfWalls(); i++)
            {
                list.Add(walls[i].GetFaceIndex());
            }
            return list;
        }
        public void SetLeadsOutOfMaze(int wallIndex)
        {
            walls[wallIndex].LeadsOutOfMaze();
        }
        public bool GetLeadsOutOfMaze(int wallIndex)
        {
            return walls[wallIndex].GetLeadsOutOfMaze();
        }
        public void SetConnectingNode(int wallIndex, Node node)
        {
            walls[wallIndex].SetConnectingNode(node);
        }
        public Node GetConnectingNode(int wallIndex)
        {
            return walls[wallIndex].GetConnectingNode();
        }
        public bool GetIsEntrance(int wallIndex)
        {
            return walls[wallIndex].GetIsEntrance();
        }
        public bool GetIsExit(int wallIndex)
        {
            return walls[wallIndex].GetIsExit();
        }

        private void UpdateCell(Bitmap[] images)
        {
            //update cell icon
            if (GetNumberOfActiveFaces() == 4)
            {
                cell.Image = images[0];
            }
            else if (GetNumberOfActiveFaces() == 3)
            {
                //rotate image so inactive wall is in the correct location
                //image is facing east by default
                if (!walls[NorthLineIndex].GetWallActive()) cell.Image = images[4];
                else if (!walls[SouthLineIndex].GetWallActive()) cell.Image = images[2];
                else if (!walls[WestLineIndex].GetWallActive()) cell.Image = images[3];
                else cell.Image = images[1];
                Application.DoEvents();
            }
            else if (GetNumberOfActiveFaces() == 2)
            {
                //check which 2 sided cell image to use
                if (!walls[NorthLineIndex].GetWallActive() && !walls[SouthLineIndex].GetWallActive() || !walls[EastLineIndex].GetWallActive() && !walls[WestLineIndex].GetWallActive())
                {
                    //rotate image so inactive walls are in the correct direction
                    //image is facing west to east by default
                    if (!walls[NorthLineIndex].GetWallActive() && !walls[SouthLineIndex].GetWallActive()) cell.Image = images[6];
                    else cell.Image = images[5];
                    Application.DoEvents();
                }
                else
                {
                    //rotate image so that inactive walls are in the correct location
                    //image is facing so that north and east walls are missing by default
                    if (!walls[EastLineIndex].GetWallActive() && !walls[SouthLineIndex].GetWallActive()) cell.Image = images[8];
                    else if (!walls[SouthLineIndex].GetWallActive() && !walls[WestLineIndex].GetWallActive()) cell.Image = images[9];
                    else if (!walls[WestLineIndex].GetWallActive() && !walls[NorthLineIndex].GetWallActive()) cell.Image = images[10];
                    else cell.Image = images[7];
                    Application.DoEvents();
                }
            }
            else if (GetNumberOfActiveFaces() == 1)
            {
                //rotate image so inactive walls are in the correct direction
                //the only active wall is north by default
                if (walls[EastLineIndex].GetWallActive()) cell.Image = images[12];
                else if (walls[SouthLineIndex].GetWallActive()) cell.Image = images[13];
                else if (walls[WestLineIndex].GetWallActive()) cell.Image = images[14];
                else cell.Image = images[11];
                Application.DoEvents();
            }
            else if (GetNumberOfActiveFaces() == 0)
                cell.Image = images[15];

            Application.DoEvents();
        }

        public int GetNumberOfActiveFaces()
        {
            int activeFaces = 4 - GetNumberOfInactiveFaces();
            return activeFaces;
        }
        public int GetNumberOfInactiveFaces()
        {
            int activeFaces = 0;
            for (int i = 0; i < walls.Count; i++)
            {
                if (!GetWallActive(i))
                {
                    activeFaces++;
                }
            }
            return activeFaces;
        }
        
        public List<int> GetMissingWallsInClockwiseOrder()
        {
            List<int> missingWalls = new List<int>();

            for (int i = 0; i < walls.Count; i++)
            {
                if (!walls[i].GetWallActive())
                {
                    missingWalls.Add(i);
                }
            }
            return missingWalls;
        }

        public void SetVisited(bool visited)
        {
            this.visited = visited;
        }
        public bool GetVisited()
        {
            return visited;
        }

        public void RemoveWall(int wallFace, Bitmap[] images)
        {
            //deletes wall
            for (int i = 0; i < walls.Count; i++)
            {
                if (wallFace == i)
                {
                    walls[i].RemoveWall();
                }
            }

            //update the icon to show changes
            UpdateCell(images);
        }
        public bool GetWallActive(int faceIndex)
        {
            return walls[faceIndex].GetWallActive();
        }

        public int[] GetCoordinate()
        {
            //returns coordinate of current node
            return new int[] { XCoordinate, YCoordinate };
        }

        public void ShowFullMazePath(Color colour)
        {
            //displays solve line for each wall in this cell
            for (int i = 0; i < walls.Count; i++)
            {
                if (!walls[i].GetWallActive())
                {
                    ShowLine(colour, i);
                }
            }
        }
        public void DeleteMazePath()
        {
            //clears solve line on cell and all walls
            cell.Invalidate();

            foreach(Wall wall in walls)
            {
                wall.DeleteMazePath();
            }
        }

        public void ShowLine(Color colour, int wallIndex)
        {
            //shows specific faces solve line
            walls[wallIndex].ShowLineForSquareCell(colour);
        }

        public void SetLastCell(int LastCellX, int LastCellY)
        {
            this.LastCellX = LastCellX;
            this.LastCellY = LastCellY;
        }
        public int[] GetLastCell()
        {
            //returns previous cell in maze path
            return new int[] { LastCellX, LastCellY };
        }
        public void CloseNode()
        {
            //deletes cell icon
            cell.SendToBack();
        }
        public PictureBox GetCell()
        {
            return cell;
        }

        public void SetPartOfEdge(bool partOfEdge)
        {
            this.partOfEdge = partOfEdge;
        }
        public bool GetPartOfEdge()
        {
            return partOfEdge;
        }

        public void SetAsJunction(bool isJunction)
        {
            this.isJunction = isJunction;
        }
        public bool GetIsJunction()
        {
            return isJunction;
        }
        public bool IsBend()
        {
            //check if solve line bends in this cell
            int offSet = 2;

            for (int i = 0; i < walls.Count; i++)
            {
                //switch between subtracting from face index to adding to face index
                if (i == 2) { offSet = -offSet; }
                if (walls[i].GetSolveLine() != null && walls[i + offSet].GetSolveLine() == null)
                {
                    return true;
                }
            }
            return false;
        }

        public void SetWallAsEntrance(int wallIndex)
        {
            walls[wallIndex].SetAsEntrance();
        }
        public void SetWallAsExit(int wallIndex)
        {
            walls[wallIndex].SetAsExit();
        }
        public int NumberOfWalls()
        {
            return walls.Count;
        }
    }
}