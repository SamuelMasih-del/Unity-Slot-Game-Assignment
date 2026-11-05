using UnityEngine;

public static class WinCalculator
{
    // Symbol payouts - index = symbol type
    // 0: Cherry, 1: Lemon, 2: Bell, 3: Bar, 4: Seven, 5: Diamond
    private static int[] threeOfAKindPayout = { 50, 100, 200, 300, 500, 1000 };
    private static int twoOfAKindPayout = 20;

    public static int CalculateWin(int[] result, int betAmount, out string winType)
    {
        winType = "No Win";
        int win = 0;

        // Check 3 of a kind
        if (result[0] == result[1] && result[1] == result[2])
        {
            int symbol = result[0];
            win = threeOfAKindPayout[symbol] * betAmount / 50;
            winType = GetSymbolName(symbol) + " Jackpot!";

            // Special - 3 Diamonds = Mega Jackpot
            if (symbol == 5)
                winType = "MEGA JACKPOT! 3 Diamonds!";
        }
        // Check 2 of a kind
        else if (result[0] == result[1] || result[1] == result[2] || result[0] == result[2])
        {
            win = twoOfAKindPayout * betAmount / 50;
            winType = "Two Match!";
        }

        return win;
    }

    public static string GetSymbolName(int index)
    {
        string[] names = { "Cherry", "Lemon", "Bell", "Bar", "Seven", "Diamond" };
        if (index >= 0 && index < names.Length)
            return names[index];
        return "Unknown";
    }

    public static bool IsJackpot(int[] result)
    {
        return result[0] == result[1] && result[1] == result[2];
    }
}
