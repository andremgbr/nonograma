using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NonogramaClasse;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace NonogramaClasse
{
    class Program
    {
        static void Main(string[] args)
        {

            var driver = new ChromeDriver(@"D:\Documentos\CS\nonograma\nonograma\chromedriver_win32");
            driver.Navigate().GoToUrl("https://www.nonograms.org/");
            char sContinue = 's';

            while (sContinue == 's')
            {

                Console.WriteLine("\n\nPronto para carregar a página, Pressiona Enter para continar");
                Console.ReadLine();


                int CountColuWeb = driver.FindElements(By.XPath("//*[@id=\"nonogram_table\"]/tbody/tr[1]/td[2]/table/tbody/tr")).Count;
                int CountVertWeb = driver.FindElements(By.XPath("//*[@id=\"nonogram_table\"]/tbody/tr[1]/td[2]/table/tbody/tr[1]/td")).Count;

                Rule rulesV = new(CountVertWeb, CountColuWeb);

                for (int i = 1; i < CountVertWeb + 1; i++)
                {
                    for (int j = 1; j < CountColuWeb + 1; j++)
                    {

                        int value = 0;
                        if (int.TryParse(driver.FindElement(By.XPath("/html/body/table/tbody/tr[1]/td[2]/div[2]/table[2]/tbody/tr[1]/td[2]/table/tbody/tr[" + j + "]/td[" + i + "]/div")).Text, out value))
                        {
                            rulesV.grid[i - 1, j - 1] = Convert.ToInt32(value);
                        }
                        else
                        {
                            rulesV.grid[i - 1, j - 1] = Convert.ToInt32(0);
                        }
                        //Console.WriteLine("X: " + (i - 1) + ", Y: " + (j - 1) + ", Value: " + value);

                    }
                }

                CountVertWeb = driver.FindElements(By.XPath("//*[@id=\"nonogram_table\"]/tbody/tr[2]/td[1]/table/tbody/tr")).Count;
                CountColuWeb = driver.FindElements(By.XPath("//*[@id=\"nonogram_table\"]/tbody/tr[2]/td[1]/table/tbody/tr[1]/td")).Count;

                Rule rulesH = new(CountVertWeb, CountColuWeb);
                for (int i = 1; i < CountVertWeb + 1; i++)
                {
                    for (int j = 1; j < CountColuWeb + 1; j++)
                    {
                        int value = 0;
                        if (int.TryParse(driver.FindElement(By.XPath("/html/body/table/tbody/tr[1]/td[2]/div[2]/table[2]/tbody/tr[2]/td[1]/table/tbody/tr[" + i + "]/td[" + j + "]/div")).Text, out value))
                        {
                            rulesH.grid[i - 1, j - 1] = value;
                            //Console.WriteLine("X: " + (i - 1) + ", Y: " + (j - 1) + ", Value: " + Convert.ToInt32(value));
                        }
                        else
                        {
                            rulesH.grid[i - 1, j - 1] = Convert.ToInt32(0);
                            // Console.WriteLine("X: " + (i - 1) + ", Y: " + (j - 1) + ", foi zero");
                        }
                    }
                }

                Order ordem_game = new(rulesH, rulesV);

                board game = new(rulesH, rulesV);

                game.ruleH = rulesH; //@TODO Instanciar no board
                game.ruleV = rulesV; //@TODO Instanciar no board
                game.orderGame = ordem_game; //@TODO Instanciar no board
                //@TODO Criar Classe pai e incluir o void Print que é comume em Order, Rule, Board

                Console.WriteLine("\n\nRegras Horizontais");
                game.ruleH.Print();

                Console.WriteLine("\n\nRegras Verticais");
                game.ruleV.Print();

                Console.WriteLine("\n\nOrdem de Solução");
                game.orderGame.Print();

                Console.WriteLine("\n\nPressione Enter para Resolver");
                Console.ReadLine();

                Console.WriteLine("\n\nResolvendo.....");
                game.solver();

                game.Print();
                Console.WriteLine("Game Resolvido! Pressione Enter para prencher a grade!");
                Console.ReadLine();


                for (int i = 0; i < game.grid.GetLength(0); i++)
                {
                    for (int j = 0; j < game.grid.GetLength(1); j++)
                    {
                        if (game.grid[i, j] == 1)
                        {
                            /*IWebElement keysEventInput = driver.FindElement(By.Id($"nmf{j}_{i}"));
                            keysEventInput.Click();*/

                            driver.FindElement(By.Id($"nmf{j}_{i}")).Click();
                        }
                    }
                }

                Console.WriteLine("Desejá fazer Outro? s/n");
                sContinue = Console.ReadKey().KeyChar;

            }
            driver.Quit();
        }

    }
}
