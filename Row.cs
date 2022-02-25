using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramaClasse
{
    class Row : Grid
    {
        Rule rule;
        List<RowValues> Valid;
        int size;
        int pos;
        int ori;
        int[] grid;

        Row(Rule rule, int size, int pos, int ori)
        {
            this.rule = rule;
            this.size = size;
            this.pos = pos;
            this.ori = ori;

            this.grid = new int[size];

            for (int i = 0; i < this.grid.GetLength(0); i++)
            {
                this.grid[i] = -1;
            }
        }

        int get_empty()
        {
            for (int z = 0; z < this.grid.GetLength(0); z++)
            {
                if (this.grid[z] == -1)
                {
                    return z;
                }
            }

            return -5 ;
        }

        bool solver (int[] row, Rule rule)
        {
            int pos = get_empty();
            if (pos != -5)
            {
                for (int x = 0; x < 2; x++)
                {
                    this.grid[pos] = x;

                    if (valido_row(this,rule)[0])
                    {
              
                        if (solver(this.grid, rule))
                        {
                            return true;
                        }
                    }
                }
                this.grid[pos] = -1;
                return false;
            }
            else
            {
                return true;
            }

        }

        bool[] valido_row(Row row, Rule rule)
        {
            for (int i = 0; i < row.grid.GetLength(0); i++)
            {
                if (row.grid[i] == -1)
                {
                    return new bool[] { true, false };
                }
            }

            return new bool[] { true, true };
        }

    }

    class RowValues
    {
        public int[] values;
        
    }


}
