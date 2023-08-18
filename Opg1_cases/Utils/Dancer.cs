using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg1_cases
{
    internal class Dancer
    {
        public string? name { get; set; }
        public int? points { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="points"></param>
        public Dancer(string name, int points)
        {
            this.points = points;
            this.name = name;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dancer1"></param>
        /// <param name="dancer2"></param>
        /// <returns></returns>
        public static int operator +(Dancer dancer1, Dancer dancer2) => (int)(dancer1.points + dancer2.points);

    }
}
