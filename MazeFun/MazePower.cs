using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFun
{
    struct Spot
    {
        public int width, height;

        public Spot(int x, int y)
        {
            width = x;
            height = y;
        }
    }
    struct mazeTile
    {
        public bool up, down, left, right, maze;

        public mazeTile(int empty)
        {
            up = down = left = right = maze = false;
        }
    }
    class Maze
    {
        private byte[,] bytesMap;
        public Maze(int width, int height)
        {
            bytesMap = new byte[width,height];
        }
    }

    class MazePower
    {
        mazeTile[,] emptyMaze(int width, int height)
        {
            mazeTile[,] result = new mazeTile[width, height];
            for (int q = 0; q < width; q++)
            {
                for (int i = 0; i < height; i++)
                {
                    result[width,height] = new mazeTile(0);
                }
            }
            return result;
        }
        mazeTile[,] makeMazeTiles(int width, int height)
        {
            mazeTile[,] result = emptyMaze(width, height);
            result[0, 0].maze = result[0,0].down = result[0, 0].right = true;
            List<Spot> activeSpots = new List<Spot>();
            activeSpots.Add(new Spot(1,0));
            activeSpots.Add(new Spot(0, 1));

            return result;
        } 
    }
}
