using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramaClasse
{
    class board : Grid
    {

        public Rule ruleH;
        public Rule ruleV;
        public Order orderGame;

        public board(Rule ruleH, Rule ruleV, Order orderGame)
        {
            this.grid = new int[ruleH.Length(), ruleV.Length()];

            for (int i = 0; i < ruleH.Length(); i++)
            {
                for (int j = 0; j < ruleV.Length(); j++)
                {
                    this.grid[i, j] = -1;
                }
            }

            this.ruleH = ruleH;
            this.ruleV = ruleV;
            this.orderGame = orderGame;
        }
        int[] get_empty()
        {
            for (int ord = 1; ord <= this.orderGame.grid.GetLength(0); ord++)
            {
                for (int z = 0; z < this.orderGame.grid.GetLength(0); z++)
                {
                    if (this.orderGame.grid[z, 0] == ord)
                    {
                        int orient;
                        if (this.orderGame.grid[z, 1] == 0)
                        {
                            orient = 1;
                        }
                        else
                        {
                            orient = 0;
                        }

                        for (int i = 0; i < this.grid.GetLength(orient); i++)
                        {
                            if (this.orderGame.grid[z, 1] == 0)
                            {
                                if (this.grid[this.orderGame.grid[z, 3], i] == -1)
                                {
                                    return new int[] { this.orderGame.grid[z, 3], i };
                                }
                            }
                            else
                            {
                                if (this.grid[i, this.orderGame.grid[z, 3]] == -1)
                                {
                                    return new int[] { i, this.orderGame.grid[z, 3] };
                                }
                            }
                        }
                        break;
                    }
                }
            }

            return new int[] { -5 };
        }
        public bool solver()
        {
            int[] pos = get_empty();
            if (pos[0] != -5)
            {
                for (int x = 0; x < 2; x++)
                {
                    this.grid[pos[0], pos[1]] = x;
        /*            if (prog.count % 1000000 == 0)
                    {

                        Console.Clear();
                        print_board(board);
                        Console.WriteLine($"{con_1} * 1000000 ");
                        con_1++;
                        //Console.ReadLine();
                        //1000000
                    }*/
                    if (valido(x, this.grid, pos, this.ruleH.grid, this.ruleV.grid))
                    {
                        //con++;
                        /*       //Console.Clear();
                              print_board(board);
                               Console.ReadLine();*/
                        if (solver())
                        {
                            return true;
                        }
                    }
                }
                this.grid[pos[0], pos[1]] = -1;
                return false;
            }
            else
            {
                return true;
            }

        }

        bool valido(int x, int[,] table, int[] pos, int[,] rh, int[,] rv)
        {
            table[pos[0], pos[1]] = x;
            bool valH = true;
            bool valV = true;

            for (int i = 0; i < table.GetLength(1); i++)
            {
                if (table[pos[0], i] == -1)
                {
                    valH = false;
                    break;
                }
            }
            if (valH)
            {
                if (!check_row(this.Get_row( 0, pos[0]), Remove_zero_row(this.ruleH.Get_row(pos[0]))))
                {
                    return false;
                }
            }

            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (table[i, pos[1]] == -1)
                {
                    valV = false;
                    break;
                }
            }
            if (valV)
            {
                if (!check_row(this.Get_row(1, pos[1]), Remove_zero_row(this.ruleV.Get_row(pos[1]))))
                {
                    return false;
                }
            }
            return true;
        }

        int[] Get_row(int orietantion, int pos)
        {
            if (orietantion == 0)
            {
                int[] result = new int[this.grid.GetLength(1)];
                for (int i = 0; i < this.grid.GetLength(1); i++)
                {
                    result[i] = this.grid[pos, i];
                }
                return result;
            }
            if (orietantion == 1)
            {
                int[] result = new int[this.grid.GetLength(0)];
                for (int i = 0; i < this.grid.GetLength(0); i++)
                {
                    result[i] = this.grid[i, pos];
                }
                return result;
            }
            return new int[0];
        }

        int[] Remove_zero_row(int[] row)
        {
            int count = 0;
            for (int i = 0; i < row.GetLength(0); i++)
            {
                if (row[i] > 0)
                {
                    count++;
                }
            }

            int[] result = new int[count];
            count = 0;
            for (int i = 0; i < row.GetLength(0); i++)
            {
                if (row[i] > 0)
                {
                    result[count] = row[i];
                    count++;
                }
            }
            return result;
        }

        bool check_row(int[] row, int[] rule)
        {
            if (row.Sum() != rule.Sum())
            {
                return false;
            }
            if (space(rule) == 0)
            {
                for (int x = 0; x < rule.GetLength(0); x++)
                {
                    if (rule[x] > 0)
                    {
                        for (int i = 0; i < row.GetLength(0); i++)
                        {
                            if (row[i] == 1)
                            {
                                int count = 0;
                                for (int z = i; z < row.GetLength(0); z++)
                                {
                                    if (row[z] == 1)
                                    {
                                        count++;
                                        if (z + 1 == row.GetLength(0) && count == rule[x])
                                        {
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        if (count == rule[x])
                                        {
                                            for (int y = z; y < row.GetLength(0); y++)
                                            {
                                                if (row[y] == 1)
                                                {
                                                    return false;
                                                }
                                            }
                                            return true;

                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }

                                    if (count > rule[x])
                                    {
                                        return false;
                                    }

                                }
                            }
                        }
                    }
                }
                return false;
            }
            else
            {
                int[] clean_rule = Remove_zero_row(rule);
                int last_pos = 0;
                int esp = space(rule);

                for (int x = 0; x <= esp; x++)
                {
                    bool val = true;
                    for (int i = last_pos; i < row.GetLength(0); i++)
                    {
                        if (row[i] == 1)
                        {
                            int count = 0;
                            for (int z = i; z < row.GetLength(0); z++)
                            {
                                if (row[z] == 1)
                                {
                                    count++;

                                    if (z + 1 == row.GetLength(0) && count == clean_rule[x])
                                    {
                                        last_pos = z + 1;
                                        val = false;
                                        break;
                                    }

                                }
                                else
                                {
                                    if (count == rule[x])
                                    {
                                        last_pos = z + 1;
                                        val = false;
                                        if (x + 1 == clean_rule.GetLength(0))
                                        {
                                            for (int y = last_pos; y < row.GetLength(0); y++)
                                            {
                                                if (row[y] == 1)
                                                {
                                                    return false;
                                                }
                                            }
                                        }
                                        break;

                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }

                                if (count > rule[x])
                                {
                                    return false;
                                }
                            }
                            break;

                        }
                    }
                    if (val)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        int space(int[] row)
        {
            int count = 0;
            for (int i = 0; i < row.GetLength(0); i++)
            {
                if (row[i] > 0)
                {
                    count++;
                }
            }
            return count - 1;
        }

    }
}
