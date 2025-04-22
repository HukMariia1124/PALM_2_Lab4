using System.Data.Common;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab4
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            byte choiceBlock;
            StringBuilder data = new StringBuilder();
            do
            {
                Console.WriteLine(
                    """
                    ------------------------------------------------------------------------------------------------------------------------
                                                                         ВИБІР ЗАВДАННЯ
                    ------------------------------------------------------------------------------------------------------------------------
                    ЗАВДАННЯ #1:
                    1) MakscoldSolution.
                    2) MariiaSolution.
                    3) JenlastSolution.
                    ЗАВДАННЯ #2:
                    4) Сформувати рядок з цифр (за зростанням) та латинських літер (за спаданням) з вихідного рядка, ігноруючи інші символи.
                    5) Реалізувати шифрування та дешифрування класичним шифром Цезаря.
                    6) Кожен символ '+' у рядку замінити на символ '-', якщо перед '+' стоїть непарна цифра.
                    ДОДАТКОВІ ЗАВДАННЯ:
                    7) MakscoldSolution.
                    8) MariiaSolution.
                    9) JenlastSolution.
                    0) Вийти з програми
                    """);

                choiceBlock = Choice(9);

                switch (choiceBlock)
                {
                    case 1:
                        MakscoldSolution.Task_1();
                        break;
                    case 2:
                        MariiaSolution.Task_1();
                        break;
                    case 3:
                        Jenlast_Solution.Task_1();
                        break;
                    case 4:
                        MakscoldSolution.Task_2();
                        break;
                    case 5:
                        MariiaSolution.Task_2_Form_12(ref data);
                        break;
                    case 6:
                        Jenlast_Solution.Task_2_Form_7(ref data);
                        break;
                    case 7:
                        MakscoldSolution.Task_3();
                        break;
                    case 8:
                        MariiaSolution.Additional(ref data);
                        break;
                    case 9:
                        Jenlast_Solution.Additional(ref data);
                        break;
                    case 0:
                        break;
                    default:
                        ShowProblemMessage();
                        break;
                }
            } while (choiceBlock!=0);
        }
        public static byte Choice(byte countOfBlocks = 9)
        {
            byte choice;
            do
            {
                try
                {
                    choice = byte.Parse(Console.ReadLine()!);
                    if (choice <= countOfBlocks) return choice;
                    ShowProblemMessage();
                }
                catch { ShowProblemMessage(); }
            } while (true);
        }
        public static void ShowProblemMessage() => Console.WriteLine("Спробуйте ще раз");
        public static void AskForNewString(ref StringBuilder data)
        {
            if (data.Length != 0)
            {
                Console.WriteLine(
                    $"""
                    Ваш рядок зараз: {data}
                    Ввести новий?
                    1) Так
                    2) Ні
                    """);

                do
                {
                    try
                    {
                        byte input = byte.Parse(Console.ReadLine()!);
                        if (input == 1)
                        {
                            InputNewString(ref data);
                            return;
                        }
                        else if (input == 2) return;
                        else ShowProblemMessage();
                    }
                    catch
                    {
                        ShowProblemMessage();
                    }
                }
                while (true);
            }
            else
            {
                InputNewString(ref data);
                return;
            }
        }
        public static void InputNewString(ref StringBuilder data)
        {
            data.Clear();
            Console.WriteLine("Введіть новий рядок:");
            data.Append(Console.ReadLine());
        }
    }
}