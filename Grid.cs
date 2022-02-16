using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramaClasse
{
    class Grid
    {
        public int[,] grid;

        public void Print()
        {
            for (int i = 0; i < this.grid.GetLength(0); i++)
            {
                for (int j = 0; j < this.grid.GetLength(1); j++)
                {
                    if (this.grid[i, j] == -1)
                    {
                        Console.Write('-');
                    }
                    else
                    {
                        Console.Write(this.grid[i, j]);
                    }


                    if (j < this.grid.GetLength(1) - 1)
                    {
                        Console.Write(" , ");
                    }
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
    }
}
