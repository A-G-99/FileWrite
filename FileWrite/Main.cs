using FileWrite;

const string path = @"..\\people\\people.txt";
const string spouse_path = @"..\\people\\spouse\\";

Person person = new Person(); // current person

// Intro
Person.intro();

// Firstname
Person.prompt_firstname();
person.FirstName = person.check_firstname();

// Lastname
Person.prompt_lastname();
person.LastName = person.check_lastname();

// Birthday
Person.prompt_birthday();
person.Birthday = person.check_birthday();

// Age Checks
if (!person.check_age())
{
    ending();
}

// Married
person.Married = person.check_marriage();

Person spouse = new Person(); // Spouse
if (person.Married) {
    // Obtain all the info and link accordingly
    Console.WriteLine("Please provide your spouse details:");

    // Spouse firstname
    Person.prompt_spouse_firstname();
    spouse.FirstName = spouse.check_firstname();
  
    // Spouse lastname
    Person.prompt_spouse_lastname();
    spouse.LastName = spouse.check_lastname();

    // Spouse birthday
    Person.prompt_spouse_birthday();
    spouse.Birthday = spouse.check_birthday();

    // Married = True
    spouse.Married = true;
}

// Debugging
//person.print();
//spouse.print();

// Writing to file
try
{
    // Ensure directory exists
    string directory = Path.GetDirectoryName(path);
    string main_text = $"{person.FirstName}|{person.LastName}|{person.Birthday:MM-dd-yy}|{person.Married}|"; // String Interpolation
    
    // Spouse File
    string spouse_text;
    string spouseFileName;
    if (person.Married)
    {
        if (!Directory.Exists(spouse_path))
        {
            Directory.CreateDirectory(spouse_path);
        }

        spouse_text = $"{spouse.FirstName}|{spouse.LastName}|{spouse.Birthday:MM-dd-yy}|{spouse.Married}|"; // String Interpolation
        spouseFileName = spouse_path + $"{spouse.FirstName}.txt";
        int i = 0;

        // Adding suffix to wife name
        while (File.Exists(spouseFileName))
        {
            spouseFileName = spouse_path + $"{spouse.FirstName}" + "(" + $"{i}" + ")" + ".txt";
            i++;
        }

        // Create the file if it doesn't exist
        using (FileStream fs = File.Create(spouseFileName))
        {
            // File created and closed
        }
        // Console.WriteLine("Created path"); // Debugging
        using (TextWriter tw = new StreamWriter(spouseFileName))
        {
            tw.WriteLine(spouse_text);
        }

        // Updating main info file
        main_text += Path.GetFullPath(spouseFileName);
    }

    if (!Directory.Exists(directory))
    {
        Directory.CreateDirectory(directory);
    }

    // Check if file exists
    if (!File.Exists(path))
    {
        // Create the file if it doesn't exist
        using (FileStream fs = File.Create(path))
        {
            // File created and closed
        }
        // Console.WriteLine("Created path"); // Debugging
        using (TextWriter tw = new StreamWriter(path))
        {
            tw.WriteLine(main_text);
        }
    }
    else
    {
        // Append to the file if it exists
        using (StreamWriter sw = new StreamWriter(path, true))
        {
            sw.WriteLine(main_text);
        }
    }

    Console.WriteLine(main_text);
    ending();
}
catch (Exception e)
{
    Console.WriteLine($"Error Writing to File! {e.Message}");
}

void ending()
{
    Console.WriteLine("Thank you for your time!");
    Environment.Exit(1);
}