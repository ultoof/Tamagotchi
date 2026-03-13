
using Newtonsoft.Json;

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
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Invalid Input, Press any key");
    Console.ForegroundColor = ConsoleColor.White;
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

// Shows the main menu which displays alot of stats about the pet
void ShowMainMenu()
{
    string moodText = pet.mood >= 50 ? "Happy" : "Sad";
    string energyText = pet.energy >= 50 ? "Energetic" : "Tired";
    string foodText = pet.food >= 50 ? "Satiated" : "Hungry";

    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"Here are {pet.name}'s stats:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"\n\nName: '{pet.name}'\nAge: {pet.age} days\nMoney: {pet.money}$\nMood: {pet.mood} ({moodText})\nEnergy: {pet.energy} ({energyText})\nFood: {pet.food} ({foodText})");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\nHere are the actions you can take:\n\n[1] Play\n[2] Feed\n[3] Shop\n[4] Work\n[5] Exit Game");
}

// Starts the game loop + opening cutscene
void StartGame()
{
    Console.Clear();
    Console.WriteLine("Let's start by giving your new friend a name!");
    pet.name = WaitForInput();

    Console.Clear();
    Console.WriteLine($"{pet.name}... What a great name!");
    PressAnyKey();

    Console.Clear();
    Console.WriteLine($"You will need to take care of {pet.name}. So they don't die and stuff, and make sure they have fun!");
    PressAnyKey();

    Console.Clear();
    Console.WriteLine("Now let's get into it...");
    PressAnyKey();

    while (true)
    {
        ShowMainMenu();
        string input = WaitForInput();

        switch (input)
        {
            case "1":
                break;
            case "2":
                break;
            case "3":
                break;
            case "4":
                break;
            case "5":
                break;
            default:
                ShowInvalidInput();
                break;
        }
    }
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
        food = Math.Clamp(food, 0, 100);
    }

    public void ChangeMood(int value)
    {
        mood += value;
        mood = Math.Clamp(mood, 0, 100);
    }

    public void ChangeEnergy(int value)
    {
        energy += value;
        energy = Math.Clamp(energy, 0, 100);
    }

    public void NextDay()
    {
        age++;
        energy -= 20 * (1 + age/10);
        food -= 20 * (1 + age/10);
        mood -= 20 * (1 + age/10);
    }
}