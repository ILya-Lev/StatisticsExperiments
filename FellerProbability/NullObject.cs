using System;

namespace FellerProbability
{
    public class Employee : IEmployee
    {
        public static IEmployee Empty { get; } = new NullEmployee();
        public bool IsPayDate(DateTime aDate)
        {
            var nextDate = aDate.AddDays(1);
            return nextDate.Month == aDate.Month + 1
                   || nextDate.Year == aDate.Year + 1;
        }

        public void Pay()
        {
            Console.WriteLine($"You've been payed 3200 USD.");
        }

        private class NullEmployee : IEmployee
        {
            public bool IsPayDate(DateTime aDate) => false;

            public void Pay() { }
        }
    }
}
