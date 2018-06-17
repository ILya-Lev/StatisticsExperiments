using System.Collections.Generic;

namespace FellerProbability.MonteCarlo
{
    public class NagelSchreckenberg
    {
        private readonly int _maxV;

        public NagelSchreckenberg(int maxV)
        {
            _maxV = maxV;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="sample">if [j] == 0 - empty place; otherwise [j] == speed of current vehicle</param>
        public void Model(int steps, List<int> sample)
        {
            for (int i = 0; i < steps; i++)
            {

            }
        }
    }
}
