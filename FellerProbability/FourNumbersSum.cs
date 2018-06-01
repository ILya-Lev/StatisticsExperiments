namespace FellerProbability
{
    public class FourNumbersSum
    {
        public int GetAmount(int threshold = 100)
        {
            var amount = 0;
            for (int a = 0; a <= threshold; a++)
            {
                for (int b = 0; b <= threshold; b++)
                {
                    for (int c = 0; c <= threshold; c++)
                    {
                        var d = threshold - a - b - c;
                        if (d >= 0 && d <= threshold)
                        {
                            ++amount;
                        }
                    }
                }
            }

            return amount;
        }
    }
}
