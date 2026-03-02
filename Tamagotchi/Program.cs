//-- Variables

//-- Functions

// Prompts the user to press anykey and waits using ReadKey().
void PressAnyKey()
{
    Console.Write("\n> Press any key:");
    Console.ReadKey();
}

// A method thats used when the user inputs something invalid.
void ShowInvalidInput()
{
    Console.Clear();
    Console.WriteLine("Invalid Input, Press any key");
    Console.ReadKey();
}

// Waits for a user input with some fancy colors.
string WaitForInput()
{
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.Write("\n> Input: ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    string inputedString = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.White;
    return inputedString;
}

//-- Runtime

//-- Classes