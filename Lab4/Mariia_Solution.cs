using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            string res = "";
            for (int i = 1; i <= n; i++)
            {
                res += i.ToString() + " ";
            }
            //Console.WriteLine(res);
        }
        static void Task_1_Version_2(uint n)
        {
            string res = "";
            for (uint i = n; i > 0; i--)
            {
                res = i.ToString() + " " + res;
            }
            //Console.WriteLine(res);
        }
        static void Task_1_Version_3(uint n)
        {
            StringBuilder res = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                res.Append(i.ToString() + " ");
            }
            //Console.WriteLine(res);
        }
        static void Task_1_Version_4(uint n)
        {
            StringBuilder res = new StringBuilder();
            for (uint i = n; i > 0; i--)
            {
                res.Insert(0, i.ToString() + " ");
            }
            //Console.WriteLine(res);
        }


        public static StringBuilder Task_2_Form_12(ref StringBuilder data)
        {
            do
            {
                Program.AskForNewString(ref data);
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
                        Task_2_CaesarCipher(ref data, true);
                        break;
                    case 2:
                        Task_2_CaesarCipher(ref data, false);
                        break;
                    case 0:
                        return data;
                    default:
                        Program.ShowProblemMessage();
                        break;
                }
            } while (true);
        }
        static void Task_2_CaesarCipher(ref StringBuilder data, bool Encrypt)
        {
            bool remove = DeleteOrNot();
            Console.WriteLine("Введіть ключ:");
            int shift = int.Parse(Console.ReadLine()!);
            const string template = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Console.WriteLine($"Текст до шифрування: {data}");
            for (int i = 0; i < data.Length; i++)
            {
                int index = template.IndexOf(data[i]);
                if (index != -1)
                {
                    if (Encrypt)
                    {
                        if (index < 26 && index + shift>=0) data[i] = template[(index + shift) % 26];
                        else data[i] = template[(index + shift) % 26 + 26];
                    }
                    else
                    {
                        if (index < 26 && index - shift >= 0) data[i] = template[(index - shift) % 26];
                        else data[i] = template[(index - shift) % 26 + 26];
                    }
                }
                else if (remove == true) data.Remove(i--, 1);
            }
            Console.WriteLine($"Текст після шифрування: {data}");
        }
        static bool DeleteOrNot()
        {
            do
            {
                Console.WriteLine(
                    """
                    Видаляти символи, які не є буквами латинського алфавіту?
                    1) Так.
                    2) Ні.
                    """);
                byte choiceBlock = Program.Choice(2);

                switch (choiceBlock)
                {
                    case 1:
                        return true;
                    case 2:
                        return false;
                    default:
                        Program.ShowProblemMessage();
                        break;
                }
            } while (true);
        }


        public static StringBuilder Additional(ref StringBuilder data)
        {
            do
            {
                Program.AskForNewString(ref data);
                Console.WriteLine(
                    """
                    ------------------------------------------------------------------------------------------------------------------------
                                                                    ВИБІР ДОДАТКОВОЇ ЗАДАЧІ
                    ------------------------------------------------------------------------------------------------------------------------
                    1) Перевірити, чи правильно в рядку розставлені круглі дужки.
                    2) 
                    3) 
                    0) Повернутися назад в меню.
                    """);
                byte choiceBlock = Program.Choice(3);

                switch (choiceBlock)
                {
                    case 1:
                        Additional_1(ref data);
                        break;
                    case 2:
                        Additional_2(ref data);
                        break;
                    case 3:
                        //Additional_3(ref data);
                        break;
                    case 0:
                        return data;
                    default:
                        Program.ShowProblemMessage();
                        break;
                }
            } while (true);
        }
        static void Additional_1(ref StringBuilder data)
        {
            int cnt = 0;
            foreach (char i in data.ToString())
            {
                if (i == '(') cnt++;
                else if (i == ')') cnt--;
                if (cnt < 0) break;
            }
            if (!data.ToString().Contains('(') && !data.ToString().Contains(')')) Console.WriteLine("У рядку немає дужок!");
            else if (cnt != 0) Console.WriteLine("Дужки розставлені НЕ правильно!");
            else Console.WriteLine("Дужки розставлені правильно!");
        }
        static void Additional_2(ref StringBuilder data)
        {
            do
            {
                Console.WriteLine(
                    """
                    ------------------------------------------------------------------------------------------------------------------------
                                                                    ВИБІР ВАРІАНТУ ВИКОНАННЯ
                    ------------------------------------------------------------------------------------------------------------------------
                    1) За допомогою регулярних виразів.
                    2) Вручну, без використання регулярних виразів.
                    """);
                byte choiceBlock = Program.Choice(2);

                switch (choiceBlock)
                {
                    case 1:
                        WithRegex(ref data);
                        return;
                    case 2:
                        WithoutRegex(ref data);
                        return;
                    default:
                        Program.ShowProblemMessage();
                        break;
                }
            } while (true);
        }
        static void WithRegex(ref StringBuilder data)
        {
            string[] words = data.ToString().Split();
            Console.WriteLine("Введіть шаблон:");
            StringBuilder pattern = new StringBuilder(Console.ReadLine()!);
            pattern.Replace('?', '.');
            pattern.Replace("*", ".*");
            pattern.Insert(0, "^");
            pattern.Insert(pattern.Length, "$");
            Regex regex = new Regex(pattern.ToString());
            List<string> matchingWords = new List<string>();
            foreach (string word in words)
            {
                if (regex.IsMatch(word))
                {
                    matchingWords.Add(word);
                }
            }
            if (matchingWords.Count == 0) Console.WriteLine("В рядку немає слів, які задовольняють шаблон!");
            else Console.WriteLine(string.Join(" ", matchingWords));
        }
        static void WithoutRegex(ref StringBuilder data)
        {
            string[] words = data.ToString().Split();
            Console.WriteLine("Введіть шаблон:");
            string pattern = Console.ReadLine()!;
            List<string> matchingWords = new List<string>();

            foreach (string word in words)
            {
                int wIndex = 0, pIndex = 0;
                bool isMatch = true;

                while (wIndex < word.Length && pIndex < pattern.Length)
                {
                    if (pattern[pIndex] == '?')
                    {
                        wIndex++;
                        pIndex++;
                    }
                    else if (pattern[pIndex] == '*')
                    {
                        if (pIndex == pattern.Length - 1)
                        {
                            wIndex = word.Length; // Match the rest of the word
                        }
                        else
                        {
                            pIndex++;
                            while (wIndex < word.Length && word[wIndex] != pattern[pIndex])
                            {
                                wIndex++;
                            }
                        }
                    }
                    else
                    {
                        if (word[wIndex] != pattern[pIndex])
                        {
                            isMatch = false;
                            break;
                        }
                        wIndex++;
                        pIndex++;
                    }
                }

                if (isMatch && wIndex == word.Length && (pIndex == pattern.Length || (pIndex == pattern.Length - 1 && pattern[pIndex] == '*')))
                {
                    matchingWords.Add(word);
                }
            }

            if (matchingWords.Count == 0)
                Console.WriteLine("В рядку немає слів, які задовольняють шаблон!");
            else
                Console.WriteLine(string.Join(" ", matchingWords));
        }
    }
}
