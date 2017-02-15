using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MazeFun.Forms;

namespace MazeFun
{
    public partial class MainMenu : Form
    {
        public MazeStyle Drawer;

        public MainMenu()
        {
            InitializeComponent();
            GenerateButton.Click += GenerateButton_Click;
            InteractiveModeButton.Click += InteractiveModeButton_Click;
        }

        private void InteractiveModeButton_Click(object sender, EventArgs e)
        {
            var interact = new Interactive();
            interact.ShowDialog();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter += "maze format | *.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Drawer = new MazeStyle();
                MazePower TestPower = new MazePower();
                var test = TestPower.makeMazeTiles(Convert.ToInt32(WidthValue.Value), Convert.ToInt32(HeightValue.Value));
                Bitmap Maze = Drawer.imagetoMaze(test);
                Maze.Save(dialog.OpenFile(), ImageFormat.Png);
                GenerateButton.Text = "finished";
            }
        }
    }
}
