namespace FileWrite
{
    abstract class Information
    {
        public Information() // default constructor
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Birthday = DateTime.MinValue;
            Married = false;
        }

        public Information(string firstName, string lastName, DateTime birthday, bool married)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
            this.Married = married;
        }

        private string firstName;
        private string lastName;
        private DateTime birthday;
        private bool married;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public bool Married { get => married; set => married = value; }

        public int GetAgeYear()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - this.birthday.Year;
            if (this.birthday.Date > today.AddYears(-age)) // leap year
            {
                age--;
            }
            return age;
        }

        public void print()
        {
            Console.WriteLine($"{firstName}|{lastName}|{birthday:MM-dd-yy}|{married}");
        }
    }
}
