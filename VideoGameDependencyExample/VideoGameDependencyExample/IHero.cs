using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameDependencyExample
{
    internal interface IHero
    {
        //void Attack(IWeapon weapon); --------- with using method
        void Attack();
    }
}
