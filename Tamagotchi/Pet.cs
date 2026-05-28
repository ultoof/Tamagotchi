namespace PetLibrary;

// This is the class for the pet
// The pet has multiple stats, methods and logic checks. To make sure nothing breaks!
class Pet
{
    // Stats
    public float food = 100f;
    public float mood = 100f;
    public float energy = 100f;
    public float money = 50f;
    public int age = 0;
    public string name = "John";
    public bool dead = false;

    // Multipliers
    public float moneyMultiplier = 1f;
    public float energyMultiplier = 1f;
    public float foodMultiplier = 1f;

    // Methods
    // Kills the pet
    private void Die(string deathMessage)
    {
        dead = true;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(deathMessage);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("\n> Press any key: ");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Used to change the value of food in a controlled way. Displays text to the player for stat change. Doesnt multiply negative values.
    public void ChangeFood(float value)
    {
        ConsoleColor color = value >= 0 ? ConsoleColor.Green : ConsoleColor.Red;
        float newMulti = value >= 0 ? foodMultiplier : 1;

        food += value * newMulti;
        food = Math.Clamp(food, 0, 100);
        Console.Clear();
        Console.ForegroundColor = color;
        Console.WriteLine($"{name}'s food changed by {value * newMulti}. Food is now {food}.");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("\n> Press any key: ");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Used to change the value of mood in a controlled way. Displays text to the player for stat change.
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

    // Used to change the value of energy in a controlled way. Displays text to the player for stat change. Doesnt multiply negative values.
    public void ChangeEnergy(float value)
    {
        ConsoleColor color = value >= 0 ? ConsoleColor.Green : ConsoleColor.Red;
        float newMulti = value >= 0 ? energyMultiplier : 1;

        energy += value * newMulti;
        energy = Math.Clamp(energy, 0, 100);
        Console.Clear();
        Console.ForegroundColor = color;
        Console.WriteLine($"{name}'s energy changed by {value * newMulti}. Energy is now {energy}.");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("\n> Press any key: ");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Used to change the value of money in a controlled way. Displays text to the player for stat change. Doesnt multiply negative values.
    // Going into debt with the car driving activity is intended!
    public void ChangeMoney(float value)
    {
        ConsoleColor color = value >= 0 ? ConsoleColor.Green : ConsoleColor.Red;
        float newMulti = value >= 0 ? moneyMultiplier : 1;
        string word = value >= 0 ? "earned" : "lost";

        money += value * newMulti;
        Console.Clear();
        Console.ForegroundColor = color;
        Console.WriteLine($"{name} has {word} {value * newMulti}$! Total money is now {money}.");
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

        ChangeFood(MathF.Round(-Math.Clamp(20f * (1 + age / 100), 0f, 50f)));

        // Checks if the cat has 0 in any stat, if so the pet dies. Displays a custom death message for each type of death.
        if (food <= 0)
        {
            Die($"{name} has died to starvation... what a glutenous cat >:(\nYour pet has died due to having no food");
        }
        else if (energy <= 0)
        {
            Die($"{name} became very tired and decided to go to permanent sleep (die)\nYour pet has died due to lack of energy");
        }
        else if (mood <= 0)
        {
            Die($"{name} gave you a sour face, and ran away. Never to be seen again...\nYour pet has died due to low mood");
        }
    }
}