using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab4
{
    internal class Jenlast_Solution
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
                        return;
                    default:
                        Program.ShowProblemMessage();
                        break;
                }
                Console.WriteLine(sw);
            } while (true);
        }
        static void Task_1_Version_1(uint n)
        {
            string str = "1";
            for (int i = 2; i <= n; i++)
            {
                str += $"{i}";
            }
            Console.WriteLine(str);
        }
        static void Task_1_Version_2(uint n)
        {
            string str = $"{n}";
            for (uint i = n - 1; i > 0; i--)
            {
                str = $"{i}" + str;
            }
            Console.WriteLine(str);
        }
        static void Task_1_Version_3(uint n)
        {
            var str = new StringBuilder("1");
            for (int i = 2; i <= n; i++)
            {
                str.Append($"{i}");
            }
            Console.WriteLine(str);
        }
        static void Task_1_Version_4(uint n)
        {
            var str = new StringBuilder($"{n}");
            for (uint i = n - 1;i > 0; i--)
            {
                str.Insert(0, $"{i}");
            }
            Console.WriteLine(str);
        }
        public static void Task_2_Form_7(ref StringBuilder data)
        {
            do
            {
                Program.AskForNewString(ref data);
                Console.WriteLine(
                    """
                    ------------------------------------------------------------------------------------------------------------------------
                                                                          ВИБІР ВЕРСІЇ
                    ------------------------------------------------------------------------------------------------------------------------
                    1) Використовуючи тільки string.
                    2) Вискористовуючи і string i StringBuilder.
                    0) Повернутися назад в меню.
                    """);

                byte choiceBlock = Program.Choice(2);

                switch (choiceBlock)
                {
                    case 1:
                        Task_2_Version_1(ref data);
                        break;
                    case 2:
                        Task_2_Version_2(ref data);
                        break;
                    case 0:
                        return;
                    default:
                        Program.ShowProblemMessage();
                        break;
                }
            } while (true);
        }
        static void Task_2_Version_1(ref StringBuilder data)
        {
            string str = data.ToString();
            string res = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '+' && i > 0 && char.IsDigit(str[i - 1]))
                {
                    int digit = int.Parse(str[i - 1].ToString());
                    if (digit % 2 != 0)
                        res += '-';
                    else
                    {
                        res += "+";
                    }
                }
                else 
                    res += str[i];
            }
            if (str == res)
                Console.WriteLine("У виразі німа непарних цифр, які стоять перед знаком +");
            data = new StringBuilder(res);
        }
        static void Task_2_Version_2(ref StringBuilder data)
        {
            string str = data.ToString();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '+' && i > 0 && char.IsDigit(str[i - 1]))
                {
                    int digit = int.Parse(str[i - 1].ToString());
                    if (digit % 2 != 0)
                    {
                        data.Remove(i, 1);
                        data.Insert(i, '-');
                    }
                }
            }
            bool comparing = str.Equals(data.ToString());
            if (comparing)
                Console.WriteLine("У виразі німа непарних цифр, які стоять перед знаком +");
        }
        public static void Additional(ref StringBuilder data)
        {
            Program.AskForNewString(ref data);
            Console.WriteLine(
                """
                ------------------------------------------------------------------------------------------------------------------------
                                                                ДОДАТКОВА ЗАДАЧА 1
                ------------------------------------------------------------------------------------------------------------------------
                Перевірити, чи правильно в рядку розставлені круглі дужки.

                """);

            int cnt = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == '(')
                    cnt++;
                else if (data[i] == ')')
                    cnt--;
                if (cnt < 0) break;
            }
            if (!data.ToString().Contains('(') && !data.ToString().Contains(')')) Console.WriteLine("В рядку немає дужок");
            else if (cnt != 0) Console.WriteLine("Дужки розставлені неправильно");
            else Console.WriteLine("Дужки розставлені правильно");
        }
    }
}
