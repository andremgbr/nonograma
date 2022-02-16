using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonogramaClasse
{
    class Order : Grid
    {
        public Order(Rule ruleH, Rule ruleV)
        {
            this.grid = new int[ruleH.Length() + ruleV.Length(), 4];
            int index = 0;
            for (int i = 0; i < ruleH.Length(); i++)
            {
                this.grid[index, 1] = 0;
                this.grid[index, 2] = (ruleH.Sum_row(i) + ruleH.Space_row(i));
                this.grid[index, 3] = i;
                index++;
            }
            for (int i = 0; i < ruleV.Length(); i++)
            {
                this.grid[index, 1] = 1;
                this.grid[index, 2] = (ruleV.Sum_row(i) + ruleV.Space_row(i)); ;
                this.grid[index, 3] = i;
                index++;
            }

            index = 0;
            int Order = 1;
            int lasOri = -1;
            bool finish = false;
            while (!finish)
            {
                int soma = 0;
                for (int i = 0; i < this.grid.GetLength(0); i++)
                {
                    if (this.grid[i, 0] == 0 && this.grid[i, 1] != lasOri && this.grid[i, 2] >= soma)
                    {
                        soma = this.grid[i, 2];
                        index = i;
                    }
                }
                Console.WriteLine(index);
                Console.WriteLine(Order);
                this.grid[index, 0] = Order;
                Order++;
                for (int i = 0; i < this.grid.GetLength(0); i++)
                {
                    if (this.grid[i,0] == 0 && this.grid[i,1] != this.grid[index, 1])
                    {
                        lasOri = this.grid[index, 1];
                        break;
                    }
                }
                        
                    

                finish = true;
                for (int i = 0; i < this.grid.GetLength(0); i++)
                {
                    if (this.grid[i, 0] == 0) 
                    {
                        finish = false;
                        break;
                    }
                }
            }

        }

    }
}
