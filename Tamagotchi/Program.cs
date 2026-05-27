using PetLibrary;
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

// Method used for showing the user when they don't have enough money
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
    Console.WriteLine("A cat magically appears in front of you! Give it a name...");
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
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Shop:\nHere are the items you can purchase:\n\nCurrent Money: {pet.money}$\n{pet.energy}/100 Energy\n{pet.food}/100 Food\n{pet.mood}/100 Mood\n");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"[1] 50$ - Magical Potion of Wonderous Joy (+25 Mood)\n[2] 25$ - Sugar Cane (+{15 * pet.energyMultiplier} Energy)\n[3] 500$ - Big Money Plans (2x Money Multiplier)\n[4] 500$ - Sleepy Cat Syndrome (2x Energy Multiplier)\n[5] 500$ - True Glutton Cat (2x Food Multiplier)");
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
                    pet.money -= 500;
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
                    pet.money -= 500;
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
                    pet.money -= 500;
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

void Work()
{
    while (true)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Work:\nHere are the jobs {pet.name} can do:\n\nCurrent Money: {pet.money}$\n{pet.energy}/100 Energy\n{pet.food}/100 Food\n{pet.mood}/100 Mood\n");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"[1] Mouse Hunting (+{35 * pet.moneyMultiplier}$, +10 Food -15 Energy)\n[2] Market Manipulation (+{100 * pet.moneyMultiplier}$, -20 Energy, -10 Mood)\n[3] To The Mines! (+{200 * pet.moneyMultiplier}$ ,-50 Energy)");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("[4] Return To Menu");

        string input = WaitForInput();

        switch (input)
        {
            case "1":
                pet.ChangeMoney(35);
                pet.ChangeFood(10);
                pet.ChangeEnergy(-15);
                pet.NextDay();
                return;
            case "2":
                pet.ChangeMoney(100);
                pet.ChangeEnergy(-20);
                pet.ChangeMood(-10);
                pet.NextDay();
                return;
            case "3":
                pet.ChangeMoney(200);
                pet.ChangeEnergy(-50);
                pet.NextDay();
                return;
            case "4":
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
        if (pet.dead)
        {
            break;
        }
        else
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
                    Work();
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
}

//-- Runtime
StartGame();