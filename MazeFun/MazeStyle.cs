using System.Drawing;
using System.Windows.Forms.VisualStyles;
using MazeFun.Properties;

namespace MazeFun
{
    public class MazeStyle
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
            public Bitmap blank;

        private string theme;

        public MazeStyle(string theme = "Simple")
        {
            this.theme = theme;
            LoadTiles();
        }
        private void LoadTiles()
        {
            end = (Bitmap)Resources.ResourceManager.GetObject(theme + "end");
            end90 = (Bitmap)Resources.ResourceManager.GetObject(theme + "end");
            end180 = (Bitmap)Resources.ResourceManager.GetObject(theme + "end");
            end270 = (Bitmap)Resources.ResourceManager.GetObject(theme + "end");
            corner = (Bitmap)Resources.ResourceManager.GetObject(theme + "corner");
            corner90 = (Bitmap)Resources.ResourceManager.GetObject(theme + "corner");
            corner180 = (Bitmap)Resources.ResourceManager.GetObject(theme + "corner");
            corner270 = (Bitmap)Resources.ResourceManager.GetObject(theme + "corner");
            _3way = (Bitmap)Resources.ResourceManager.GetObject(theme + "3way");
            _3way90 = (Bitmap)Resources.ResourceManager.GetObject(theme + "3way");
            _3way180 = (Bitmap)Resources.ResourceManager.GetObject(theme + "3way");
            _3way270 = (Bitmap)Resources.ResourceManager.GetObject(theme + "3way");
            straight = (Bitmap)Resources.ResourceManager.GetObject(theme + "straight");
            straight90 = (Bitmap)Resources.ResourceManager.GetObject(theme + "straight");
            cross = (Bitmap)Resources.ResourceManager.GetObject(theme + "4way");
            start = (Bitmap)Resources.ResourceManager.GetObject(theme + "start");
            finish = (Bitmap)Resources.ResourceManager.GetObject(theme + "finish");

            blank = new Bitmap(Offset(),Offset());

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
                        if (Tile.down) return cross; // left, up, right, down
                        return _3way180; //left, up, right
                    }
                    if (Tile.down) return _3way90; // left, up, down
                    return corner270; // left, up
                }
                if (Tile.right)
                {
                    if (Tile.down) return _3way; // left, right, down
                    return straight; // left, right
                }
                if (Tile.down) return corner180; //left, down
                return end180; // left
            }
            if (Tile.up)
            {
                if (Tile.down)
                {
                    if (Tile.right) return _3way270; // up, down, right
                    return straight90; // up, down
                }
                if (Tile.right) return corner; //up,right
                return end270; // up
            }
            if (Tile.down)
            {
                if (Tile.right) return corner90; //down,right
                return end90; // down
            }
            if (Tile.right) { return end; } //right
            throw new System.Exception();
            //add check for start or finish
        }
        public int Offset()
        {
            return cross.Width;
        }
        public Bitmap imagetoMaze(mazeTile[,] mazeImage)
        {
            int width = mazeImage.GetLength(0);
            int height = mazeImage.GetLength(1);
            int offset = Offset(); // assuming same with all tiles and square
            var result = new Bitmap(offset * width, offset * height);
            using (var canvas = Graphics.FromImage(result))
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (x == 0 & y == 0) canvas.DrawImage(start, new Rectangle(x * offset, y * offset, offset, offset));
                        else if (x == width - 1 & y == height - 1)
                        {
                            if (mazeImage[x, y].left) finish.RotateFlip(RotateFlipType.RotateNoneFlipX);
                            else finish.RotateFlip(RotateFlipType.Rotate270FlipX);
                            canvas.DrawImage(finish, new Rectangle(x * offset, y * offset, offset, offset));
                        }
                        else canvas.DrawImage(TileToImage(mazeImage[x, y]), new Rectangle(x * offset, y * offset, offset, offset));
                    }
                }
            }
            return result;
        }
    }
}