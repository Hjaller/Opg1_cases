using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg1_cases
{
    internal class Football
    {

        private const string _goal = "mål";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="goal"></param>
        /// <param name="passes"></param>
        /// <returns></returns>
        public string GoalOrPasses(string goal, int passes)
        {
            if (goal.ToLower() == _goal)
            {
                return "Olé olé olé!";
            }
            else
            {
                if (passes < 0)
                {
                    return "Man kan ikke have minus afleveringer";
                }
                else if (passes < 1)
                {
                    return "Shh";
                }
                else if (passes > 10)
                {
                    return "High five!!!";
                }

                else
                {
                    var str = "";
                    for (int i = 0; i < passes; i++) str += "Huh! ";
                    return str.TrimEnd();
                }

            }
        }
    }
}
