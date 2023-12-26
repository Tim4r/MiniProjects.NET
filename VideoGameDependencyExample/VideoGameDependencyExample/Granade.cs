using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameDependencyExample
{
    internal class Granade : IWeapon
    {
        public string Name { get; set; }

        public void AttackWithMe()
        {
            Console.WriteLine(Name + " sizzles for a moment and then explodes into a shower of deadly metal");
        }
    }
}
