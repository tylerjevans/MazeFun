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

namespace MazeFun
{
    public partial class Form1 : Form
    {
        public int x, y;
        public Form1()
        {
            InitializeComponent();
            GenerateButton.Click += GenerateButton_Click;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter += "maze format | *.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MazePower TestPower = new MazePower();
                var test = TestPower.makeMazeTiles(Convert.ToInt32(WidthValue.Value), Convert.ToInt32(HeightValue.Value));
                Bitmap Maze = imagetoMaze(test);
                Maze.Save(dialog.OpenFile(), ImageFormat.Png);
                //Maze.Save("MazeTest.png", ImageFormat.Png);
                GenerateButton.Text = "finished";
            }
        }
        public Bitmap TileToImage(mazeTile Tile, bool special = false)
        {
            if (Tile.left)
            {
                if (Tile.up)
                {
                    if (Tile.right)
                    {
                        if (Tile.down) return new Bitmap(Properties.Resources._4way); // left, up, right, down
                        else
                        {
                            Bitmap tileresult = new Bitmap(Properties.Resources._3way);
                            tileresult.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            return tileresult; //left, up, right
                        }
                    }
                    else
                    {
                        if (Tile.down)
                        {
                            Bitmap tileresult = new Bitmap(Properties.Resources._3way);
                            tileresult.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            return tileresult; // left, up, down
                        }
                        else
                        {
                            Bitmap tileresult = new Bitmap(Properties.Resources.corner);
                            tileresult.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            return tileresult; // left, up
                        }
                    }
                }
                else
                {
                    if (Tile.right)
                    {
                        if (Tile.down)
                        {
                            return new Bitmap(Properties.Resources._3way); // left, right, down
                        }
                        else
                        {
                            return new Bitmap(Properties.Resources.straight); // left, right
                        }
                    }
                    if (Tile.down)
                    {
                        Bitmap tileresult = new Bitmap(Properties.Resources.corner);
                        tileresult.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        return tileresult; //left, down
                    }
                    else
                    {
                        Bitmap tileresult = new Bitmap(Properties.Resources.end);
                        tileresult.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        return tileresult; // left
                    }
                }
            }
            if (Tile.up)
            {
                if (Tile.down)
                {
                    if (Tile.right)
                    {
                        Bitmap tileresult = new Bitmap(Properties.Resources._3way);
                        tileresult.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        return tileresult; // up, down, right
                    }
                    else
                    {
                        Bitmap tileresult = new Bitmap(Properties.Resources.straight);
                        tileresult.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        return tileresult; // up, down
                    }
                } else {
                    if (Tile.right)
                    {
                        return new Bitmap(Properties.Resources.corner); //up,right
                    }
                    else
                    {
                        Bitmap tileresult = new Bitmap(Properties.Resources.end);
                        tileresult.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        return tileresult; // up
                    } }
            }
            if (Tile.down)
            {
                if (Tile.right)
                {
                    Bitmap tileresult = new Bitmap(Properties.Resources.corner);
                    tileresult.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return tileresult; //down,right
                }
                else {
                    Bitmap tileresult = new Bitmap(Properties.Resources.end);
                    tileresult.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return tileresult; // down
                }
            }
            // if (Tile.right) {}
            return new Bitmap(Properties.Resources.end); // wrong default for testing
        }

        public Bitmap imagetoMaze(mazeTile[,] mazeImage)
        {
            int width = mazeImage.GetLength(0);
            int height = mazeImage.GetLength(1);
            Bitmap[,] mazeDisplay = new Bitmap[width,height]; // maze display needs to be converted to ref list with rotation counter, save memory
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 & y == 0) mazeDisplay[0, 0] = new Bitmap(Properties.Resources.start);
                    else if (x == width - 1 & y == height - 1)
                    {
                        var temp = new Bitmap(Properties.Resources.finish);
                        if (mazeImage[x, y].left) temp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        else temp.RotateFlip(RotateFlipType.Rotate270FlipX);
                        mazeDisplay[x, y] = temp;
                    }
                        
                    else
                        mazeDisplay[x, y] = TileToImage(mazeImage[x, y]);
                }
            }
            int offset = mazeDisplay[0, 0].Width; // assuming same with all tiles and square
            var result = new Bitmap(offset * width, offset * height);
            using (var canvas = Graphics.FromImage(result))
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        canvas.DrawImage(mazeDisplay[x,y], new Rectangle(x * offset, y * offset, offset, offset));
                    }
                }
            }
            return result;
        }
    }
}
