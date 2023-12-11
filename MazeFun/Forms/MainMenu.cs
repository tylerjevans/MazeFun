using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using MazeFun.Forms;
using MazeFun.Processing;

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
            var interact = new Interactive(Convert.ToInt32(WidthValue.Value), Convert.ToInt32(HeightValue.Value));
            interact.ShowDialog();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter += "maze format | *.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Drawer = new MazeStyle();
                mazeTile[,] test = MazePower.makeMazeTiles(Convert.ToInt32(WidthValue.Value), Convert.ToInt32(HeightValue.Value));
                Bitmap Maze = Drawer.imagetoMaze(test);
                Maze.Save(dialog.OpenFile(), ImageFormat.Png);
                GenerateButton.Text = "finished";
            }
        }
    }
}
