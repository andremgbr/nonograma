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

            //int[,] rulesH = new int[,] { { 2, 0 ,0}, { 1, 1,0 }, { 1, 1,1 }, { 2, 1,0 }, { 1,1,1 } };
            //int[,] rulesV = new int[,] { { 3, 0 }, { 1, 1 }, { 1, 1 }, { 2, 0 }, { 1 ,3} };

            int[,] rulesH = new int[,] { { 1, 1}, { 2,0 }, {3,0 }, { 4,0}, { 2,0 } };
            int[,] rulesV = new int[,] { {1,1 }, { 3,0 }, { 4,0 }, { 2, 0 }, { 2 ,0} };


            //int[,] rulesH = new int[,] { { 1, 1 ,1,4}, { 3, 1,6,0 }, { 1, 8,2,0 }, { 4, 1,2,5 }, { 5,3,3,0 }, { 3, 5, 1, 1 }, { 1, 2, 7, 0 }, { 4, 7, 0, 0 }, { 1, 7, 1, 2 }, { 2, 1, 2, 1 }, { 4, 4, 2, 0 }, { 6, 2, 0, 0 }, { 5, 3, 0, 0 }, { 8, 0, 0, 0 }, { 5, 3, 1, 0 } };
            //int[,] rulesV = new int[,] { { 5, 1, 2, 0 ,0}, { 1, 2, 3, 0 ,0}, { 1, 4, 5, 1,0 }, { 1, 3, 2, 3 , 1}, { 1, 5, 2, 1, 0 }, { 1, 2, 3, 4, 0 }, { 2, 2, 4, 3, 0 }, { 5, 1, 1, 1, 0 }, { 7, 1, 2, 0, 0 }, { 2, 3, 1, 2, 0 }, { 3, 4, 1, 2, 0 }, { 4, 2, 1, 1, 1 }, { 2, 5, 1, 3, 0 }, { 5, 3, 1, 1, 0 }, { 6, 4, 1, 0, 0 } };

            //int[,] rulesH = new int[,] { { 1, 1 }, { 1, 0}, { 2, 0}, { 5,0 }, {2,0 }, { 2,0 }, { 5,0 }, { 1,1 }, { 2,0 }, {3,1 }};
            //int[,] rulesV = new int[,] { { 4,2,1,0}, { 3,1,1,0 }, { 2,1,2,0 }, {1,1,2,1 }, { 1,1,3,1 } };


            int[,] scale_board = new int[rulesH.GetLength(0),rulesV.GetLength(0)];
          
            for (int i = 0; i < scale_board.GetLength(0); i++)
            {
                for (int j = 0; j < scale_board.GetLength(1); j++)
                {
                    scale_board[i, j] = -1;
                }
            }
            

            int contagem = 1;

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
                for (int i =0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i,j] == -1)
                        {
                            return new int[] { i, j };
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
                table[pos[0], pos[1]] = x;
                //Console.WriteLine("Valor 01 teste - > {0:D}", get_row(table, 0, pos[0]).GetLength(0) - get_row(rh, 0, pos[0]).Sum() - space(get_row(rh, 0, pos[0])) + sum_row(get_row(table, 0, pos[0])));

                if (pos[0] + 1 == table.GetLength(0) && pos[1] + 1 == table.GetLength(1))
                {
                    /*
                    bool row_empty = true;
                    for (int i = 0; i < table.GetLength(0); i++)
                    {
                        if (get_row(table, 0, 0)[i] == 1)
                        {
                            row_empty = false;
                            break;
                        }
                    }
                    if (row_empty) 
                    {
                        return false;
                    }
                    */

                    for (int i = 0; i < table.GetLength(0); i++)
                    {
                        if (!check_row(get_row(table, 0, i), get_row(rh, 0, i)))
                        {
                            return false;
                        }
                    }

                    for (int i = 0; i<table.GetLength(1); i++)
                    {
                        if (!check_row(get_row(table, 1, i), get_row(rv, 0, i)))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            //bool end_fill = false;

            bool solver (int [,] board,int[,]rh,int[,]rv)
            {
                int [] pos = get_empty(board);
                if (pos[0] != -5)
                {
                    /*
                    if (contagem >= 224)
                    {
                        end_fill = true;
                    }
                    */
                    for (int x = 0; x < 2; x++)
                    {
                        //if (end_fill || pos[0]==0 || x>0)
                       // {
                            if (valido(x, board, pos, rh, rv))
                            {

                                board[pos[0], pos[1]] = x;
                                contagem++;
                                if (solver(board, rh, rv))
                                {
                                    return true;
                                }
                            }
                        //}
                    }




                    board[pos[0], pos[1]] = -1;
                    if (contagem % 10000 == 0)
                    {
                        Console.Clear();
                        print_board(board);
                    }
                    return false;
                }
                else
                {
                    Console.WriteLine("Encerrou a bagaça");
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
