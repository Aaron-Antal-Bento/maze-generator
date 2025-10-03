
namespace Maze_Generator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            IsSquareCheckBox = new System.Windows.Forms.CheckBox();
            GenerateButton = new System.Windows.Forms.Button();
            YValuesTrackBar = new System.Windows.Forms.TrackBar();
            TextBoxOutline2 = new System.Windows.Forms.Button();
            TextBoxOutline1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            NewMazeScreenPanel = new System.Windows.Forms.Panel();
            textBox4 = new System.Windows.Forms.TextBox();
            textBox3 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            textBox1 = new System.Windows.Forms.TextBox();
            button4 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            checkBox1 = new System.Windows.Forms.CheckBox();
            XValuesTrackBar = new System.Windows.Forms.TrackBar();
            GeneratingScreenPanel = new System.Windows.Forms.Panel();
            MazeBoundingBox1 = new System.Windows.Forms.Button();
            tabControl1 = new System.Windows.Forms.TabControl();
            NewMazeScreen = new System.Windows.Forms.TabPage();
            GeneratingScreen = new System.Windows.Forms.TabPage();
            MainScreen = new System.Windows.Forms.TabPage();
            MainScreenPanel = new System.Windows.Forms.Panel();
            MazeDataText = new System.Windows.Forms.TextBox();
            MazeBoundingBox2 = new System.Windows.Forms.Button();
            MazeImagespacePanel = new System.Windows.Forms.Panel();
            SolveScreenPanel = new System.Windows.Forms.Panel();
            DijkstraSolveDataPanel = new System.Windows.Forms.Panel();
            NodesCalculatedText2 = new System.Windows.Forms.TextBox();
            solveTimeText2 = new System.Windows.Forms.TextBox();
            DisplaySolvedDijkstra = new System.Windows.Forms.CheckBox();
            DijkstraInfoBox = new System.Windows.Forms.Button();
            LHRSolveDataPanel = new System.Windows.Forms.Panel();
            NodesCalculatedText = new System.Windows.Forms.TextBox();
            DisplaySolvedLHR = new System.Windows.Forms.CheckBox();
            solveTimeText = new System.Windows.Forms.TextBox();
            LeftWallInfoBox = new System.Windows.Forms.Button();
            DisplaySolveDetails = new System.Windows.Forms.CheckBox();
            efficiencyRatingText = new System.Windows.Forms.TextBox();
            pathLengthText = new System.Windows.Forms.TextBox();
            numOfJunctionsText = new System.Windows.Forms.TextBox();
            numOfBendsText = new System.Windows.Forms.TextBox();
            button5 = new System.Windows.Forms.Button();
            BackButton1 = new System.Windows.Forms.Button();
            ExportFromSolveButton = new System.Windows.Forms.Button();
            SolveTitle = new System.Windows.Forms.RichTextBox();
            NewMazeButton2 = new System.Windows.Forms.Button();
            MainScreenButtonsContainer = new System.Windows.Forms.Panel();
            SolveBoth = new System.Windows.Forms.CheckBox();
            SolveDijkstra = new System.Windows.Forms.CheckBox();
            SolveLHR = new System.Windows.Forms.CheckBox();
            NewMazeButton1 = new System.Windows.Forms.Button();
            ExportButton = new System.Windows.Forms.Button();
            SolveButton = new System.Windows.Forms.Button();
            ExportScreenPanel = new System.Windows.Forms.Panel();
            PrintButton = new System.Windows.Forms.Button();
            SaveButton = new System.Windows.Forms.Button();
            BackButton2 = new System.Windows.Forms.Button();
            SolveFromExportButton = new System.Windows.Forms.Button();
            ExportTitle = new System.Windows.Forms.RichTextBox();
            NewMazeButton3 = new System.Windows.Forms.Button();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)YValuesTrackBar).BeginInit();
            NewMazeScreenPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)XValuesTrackBar).BeginInit();
            GeneratingScreenPanel.SuspendLayout();
            tabControl1.SuspendLayout();
            NewMazeScreen.SuspendLayout();
            GeneratingScreen.SuspendLayout();
            MainScreen.SuspendLayout();
            MainScreenPanel.SuspendLayout();
            SolveScreenPanel.SuspendLayout();
            DijkstraSolveDataPanel.SuspendLayout();
            LHRSolveDataPanel.SuspendLayout();
            MainScreenButtonsContainer.SuspendLayout();
            ExportScreenPanel.SuspendLayout();
            SuspendLayout();
            // 
            // IsSquareCheckBox
            // 
            IsSquareCheckBox.AutoSize = true;
            IsSquareCheckBox.Location = new System.Drawing.Point(279, 302);
            IsSquareCheckBox.Name = "IsSquareCheckBox";
            IsSquareCheckBox.Size = new System.Drawing.Size(62, 19);
            IsSquareCheckBox.TabIndex = 0;
            IsSquareCheckBox.Text = "Square";
            IsSquareCheckBox.UseVisualStyleBackColor = true;
            IsSquareCheckBox.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // GenerateButton
            // 
            GenerateButton.BackColor = System.Drawing.Color.WhiteSmoke;
            GenerateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            GenerateButton.Font = new System.Drawing.Font("Verdana", 24F);
            GenerateButton.Location = new System.Drawing.Point(286, 346);
            GenerateButton.Name = "GenerateButton";
            GenerateButton.Size = new System.Drawing.Size(185, 52);
            GenerateButton.TabIndex = 3;
            GenerateButton.Text = "Generate";
            GenerateButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            GenerateButton.UseVisualStyleBackColor = false;
            GenerateButton.Click += button3_Click;
            // 
            // YValuesTrackBar
            // 
            YValuesTrackBar.BackColor = System.Drawing.Color.White;
            YValuesTrackBar.Location = new System.Drawing.Point(364, 156);
            YValuesTrackBar.Maximum = 30;
            YValuesTrackBar.Minimum = 1;
            YValuesTrackBar.Name = "YValuesTrackBar";
            YValuesTrackBar.Size = new System.Drawing.Size(256, 45);
            YValuesTrackBar.TabIndex = 7;
            YValuesTrackBar.TabStop = false;
            YValuesTrackBar.Value = 1;
            YValuesTrackBar.Scroll += trackBar2_Scroll;
            // 
            // TextBoxOutline2
            // 
            TextBoxOutline2.BackColor = System.Drawing.Color.Transparent;
            TextBoxOutline2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            TextBoxOutline2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            TextBoxOutline2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            TextBoxOutline2.Font = new System.Drawing.Font("Verdana", 10F);
            TextBoxOutline2.ForeColor = System.Drawing.Color.Black;
            TextBoxOutline2.Location = new System.Drawing.Point(164, 151);
            TextBoxOutline2.Name = "TextBoxOutline2";
            TextBoxOutline2.Size = new System.Drawing.Size(185, 52);
            TextBoxOutline2.TabIndex = 8;
            TextBoxOutline2.Text = "Number of Nodes on the Y-Axis";
            TextBoxOutline2.UseVisualStyleBackColor = false;
            // 
            // TextBoxOutline1
            // 
            TextBoxOutline1.BackColor = System.Drawing.Color.Transparent;
            TextBoxOutline1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            TextBoxOutline1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            TextBoxOutline1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            TextBoxOutline1.Font = new System.Drawing.Font("Verdana", 10F);
            TextBoxOutline1.ForeColor = System.Drawing.Color.Black;
            TextBoxOutline1.Location = new System.Drawing.Point(164, 72);
            TextBoxOutline1.Name = "TextBoxOutline1";
            TextBoxOutline1.Size = new System.Drawing.Size(185, 52);
            TextBoxOutline1.TabIndex = 9;
            TextBoxOutline1.Text = "Number of Nodes on the X-Axis";
            TextBoxOutline1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.CausesValidation = false;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(354, 64);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 15);
            label1.TabIndex = 14;
            label1.Text = "1";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.CausesValidation = false;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(354, 145);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(32, 15);
            label2.TabIndex = 16;
            label2.Text = "1";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.CausesValidation = false;
            label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            label5.Location = new System.Drawing.Point(354, 186);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(32, 15);
            label5.TabIndex = 17;
            label5.Text = "1";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.CausesValidation = false;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            label3.Location = new System.Drawing.Point(354, 104);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(32, 15);
            label3.TabIndex = 18;
            label3.Text = "1";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.CausesValidation = false;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            label4.Location = new System.Drawing.Point(584, 104);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(32, 15);
            label4.TabIndex = 19;
            label4.Text = "30";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.CausesValidation = false;
            label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            label6.Location = new System.Drawing.Point(584, 183);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(32, 15);
            label6.TabIndex = 20;
            label6.Text = "30";
            label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NewMazeScreenPanel
            // 
            NewMazeScreenPanel.BackColor = System.Drawing.Color.White;
            NewMazeScreenPanel.Controls.Add(textBox4);
            NewMazeScreenPanel.Controls.Add(textBox3);
            NewMazeScreenPanel.Controls.Add(textBox2);
            NewMazeScreenPanel.Controls.Add(textBox1);
            NewMazeScreenPanel.Controls.Add(button4);
            NewMazeScreenPanel.Controls.Add(button3);
            NewMazeScreenPanel.Controls.Add(button2);
            NewMazeScreenPanel.Controls.Add(button1);
            NewMazeScreenPanel.Controls.Add(checkBox1);
            NewMazeScreenPanel.Controls.Add(label6);
            NewMazeScreenPanel.Controls.Add(label4);
            NewMazeScreenPanel.Controls.Add(TextBoxOutline2);
            NewMazeScreenPanel.Controls.Add(label3);
            NewMazeScreenPanel.Controls.Add(IsSquareCheckBox);
            NewMazeScreenPanel.Controls.Add(label5);
            NewMazeScreenPanel.Controls.Add(GenerateButton);
            NewMazeScreenPanel.Controls.Add(label2);
            NewMazeScreenPanel.Controls.Add(label1);
            NewMazeScreenPanel.Controls.Add(TextBoxOutline1);
            NewMazeScreenPanel.Controls.Add(XValuesTrackBar);
            NewMazeScreenPanel.Controls.Add(YValuesTrackBar);
            NewMazeScreenPanel.Location = new System.Drawing.Point(10, 5);
            NewMazeScreenPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            NewMazeScreenPanel.Name = "NewMazeScreenPanel";
            NewMazeScreenPanel.Size = new System.Drawing.Size(779, 432);
            NewMazeScreenPanel.TabIndex = 21;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox4.Cursor = System.Windows.Forms.Cursors.IBeam;
            textBox4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            textBox4.Location = new System.Drawing.Point(438, 265);
            textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            textBox4.MaxLength = 2;
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(27, 15);
            textBox4.TabIndex = 29;
            textBox4.Text = "1";
            textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox4.Click += SelectAllInTextBox;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            textBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            textBox3.Location = new System.Drawing.Point(404, 265);
            textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            textBox3.MaxLength = 2;
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(25, 15);
            textBox3.TabIndex = 28;
            textBox3.Text = "1";
            textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox3.Click += SelectAllInTextBox;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            textBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            textBox2.Location = new System.Drawing.Point(438, 234);
            textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            textBox2.MaxLength = 2;
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(27, 15);
            textBox2.TabIndex = 27;
            textBox2.Text = "1";
            textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox2.Click += SelectAllInTextBox;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            textBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            textBox1.Location = new System.Drawing.Point(404, 234);
            textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            textBox1.MaxLength = 2;
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(25, 15);
            textBox1.TabIndex = 26;
            textBox1.Text = "1";
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            textBox1.Click += SelectAllInTextBox;
            textBox1.TextChanged += textBox1_Click_1;
            // 
            // button4
            // 
            button4.BackColor = System.Drawing.Color.Transparent;
            button4.Enabled = false;
            button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            button4.ForeColor = System.Drawing.Color.Black;
            button4.Location = new System.Drawing.Point(386, 259);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(99, 26);
            button4.TabIndex = 25;
            button4.Text = "(  X  ,   Y  )";
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = System.Drawing.Color.Transparent;
            button3.Enabled = false;
            button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            button3.ForeColor = System.Drawing.Color.Black;
            button3.Location = new System.Drawing.Point(386, 228);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(99, 26);
            button3.TabIndex = 24;
            button3.Text = "(  X  ,   Y  )";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.Transparent;
            button2.Enabled = false;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Font = new System.Drawing.Font("Verdana", 9F);
            button2.ForeColor = System.Drawing.Color.Black;
            button2.Location = new System.Drawing.Point(269, 259);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(118, 26);
            button2.TabIndex = 23;
            button2.Text = "Maze Exit:";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.Transparent;
            button1.Enabled = false;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Verdana", 9F);
            button1.ForeColor = System.Drawing.Color.Black;
            button1.Location = new System.Drawing.Point(269, 228);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(118, 26);
            button1.TabIndex = 22;
            button1.Text = "Maze Entrance:";
            button1.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(349, 302);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(118, 19);
            checkBox1.TabIndex = 21;
            checkBox1.Text = "Proportional cells";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // XValuesTrackBar
            // 
            XValuesTrackBar.Location = new System.Drawing.Point(364, 78);
            XValuesTrackBar.Maximum = 30;
            XValuesTrackBar.Minimum = 1;
            XValuesTrackBar.Name = "XValuesTrackBar";
            XValuesTrackBar.Size = new System.Drawing.Size(256, 45);
            XValuesTrackBar.TabIndex = 4;
            XValuesTrackBar.TabStop = false;
            XValuesTrackBar.Value = 1;
            XValuesTrackBar.Scroll += trackBar1_Scroll;
            // 
            // GeneratingScreenPanel
            // 
            GeneratingScreenPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            GeneratingScreenPanel.Controls.Add(MazeBoundingBox1);
            GeneratingScreenPanel.Location = new System.Drawing.Point(10, 7);
            GeneratingScreenPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            GeneratingScreenPanel.Name = "GeneratingScreenPanel";
            GeneratingScreenPanel.Size = new System.Drawing.Size(779, 432);
            GeneratingScreenPanel.TabIndex = 23;
            // 
            // MazeBoundingBox1
            // 
            MazeBoundingBox1.BackColor = System.Drawing.Color.Transparent;
            MazeBoundingBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            MazeBoundingBox1.Font = new System.Drawing.Font("Verdana", 10F);
            MazeBoundingBox1.Location = new System.Drawing.Point(75, 41);
            MazeBoundingBox1.Name = "MazeBoundingBox1";
            MazeBoundingBox1.Size = new System.Drawing.Size(370, 370);
            MazeBoundingBox1.TabIndex = 10;
            MazeBoundingBox1.UseVisualStyleBackColor = false;
            MazeBoundingBox1.Visible = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(NewMazeScreen);
            tabControl1.Controls.Add(GeneratingScreen);
            tabControl1.Controls.Add(MainScreen);
            tabControl1.Location = new System.Drawing.Point(-4, -23);
            tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(808, 476);
            tabControl1.TabIndex = 22;
            // 
            // NewMazeScreen
            // 
            NewMazeScreen.BackColor = System.Drawing.Color.White;
            NewMazeScreen.Controls.Add(NewMazeScreenPanel);
            NewMazeScreen.Location = new System.Drawing.Point(4, 24);
            NewMazeScreen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            NewMazeScreen.Name = "NewMazeScreen";
            NewMazeScreen.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            NewMazeScreen.Size = new System.Drawing.Size(800, 448);
            NewMazeScreen.TabIndex = 0;
            NewMazeScreen.Text = "tabPage1";
            // 
            // GeneratingScreen
            // 
            GeneratingScreen.BackColor = System.Drawing.Color.WhiteSmoke;
            GeneratingScreen.Controls.Add(GeneratingScreenPanel);
            GeneratingScreen.Location = new System.Drawing.Point(4, 24);
            GeneratingScreen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            GeneratingScreen.Name = "GeneratingScreen";
            GeneratingScreen.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            GeneratingScreen.Size = new System.Drawing.Size(800, 448);
            GeneratingScreen.TabIndex = 1;
            GeneratingScreen.Text = "tabPage2";
            // 
            // MainScreen
            // 
            MainScreen.BackColor = System.Drawing.Color.WhiteSmoke;
            MainScreen.Controls.Add(MainScreenPanel);
            MainScreen.Location = new System.Drawing.Point(4, 24);
            MainScreen.Name = "MainScreen";
            MainScreen.Padding = new System.Windows.Forms.Padding(3);
            MainScreen.Size = new System.Drawing.Size(800, 448);
            MainScreen.TabIndex = 2;
            MainScreen.Text = "tabPage3";
            // 
            // MainScreenPanel
            // 
            MainScreenPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            MainScreenPanel.Controls.Add(MazeDataText);
            MainScreenPanel.Controls.Add(MazeBoundingBox2);
            MainScreenPanel.Controls.Add(MazeImagespacePanel);
            MainScreenPanel.Controls.Add(SolveScreenPanel);
            MainScreenPanel.Controls.Add(MainScreenButtonsContainer);
            MainScreenPanel.Controls.Add(ExportScreenPanel);
            MainScreenPanel.Location = new System.Drawing.Point(11, 8);
            MainScreenPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MainScreenPanel.Name = "MainScreenPanel";
            MainScreenPanel.Size = new System.Drawing.Size(779, 432);
            MainScreenPanel.TabIndex = 24;
            // 
            // MazeDataText
            // 
            MazeDataText.BackColor = System.Drawing.Color.WhiteSmoke;
            MazeDataText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            MazeDataText.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            MazeDataText.Location = new System.Drawing.Point(532, 15);
            MazeDataText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MazeDataText.Name = "MazeDataText";
            MazeDataText.Size = new System.Drawing.Size(200, 19);
            MazeDataText.TabIndex = 26;
            MazeDataText.Text = "Maze Size: 30x30 (900 nodes)";
            MazeDataText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MazeBoundingBox2
            // 
            MazeBoundingBox2.BackColor = System.Drawing.Color.Transparent;
            MazeBoundingBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            MazeBoundingBox2.Font = new System.Drawing.Font("Verdana", 10F);
            MazeBoundingBox2.Location = new System.Drawing.Point(75, 41);
            MazeBoundingBox2.Name = "MazeBoundingBox2";
            MazeBoundingBox2.Size = new System.Drawing.Size(370, 370);
            MazeBoundingBox2.TabIndex = 10;
            MazeBoundingBox2.UseVisualStyleBackColor = false;
            MazeBoundingBox2.Visible = false;
            // 
            // MazeImagespacePanel
            // 
            MazeImagespacePanel.BackColor = System.Drawing.Color.LimeGreen;
            MazeImagespacePanel.Location = new System.Drawing.Point(34, 2);
            MazeImagespacePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MazeImagespacePanel.Name = "MazeImagespacePanel";
            MazeImagespacePanel.Size = new System.Drawing.Size(451, 444);
            MazeImagespacePanel.TabIndex = 22;
            MazeImagespacePanel.Visible = false;
            // 
            // SolveScreenPanel
            // 
            SolveScreenPanel.BackColor = System.Drawing.SystemColors.Window;
            SolveScreenPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            SolveScreenPanel.Controls.Add(DijkstraSolveDataPanel);
            SolveScreenPanel.Controls.Add(LHRSolveDataPanel);
            SolveScreenPanel.Controls.Add(DisplaySolveDetails);
            SolveScreenPanel.Controls.Add(efficiencyRatingText);
            SolveScreenPanel.Controls.Add(pathLengthText);
            SolveScreenPanel.Controls.Add(numOfJunctionsText);
            SolveScreenPanel.Controls.Add(numOfBendsText);
            SolveScreenPanel.Controls.Add(button5);
            SolveScreenPanel.Controls.Add(BackButton1);
            SolveScreenPanel.Controls.Add(ExportFromSolveButton);
            SolveScreenPanel.Controls.Add(SolveTitle);
            SolveScreenPanel.Controls.Add(NewMazeButton2);
            SolveScreenPanel.Location = new System.Drawing.Point(490, 37);
            SolveScreenPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            SolveScreenPanel.Name = "SolveScreenPanel";
            SolveScreenPanel.Size = new System.Drawing.Size(286, 377);
            SolveScreenPanel.TabIndex = 26;
            SolveScreenPanel.Visible = false;
            // 
            // DijkstraSolveDataPanel
            // 
            DijkstraSolveDataPanel.Controls.Add(NodesCalculatedText2);
            DijkstraSolveDataPanel.Controls.Add(solveTimeText2);
            DijkstraSolveDataPanel.Controls.Add(DisplaySolvedDijkstra);
            DijkstraSolveDataPanel.Controls.Add(DijkstraInfoBox);
            DijkstraSolveDataPanel.Location = new System.Drawing.Point(34, 119);
            DijkstraSolveDataPanel.Margin = new System.Windows.Forms.Padding(2);
            DijkstraSolveDataPanel.Name = "DijkstraSolveDataPanel";
            DijkstraSolveDataPanel.Size = new System.Drawing.Size(222, 69);
            DijkstraSolveDataPanel.TabIndex = 38;
            // 
            // NodesCalculatedText2
            // 
            NodesCalculatedText2.BackColor = System.Drawing.Color.White;
            NodesCalculatedText2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            NodesCalculatedText2.Location = new System.Drawing.Point(14, 44);
            NodesCalculatedText2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            NodesCalculatedText2.Name = "NodesCalculatedText2";
            NodesCalculatedText2.Size = new System.Drawing.Size(186, 16);
            NodesCalculatedText2.TabIndex = 32;
            NodesCalculatedText2.Text = "Nodes Calculated:";
            // 
            // solveTimeText2
            // 
            solveTimeText2.BackColor = System.Drawing.Color.White;
            solveTimeText2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            solveTimeText2.Location = new System.Drawing.Point(14, 29);
            solveTimeText2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            solveTimeText2.Name = "solveTimeText2";
            solveTimeText2.Size = new System.Drawing.Size(186, 16);
            solveTimeText2.TabIndex = 27;
            solveTimeText2.Text = "Solve Time:";
            // 
            // DisplaySolvedDijkstra
            // 
            DisplaySolvedDijkstra.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            DisplaySolvedDijkstra.AutoSize = true;
            DisplaySolvedDijkstra.BackColor = System.Drawing.Color.Transparent;
            DisplaySolvedDijkstra.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            DisplaySolvedDijkstra.Checked = true;
            DisplaySolvedDijkstra.CheckState = System.Windows.Forms.CheckState.Checked;
            DisplaySolvedDijkstra.Location = new System.Drawing.Point(196, 11);
            DisplaySolvedDijkstra.Margin = new System.Windows.Forms.Padding(2);
            DisplaySolvedDijkstra.Name = "DisplaySolvedDijkstra";
            DisplaySolvedDijkstra.Size = new System.Drawing.Size(15, 14);
            DisplaySolvedDijkstra.TabIndex = 34;
            DisplaySolvedDijkstra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            DisplaySolvedDijkstra.UseVisualStyleBackColor = false;
            DisplaySolvedDijkstra.CheckedChanged += DisplaySolvedDijkstra_CheckedChanged;
            // 
            // DijkstraInfoBox
            // 
            DijkstraInfoBox.BackColor = System.Drawing.Color.Transparent;
            DijkstraInfoBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            DijkstraInfoBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            DijkstraInfoBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            DijkstraInfoBox.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            DijkstraInfoBox.ForeColor = System.Drawing.Color.Blue;
            DijkstraInfoBox.Location = new System.Drawing.Point(6, 6);
            DijkstraInfoBox.Name = "DijkstraInfoBox";
            DijkstraInfoBox.Size = new System.Drawing.Size(208, 58);
            DijkstraInfoBox.TabIndex = 26;
            DijkstraInfoBox.Text = "Solve Data - Dijkstra:";
            DijkstraInfoBox.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            DijkstraInfoBox.UseVisualStyleBackColor = false;
            // 
            // LHRSolveDataPanel
            // 
            LHRSolveDataPanel.Controls.Add(NodesCalculatedText);
            LHRSolveDataPanel.Controls.Add(DisplaySolvedLHR);
            LHRSolveDataPanel.Controls.Add(solveTimeText);
            LHRSolveDataPanel.Controls.Add(LeftWallInfoBox);
            LHRSolveDataPanel.Location = new System.Drawing.Point(34, 56);
            LHRSolveDataPanel.Margin = new System.Windows.Forms.Padding(2);
            LHRSolveDataPanel.Name = "LHRSolveDataPanel";
            LHRSolveDataPanel.Size = new System.Drawing.Size(222, 70);
            LHRSolveDataPanel.TabIndex = 37;
            // 
            // NodesCalculatedText
            // 
            NodesCalculatedText.BackColor = System.Drawing.Color.White;
            NodesCalculatedText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            NodesCalculatedText.Location = new System.Drawing.Point(14, 42);
            NodesCalculatedText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            NodesCalculatedText.Name = "NodesCalculatedText";
            NodesCalculatedText.Size = new System.Drawing.Size(186, 16);
            NodesCalculatedText.TabIndex = 25;
            NodesCalculatedText.Tag = "";
            NodesCalculatedText.Text = "Nodes Calculated:";
            // 
            // DisplaySolvedLHR
            // 
            DisplaySolvedLHR.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            DisplaySolvedLHR.AutoSize = true;
            DisplaySolvedLHR.BackColor = System.Drawing.Color.Transparent;
            DisplaySolvedLHR.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            DisplaySolvedLHR.Location = new System.Drawing.Point(196, 10);
            DisplaySolvedLHR.Margin = new System.Windows.Forms.Padding(2);
            DisplaySolvedLHR.Name = "DisplaySolvedLHR";
            DisplaySolvedLHR.Size = new System.Drawing.Size(15, 14);
            DisplaySolvedLHR.TabIndex = 33;
            DisplaySolvedLHR.Tag = "";
            DisplaySolvedLHR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            DisplaySolvedLHR.UseVisualStyleBackColor = false;
            DisplaySolvedLHR.CheckedChanged += DisplaySolvedLHR_CheckedChanged;
            // 
            // solveTimeText
            // 
            solveTimeText.BackColor = System.Drawing.Color.White;
            solveTimeText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            solveTimeText.Location = new System.Drawing.Point(14, 27);
            solveTimeText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            solveTimeText.Name = "solveTimeText";
            solveTimeText.Size = new System.Drawing.Size(186, 16);
            solveTimeText.TabIndex = 20;
            solveTimeText.Tag = "";
            solveTimeText.Text = "Solve Time:";
            // 
            // LeftWallInfoBox
            // 
            LeftWallInfoBox.BackColor = System.Drawing.Color.White;
            LeftWallInfoBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            LeftWallInfoBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            LeftWallInfoBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            LeftWallInfoBox.Font = new System.Drawing.Font("Verdana", 8.4F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            LeftWallInfoBox.ForeColor = System.Drawing.Color.Red;
            LeftWallInfoBox.Location = new System.Drawing.Point(6, 5);
            LeftWallInfoBox.Name = "LeftWallInfoBox";
            LeftWallInfoBox.Size = new System.Drawing.Size(208, 58);
            LeftWallInfoBox.TabIndex = 16;
            LeftWallInfoBox.Tag = "";
            LeftWallInfoBox.Text = "Solve Data - Left Hand Rule:";
            LeftWallInfoBox.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            LeftWallInfoBox.UseVisualStyleBackColor = false;
            // 
            // DisplaySolveDetails
            // 
            DisplaySolveDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            DisplaySolveDetails.AutoSize = true;
            DisplaySolveDetails.BackColor = System.Drawing.Color.Transparent;
            DisplaySolveDetails.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            DisplaySolveDetails.Location = new System.Drawing.Point(231, 195);
            DisplaySolveDetails.Margin = new System.Windows.Forms.Padding(2);
            DisplaySolveDetails.Name = "DisplaySolveDetails";
            DisplaySolveDetails.Size = new System.Drawing.Size(15, 14);
            DisplaySolveDetails.TabIndex = 36;
            DisplaySolveDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            DisplaySolveDetails.UseVisualStyleBackColor = false;
            DisplaySolveDetails.CheckedChanged += DisplaySolveDetails_CheckedChanged;
            // 
            // efficiencyRatingText
            // 
            efficiencyRatingText.BackColor = System.Drawing.Color.White;
            efficiencyRatingText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            efficiencyRatingText.Location = new System.Drawing.Point(49, 262);
            efficiencyRatingText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            efficiencyRatingText.Name = "efficiencyRatingText";
            efficiencyRatingText.Size = new System.Drawing.Size(186, 16);
            efficiencyRatingText.TabIndex = 23;
            efficiencyRatingText.Text = "Efficiency:";
            // 
            // pathLengthText
            // 
            pathLengthText.BackColor = System.Drawing.Color.White;
            pathLengthText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pathLengthText.Location = new System.Drawing.Point(49, 214);
            pathLengthText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            pathLengthText.Name = "pathLengthText";
            pathLengthText.Size = new System.Drawing.Size(186, 16);
            pathLengthText.TabIndex = 21;
            pathLengthText.Text = "Path Length:";
            // 
            // numOfJunctionsText
            // 
            numOfJunctionsText.BackColor = System.Drawing.Color.White;
            numOfJunctionsText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            numOfJunctionsText.Location = new System.Drawing.Point(49, 230);
            numOfJunctionsText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            numOfJunctionsText.Name = "numOfJunctionsText";
            numOfJunctionsText.Size = new System.Drawing.Size(186, 16);
            numOfJunctionsText.TabIndex = 22;
            numOfJunctionsText.Text = "No. of Junctions:";
            // 
            // numOfBendsText
            // 
            numOfBendsText.BackColor = System.Drawing.Color.White;
            numOfBendsText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            numOfBendsText.Location = new System.Drawing.Point(49, 246);
            numOfBendsText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            numOfBendsText.Name = "numOfBendsText";
            numOfBendsText.Size = new System.Drawing.Size(186, 16);
            numOfBendsText.TabIndex = 24;
            numOfBendsText.Text = "No. of Bends:";
            // 
            // button5
            // 
            button5.BackColor = System.Drawing.Color.Transparent;
            button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button5.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            button5.ForeColor = System.Drawing.Color.Black;
            button5.Location = new System.Drawing.Point(41, 190);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(208, 93);
            button5.TabIndex = 35;
            button5.Text = "Maze Solve Data:";
            button5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            button5.UseVisualStyleBackColor = false;
            // 
            // BackButton1
            // 
            BackButton1.BackColor = System.Drawing.Color.WhiteSmoke;
            BackButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BackButton1.Font = new System.Drawing.Font("Verdana", 12F);
            BackButton1.Location = new System.Drawing.Point(41, 336);
            BackButton1.Name = "BackButton1";
            BackButton1.Size = new System.Drawing.Size(109, 34);
            BackButton1.TabIndex = 19;
            BackButton1.Text = "<< Back";
            BackButton1.UseVisualStyleBackColor = false;
            BackButton1.Click += button11_Click;
            // 
            // ExportFromSolveButton
            // 
            ExportFromSolveButton.BackColor = System.Drawing.Color.WhiteSmoke;
            ExportFromSolveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ExportFromSolveButton.Font = new System.Drawing.Font("Verdana", 12F);
            ExportFromSolveButton.Location = new System.Drawing.Point(156, 336);
            ExportFromSolveButton.Name = "ExportFromSolveButton";
            ExportFromSolveButton.Size = new System.Drawing.Size(93, 34);
            ExportFromSolveButton.TabIndex = 18;
            ExportFromSolveButton.Text = "Export";
            ExportFromSolveButton.UseVisualStyleBackColor = false;
            ExportFromSolveButton.Click += button10_Click;
            // 
            // SolveTitle
            // 
            SolveTitle.BackColor = System.Drawing.Color.White;
            SolveTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            SolveTitle.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            SolveTitle.Location = new System.Drawing.Point(82, 11);
            SolveTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            SolveTitle.Name = "SolveTitle";
            SolveTitle.Size = new System.Drawing.Size(133, 41);
            SolveTitle.TabIndex = 15;
            SolveTitle.Text = "SOLVE";
            // 
            // NewMazeButton2
            // 
            NewMazeButton2.BackColor = System.Drawing.Color.WhiteSmoke;
            NewMazeButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            NewMazeButton2.Font = new System.Drawing.Font("Verdana", 12F);
            NewMazeButton2.Location = new System.Drawing.Point(41, 296);
            NewMazeButton2.Name = "NewMazeButton2";
            NewMazeButton2.Size = new System.Drawing.Size(208, 34);
            NewMazeButton2.TabIndex = 12;
            NewMazeButton2.Text = "New Maze>>>";
            NewMazeButton2.UseVisualStyleBackColor = false;
            NewMazeButton2.Click += button9_Click;
            // 
            // MainScreenButtonsContainer
            // 
            MainScreenButtonsContainer.BackColor = System.Drawing.Color.White;
            MainScreenButtonsContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            MainScreenButtonsContainer.Controls.Add(SolveBoth);
            MainScreenButtonsContainer.Controls.Add(SolveDijkstra);
            MainScreenButtonsContainer.Controls.Add(SolveLHR);
            MainScreenButtonsContainer.Controls.Add(NewMazeButton1);
            MainScreenButtonsContainer.Controls.Add(ExportButton);
            MainScreenButtonsContainer.Controls.Add(SolveButton);
            MainScreenButtonsContainer.Location = new System.Drawing.Point(490, 37);
            MainScreenButtonsContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            MainScreenButtonsContainer.Name = "MainScreenButtonsContainer";
            MainScreenButtonsContainer.Size = new System.Drawing.Size(286, 377);
            MainScreenButtonsContainer.TabIndex = 26;
            // 
            // SolveBoth
            // 
            SolveBoth.AutoSize = true;
            SolveBoth.Checked = true;
            SolveBoth.CheckState = System.Windows.Forms.CheckState.Checked;
            SolveBoth.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold);
            SolveBoth.ForeColor = System.Drawing.Color.Purple;
            SolveBoth.Location = new System.Drawing.Point(194, 89);
            SolveBoth.Margin = new System.Windows.Forms.Padding(2);
            SolveBoth.Name = "SolveBoth";
            SolveBoth.Size = new System.Drawing.Size(42, 15);
            SolveBoth.TabIndex = 17;
            SolveBoth.Text = "Both";
            SolveBoth.UseVisualStyleBackColor = true;
            SolveBoth.CheckedChanged += SolveBoth_CheckedChanged;
            // 
            // SolveDijkstra
            // 
            SolveDijkstra.AutoSize = true;
            SolveDijkstra.Checked = true;
            SolveDijkstra.CheckState = System.Windows.Forms.CheckState.Checked;
            SolveDijkstra.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold);
            SolveDijkstra.ForeColor = System.Drawing.Color.Blue;
            SolveDijkstra.Location = new System.Drawing.Point(140, 89);
            SolveDijkstra.Margin = new System.Windows.Forms.Padding(2);
            SolveDijkstra.Name = "SolveDijkstra";
            SolveDijkstra.Size = new System.Drawing.Size(52, 15);
            SolveDijkstra.TabIndex = 16;
            SolveDijkstra.Text = "Dijkstra";
            SolveDijkstra.UseVisualStyleBackColor = true;
            SolveDijkstra.CheckedChanged += SolveDijkstra_CheckedChanged;
            // 
            // SolveLHR
            // 
            SolveLHR.AutoSize = true;
            SolveLHR.Checked = true;
            SolveLHR.CheckState = System.Windows.Forms.CheckState.Checked;
            SolveLHR.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Bold);
            SolveLHR.ForeColor = System.Drawing.Color.Red;
            SolveLHR.Location = new System.Drawing.Point(60, 89);
            SolveLHR.Margin = new System.Windows.Forms.Padding(2);
            SolveLHR.Name = "SolveLHR";
            SolveLHR.Size = new System.Drawing.Size(78, 15);
            SolveLHR.TabIndex = 15;
            SolveLHR.Text = "Left Hand Rule";
            SolveLHR.UseVisualStyleBackColor = true;
            SolveLHR.CheckedChanged += SolveLHR_CheckedChanged;
            // 
            // NewMazeButton1
            // 
            NewMazeButton1.BackColor = System.Drawing.Color.WhiteSmoke;
            NewMazeButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            NewMazeButton1.Font = new System.Drawing.Font("Verdana", 12F);
            NewMazeButton1.Location = new System.Drawing.Point(60, 325);
            NewMazeButton1.Name = "NewMazeButton1";
            NewMazeButton1.Size = new System.Drawing.Size(174, 34);
            NewMazeButton1.TabIndex = 12;
            NewMazeButton1.Text = "New Maze>>>";
            NewMazeButton1.UseVisualStyleBackColor = false;
            NewMazeButton1.Click += button5_Click;
            // 
            // ExportButton
            // 
            ExportButton.BackColor = System.Drawing.Color.WhiteSmoke;
            ExportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ExportButton.Font = new System.Drawing.Font("Verdana", 25F);
            ExportButton.Location = new System.Drawing.Point(60, 194);
            ExportButton.Name = "ExportButton";
            ExportButton.Size = new System.Drawing.Size(174, 54);
            ExportButton.TabIndex = 13;
            ExportButton.Text = "Export";
            ExportButton.UseVisualStyleBackColor = false;
            ExportButton.Click += button7_Click;
            // 
            // SolveButton
            // 
            SolveButton.BackColor = System.Drawing.Color.WhiteSmoke;
            SolveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SolveButton.Font = new System.Drawing.Font("Verdana", 25F);
            SolveButton.Location = new System.Drawing.Point(60, 104);
            SolveButton.Name = "SolveButton";
            SolveButton.Size = new System.Drawing.Size(174, 54);
            SolveButton.TabIndex = 14;
            SolveButton.Text = "Solve";
            SolveButton.UseVisualStyleBackColor = false;
            SolveButton.Click += button8_Click;
            // 
            // ExportScreenPanel
            // 
            ExportScreenPanel.BackColor = System.Drawing.SystemColors.Window;
            ExportScreenPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ExportScreenPanel.Controls.Add(PrintButton);
            ExportScreenPanel.Controls.Add(SaveButton);
            ExportScreenPanel.Controls.Add(BackButton2);
            ExportScreenPanel.Controls.Add(SolveFromExportButton);
            ExportScreenPanel.Controls.Add(ExportTitle);
            ExportScreenPanel.Controls.Add(NewMazeButton3);
            ExportScreenPanel.Location = new System.Drawing.Point(490, 37);
            ExportScreenPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ExportScreenPanel.Name = "ExportScreenPanel";
            ExportScreenPanel.Size = new System.Drawing.Size(286, 377);
            ExportScreenPanel.TabIndex = 27;
            ExportScreenPanel.Visible = false;
            // 
            // PrintButton
            // 
            PrintButton.BackColor = System.Drawing.Color.WhiteSmoke;
            PrintButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            PrintButton.Font = new System.Drawing.Font("Verdana", 10F);
            PrintButton.Location = new System.Drawing.Point(41, 194);
            PrintButton.Name = "PrintButton";
            PrintButton.Size = new System.Drawing.Size(208, 41);
            PrintButton.TabIndex = 21;
            PrintButton.Text = "PRINT";
            PrintButton.UseVisualStyleBackColor = false;
            PrintButton.Click += PrintButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = System.Drawing.Color.WhiteSmoke;
            SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SaveButton.Font = new System.Drawing.Font("Verdana", 10F);
            SaveButton.Location = new System.Drawing.Point(41, 147);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new System.Drawing.Size(208, 41);
            SaveButton.TabIndex = 20;
            SaveButton.Text = "SAVE";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Click;
            // 
            // BackButton2
            // 
            BackButton2.BackColor = System.Drawing.Color.WhiteSmoke;
            BackButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            BackButton2.Font = new System.Drawing.Font("Verdana", 12F);
            BackButton2.Location = new System.Drawing.Point(41, 336);
            BackButton2.Name = "BackButton2";
            BackButton2.Size = new System.Drawing.Size(109, 34);
            BackButton2.TabIndex = 19;
            BackButton2.Text = "<< Back";
            BackButton2.UseVisualStyleBackColor = false;
            BackButton2.Click += button15_Click;
            // 
            // SolveFromExportButton
            // 
            SolveFromExportButton.BackColor = System.Drawing.Color.WhiteSmoke;
            SolveFromExportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SolveFromExportButton.Font = new System.Drawing.Font("Verdana", 12F);
            SolveFromExportButton.Location = new System.Drawing.Point(156, 336);
            SolveFromExportButton.Name = "SolveFromExportButton";
            SolveFromExportButton.Size = new System.Drawing.Size(94, 34);
            SolveFromExportButton.TabIndex = 18;
            SolveFromExportButton.Text = "Solve";
            SolveFromExportButton.UseVisualStyleBackColor = false;
            SolveFromExportButton.Click += button16_Click;
            // 
            // ExportTitle
            // 
            ExportTitle.BackColor = System.Drawing.SystemColors.Window;
            ExportTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            ExportTitle.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            ExportTitle.Location = new System.Drawing.Point(68, 87);
            ExportTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ExportTitle.Name = "ExportTitle";
            ExportTitle.Size = new System.Drawing.Size(164, 41);
            ExportTitle.TabIndex = 15;
            ExportTitle.Text = "EXPORT";
            // 
            // NewMazeButton3
            // 
            NewMazeButton3.BackColor = System.Drawing.Color.WhiteSmoke;
            NewMazeButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            NewMazeButton3.Font = new System.Drawing.Font("Verdana", 12F);
            NewMazeButton3.Location = new System.Drawing.Point(41, 296);
            NewMazeButton3.Name = "NewMazeButton3";
            NewMazeButton3.Size = new System.Drawing.Size(208, 34);
            NewMazeButton3.TabIndex = 12;
            NewMazeButton3.Text = "New Maze>>>";
            NewMazeButton3.UseVisualStyleBackColor = false;
            NewMazeButton3.Click += button19_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.FileName = "Maze";
            saveFileDialog1.Title = "Save Location";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(800, 449);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Maze Generator";
            ((System.ComponentModel.ISupportInitialize)YValuesTrackBar).EndInit();
            NewMazeScreenPanel.ResumeLayout(false);
            NewMazeScreenPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)XValuesTrackBar).EndInit();
            GeneratingScreenPanel.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            NewMazeScreen.ResumeLayout(false);
            GeneratingScreen.ResumeLayout(false);
            MainScreen.ResumeLayout(false);
            MainScreenPanel.ResumeLayout(false);
            MainScreenPanel.PerformLayout();
            SolveScreenPanel.ResumeLayout(false);
            SolveScreenPanel.PerformLayout();
            DijkstraSolveDataPanel.ResumeLayout(false);
            DijkstraSolveDataPanel.PerformLayout();
            LHRSolveDataPanel.ResumeLayout(false);
            LHRSolveDataPanel.PerformLayout();
            MainScreenButtonsContainer.ResumeLayout(false);
            MainScreenButtonsContainer.PerformLayout();
            ExportScreenPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.CheckBox IsSquareCheckBox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.TrackBar YValuesTrackBar;
        private System.Windows.Forms.Button TextBoxOutline2;
        private System.Windows.Forms.Button TextBoxOutline1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel NewMazeScreenPanel;
        private System.Windows.Forms.Panel GeneratingScreenPanel;
        private System.Windows.Forms.Button MazeBoundingBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage NewMazeScreen;
        private System.Windows.Forms.TabPage GeneratingScreen;
        private System.Windows.Forms.TrackBar XValuesTrackBar;
        private System.Windows.Forms.TabPage MainScreen;
        private System.Windows.Forms.Panel MainScreenPanel;
        private System.Windows.Forms.Button NewMazeButton1;
        private System.Windows.Forms.Button MazeBoundingBox2;
        private System.Windows.Forms.Button SolveButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Panel MainScreenButtonsContainer;
        private System.Windows.Forms.Panel SolveScreenPanel;
        private System.Windows.Forms.Button BackButton1;
        private System.Windows.Forms.Button ExportFromSolveButton;
        private System.Windows.Forms.Button LeftWallInfoBox;
        private System.Windows.Forms.RichTextBox SolveTitle;
        private System.Windows.Forms.Button NewMazeButton2;
        private System.Windows.Forms.Panel ExportScreenPanel;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button BackButton2;
        private System.Windows.Forms.Button SolveFromExportButton;
        private System.Windows.Forms.RichTextBox ExportTitle;
        private System.Windows.Forms.Button NewMazeButton3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel MazeImagespacePanel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox pathLengthText;
        private System.Windows.Forms.TextBox solveTimeText;
        private System.Windows.Forms.TextBox efficiencyRatingText;
        private System.Windows.Forms.TextBox numOfJunctionsText;
        private System.Windows.Forms.TextBox numOfBendsText;
        private System.Windows.Forms.TextBox NodesCalculatedText;
        private System.Windows.Forms.TextBox MazeDataText;
        private System.Windows.Forms.TextBox NodesCalculatedText2;
        private System.Windows.Forms.TextBox solveTimeText2;
        private System.Windows.Forms.Button DijkstraInfoBox;
        private System.Windows.Forms.CheckBox SolveBoth;
        private System.Windows.Forms.CheckBox SolveDijkstra;
        private System.Windows.Forms.CheckBox SolveLHR;
        private System.Windows.Forms.CheckBox DisplaySolvedDijkstra;
        private System.Windows.Forms.CheckBox DisplaySolvedLHR;
        private System.Windows.Forms.CheckBox DisplaySolveDetails;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel LHRSolveDataPanel;
        private System.Windows.Forms.Panel DijkstraSolveDataPanel;
    }
}

