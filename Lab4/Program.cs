namespace Lab4
{
    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
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

                byte choiceBlock = Choice(6);

                switch (choiceBlock)
                {
                    case 1:
                        //MakscoldSolution.Task_1();
                        break;
                    case 2:
                        MariiaSolution.Task_1();
                        break;
                    case 3:
                        //Jenlast_Solution.Task_1();
                        break;
                    case 4:
                        //MakscoldSolution.Task_2_Form_10();
                        break;
                    case 5:
                        //MariiaSolution.Task_2_Form_12();
                        break;
                    case 6:
                        //Jenlast_Solution.Task_2_Form_7();
                        break;
                    case 7:
                        //MakscoldSolution.Additional();
                        break;
                    case 8:
                        //MariiaSolution.Additional();
                        break;
                    case 9:
                        //Jenlast_Solution.Additional();
                        break;
                    default:
                        ShowProblemMessage();
                        break;
                }
            } while (true);
        }
        public static byte Choice(byte countOfBlocks = 6)
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
    }
}
