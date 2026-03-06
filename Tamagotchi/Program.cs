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

void StartGame()
{
    Console.Clear();
    Console.WriteLine("Let's start by giving your new friend a name!");
    pet.name = WaitForInput();

    Console.Clear();
    Console.WriteLine($"{pet.name}... What a great name!");
    PressAnyKey();

    Console.Clear();
    Console.WriteLine($"You will need to take care of {pet.name}. Make sure he doesn't die, and make sure they have fun!");
    PressAnyKey();

    Console.Clear();
    Console.WriteLine("Now let's get into it.");
    PressAnyKey();

    while (true){
        ShowMainMenu();
        WaitForInput();
    }
}

void ShowMainMenu(){
    Console.Clear();
    Console.WriteLine($"");
}

//-- Runtime
StartGame();

//-- Classes

class Pet
{
    // Stats
    public float food = 100f;
    public float mood = 100f;
    public float energy = 100f;
    public float money = 50f;
    public int age = 0;
    public string name = "John";

    // Multipliers
    public float moneyMultiplier = 1f;
    public float energyMultiplier = 1f;
    public float foodMultiplier = 1f;

    // Methods
    public void ChangeFood(int value)
    {
        food += value;
    }

    public void ChangeMood(int value)
    {
        mood += value;
    }

    public void ChangeEnergy(int value)
    {
        energy += value;
    }

    public void NextDay()
    {
        age++;
        energy -= 20 * (1 + age/10);
        food -= 20 * (1 + age/10);
        mood -= 20 * (1 + age/10);
    }
}