using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NonogramaClasse;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using System.IO;

namespace NonogramaClasse
{
    class Program 
    {
        public int count = 0;
        static void Main(string[] args)
        {

            //Processo de Carregar página no Selenium
            WebNonogram();
            
            //Processo de Inserir Regra Manualmente
            //ManualNonogram();

        }

        static void ManualNonogram()
        {
            Rule rulesH = new(11, 5);
            rulesH.grid = new int[,]  { { 2,3,3,0,0 }, 
                                        { 2,2,0,0,0 },
                                        { 1,2,2,1,0 },
                                        { 1,1,1,1,1 },
                                        { 1,3,3,0,0 },
                                        { 1,1,1,0,0 },
                                        { 1,2,2,0,0 },
                                        { 1,1,0,0,0 },
                                        { 2,3,2,0,0 },
                                        { 1,1,1,0,0 },
                                        { 1,5,0,0,0 } };
            
            Rule rulesV = new(11, 4);
            rulesV.grid = new int[,]  { { 1,1,2,1 },
                                        { 2,3,1,0 },
                                        { 1,2,2,0 },
                                        { 1,1,1,1 },
                                        { 1,3,1,1 },
                                        { 1,1,1,1 },
                                        { 4,1,1,0 },
                                        { 1,1,1,1 },
                                        { 1,3,2,0 },
                                        { 2,3,0,0 },
                                        { 3,2,0,0 } };

            Order ordem_game = new(rulesH, rulesV);

            board game = new(rulesH, rulesV, ordem_game);

            Console.Clear();
            Console.WriteLine("\n\nRegras Horizontais");
            game.ruleH.Print();

            Console.WriteLine("\n\nRegras Verticais");
            game.ruleV.Print();

            Console.WriteLine("\n\nOrdem de Solução");
            game.orderGame.Print();

            Console.WriteLine("\n\nPressione Enter para Resolver");
            Console.ReadLine();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine("\n\nResolvendo.....");
            game.solver();

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            game.Print();
            Console.WriteLine($"Game Resolvido em {ts.Minutes}:{ts.Seconds}! Pressione Enter para encerrar!");
            Console.ReadLine();
        }

        static void WebNonogram()
        {
            string path = Directory.GetCurrentDirectory();
            var driver = new ChromeDriver(path+@"\chromedriver_win32");
            driver.Navigate().GoToUrl("https://www.nonograms.org/");
            char sContinue = 's';

            while (sContinue == 's')
            {
                Console.Clear();
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

                board game = new(rulesH, rulesV, ordem_game);

                Console.Clear();
                Console.WriteLine("\n\nRegras Horizontais");
                game.ruleH.Print();

                Console.WriteLine("\n\nRegras Verticais");
                game.ruleV.Print();

                Console.WriteLine("\n\nOrdem de Solução");
                game.orderGame.Print();

                Console.WriteLine("\n\nPressione Enter para Resolver");
                Console.ReadLine();

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                Console.WriteLine("\n\nResolvendo.....");
                game.solver();

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                game.Print();
                Console.WriteLine($"Game Resolvido em {ts.Minutes}:{ts.Seconds}! Pressione Enter para prencher a grade!");
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

                Console.WriteLine("Deseja fazer Outro? s/n");
                sContinue = Console.ReadKey().KeyChar;

            }
            driver.Quit();
        }

    }
}
