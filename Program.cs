namespace Stumbus1._0;

public class Program
{
    // Is it the red team's turn or not?
    private static bool _redTeamTurn { get; set; }

    // 0 - has not gone, 1 - has gone
    private static int[] _characterTurns { get; set; }

    private static bool TurnOver()
    {
        return _characterTurns[0] == 1 && _characterTurns[1] == 1 && _characterTurns[2] == 1 && _characterTurns[3] == 1;
    }

    // Prompt for per-character action. a = act, p = pass, l = lore.
    private const string _characterTurnUserInputPrompt = "[a][p][l]";

    // Is it the first time the game loop is running? Determines what UserInputDisplay to show.
    private static bool _drawingInitialGameState = true;

    private static bool _displayActingCharacterMoveset;
    private static int _actingCharacterIndex;

    private static void DrawGameState(List<CharacterCard> redTeam, List<CharacterCard> blackTeam)
    {
        // draw red team
        Console.WriteLine();
        Console.Write("RED TEAM");
        if (_redTeamTurn) Console.Write('*');
        Console.WriteLine();

        // draw red team characters and movesets
        foreach (CharacterCard card in redTeam)
        {
            Console.Write(" ____          ");
        }

        if (_redTeamTurn && _displayActingCharacterMoveset)
        {
            Console.Write($"{redTeam[_actingCharacterIndex].Name} Moves:");
        }
        Console.WriteLine();

        foreach (CharacterCard card in redTeam)
        {
            Console.Write("|    |         ");
        }

        if (_redTeamTurn && _displayActingCharacterMoveset)
        {
            Console.Write($"{redTeam[_actingCharacterIndex].MoveNames.Item1} (HP +{redTeam[_actingCharacterIndex].MoveMagnitudes.Item1})");
        }
        Console.WriteLine();

        foreach (CharacterCard card in redTeam)
        {
            if (card.Alive) Console.Write("o    o         ");
            else Console.Write("x    x         ");
        }

        if (_redTeamTurn && _displayActingCharacterMoveset)
        {
            Console.Write($"{redTeam[_actingCharacterIndex].MoveNames.Item2} (PHY ATK {redTeam[_actingCharacterIndex].MoveMagnitudes.Item2})");
        }
        Console.WriteLine();

        // draw red team IVs
        foreach (CharacterCard card in redTeam)
        {
            Console.Write($"HP:      {card.Health}    ");
            if (card.Health < 10) Console.Write(' ');
        }

        if (_redTeamTurn && _displayActingCharacterMoveset)
        {
            Console.Write($"{redTeam[_actingCharacterIndex].MoveNames.Item3} (ELM ATK {redTeam[_actingCharacterIndex].MoveMagnitudes.Item3})");
        }
        Console.WriteLine();

        foreach (CharacterCard card in redTeam)
        {
            Console.Write($"PHY ATK: {card.PhysicalAttack}    ");
            if (card.PhysicalAttack < 10) Console.Write(' ');
        }

        if (_redTeamTurn && _displayActingCharacterMoveset)
        {
            CharacterDefinitions characterDefinitions = new CharacterDefinitions();
            string ivString = characterDefinitions.IVToString(redTeam[_actingCharacterIndex].MoveIVs.Item1);
            Console.Write($"{redTeam[_actingCharacterIndex].MoveNames.Item4} ({ivString} +{redTeam[_actingCharacterIndex].MoveMagnitudes.Item4})");
        }
        Console.WriteLine();

        foreach (CharacterCard card in redTeam)
        {
            Console.Write($"PHY DEF: {card.PhysicalDefense}    ");
            if (card.PhysicalDefense < 10) Console.Write(' ');
        }

        if(_redTeamTurn && _displayActingCharacterMoveset)
        {
            CharacterDefinitions characterDefinitions = new CharacterDefinitions();
            string ivString = characterDefinitions.IVToString(redTeam[_actingCharacterIndex].MoveIVs.Item2);
            Console.Write($"{redTeam[_actingCharacterIndex].MoveNames.Item5} ({ivString} -{redTeam[_actingCharacterIndex].MoveMagnitudes.Item5})");
        }
        Console.WriteLine();

        foreach (CharacterCard card in redTeam)
        {
            Console.Write($"ELM ATK: {card.ElementalAttack}    ");
            if (card.ElementalAttack < 10) Console.Write(' ');
        }
        Console.WriteLine();

        foreach (CharacterCard card in redTeam)
        {
            Console.Write($"ELM DEF: {card.ElementalDefense}    ");
            if (card.ElementalDefense < 10) Console.Write(' ');
        }
        Console.WriteLine();

        // draw red team UserInputDisplays
        for (int i = 0; i < redTeam.Count; i++)
        {
            redTeam[i].UserInputNumber = i + 1;
            if (_drawingInitialGameState == true) redTeam[i].UserInputDisplay = $"[{i + 1}]            ";
            Console.Write(redTeam[i].UserInputDisplay);
        }
        Console.WriteLine();

        /* ------------------------------------------------------------------------------ */

        // draw black team
        Console.WriteLine();
        Console.Write("BLACK TEAM");
        if (!_redTeamTurn) Console.Write('*');
        Console.WriteLine();

        // draw black team characters
        foreach (CharacterCard card in blackTeam)
        {
            Console.Write(" ____          ");
        }
        Console.WriteLine();

        foreach (CharacterCard card in blackTeam)
        {
            Console.Write("|    |         ");
        }
        Console.WriteLine();

        foreach (CharacterCard card in blackTeam)
        {
            if (card.Alive) Console.Write("o    o         ");
            else Console.Write("x    x         ");
        }
        Console.WriteLine();

        // draw black team IVs
        foreach (CharacterCard card in blackTeam)
        {
            Console.Write($"HP:      {card.Health}    ");
            if (card.Health < 10) Console.Write(' ');
        }
        Console.WriteLine();

        foreach (CharacterCard card in blackTeam)
        {
            Console.Write($"PHY ATK: {card.PhysicalAttack}    ");
            if (card.PhysicalAttack < 10) Console.Write(' ');
        }
        Console.WriteLine();

        foreach (CharacterCard card in blackTeam)
        {
            Console.Write($"PHY DEF: {card.PhysicalDefense}    ");
            if (card.PhysicalDefense < 10) Console.Write(' ');
        }
        Console.WriteLine();

        foreach (CharacterCard card in blackTeam)
        {
            Console.Write($"ELM ATK: {card.ElementalAttack}    ");
            if (card.ElementalAttack < 10) Console.Write(' ');
        }
        Console.WriteLine();

        foreach (CharacterCard card in blackTeam)
        {
            Console.Write($"ELM DEF: {card.ElementalDefense}    ");
            if (card.ElementalDefense < 10) Console.Write(' ');
        }
        Console.WriteLine();

        // draw black team UserInputDisplays
        for (int i = 0; i < blackTeam.Count; i++)
        {
            blackTeam[i].UserInputNumber = i + 5;
            if (_drawingInitialGameState == true) blackTeam[i].UserInputDisplay = $"[{i + 5}]            ";
            Console.Write(blackTeam[i].UserInputDisplay);
        }
        _drawingInitialGameState = false;
        Console.WriteLine();
    }

    private static void GameLoop()
    {
        // init
        List<CharacterCard> redTeam = new List<CharacterCard>();
        for (int i = 0; i < 4; i++)
        {
            redTeam.Add(new CharacterCard());
        }

        List<CharacterCard> blackTeam = new List<CharacterCard>();
        for (int i = 0; i < 4; i++)
        {
            blackTeam.Add(new CharacterCard());
        }

        //_redTeamTurn = Random.Shared.Next(0, 2) == 1; // 50/50 chance of going first
        _redTeamTurn = true;
        _characterTurns = new int[4] { 0, 0, 0, 0};

        DrawGameState(redTeam, blackTeam);

        // persistent game loop
        while (true)
        {
            while (!TurnOver())
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                // red team's turn
                if (_redTeamTurn)
                {
                    // prompt for action
                    if (keyPressed.KeyChar == '1' || keyPressed.KeyChar == '2' || keyPressed.KeyChar == '3' || keyPressed.KeyChar == '4')
                    {
                        int userInputNumber = redTeam[keyPressed.KeyChar - '0' - 1].UserInputNumber;
                        redTeam[keyPressed.KeyChar - '0' - 1].UserInputDisplay = $"[{userInputNumber}]{_characterTurnUserInputPrompt}   ";
                        DrawGameState(redTeam, blackTeam);

                        // respond to action
                        ConsoleKeyInfo action = Console.ReadKey();

                        // handle pass action
                        if (action.KeyChar == 'p')
                        {
                            redTeam[keyPressed.KeyChar - '0' - 1].UserInputDisplay = redTeam[keyPressed.KeyChar - '0' - 1].UserInputDisplay.Replace(_characterTurnUserInputPrompt, "         ");
                            DrawGameState(redTeam, blackTeam);
                            _characterTurns[keyPressed.KeyChar - '0' - 1] = 1;
                            continue;
                        }

                        // handle act action
                        else if (action.KeyChar == 'a')
                        {
                            _displayActingCharacterMoveset = true;
                            _actingCharacterIndex = keyPressed.KeyChar - '0' - 1;
                            DrawGameState(redTeam, blackTeam);
                        }
                    }
                }

                // black team's turn
                else
                {
                    // prompt for action
                    if (keyPressed.KeyChar == '5' || keyPressed.KeyChar == '6' || keyPressed.KeyChar == '7' || keyPressed.KeyChar == '8')
                    {
                        int userInputNumber = blackTeam[keyPressed.KeyChar - '0' - 5].UserInputNumber;
                        blackTeam[keyPressed.KeyChar - '0' - 5].UserInputDisplay = $"[{userInputNumber}]{_characterTurnUserInputPrompt}   ";
                        DrawGameState(redTeam, blackTeam);

                        // respond to action
                        ConsoleKeyInfo action = Console.ReadKey();

                        // handle pass action
                        if (action.KeyChar == 'p')
                        {
                            blackTeam[keyPressed.KeyChar - '0' - 5].UserInputDisplay = blackTeam[keyPressed.KeyChar - '0' - 5].UserInputDisplay.Replace(_characterTurnUserInputPrompt, "         ");
                            DrawGameState(redTeam, blackTeam);
                            _characterTurns[keyPressed.KeyChar - '0' - 5] = 1;
                            continue;
                        }
                    }
                }
            }

            // reset for other team's turn
            _redTeamTurn = !_redTeamTurn;
            _characterTurns = new int[4] { 0, 0, 0, 0 };
            DrawGameState(redTeam, blackTeam);
        }
    }

    private static void Main(string[] args)
    {
        GameLoop();
    }
}