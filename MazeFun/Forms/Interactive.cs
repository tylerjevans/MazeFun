﻿using System;
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
                    LiveTiles[width, height].Click += (sender, args) =>
                    {
                        LiveTiles[width,height].BackgroundImage = Drawer.TileToImage(tileMap[width, height]);
                    };
                    this.Controls.Add(LiveTiles[width, height]);
                }
            }
        }
    }
}
