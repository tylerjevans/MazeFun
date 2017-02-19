using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeFun.Forms
{
    public partial class Interactive : Form
    {
        private mazeTile[,] tileMap;
        private MazeStyle Drawer;
        private int x, y;
        private Button[,] LiveTiles;
        public Interactive()
        {
            InitializeComponent();
            Drawer = new MazeStyle();
            MazePower TestPower = new MazePower();
            tileMap = TestPower.makeMazeTiles(Convert.ToInt32(5), Convert.ToInt32(5));
            x = tileMap.GetLength(0);
            y = tileMap.GetLength(1);
            int delta = Drawer.Offset();
            LiveTiles = new Button[x,y];

            for (int l = 0; l < x; l++)
            {
                for (int m = 0; m < y; m++)
                {
                    int width = l;
                    int height = m;
                    LiveTiles[width,height] = new Button();
                    LiveTiles[width, height].SetBounds(l * delta, m * delta, delta,delta);
                    LiveTiles[width, height].BackgroundImage = Drawer.blank;
                    LiveTiles[width, height].Click += (sender, args) =>
                    {
                        ActivateTile(width, height);
                    };
                    LiveTiles[width, height].Enabled = false;
                    this.Controls.Add(LiveTiles[width, height]);
                }
            }
            ActivateTile(0,0);
        }

        void ActivateTile(int column, int row)
        {
            LiveTiles[column, row].BackgroundImage = Drawer.TileToImage(tileMap[column, row]);
            LiveTiles[column, row].Enabled = false;
            if (tileMap[column, row].up && (!LiveTiles[column, row - 1].Enabled))
            {
                LiveTiles[column, row - 1].Enabled = true;
            }
            if (tileMap[column, row].down && (!LiveTiles[column, row + 1].Enabled))
            {
                LiveTiles[column, row + 1].Enabled = true;
            }
            if (tileMap[column, row].left && (!LiveTiles[column - 1, row].Enabled))
            {
                LiveTiles[column - 1, row].Enabled = true;
            }
            if (tileMap[column, row].right && (!LiveTiles[column + 1, row].Enabled))
            {
                LiveTiles[column + 1, row].Enabled = true;
            }
        }
    }
}
