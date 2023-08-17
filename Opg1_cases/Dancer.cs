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
        public Dancer(string name, int points)
        {
            this.points = points;
            this.name = name;
        }

        public static int operator +(Dancer dancer1, Dancer dancer2) => (int)(dancer1.points + dancer2.points);
    }
}
