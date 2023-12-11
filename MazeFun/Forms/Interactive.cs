﻿using System.Drawing;
using System.Windows.Forms;
using MazeFun.Processing;

namespace MazeFun.Forms
{
    public partial class Interactive : Form
    {
        private mazeTile[,] tileMap;
        private MazeStyle Drawer;
        private Button[,] LiveTiles;
        public Interactive(int w, int h)
        {
            InitializeComponent();
            Drawer = new MazeStyle();
            tileMap = MazePower.makeMazeTiles(w, h);
            int delta = Drawer.Offset();
            LiveTiles = new Button[w,h];

            for (int l = 0; l < w; l++)
            {
                for (int m = 0; m < h; m++)
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
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.AutoScrollPosition;
        }
    }
}
