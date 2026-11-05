public static class WinCalculator
{
    public static int CalculateWin(int a, int b, int c, int bet)
    {
        if (a == b && b == c)
        {
            if (a == 5) return 1000;
            if (a == 4) return 500;
            if (a == 3) return 300;
            if (a == 2) return 200;
            if (a == 1) return 100;
            if (a == 0) return 50;
        }
        if (a == b || b == c || a == c) return 20;
        return 0;
    }
}
