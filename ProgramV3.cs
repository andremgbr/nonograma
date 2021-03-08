using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nonograma
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] rulesH = new int[,] { { 1, 1 }, { 1, 0 }, { 2, 1 }, { 3, 0 }, { 4, 0 } };
            //int[,] rulesV = new int[,] { { 3, 0 }, { 1, 1 }, { 2, 0 }, { 2, 0 }, { 1, 3 } };

            //int[,] rulesH = new int[,] { { 6, 0, 0 }, { 7, 1, 0 }, { 4, 3, 0 }, { 4, 1, 0 }, { 1, 1, 1 }, { 1, 1, 2 }, { 1, 2, 0 }, { 3, 0, 0 }, { 3, 2, 0 }, { 3, 3, 0 } };
            //int[,] rulesV = new int[,] { { 2, 3 }, { 9, 0 }, { 4, 3 }, { 6,0}, { 2,0 }, { 5, 1 }, { 3, 2 }, { 3, 2 }, { 2, 0 }, { 1,2 } };

            //int[,] rulesH = new int[,] { { 5, 1, 0 }, { 4, 5, 0 }, { 3, 4, 0 }, { 3, 3, 0 }, { 5, 1, 0 }, { 2, 3, 0 }, { 5, 2, 0 }, { 1, 1, 2 }, { 7, 1, 0 }, { 1, 5, 1 } };
            //int[,] rulesV = new int[,] { { 1, 2, 2 }, { 2, 2,1 }, { 3, 4,0 }, { 7, 2, 0 }, { 1, 7, 0 }, { 2, 2, 2 }, { 3, 1, 2 }, { 5, 1, 0 }, { 3, 2, 1 }, { 5, 1, 1 } };

            //int[,] rulesH = new int[,] { { 3, 2 }, { 1, 3 }, { 8, 0 }, { 2,6 }, { 9, 0 }, { 1, 1 }, { 2, 0 }, { 4, 2 }, { 5, 3 }, { 4, 4 } };
            //int[,] rulesV = new int[,] { { 3, 1,0 }, { 4, 3,0 }, { 2,1, 3 },{ 3,1,3}, { 5, 2,0 }, { 1, 3, 1 }, { 3, 1, 1 }, { 3, 1, 2 }, { 1, 3, 3 }, { 1, 2, 3 } };

            int[,] rulesH = new int[,] { { 9,3,1,0,0,0},{ 14,0,0,0,0,0},{ 2,2,1,1,0,0},{ 4,1,1,0,0,0},{ 1,1,1,1,0,0},{1,2,8,0,0,0 },{ 3,4,1,2,0,0},{ 2,1,2,1,1,1 },{ 1,12,0,0,0,0 },{ 2,2,1,1,2,0 },{ 2,4,0,0,0,0 },{ 1,2,4,1,0,0 },{ 2,2,1,1,0,0 },{ 4,1,4,0,0,0 },{ 1,1,5,2,0,0 } };
            int[,] rulesV = new int[,] { { 2,5,1,1,0,0},{ 2,2,1,1,0,0 },{ 3,1,1,2,1,0 },{ 6,2,1,3,0,0 },{ 2,1,1,2,3,0 },{ 2,2,1,2,1,1 },{ 4,3,1,1,0,0 },{ 3,7,1,0,0,0 },{ 2,1,2,1,3,1 },{ 1,2,2,2,2,0},{ 2,1,2,2,1,1},{ 3,1,1,1,0,0 },{2,4,1,1,0,0 },{ 1,3,2,3,0,0 },{ 1,1,1,1,1,2 }};


            double con = 0;

            int[,] scale_board = new int[rulesH.GetLength(0),rulesV.GetLength(0)];
          
            for (int i = 0; i < scale_board.GetLength(0); i++)
            {
                for (int j = 0; j < scale_board.GetLength(1); j++)
                {
                    scale_board[i, j] = -1;
                }
            }

            void print_board(int[,] table)
            {
                for (int i = 0; i < table.GetLength(0); i++)
                {
                    for (int j = 0; j < table.GetLength(1); j++)
                    {
                        Console.Write(table[i, j]);
                        if (j < table.GetLength(1) - 1)
                        {
                            Console.Write(" , ");
                        }
                    }
                    Console.Write("\n");
                }
                Console.Write("\n");
            }

            void print_row(int[] row)
            {
                for (int i = 0; i < row.GetLength(0); i++)
                {
                    Console.Write("{0:D} \t",row[i]);
                }
                Console.Write("\n");
            }

            int[] get_row(int[,] table, int orietantion, int pos)
            {
                if (orietantion == 0)
                {
                    int[] result = new int[table.GetLength(1)];
                    for (int i = 0; i < table.GetLength(1); i++)
                    {
                        result[i] = table[pos, i];
                    }
                    return result;
                }
                if (orietantion == 1)
                {
                    int[] result = new int[table.GetLength(0)];
                    for (int i = 0; i < table.GetLength(0); i++)
                    {
                        result[i] = table[i, pos];
                    }
                    return result;
                }
                return new int[0];
            }

            int[] get_empty(int [,] board)
            {
                int orient=0;
                int pos=0;
                bool found = false;

                while (!found)
                {
                    if (orient == 0)
                    {
                        for (int i = 0; i < board.GetLength(1); i++)
                        {
                            if (board[pos, i] == -1)
                            {
                                found = true;
                                return new int[] { pos, i };
                            }
                        }
                        orient = 1;
                        if (pos >= board.GetLength(1))
                        {
                            found = true;
                        }
                    }
                    if (orient == 1)
                    {
                        for (int i = 0; i < board.GetLength(0); i++)
                        {
                            if (board[i, pos] == -1)
                            {
                                found = true;
                                return new int[] {i,pos};                         
                            }
                        }
                        pos++;
                        orient = 0;
                        if (pos >= board.GetLength(0))
                        {
                            found = true;
                        }
                    }
                }

                return new int[] { -5 };
            }

            int space(int [] row)
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

            int sum_row(int[] row)
            {
                int count = 0;
                for (int i = 0; i < row.GetLength(0); i++)
                {
                    if (row[i] > 0)
                    {
                        count += row[i];
                    }
                }
                if (count > 0)
                {
                    count++;
                }
                return count;

            } 

            int[] remove_zero_row(int[] row)
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
                for(int i = 0; i < row.GetLength(0); i++)
                {
                    if (row[i] > 0)
                    {
                        result[count] = row[i];
                        count++;
                    }
                }
                return result;
            }

            bool check_row(int[] row,int[] rule)
            {
                if (space(rule) == 0)
                {
                    for (int x = 0; x < rule.GetLength(0); x++)
                    {
                        if (rule[x] > 0)
                        {
                            for (int i  = 0; i < row.GetLength(0); i++)
                            {
                                if (row[i] == 1)
                                {
                                    int count = 0;
                                    for (int z = i; z < row.GetLength(0); z++)
                                    {
                                        if (row[z] == 1)
                                        {
                                            count++;
                                            if(z + 1 == row.GetLength(0) && count == rule[x])
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
                    int[] clean_rule = remove_zero_row(rule);
                    int last_pos = 0;
                    int esp = space(rule);
                    for (int x=0; x <= esp; x++)
                    {
                        bool val = true;
                        for(int i = last_pos; i < row.GetLength(0); i++)
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
                                            last_pos = z + 1;
                                            val = false;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (count == rule[x])
                                        {
                                           last_pos = z+1;
                                            val = false;
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

            bool valido (int x, int[,] table ,int [] pos,int[,] rh, int[,] rv)
            {
                //Console.WriteLine("posição -- {0:D}",pos[1]);
                //Console.WriteLine("valor de X -- {0:D}", x);
                //Console.WriteLine("Valor 01 teste - > {0:D}", get_row(table, 0, pos[0]).GetLength(0) - get_row(rh, 0, pos[0]).Sum() - space(get_row(rh, 0, pos[0])) + sum_row(get_row(table, 0, pos[0])));

                table[pos[0], pos[1]] = x;
                bool valH = true;
                bool valV = true;
                
                for (int i = 0; i < table.GetLength(1); i++)
                {
                    if(table[pos[0],i] == -1)
                    {
                        valH = false;
                        break;
                    }
                }
                if (valH)
                {
                    //for (int i = 0; i < table.GetLength(0); i++)
                    //{
                        if (!check_row(get_row(table, 0, pos[0]), get_row(rh, 0, pos[0])))
                        {
                            //Console.WriteLine("Teste falhado");
                            return false;
                        }
                    //}
                    //Console.WriteLine("passou a linha");
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
                    //for (int i = 0; i < table.GetLength(1); i++)
                    //{
                        if (!check_row(get_row(table, 1, pos[1]), get_row(rv, 0, pos[1])))
                        {
                            return false;
                        }
                    //}
                }
                return true;
            }



            bool solver (int [,] board,int[,]rh,int[,]rv)
            {
                int[] pos = get_empty(board);
                if(pos[0] != -5)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        board[pos[0], pos[1]] = x;
                        if (con % 10000000 == 0)
                        {
                            print_board(board);
                        }
                        if (valido(x, board, pos, rh, rv))
                        {
                            con++;
                            //print_board(board);
                            //Console.ReadLine();
                            if(solver(board, rh, rv))
                            {
                                return true;
                            }
                        }
                    }
                    board[pos[0], pos[1]] = -1;
                    return false;
                }
                else
                {
                    Console.WriteLine("TERMINOU.................");
                    print_board(board);
                    return true;
                }

            }

            solver(scale_board,rulesH,rulesV);
            Console.WriteLine("Pressione ENTER para sair...");
            Console.Read();
        }
    }
}
