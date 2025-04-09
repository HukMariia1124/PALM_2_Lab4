using System.Diagnostics;
using System.Text;

namespace Lab4
{
    public class MariiaSolution
    {
        public static void Task_1()
        {
            do
            {
                Console.WriteLine(
                    """
                    ------------------------------------------------------------------------------------------------------------------------
                                                                          ВИБІР ВЕРСІЇ
                    ------------------------------------------------------------------------------------------------------------------------
                    1) З використанням лише типу string та додаванням чисел 1, 2, 3,..., n у кінець за допомогою оператора += типу string.
                    2) З використанням лише типу string та додаванням чисел n, n–1,..., 2, 1 в початок за допомогою оператора + типу string.
                    3) З використанням string, StringBuilder, та додаванням чисел 1, 2, 3,..., n у кінець за допомогою метода Append.
                    4) З використанням string, StringBuilder, та додаванням чисел n, n–1,..., 3, 2, 1 в початок за допомогою метода Insert.
                    0) Повернутися назад в меню.
                    """);

                byte choiceBlock = Program.Choice(4);
                uint n = 0;
                Stopwatch sw = Stopwatch.StartNew();
                sw.Stop();
                if (choiceBlock != 0)
                {
                    Console.Write("Введіть n: ");
                    do
                    {
                        try
                        {
                            n = uint.Parse(Console.ReadLine()!);
                        }
                        catch { Program.ShowProblemMessage(); }
                    } while (n == 0);
                }

                switch (choiceBlock)
                {
                    case 1:
                        sw.Restart();
                        Task_1_Version_1(n);
                        sw.Stop();
                        break;
                    case 2:
                        sw.Restart();
                        Task_1_Version_2(n);
                        sw.Stop();
                        break;
                    case 3:
                        sw.Restart();
                        Task_1_Version_3(n);
                        sw.Stop();
                        break;
                    case 4:
                        sw.Restart();
                        Task_1_Version_4(n);
                        sw.Stop();
                        break;
                    case 0:
                        Program.Main();
                        break;
                    default:
                        Program.ShowProblemMessage();
                        break;
                }
                Console.WriteLine(sw);
            } while (true);
        }
        static void Task_1_Version_1(uint n)
        {
            string res = "";
            for (int i = 1; i <= n; i++)
            {
                res += i.ToString() + " ";
            }
            Console.WriteLine(res);
        }
        static void Task_1_Version_2(uint n)
        {
            string res = "";
            for (uint i = n; i > 0; i--)
            {
                res = i.ToString() + " " + res;
            }
            Console.WriteLine(res);
        }
        static void Task_1_Version_3(uint n)
        {
            StringBuilder res = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                res.Append(i.ToString() + " ");
            }
            Console.WriteLine(res);
        }
        static void Task_1_Version_4(uint n)
        {
            StringBuilder res = new StringBuilder();
            for (uint i = n; i > 0; i--)
            {
                res.Insert(0, i.ToString() + " ");
            }
            Console.WriteLine(res);
        }


        public static void Task_2_Form_12()
        {
            do
            {
                Console.WriteLine(
                    """
                    ------------------------------------------------------------------------------------------------------------------------
                                                                          ВИБІР ВЕРСІЇ
                    ------------------------------------------------------------------------------------------------------------------------
                    1) Шифрування шифром Цезаря.
                    2) Дешифрування шифром Цезаря.
                    0) Повернутися назад в меню.
                    """);

                byte choiceBlock = Program.Choice(2);

                switch (choiceBlock)
                {
                    case 1:
                        Task_2_Encryption();
                        break;
                    case 2:
                        Task_2_Deciphering();
                        break;
                    case 0:
                        Program.Main();
                        break;
                    default:
                        Program.ShowProblemMessage();
                        break;
                }
            } while (true);
        }
        static void Task_2_Encryption()
        {

        }
        static void Task_2_Deciphering()
        {

        }
    }
}
