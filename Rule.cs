using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramaClasse
{
    class Rule : Grid
    {

        public Rule(int x, int y)
        {
            this.grid = new int[x, y];
        }

        public int Length()
        {
            return this.grid.GetLength(0);
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
