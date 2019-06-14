using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteen
{
    class Game
    {
        public int size;//размер
        public int[,] map;//карта
        public int spaceX, spaceY;//пустая ячейка
        static Random rand = new Random();


        public void game(int size)
        {
                if (size < 2) size = 2;
                if (size > 5) size = 5;
                this.size = size;
                map = new int[size, size];
        }

        public void Start()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    map[x, y] = CoordsToPosition(x, y) + 1;
                }
            }
            spaceX = size - 1;
            spaceY = size - 1;
            map[spaceX, spaceY] = 0;
        }

        public int GetNumber(int button)
        {
            int x, y;
            PositionToCoords(button, out x, out y);
            if (x < 0 || x >= size)
                return 0;
            if (y < 0 || y >= size)
                return 0;
            return map[x, y];
        }

        public int CoordsToPosition (int x, int y)
        {
            if (x < 0)
                x = 0;
            if (x > size - 1)
                x = size - 1;
            if (y < 0)
                y = 0;
            if (y > size - 1)
                y = size - 1;
            return y * size + x;
        }

        public void PositionToCoords (int button, out int x, out int y)
        {
            if (button < 0)
                button = 0;
            if (button > size * size - 1)
                button = size * size - 1;
            x = button % size;
            y = button / size;
        }

        public void Shift(int button)//перемещение кнопки
        {
            
            int x, y;
            PositionToCoords(button, out x, out y);
            if (Math.Abs(spaceX - x) + Math.Abs(spaceY - y) != 1)//условие перемещения кнопки
                return;
            map[spaceX, spaceY] = map[x, y];
            map[x, y] = 0;
            spaceX = x;
            spaceY = y;
        }

        public void Shuffle()//перемешать
        {
            Shift(rand.Next(0, size * size));
            int r = rand.Next(0, 4);
            int x = spaceX;
            int y = spaceY;
            switch (r)
            {
                case 0: x--; break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;
            }
            Shift(CoordsToPosition(x, y));
        }

        public bool isEndGame()
        {
            
            if (!(spaceX == size - 1 && spaceY == size - 1))
                return false;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (!(x == size - 1 && y == size - 1))
                        if (map[x, y] != CoordsToPosition(x, y) + 1)
                            return false;
            return true;
        }
    }
}
