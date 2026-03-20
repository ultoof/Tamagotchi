
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

//-- Variables
Pet pet = new Pet();
Random random = new Random();

//-- Functions

// Prompts the user to press anykey and waits using ReadKey().
void PressAnyKey()
{
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.Write("\n> Press any key: ");
    Console.ReadKey();
    Console.ForegroundColor = ConsoleColor.White;
}

// A method thats used when the user inputs something invalid.
void ShowInvalidInput()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("Invalid Input, Press any key: ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.ReadKey();
}

void ShowNotEnoughMoney()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("You don't have enough money for this.");
    PressAnyKey();
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
    Console.Write($"Here are '{pet.name}'s stats:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"\n\nName: '{pet.name}'\nAge: {pet.age} days\nMoney: {pet.money}$\nMood: {pet.mood}/100 ({moodText})\nEnergy: {pet.energy}/100 ({energyText})\nFood: {pet.food}/100 ({foodText})\nStatus Effects: None");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\nHere are the actions you can take:\n\n[1] Play\n[2] Feed\n[3] Shop\n[4] Work\n[5] Exit Game");
}

// Show the exit tab
void ExitGame()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Do you want to save your data? [y/n]");
        string input = WaitForInput().ToLower();

        if (input == "y")
        {
            string ConvertedData = JsonConvert.SerializeObject(pet);
            File.WriteAllText("Data", ConvertedData);

            Console.Clear();
            Console.WriteLine("Data Saved!");
            PressAnyKey();
            break;
        }
        else if (input == "n")
        {
            Console.Clear();
            Console.WriteLine("Data has not been saved.");
            PressAnyKey();
            break;
        }
        else
        {
            ShowInvalidInput();
        }
    }
    Console.Clear();
}

// Opening scene for naming the tamagotchi
void Opening()
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
}

// The shop scene and logic
void Shop()
{
    while (true)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Shop:\nHere are the items you can purchase:\n\nCurrent Money: {pet.money}$\n");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("[1] 50$ - Magical Potion of Wonderous Joy (+25 Mood)\n[2] 25$ - Sugar Cane (+15 Energy)\n[3] 500$ - Big Money Plans (2x Money Multiplier)\n[4] 500$ - Narcolepsy (2x Energy Multiplier)\n[5] 500$ - Deepwoken Carnivore (2x Food Multiplier)");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("[6] Return To Menu");

        string input = WaitForInput();
        switch (input)
        {
            case "1":
                if (pet.money >= 50)
                {
                    pet.money -= 50;
                    pet.ChangeMood(25);
                }
                else
                {
                    ShowNotEnoughMoney();
                }
                break;
            case "2":
                if (pet.money >= 25)
                {
                    pet.money -= 25;
                    pet.ChangeEnergy(15);
                }
                else
                {
                    ShowNotEnoughMoney();
                }
                break;
            case "3":
                if (pet.moneyMultiplier == 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This upgrade is sold out :(");
                    PressAnyKey();
                }
                else if (pet.money >= 500)
                {
                    pet.moneyMultiplier = 2;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{pet.name} now gains 2x the money");
                    PressAnyKey();
                }
                else
                {
                    ShowNotEnoughMoney();
                }
                break;
            case "4":
                if (pet.energyMultiplier == 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This upgrade is sold out :(");
                    PressAnyKey();
                }
                else if (pet.money >= 500)
                {
                    pet.energyMultiplier = 2;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{pet.name} now gains 2x the energy");
                    PressAnyKey();
                }
                else
                {
                    ShowNotEnoughMoney();
                }
                break;
            case "5":
                if (pet.foodMultiplier == 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This upgrade is sold out :(");
                    PressAnyKey();
                }
                else if (pet.money >= 500)
                {
                    pet.foodMultiplier = 2;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{pet.name} now gains 2x the food");
                    PressAnyKey();
                }
                else
                {
                    ShowNotEnoughMoney();
                }
                break;
            case "6":
                return;
            default:
                ShowInvalidInput();
                break;
        }
    }
}

// Starts the game loop + opening cutscene
void StartGame()
{
    if (File.Exists("Data"))
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Existing game data found. Do you want to load it? [y/n]");
            string input = WaitForInput().ToLower();

            if (input == "y")
            {
                string Data = File.ReadAllText("Data");
                pet = JsonConvert.DeserializeObject<Pet>(Data);

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Your tamagotchi '{pet.name}' has been loaded!");
                PressAnyKey();
                break;
            }
            else if (input == "n")
            {
                Opening();
                break;
            }
            else
            {
                ShowInvalidInput();
            }
        }
    }
    else
    {
        Opening();
    }

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
                Shop();
                break;
            case "4":
                break;
            case "5":
                ExitGame();
                return;
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
    public int difficulty = 10;
    public string name = "John";

    // Multipliers
    public float moneyMultiplier = 1f;
    public float energyMultiplier = 1f;
    public float foodMultiplier = 1f;

    // Methods
    public void ChangeFood(int value)
    {
        ConsoleColor color = value >= 0 ? ConsoleColor.Green : ConsoleColor.Red;
        float newMulti = value >= 0 ? foodMultiplier : 1;

        food += value*newMulti;
        food = Math.Clamp(food, 0, 100);
        Console.Clear();
        Console.ForegroundColor = color;
        Console.WriteLine($"{name}'s food changed by {value*newMulti}. Food is now {food}.");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("\n> Press any key: ");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void ChangeMood(int value)
    {
        ConsoleColor color = value >= 0 ? ConsoleColor.Green : ConsoleColor.Red;

        mood += value;
        mood = Math.Clamp(mood, 0, 100);
        Console.Clear();
        Console.ForegroundColor = color;
        Console.WriteLine($"{name}'s mood changed by {value}. Mood is now {mood}.");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("\n> Press any key: ");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void ChangeEnergy(int value)
    {
        ConsoleColor color = value >= 0 ? ConsoleColor.Green : ConsoleColor.Red;
        float newMulti = value >= 0 ? energyMultiplier : 1;

        energy += value*newMulti;
        energy = Math.Clamp(energy, 0, 100);
        Console.Clear();
        Console.ForegroundColor = color;
        Console.WriteLine($"{name}'s energy changed by {value*newMulti}. Energy is now {energy}.");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("\n> Press any key: ");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void ChangeMoney(int value)
    {
        money += money * moneyMultiplier;
    }

    public void NextDay()
    {
        age++;
        energy -= 20 * (1 + age / difficulty);
        food -= 20 * (1 + age / difficulty);
        mood -= 20 * (1 + age / difficulty);
    }
}