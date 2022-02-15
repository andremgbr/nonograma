using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramaClasse
{
    class Rule
    {
        public int[,] grid;

        public Rule(int x, int y)
        {
            this.grid = new int[x, y];
        }

        public int Length()
        {
            return this.grid.GetLength(0);
        }

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

        public int Sum_row(int pos)
        {
            int result = 0;
            for (int i = 0; i < this.grid.GetLength(1); i++)
            {
                result += this.grid[pos,i];
            }
            return result;
        }

        public int Space_row(int pos)
        {   
            int count = 0;
            for (int i = 0; i < this.grid.GetLength(1); i++)
            {
                if (this.grid[pos,i] > 0)
                {
                    count++;
                }
            }
            return count - 1;
        }

        public int[] Get_row(int pos)
        {

            int[] result = new int[this.grid.GetLength(1)];
            for (int i = 0; i < this.grid.GetLength(1); i++)
            {
                result[i] = this.grid[pos, i];
            }
            return result;
        }
           

    }
}
