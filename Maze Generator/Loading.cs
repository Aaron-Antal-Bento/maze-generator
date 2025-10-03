using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Maze_Generator
{
    public partial class Loading : Form
    {
        private Stopwatch timer = Stopwatch.StartNew();

        public Loading()
        {
            InitializeComponent();
        }

        public void SetProgressBar(double value)
        {
            //set progress bar fullness
            progressBar1.Value = (int)value;
        }

        private void updateValues_Tick(object sender, EventArgs e)
        {
            //displays time elspased excluding hours and only including the first two numbers of milliseconds
            textBox2.Text = "Time Elapsed: " + timer.Elapsed.ToString().Substring(3, 8);
            UpdateMemoryUsage();
        }
        public void UpdateMemoryUsage()
        {
            //get current memory usage
            long memoryInBytes = Process.GetCurrentProcess().PrivateMemorySize64;
            //convert to gigabytes
            double memoryInGB = (double)memoryInBytes / 1000000000;
            //get number of decimal places there should be to make 3 significant figs
            int decimalPlaces = 0;
            if(memoryInGB < 10) { decimalPlaces = 2; }
            else if (memoryInGB < 100) { decimalPlaces = 1; }
            else if (memoryInGB < 1000) { decimalPlaces = 0; }

            //display to correct significant figures
            textBox3.Text = "Memory Used: " + Math.Round(memoryInGB, decimalPlaces, MidpointRounding.ToEven);
        }
        public void ResetTimer()
        {
            //records time since node creation started
            timer = Stopwatch.StartNew();
        }
        public void SetEstimatedTime(TimeSpan time)
        {
            //display time in either minutes seconds or milliseconds depending on the time remaining
            if (time < new TimeSpan(0, 0, 1))
            {
                textBox1.Text = "Time Remaining: About " + time.Milliseconds.ToString() + " millisecond" + ManagePlural(time.Milliseconds);
            }
            else if (time < new TimeSpan(0, 1, 0))
            {
                textBox1.Text = "Time Remaining: About " + time.Seconds.ToString() + " second" + ManagePlural(time.Seconds);
            }
            else if (time < new TimeSpan(1, 0, 0))
            {
                textBox1.Text = "Time Remaining: About " + time.Minutes.ToString() + " minute" + ManagePlural(time.Minutes);
            }
            else
            {
                textBox1.Text = "Estimating Time Remaining...";
            }
        }
        public void DisplayNodesComplete(int nodesComplete, int totalNodes)
        {
            textBox5.Text = "Nodes Created: " + nodesComplete + "/" + totalNodes;
        }
        private string ManagePlural(int input)
        {
            //adds an s to make strings plural
            if (input == 1)
            {
                return "";
            }
            return "s";
        }
    }
}
