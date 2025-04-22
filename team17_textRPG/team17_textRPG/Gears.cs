using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team17_textRPG
{
    internal class Gears
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Effect { get; set; }
        public int Price { get; set; }
        public int Type { get; set; }

        public Gears(string name, string desc, int eff, int price, int type)
        {
            Name = name;
            Desc = desc;
            Effect = eff;
            Price = price;
            Type = type;
        }
    }
}
