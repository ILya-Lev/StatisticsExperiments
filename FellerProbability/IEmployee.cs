using System;

namespace FellerProbability
{
    public interface IEmployee
    {
        bool IsPayDate(DateTime aDate);
        void Pay();
    }
}