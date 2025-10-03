using System.Drawing;
using System.Windows.Forms;

namespace Maze_Generator
{
    internal class Wall
    {
        //face starts from top and goes clockwise around each faces
        int faceIndex;
        Node connectingNode;
        bool wallActive;
        Graphics solveLine;
        bool leadsOutOfMaze;
        bool isEntrance;
        bool isExit;
        PictureBox cell;

        public Wall(int faceIndex, PictureBox cell)
        {
            this.faceIndex = faceIndex;
            this.cell = cell;
        }

        public void LeadsOutOfMaze()
        {
            //sets if this face leads out of maze
            leadsOutOfMaze = true;
        }
        public bool GetLeadsOutOfMaze()
        {
            return leadsOutOfMaze;
        } 
        public void SetConnectingNode(Node node)
        {
            connectingNode = node;
        }
        public Node GetConnectingNode()
        {
            return connectingNode;
        }

        public bool GetWallActive()
        {
            return wallActive;
        }
        public void SetWallActive(bool active)
        {
            wallActive = active;
        }
        public void RemoveWall()
        {
            wallActive = false;
        }

        private void ShowLine(Color colour, float p1x, float p1y, float p2x, float p2y, float thickness)
        {
            Application.DoEvents();
            //shows solve line using inputs
            if (solveLine == null)
            {
                solveLine = cell.CreateGraphics();
            }

            Pen p = new Pen(colour, thickness);
            solveLine.DrawLine(p, p1x, p1y, p2x, p2y);

            Application.DoEvents();
        }
        public void ShowLineForSquareCell(Color colour)
        {
            //creates different configs of solve lines dependant on which way this wall is facing
            float thicknessX = cell.Width * 0.2f;
            float thicknessY = cell.Height * 0.2f;

            float middleX = cell.Width / 2;
            float middleY = cell.Height / 2;
            float top = 0;
            float bottom = cell.Height;
            float left = 0;
            float right = cell.Width;
            float overHangY = thicknessY / 2;
            float overHangX = thicknessX / 2;

            if (this.faceIndex == 0) { ShowLine(colour, middleX, top, middleX, middleY + overHangY, thicknessX); }
            else if (this.faceIndex == 1) { ShowLine(colour, middleX - overHangX, middleY, right, middleY, thicknessY); }
            else if (this.faceIndex == 2) { ShowLine(colour, middleX, middleY - overHangY, middleX, bottom, thicknessX); }
            else if (this.faceIndex == 3) { ShowLine(colour, left, middleY, middleX + overHangX, middleY, thicknessY); }
        }
        public void DeleteMazePath()
        {
            //clears solve graphic
            solveLine = null;
        }
        public Graphics GetSolveLine()
        {
            return solveLine;
        }

        public void SetAsEntrance()
        {
            isEntrance = true;
        }
        public bool GetIsEntrance()
        {
            return isEntrance;
        }
        public void SetAsExit()
        {
            isExit = true;
        }
        public bool GetIsExit()
        {
            return isExit;
        }

        public int GetFaceIndex()
        {
            //returns this faces index
            return faceIndex;
        }
    }
}