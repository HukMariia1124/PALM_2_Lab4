using System;
using System.Diagnostics;
using System.Text;

namespace Lab4
{
    public class MakscoldSolution
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
            
        }
        static void Task_1_Version_2(uint n)
        {
            
        }
        static void Task_1_Version_3(uint n)
        {
            
        }
        static void Task_1_Version_4(uint n)
        {

        }
        public static void Task_2()
        {/* Відомо, що у рядку є латинські (англійські) букви і цифри. Перетворити рядок так, щоб спочатку
            розміщувалися цифри у прямому порядку, а потім літери у зворотному порядку. Якщо рядок містив
            також інші символи(не букви й не цифри), їх слід пропустити(видалити).*/

            // 5bA4 => 54AB

            Console.WriteLine($"Введіть рядок");
            var str = new StringBuilder(Console.ReadLine());

            DaleteSimvol(str);
            RearrangeSmart(str);

            Console.Error.WriteLine(str);
        }
        static bool IsLetter(char c) => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
        static bool IsDigit(char c) => (c >= '0' && c <= '9');
        static bool IsLetterOrDigit(char c) => (IsDigit(c) || IsLetter(c));
        static void DaleteSimvol(StringBuilder str)
        {
            int dataIndex = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (IsLetterOrDigit(str[i])) str[dataIndex++] = str[i];
            }
            str.Remove(dataIndex, str.Length - dataIndex);
        }
        static void RearrangeSmart(StringBuilder str)
        {
            int i = str.Length - 1;

            while (i >= 0)
            {
                if (IsLetter(str[i]))
                {
                    str.Append(' ');

                    str[^1] = str[i]; //^1 бере останній елемент

                    str.Remove(i, 1);

                }
                else i--;
            }
        }

    }
}
