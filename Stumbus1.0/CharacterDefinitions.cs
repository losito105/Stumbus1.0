namespace Stumbus1._0;

public class CharacterDefinitions
{
    public enum IV
    {
        PHY_ATK = 0,
        PHY_DEF = 1,
        ELM_ATK = 2,
        ELM_DEF = 3
    }

    // the values at index n in each of these lists correspond to the same character n

    private List<string> _names = new List<string>();

    // always health restoration, physical attack, elemental attack, random non-health IV boost, random non-health IV drain
    private List<Tuple<string, string, string, string, string>> _moveNames = new List<Tuple<string, string, string, string, string>>();

    // only relevant for non-health IV boost and non-health IV drain
    private List<Tuple<IV, IV>> _moveIVs = new List<Tuple<IV, IV>>();

    // health restoration (random 1-50): add value to selected character's health

    // physical attack (random 1-20):
    // if user's PHY ATK > target's PHY DEF -> add user's PHY ATK / 10
    // if user's PHY ATK < target's PHY DEF -> subtract target's PHY DEF / 10
    // if user's PHY ATK = target's PHY DEF -> use base value


    // elemental attack (random 1-20):
    // if user's ELM ATK > target's ELM DEF -> add user's ELM ATK / 10
    // if user's ELM ATK < target's ELM DEF -> subtract target's ELM DEF / 10
    // if user's ELM ATK = target's ELM DEF -> use base value

    // non-health IV boost (random 10-20): add value to target's IV (ally or self only)

    // non-health IV drain (random 10-20): subtract value from target's IV (enemy only)
    private List<Tuple<int, int, int, int, int>> _moveMagnitiudes = new List<Tuple<int, int, int, int, int>>();

    public CharacterDefinitions()
    {
        Random random = new Random();

        // this is an example of how we'll create a character
        _names.Add("Clorb Splerf");
        _moveNames.Add(new Tuple<string, string, string, string, string>(
            "Clorbus Healiarmus", 
            "Clorb Club", 
            "Icy Slerf Sandwich", 
            "Clorby Buff Sauce", 
            "Splerf Subtraction"
        ));
        Array values = Enum.GetValues(typeof(IV));
        
        IV boostedIV = (IV)values.GetValue(random.Next(values.Length));
        IV drainedIV = (IV)values.GetValue(random.Next(values.Length));
        _moveIVs.Add(new Tuple<IV, IV>(
            boostedIV,
            drainedIV
         ));
        _moveMagnitiudes.Add(new Tuple<int, int, int, int, int>(
            random.Next(1, 50),
            random.Next(1, 20),
            random.Next(1, 20),
            random.Next(10, 20),
            random.Next(10, 20)
        ));

        // TODO: create other characters here
        _names.Add("Glumby Glimbus");
        _names.Add("Jargon Pantry");
        _names.Add("Albaz McDroopo");
        _names.Add("Shiny Shorts Steven");
        _names.Add("Rhino Eggward");
        _names.Add("Quadratic Beans");
        _names.Add("Papyrus Carl");
        _names.Add("Jingleton Jackson");
        _names.Add("Peter Plural");
    }

    public class CharacterInfo
    {
        public string Name { get; set; }
        public Tuple<string, string, string, string, string> MoveNames { get; set; }
        public Tuple<IV, IV> MoveIVs { get; set; }
        public Tuple<int, int, int, int, int> MoveMagnitudes { get; set; }
    }

    public CharacterInfo? GetRandomCharacter()
    {
        // this will not be a problem for now since we have > 8 but will be once we add character swaps
        if (_names.Count == 0) return null;

        Random random = new Random();
        int idx = random.Next(0, _names.Count);

        return new CharacterInfo
        {
            Name = _names[idx],
            MoveNames = _moveNames[idx],
            MoveIVs = _moveIVs[idx],
            MoveMagnitudes = _moveMagnitiudes[idx]
        };
    }
}
