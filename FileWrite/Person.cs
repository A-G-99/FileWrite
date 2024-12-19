using System.Globalization;
using System.Text.RegularExpressions;

namespace FileWrite
{
    internal class Person : Information
    {
        public static void intro()
        {
            Console.WriteLine("Hello please answer the questions in the format given by the prompt!");
        }

        public static void prompt_firstname()
        {
            Console.WriteLine("What is your first name? Ex. John");
        }

        public static void prompt_spouse_firstname()
        {
            Console.WriteLine("What is your spouse's first name? Ex. John");
        }

        public static void prompt_lastname()
        {
            Console.WriteLine("What is your last name? Ex. Doe");
        }

        public static void prompt_spouse_lastname()
        {
            Console.WriteLine("What is your spouse's last name? Ex. Doe");
        }

        public static void prompt_birthday()
        {
            Console.WriteLine("What is your date of birth? month/day/year ex. 1/4/1999");
        }

        public static void prompt_spouse_birthday()
        {
            Console.WriteLine("What is your spouse's date of birth? month/day/year ex. 1/4/1999");
        }


        public string check_firstname()
        {
            string firstname = null;
            while (firstname == null)
            {
                try
                {
                    firstname = Console.ReadLine();
                    if (!Regex.IsMatch(firstname, @"^[a-zA-Z]+$")) // If we have anything other than letters
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    firstname = null;
                    Console.WriteLine("Error Processing name. Invalid character/format found. Please reinput.");
                }
            }

            return firstname.ToUpper();
        }

        public string check_lastname()
        {
            string lastname = null;
            while (lastname == null)
            {
                try
                {
                    lastname = Console.ReadLine();
                    if (!Regex.IsMatch(lastname, @"^[a-zA-Z]+$")) // If we have anything other than letters
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    lastname = null;
                    Console.WriteLine("Error Processing name. Invalid character/format found. Please reinput.");
                }
            }

            return lastname.ToUpper();
        }

        public DateTime check_birthday()
        {
            DateTime birthday = DateTime.MaxValue;
            while (birthday > DateTime.Today)
            {
                try
                {
                    CultureInfo enUS = new CultureInfo("en-US");
                    
                    var temp = Console.ReadLine();
                    birthday = DateTime.Parse(temp);

                    // Date format check
                    bool pass = DateTime.TryParseExact(temp, "d/M/yy", enUS, DateTimeStyles.AllowLeadingWhite, out DateTime a);
                    // Console.WriteLine(pass); // Debugging

                    if (birthday > DateTime.Today || !pass)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    birthday = DateTime.MaxValue;
                    Console.WriteLine("Error Processing date. Invalid character/format/date > today found. Please reinput.");
                }
            }

            return birthday;
        }

        public bool check_age()
        {
            int age = GetAgeYear();
            if (age < 16)
            {
                Console.WriteLine("Sorry anyone younger than 16 years of age is unable to register. :(");
                return false;
            }
            else if (age < 18)
            {
                Console.WriteLine("Due to being under 18, do your parents allow registration? y/n");
                string parental_consent = Console.ReadLine();
                while (!parental_consent.Equals("y") && !parental_consent.Equals("n"))
                {
                    Console.WriteLine("Error Processing Parental Consent. Invalid character/format. Please reinput.");
                    Console.WriteLine("Due to being under 18, do your parents allow registration? y/n"); 
                    parental_consent = Console.ReadLine();
                }
                if (parental_consent.Equals("n"))
                {
                    Console.WriteLine("Sorry parental consent required to register. :(");
                    return false;
                }
            }

            return true;
        }

        public bool check_marriage()
        {
            Console.WriteLine("Are you married? ex. y/n");
            string ans = Console.ReadLine();
            while (!ans.Equals("y") && !ans.Equals("n"))
            {
                Console.WriteLine("Error Processing marriage. Invalid character/format. Please reinput.");
                Console.WriteLine("Are you married? ex. y/n");
                ans = Console.ReadLine();
            }
            if (ans.Equals("y"))
            {
                return true;
            }
            return false;
        }
    }
}
