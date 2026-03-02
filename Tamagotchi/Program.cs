//-- Variables
Pet pet = new Pet();
Random random = new Random();

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

class Pet
{
    // Stats
    public float food = 100f;
    public float mood = 100f;
    public float energy = 100f;
    public int age = 0;
    public float money = 50f;

    // Multipliers
    public float moneyMultiplier = 1f;
    public float energyMultiplier = 1f;
    public float foodMultiplier = 1f;

    // Methods
    public void changeFood(int value)
    {
        food += value;
    }

    public void changeMood(int value)
    {
        mood += value;
    }

    public void changeEnergy(int value)
    {
        energy += value;
    }

    public void nextDay()
    {
        age++;
        energy -= 20;
        food -= 20;
        mood -= 20;
    }
}