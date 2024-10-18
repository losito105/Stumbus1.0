namespace Stumbus1._0;

public class CharacterCard
{
    public int Health { get; set; }
    public int PhysicalAttack { get; set; }
    public int PhysicalDefense { get; set; }
    public int ElementalAttack { get; set; }
    public int ElementalDefense { get; set; }

    public bool Alive { get; set; }

    public int UserInputNumber { get; set; }
    public string UserInputDisplay { get; set; }

    public string Name { get; set; }
    public Tuple<string, string, string, string, string> MoveNames { get; set; }
    public Tuple<IV, IV> MoveIVs { get; set; }
    public Tuple<int, int, int, int, int> MoveMagnitudes { get; set; }

    public CharacterCard()
    {
        CharacterDefinitions characterDefs = new CharacterDefinitions();
        CharacterDefinitions.CharacterInfo characterInfo = characterDefs.GetRandomCharacter();
        Name = characterInfo.Name;
        MoveNames = characterInfo.MoveNames;
        MoveIVs = characterInfo.MoveIVs;
        MoveMagnitudes = characterInfo.MoveMagnitudes;

        Random random = new Random();
        Health = random.Next(0, 100);
        PhysicalAttack = random.Next(0, 100);
        PhysicalDefense = random.Next(0, 100);
        ElementalAttack = random.Next(0, 100);
        ElementalDefense = random.Next(0, 100);

        if (Health == 0) Alive = false;
        else Alive = true;
    }
}

public class ConsumableCard
{
    // TODO
}
