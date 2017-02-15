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
    public partial class MainMenu : Form
    {
        private Bitmap end,
            end90,
            end180,
            end270,
            corner,
            corner90,
            corner180,
            corner270,
            _3way,
            _3way90,
            _3way180,
            _3way270,
            straight,
            straight90,
            cross,
            start,
            finish;

        public MainMenu()
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
                GenerateButton.Text = "finished";
            }
        }

        private void LoadTiles(string theme = "Simple")
        {
            end = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "end"));
            end90 = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "end"));
            end180 = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "end"));
            end270 = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "end"));
            corner = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "corner"));
            corner90 = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "corner"));
            corner180 = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "corner"));
            corner270 = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "corner"));
            _3way = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "3way"));
            _3way90 = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "3way"));
            _3way180 = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "3way"));
            _3way270 = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "3way"));
            straight = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "straight"));
            straight90 = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "straight"));
            cross = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "4way"));
            start = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "start"));
            finish = new Bitmap(Properties.Resources.ResourceManager.GetString(theme + "finish"));

            end90.RotateFlip(RotateFlipType.Rotate90FlipNone);
            corner90.RotateFlip(RotateFlipType.Rotate90FlipNone);
            _3way90.RotateFlip(RotateFlipType.Rotate90FlipNone);
            straight90.RotateFlip(RotateFlipType.Rotate90FlipNone);

            end180.RotateFlip(RotateFlipType.Rotate180FlipNone);
            corner180.RotateFlip(RotateFlipType.Rotate180FlipNone);
            _3way180.RotateFlip(RotateFlipType.Rotate180FlipNone);

            end270.RotateFlip(RotateFlipType.Rotate270FlipNone);
            corner270.RotateFlip(RotateFlipType.Rotate270FlipNone);
            _3way270.RotateFlip(RotateFlipType.Rotate270FlipNone);


        }
        public Bitmap TileToImage(mazeTile Tile)
        {
            if (Tile.left)
            {
                if (Tile.up)
                {
                    if (Tile.right)
                    {
                        if (Tile.down) return new Bitmap(Properties.Resources.Simple4way); // left, up, right, down
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
                            Bitmap tileresult = new Bitmap(Properties.Resources.Simplecorner);
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
                            return new Bitmap(Properties.Resources.Simplestraight); // left, right
                        }
                    }
                    if (Tile.down)
                    {
                        Bitmap tileresult = new Bitmap(Properties.Resources.Simplecorner);
                        tileresult.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        return tileresult; //left, down
                    }
                    else
                    {
                        Bitmap tileresult = new Bitmap(Properties.Resources.Simpleend);
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
                        Bitmap tileresult = new Bitmap(Properties.Resources.Simplestraight);
                        tileresult.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        return tileresult; // up, down
                    }
                } else {
                    if (Tile.right)
                    {
                        return new Bitmap(Properties.Resources.Simplecorner); //up,right
                    }
                    else
                    {
                        Bitmap tileresult = new Bitmap(Properties.Resources.Simpleend);
                        tileresult.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        return tileresult; // up
                    } }
            }
            if (Tile.down)
            {
                if (Tile.right)
                {
                    Bitmap tileresult = new Bitmap(Properties.Resources.Simplecorner);
                    tileresult.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return tileresult; //down,right
                }
                else {
                    Bitmap tileresult = new Bitmap(Properties.Resources.Simpleend);
                    tileresult.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    return tileresult; // down
                }
            }
            // if (Tile.right) {}
            return new Bitmap(Properties.Resources.Simpleend); // wrong default for testing
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
                    if (x == 0 & y == 0) mazeDisplay[0, 0] = new Bitmap(Properties.Resources.Simplestart);
                    else if (x == width - 1 & y == height - 1)
                    {
                        var temp = new Bitmap(Properties.Resources.Simplefinish);
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
