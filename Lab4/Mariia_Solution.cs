using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
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
            int shift;
            while (!int.TryParse(Console.ReadLine(), out shift))
            {
                Program.ShowProblemMessage();
            }
            const string template = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            DisplayCipherTemplate(shift, template, Encrypt);
            Console.WriteLine($"Текст до шифрування: {data}");
            for (int i = 0; i < data.Length; i++)
            {
                int index = template.IndexOf(data[i]);
                if (index != -1)
                {
                    if (Encrypt)
                    {
                        if (index < 26 && index + shift >= 0) data[i] = template[(index + shift) % 26];
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

        private static void DisplayCipherTemplate(int shift, string template, bool Encrypt)
        {
            Console.WriteLine("Шаблон шмфрування:");
            Console.WriteLine("┌" + new string('─', 52) + "┐");
            Console.WriteLine("|" + template + "|");
            Console.WriteLine(new string('|', 54));
            if (Encrypt)
            {
                if (shift >= 0) Console.WriteLine("|" + template[shift..] + template[0..shift] + "|");
                else Console.WriteLine("|" + template.Substring(52 + shift, Math.Abs(shift)) + template.Substring(0, 52 + shift) + "|");
            }
            else
            {
                if (shift >= 0) Console.WriteLine("|" + template.Substring(52 - shift, Math.Abs(shift)) + template.Substring(0, 52 - shift) + "|");
                else Console.WriteLine("|" + template[Math.Abs(shift)..] + template[0..Math.Abs(shift)] + "|");
            }
            Console.WriteLine("└" + new string('─', 52) + "┘");
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
                    2) Знайдіть у рядку слова, що відповідають заданому шаблону, де '?' - будь-який один символ, а '*' — будь-який підрядок.
                    3) Замініть у рядку числа перед "м", "грн" на їх словесний еквівалент, узгодивши рід числівника та форму одиниці виміру.
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
                        Additional_3(ref data);
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
                            wIndex = word.Length;
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



        public enum Gender { Masculine, Feminine }
        static readonly string[] OnesMasculine = { "нуль", "один", "два", "три", "чотири", "п'ять", "шість", "сім", "вісім", "дев'ять" };
        static readonly string[] OnesFeminine = { "нуль", "одна", "дві", "три", "чотири", "п'ять", "шість", "сім", "вісім", "дев'ять" };
        static readonly string[] Teens = { "десять", "одинадцять", "дванадцять", "тринадцять", "чотирнадцять", "п'ятнадцять", "шістнадцять", "сімнадцять", "вісімнадцять", "дев'ятнадцять" };
        static readonly string[] Tens = { "", "десять", "двадцять", "тридцять", "сорок", "п'ятдесят", "шістдесят", "сімдесят", "вісімдесят", "дев'яносто" };
        static readonly string[] Hundreds = { "", "сто", "двісті", "триста", "чотириста", "п'ятсот", "шістсот", "сімсот", "вісімсот", "дев'ятсот" };
        static readonly string[] ThousandsForms = { "тисяча", "тисячі", "тисяч" };
        static readonly string[] MillionsForms = { "мільйон", "мільйони", "мільйонів" };
        static readonly string[] BillionsForms = { "мільярд", "мільярди" };

        static void Additional_3(ref StringBuilder data)
        {
            Console.WriteLine("Рядок до опрацювання: " + data);
            string pattern = @"([0-9]+)\s(м|грн)\b";

            //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.matchcollection?view=net-9.0
            MatchCollection matches = Regex.Matches(data.ToString(), pattern);

            for (int i = matches.Count - 1; i >= 0; i--)
            {
                //https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.match?view=net-9.0 (Example 1)
                //Групи захоплення дозволяють виділити частини тексту, які відповідають певним підшаблонам у регулярному виразі.
                //Вони визначаються круглими дужками() у шаблоні регулярного виразу. Кожна група отримує свій індекс, починаючи з 1(група 0 завжди представляє весь збіг).
                //Наш шаблон має дві групи захоплення:
                //1. ([0-9]+) — перша група, яка захоплює послідовність цифр(число).
                //2. (м | грн) — друга група, яка захоплює одиницю вимірювання: "м" або "грн".
                //Коли виконується метод Regex.Matches, він повертає колекцію об'єктів Match. Кожен об'єкт Match представляє один збіг у тексті.
                //У цьому об'єкті є властивість Groups, яка містить всі групи захоплення для цього збігу.
                //Value: Повертає текст, який був захоплений цією групою.
                Match match = matches[i];

                int number = int.Parse(match.Groups[1].Value);
                string unit = match.Groups[2].Value;
                Gender gender = unit.Equals("м") ? Gender.Masculine : Gender.Feminine;

                string numberInWords = ConvertNumberToWords(number, gender);
                string unitInWords = ConvertUnitToWord(number, gender);
                string replacement = $"{numberInWords} {unitInWords}";

                data = data.Replace(match.Value, replacement);
            }
            Console.WriteLine("Рядок після опрацювання: " + data);
        }
        static string ConvertNumberToWords(int number, Gender gender)
        {
            if (number == 0) return "нуль";

            StringBuilder words = new StringBuilder();
            int level = 0; // 0: одиниці, 1: тисячі, 2: мільйони, 3: мільярди
            while (number > 0)
            {
                int chunk = number % 1000;
                if (chunk > 0)
                {
                    string chunkWords = ConvertChunkToWords(chunk, level, gender);
                    string placeValueWord = PlaceValueWord(chunk, level);

                    if (words.Length > 0)
                    {
                        words.Insert(0, " ");
                    }
                    if (!string.IsNullOrEmpty(placeValueWord))
                    {
                        words.Insert(0, placeValueWord);
                        words.Insert(0, " ");
                    }
                    words.Insert(0, chunkWords);
                }
                number /= 1000;
                level++;
            }
            return words.ToString();
        }
        static string ConvertChunkToWords(int chunk, int level, Gender gender)
        {
            List<string> parts = new List<string>();

            if (level == 1) // Тисячі - жіночий рід
            {
                gender = Gender.Feminine;
            }
            else if (level > 1) // Мільйони, мільярди - чоловічий рід
            {
                gender = Gender.Masculine;
            }

            int hundredsDigit = chunk / 100;
            if (hundredsDigit > 0)
            {
                parts.Add(Hundreds[hundredsDigit]);
            }

            int tensAndOnes = chunk % 100;
            if (tensAndOnes > 0)
            {
                if (tensAndOnes < 10)
                {
                    parts.Add(gender == Gender.Feminine ? OnesFeminine[tensAndOnes] : OnesMasculine[tensAndOnes]);
                }
                else if (tensAndOnes < 20)
                {
                    parts.Add(Teens[tensAndOnes - 10]);
                }
                else
                {
                    parts.Add(Tens[tensAndOnes / 10]);
                    int unitsDigit = tensAndOnes % 10;
                    if (unitsDigit > 0)
                    {
                        parts.Add(gender == Gender.Feminine ? OnesFeminine[unitsDigit] : OnesMasculine[unitsDigit]);
                    }
                }
            }

            return string.Join(" ", parts);
        }
        static string PlaceValueWord(int chunkValue, int level)
        {
            if (level == 0) return "";

            string[] forms;
            switch (level)
            {
                case 1: forms = ThousandsForms; break;
                case 2: forms = MillionsForms; break;
                case 3: forms = BillionsForms; break;
                default: return "";
            }

            int lastDigit = chunkValue % 10;
            int lastTwoDigits = chunkValue % 100;

            if (lastTwoDigits >= 11 && lastTwoDigits <= 19)
            {
                return forms[2];
            }
            switch (lastDigit)
            {
                case 1: return forms[0];
                case 2:
                case 3:
                case 4: return forms[1];
                default: return forms[2];
            }
        }
        static string ConvertUnitToWord(int number, Gender gender)
        {
            int lastDigit = number % 10;
            int lastTwoDigits = number % 100;

            bool isTeen = lastTwoDigits >= 11 && lastTwoDigits <= 19;

            if (gender == Gender.Masculine)
            {
                if (isTeen) return "метрів";
                switch (lastDigit)
                {
                    //Якщо значення lastDigit дорівнює 2, 3 або 4, виконання перейде до наступного блоку з кодом, тобто return "метри";.
                    //Це називається fall-through і дозволяє об'єднати кілька умов в один блок коду.
                    case 1: return "метр";
                    case 2:
                    case 3:
                    case 4: return "метри";
                    default: return "метрів";
                }
            }
            else
            {
                if (isTeen) return "гривень";
                switch (lastDigit)
                {
                    case 1: return "гривня";
                    case 2:
                    case 3:
                    case 4: return "гривні";
                    default: return "гривень";
                }
            }
        }
    }
}