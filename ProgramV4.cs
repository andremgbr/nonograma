using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nonograma;

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

            //int[,] rulesH = new int[,] { { 9,3,1,0,0,0},{ 14,0,0,0,0,0},{ 2,2,1,1,0,0},{ 4,1,1,0,0,0},{ 1,1,1,1,0,0},{1,2,8,0,0,0 },{ 3,4,1,2,0,0},{ 2,1,2,1,1,1 },{ 1,12,0,0,0,0 },{ 2,2,1,1,2,0 },{ 2,4,0,0,0,0 },{ 1,2,4,1,0,0 },{ 2,2,1,0,0,0 },{ 4,1,4,0,0,0 },{ 1,1,5,2,0,0 } };
            //int[,] rulesV = new int[,] { { 2,5,1,1,0,0},{ 2,2,1,1,0,0 },{ 3,1,1,2,1,0 },{ 6,2,1,3,0,0 },{ 2,1,1,2,3,0 },{ 2,2,1,2,1,1 },{ 4,3,1,1,0,0 },{ 3,7,1,0,0,0 },{ 2,1,2,1,3,1 },{ 1,2,2,2,2,0},{ 2,1,2,2,1,1},{ 3,1,1,1,0,0 },{2,4,1,1,0,0 },{ 1,3,2,3,0,0 },{ 1,1,1,1,1,2 }};


            //int[,] rulesH = new int[,] { { 2,1,10,0,0},{ 1,1,5,1,1},{ 3,6,1,0,0},{ 1,1,6,2,0},{ 2,1,1,3,1},{6,2,1,1,1 },{ 6,1,6,0,0},{ 5,5,0,0,0 },{ 5,1,5,0,0 },{ 5,1,5,0,0 },{ 4,1,4,0,0 },{ 3,1,3,0,0 },{3,1,3,0,0 },{ 4,1,4,0,0 },{ 5,5,0,0,0 } };
            //int[,] rulesV = new int[,] { { 15,0,0,0,0},{1,1,11,0,0 },{ 1,10,0,0,0 },{ 2,8,2,0,0 },{ 1,5,1,0,0 },{ 1,1,3,0,0 },{ 4,0,0,0,0 },{ 7,0,0,0,0 },{ 6,2,0,0,0 },{5,1,1,1,0},{2,1,5,2,1},{ 1,1,5,2,0 },{3,11,0,0,0},{ 1,1,9,0,0 },{ 2,1,10,0,0}};


            int[,] rulesH = new int[,] { 
                                        { 4,0,0,0},
                                        { 2,1,1,0},
                                        { 3,3,0,0},
                                        { 10,0,0,0},
                                        { 2,4,2,0},
                                        {4,2,1,0 },
                                        { 6,2,0,0},
                                        { 7,2,0,0 },
                                        { 7,1,0,0 },
                                        { 7,2,0,0 },
                                        { 6,2,0,0 },
                                        { 6,2,0,0 },
                                        {5,2,6,0 },
                                        { 9,7,0,0 },
                                        { 8,4,0,0 },
                                        { 3,3,5,0},
                                        { 2,3,2,1},
                                        { 2,3,0,0 },
                                        { 1,2,0,0 },
                                        { 2,0,0,0 }
            };

            int[,] rulesV = new int[,] {
                                        { 1,0,0,0},
                                        { 2,0,0,0},
                                        { 2,0,0,0},
                                        { 3,0,0,0},
                                        { 4,3,0,0},
                                        {9,0,0,0},
                                        { 10,0,0,0},
                                        {10,1,0,0 },
                                        { 10,2,0,0 },
                                        { 8,3,2,0 },
                                        {8,2,3,0 },
                                        {1,5,7,0 },
                                        {2,3,2,2 },
                                        { 4,2,4,0},
                                        { 10,3,0,0 },
                                        { 1,5,2,0},
                                        { 2,2,2,0},
                                        { 1,2,2,0 },
                                        { 5,2,0,0 },
                                        { 3,2,0,0 }
            };




            double con = 0;


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

            int[] get_empty(int [,] board,int[,]rh,int[,]rv)
            {
                int orient=0;
                int pos=0;
                int rhtam = 0;

                for (int z = 0; z < rh.GetLength(0); z++)
                { 
                    if((get_row(rh,0,z).Sum() + space(get_row(rh, 0, z))) > rhtam)
                    {
                        for (int i = 0; i < board.GetLength(1); i++)
                        {
                            if (board[z, i] == -1)
                            {
                                rhtam = get_row(rh, 0, z).Sum() + space(get_row(rh, 0, z));
                                orient = 0;
                                pos = z;
                                break;
                            }
                        }

                    }
                        
                }
                for (int z = 0; z < rv.GetLength(0); z++)
                {
                    if ((get_row(rv, 0, z).Sum() + space(get_row(rv, 0, z))) > rhtam)
                    {
                        for (int i = 0; i < board.GetLength(0); i++)
                        {
                            if (board[i, z] == -1)
                            {
                                rhtam = get_row(rv, 0, z).Sum() + space(get_row(rv, 0, z));
                                orient = 1;
                                pos = z;
                            }
                        }
                    }

                }

                if(orient == 0)
                {
                    for(int i = 0; i < board.GetLength(1); i++)
                    {
                        if(board[pos,i] == -1)
                        {
                            return new int[] { pos, i };
                        }
                    }
                }
                if (orient == 1)
                {
                    for (int i = 0; i < board.GetLength(0); i++)
                    {
                        if (board[i, pos] == -1)
                        {
                            return new int[] { i, pos };
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
                                           last_pos = z+1;
                                            val = false;
                                            if (x + 1 == clean_rule.GetLength(0))
                                            {
                                                for(int y = last_pos; y < row.GetLength(0); y++)
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

            bool valido (int x, int[,] table ,int [] pos,int[,] rh, int[,] rv)
            {
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
                        if (!check_row(get_row(table, 0, pos[0]), get_row(rh, 0, pos[0])))
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
                        if (!check_row(get_row(table, 1, pos[1]), get_row(rv, 0, pos[1])))
                        {
                            return false;
                        }
                }
                return true;
            }

            bool solver (int [,] board,int[,]rh,int[,]rv)
            {
                int[] pos = get_empty(board,rh,rv);
                if(pos[0] != -5)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        board[pos[0], pos[1]] = x;
                        if (con % 100000 == 0)
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

            int[,] montaRegra(int x , int y)
            {
                int[,] temp = new int[x, y];
                for (int i = 0; i< x ; i++)
                {
                    for (int j = 0; j< y ; j++)
                    {
                        Console.WriteLine($"x - {i} --- y - {j}");

                        temp[i,j] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                return temp;

            }



            //int[,] rulesH = montaRegra(20, 4);
            //int[,] rulesV = montaRegra(20, 4);


            int[,] scale_board = new int[rulesH.GetLength(0),rulesV.GetLength(0)];
          
            for (int i = 0; i < scale_board.GetLength(0); i++)
            {
                for (int j = 0; j < scale_board.GetLength(1); j++)
                {
                    scale_board[i, j] = -1;
                }
            }

            solver(scale_board,rulesH,rulesV);
            Console.WriteLine("Pressione ENTER para sair...");
            Console.Read();
        }
    }
}
