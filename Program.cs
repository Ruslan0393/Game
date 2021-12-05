using System;
using System.IO;
using System.Linq;






namespace C_
{
    class Program
    {
        // Function for read random string word in txt file
        static string RandomText()
        {

            string textFile = File.ReadAllText(@"/home/ruslan/Desktop/Game/words.txt");
            string[] arr = textFile.Split(" ");
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, arr.Length);
            string randomString = arr[randomNumber];
            return randomString;
        }

        // Function for make hide word
        static char[] HideText(int length)
        {
            char[] hideString = new char[length];
            for (int i = 0; i < length; i++)
            {
                hideString[i] = '*';
            }
            return hideString;
        }

        // Check letter from random string
        static void CheckLetterInString(char[] orginalString, char[] hideString, char inputString, int[] count)
        {
            int no = 0;
            for (int i = 0; i < orginalString.Length; i++)
            {
                if (orginalString[i] == inputString)
                {
                    orginalString[i] = '!';
                    hideString[i] = inputString;
                    no = 1;
                }
            }
            if (no == 0)
            {
                System.Console.WriteLine("Oh no! Wrong answer");
                --count[0];
            }
            else {
                System.Console.WriteLine("Excellent. Right answer");
            }
        }

        // Chance function
        static void Chance(int[] count)
        {
            string element = "\x2764";
            string[] chance = Enumerable.Repeat(element, count[0]).ToArray();
            Console.Write("Chance: ");
            foreach (var i in chance) System.Console.Write(i);
            Console.WriteLine();
        }

        // The first game
        static void GameOne(char[] randomCharArray, char[] hideCharArray, string randomStr)
        {
            int[] count = { randomStr.Length };
            if (count[0] >= 9)
            {
                count[0] = 3 + count[0];
            }
            else if (count[0] >= 5)
            {
                count[0] = 5 + count[0];
            }
            else
            {
                count[0] = 8 + count[0];
            }

            while (true)
            {
                try
                {
                    Chance(count);
                    HideWord(hideCharArray);
                    Console.Write("Input:  ");
                    char inputLetter = char.Parse(Console.ReadLine());

                    if ((inputLetter >= 'a' && inputLetter <= 'z') || (inputLetter >= 'A' && inputLetter <= 'Z'))
                    {
                        CheckLetterInString(randomCharArray, hideCharArray, inputLetter, count);
                        Console.WriteLine("\n");

                        string str = new string(hideCharArray);
                        if (randomStr.Equals(str))
                        {
                            System.Console.WriteLine($"\t\t\tYou WIN\n\t\t\tRight letter is {randomStr}");
                            System.Console.WriteLine("\n\n\n");
                            break;
                        }
                        if (count[0] == 0)
                        {
                            System.Console.WriteLine($"\t\t\tYou lost\n\t\t\tRight letter is {randomStr}");
                            System.Console.WriteLine("\n\n\n");
                            break;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Please! Enter only letter");
                        Console.WriteLine("\n");
                    }


                }
                catch
                {
                    Console.WriteLine("Please! Enter only one letter");
                    System.Console.WriteLine("\n");
                }
            }
        }

        // Who the first start game
        static int WhoFirst()
        {
            string abc = Console.ReadLine();
            System.Console.WriteLine();
            if (RandomText().Length % 2 == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static void HideWord(char[] hideCharArray)
        {
            Console.Write("Word:   ");
            foreach (var i in hideCharArray)
            {
                Console.Write(i);
            }
            System.Console.WriteLine();
        }

        static char[] CharAlphabet(char[] alpha, char inpStr)
        {
            if (alpha.Contains(inpStr))
            {
                int index = Array.FindIndex(alpha, i => i.Equals(inpStr));
                char[] tempAlphabet = new string(alpha).Remove(index, 1).ToCharArray();
                alpha = tempAlphabet;
            }
            return alpha;
        }

        static void InputLetter(char[] randomCharArray, char[] hideCharArray, string randomStr, int a, int b)
        {
            int[] temp = { 1000 };
            if (a == 1 || a == 2)
            {
                if (a == 1)
                {
                    temp[0]--;
                }
                while (true)
                {
                    try
                    {
                        HideWord(hideCharArray);
                        if (temp[0] % 2 == 0)
                        {
                            Console.Write($"Eshmat enter your latter: ");
                        }
                        else
                        {
                            Console.Write($"Toshmat enter your latter: ");
                        }
                        char inputLetter = char.Parse(Console.ReadLine());
                        CheckLetterInString(randomCharArray, hideCharArray, inputLetter, temp);
                        Console.WriteLine("\n");
                        string str = new string(hideCharArray);
                        if (randomStr.Equals(str))
                        {
                            if (temp[0] % 2 == 0)
                            {
                                System.Console.WriteLine($"\t\t\tEshmat WIN\n\t\t\tWord: {randomStr}\n\n\n");
                                break;
                            }
                            else
                            {
                                System.Console.WriteLine($"\t\t\tToshmat WIN\n\t\t\tWord: {randomStr}");
                                System.Console.WriteLine();
                                break;
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please! Enter only one letter");
                        System.Console.WriteLine("\n");
                    }
                }
            }
            else if (a == 3 || a == 4)
            {
                char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                if (a == 3)
                {
                    --temp[0];
                }
                while (true)
                {
                    try
                    {
                        HideWord(hideCharArray);
                        if (temp[0] % 2 == 0)
                        {
                            Console.Write($"Enter your latter: ");
                            char inputLetter = char.Parse(Console.ReadLine());
                            alphabet = CharAlphabet(alphabet, inputLetter);
                            CheckLetterInString(randomCharArray, hideCharArray, inputLetter, temp);
                            Console.WriteLine("\n");
                            string str = new string(hideCharArray);
                            if (randomStr.Equals(str))
                            {
                                System.Console.WriteLine($"\t\t\tYou WIN\n\t\t\tWord: {randomStr}");
                                System.Console.WriteLine("\n\n\n");
                                break;
                            }
                        }
                        else
                        {
                            
                            Console.Write("Letter entered by computer: ");
                            Random rand = new Random();
                            int randomIndex = rand.Next(0, alphabet.Length);
                            char randomIndexLetter = alphabet[randomIndex];
                            for(long l=0; l<799000000; l++){
                            }
                            Console.WriteLine(randomIndexLetter);
                            alphabet = CharAlphabet(alphabet, randomIndexLetter);
                            CheckLetterInString(randomCharArray, hideCharArray, randomIndexLetter, temp);
                            Console.WriteLine("\n");

                            string str = new string(hideCharArray);
                            if (randomStr.Equals(str))
                            {   
                                System.Console.WriteLine($"\t\t\tComputer WIN\n\t\t\tWord: {randomStr}");
                                System.Console.WriteLine("\n\n\n");
                                break;
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please! Enter only one letter");
                        System.Console.WriteLine("\n");
                    }
                }
            }
        }

        // The second game
        static void GameTwo(char[] randomCharArray, char[] hideCharArray, string randomStr, int a, int b)
        {
            int whoFirst = WhoFirst();
            if (whoFirst == 1)
            {
                InputLetter(randomCharArray, hideCharArray, randomStr, a, b);
            }
            else
            {
                InputLetter(randomCharArray, hideCharArray, randomStr, b, a);
            }
        }

        // Main function
        static void Main()
        {
            while (true)
            {
                string randomString = RandomText();
                char[] randomStringCharArray = randomString.ToCharArray();
                char[] hideCharArray = HideText(randomString.Length);


                System.Console.WriteLine("\t\t\tWelcome to \"Random Words World\" game\n\t\t\t1 - Play with yourself\n\t\t\t2 - Play with your friend\n\t\t\t3 - Play with computer\n\t\t\t0 - Exit");
                int chooseGame = Convert.ToInt32(Console.ReadLine());
                System.Console.WriteLine();


                if (chooseGame == 1)
                {

                    GameOne(randomStringCharArray, hideCharArray, randomString);
                }
                else if (chooseGame == 2)
                {
                    System.Console.WriteLine("\"Eshmat\" or \"Toshmat\"");
                    System.Console.Write("Choose one person and enter anyone letter: ");
                    GameTwo(randomStringCharArray, hideCharArray, randomString, 1, 2);
                }
                else if (chooseGame == 3)
                {
                    System.Console.WriteLine("The computer itself determines who should start first");
                    System.Console.Write("Enter anyone letter: ");
                    GameTwo(randomStringCharArray, hideCharArray, randomString, 3, 4);
                }
                else if (chooseGame == 0)
                {
                    System.Console.WriteLine("Thanks you");
                    break;
                }
                else
                {
                    Console.BackgroundColor=ConsoleColor.DarkYellow;
                    System.Console.WriteLine("Wronge! This command doesn't exist ");
                    Console.ResetColor();
                }

            }
        }
    }
}