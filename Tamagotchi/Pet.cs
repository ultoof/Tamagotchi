namespace PetLibrary;

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
    public void ChangeFood(float value)
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

    public void ChangeMood(float value)
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

    public void ChangeEnergy(float value)
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

    public void ChangeMoney(float value)
    {
        ConsoleColor color = value >= 0 ? ConsoleColor.Green : ConsoleColor.Red;
        float newMulti = value >= 0 ? moneyMultiplier : 1;

        money += value*newMulti;
        Console.Clear();
        Console.ForegroundColor = color;
        Console.WriteLine($"{name} has earned {value*newMulti}$! Total money is now {money}.");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("\n> Press any key: ");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Advances to the next day and removes food, the more days that have gone by, the more food is removed. Caps at 50 food.
    public void NextDay()
    {
        age++;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{name} sleeps through the night...");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("\n> Press any key: ");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
    
        ChangeFood(MathF.Round(-Math.Clamp(20f * (1 + age / 100),0f,50f)));
    }
}