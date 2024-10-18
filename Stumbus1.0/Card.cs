namespace Stumbus1._0;

public abstract class Card
{
    public string Name { get; set; }
}

public class CharacterCard : Card
{
    public int Health { get; set; }
    public int PhysicalAttack { get; set; }
    public int PhysicalDefense { get; set; }
    public int ElementalAttack { get; set; }
    public int ElementalDefense { get; set; }

    public bool Alive { get; set; }

    public int UserInputNumber { get; set; }
    public string UserInputDisplay { get; set; }

    public CharacterCard()
    {
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

public class ConsumableCard : Card
{

}
