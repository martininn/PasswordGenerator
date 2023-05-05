namespace PasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                ShowMenu();
                return;
            }
            
            if (IsArgumentsValid(args))
            {
                Console.WriteLine(PasswordGenerating(args));
            }
            else
            {
                ShowMenu();
            }
        }

        

        static bool IsArgumentsValid(string[] args)
        {
            var passwordLength = args[0];
            foreach (var character in passwordLength)
            {
                var isdigit = char.IsDigit(character);
                if (isdigit == false)
                {
                    return false;
                }
            }
            var options = args[1];
            foreach (var character in options)
            {
                if (character is not ('l' or 'L' or 'd' or 's'))
                {
                    return false;
                }
            }
            return true;
        }

        static void ShowMenu()
        {
            var menustring = @"PasswordGenerator
                    Options:
                    -l = lower case letter
                    - L = upper case letter
                    - d = digit
                    - s = special character (!""#¤%&/(){}[]
                 Example: PasswordGenerator 14 lLssdd
                            Min. 1 lower case
                            Min. 1 upper case
                            Min. 2 special characters
                            Min. 2 digits";

            Console.WriteLine(menustring);
        }

        private static string PasswordGenerating(string[] args)
        {
            var password = string.Empty;
            var number = Convert.ToInt32(args[0]);
            foreach (var character in args[1])
            {
                if (character == 'l') password += GetRandomLowerCaseLetter();
                if (character == 'L') password += GetRandomUpperCaseLetter();
                if (character == 's') password += GetRandomSpecialCharacter();
                if (character == 'd') password += GetRandomDigit();
            }

            while (password.Length != number)
            {
                var rdm = new Random().Next(0,4);
                if (rdm == 0) password += GetRandomLowerCaseLetter();
                if (rdm == 1) password += GetRandomUpperCaseLetter();
                if (rdm == 2) password += GetRandomSpecialCharacter();
                if (rdm == 3) password += GetRandomDigit();
            }
            return password;
        }

        private static char GetRandomSpecialCharacter()
        {
            const string tekst = "(!\"#¤%&/(){}[]";
            var randomSpecial = new Random().Next(0, tekst.Length);
            return tekst[randomSpecial];
        }
        private static char GetRandomDigit()
        {
            return new Random().Next(0, 10).ToString()[0];
        }

        private static char GetRandomUpperCaseLetter()
        {
            return GetRandomLetter('A', 'Z');
        }
        private static char GetRandomLowerCaseLetter()
        {
            return GetRandomLetter('a', 'z');
        }

        private static char GetRandomLetter(char min, char max)
        {
            return (char)new Random().Next(min, max);
        }
    }
}