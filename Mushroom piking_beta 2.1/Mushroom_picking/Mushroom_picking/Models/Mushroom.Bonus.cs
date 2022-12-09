using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mushroom_picking.Models
{
    internal partial class Mushroom
    {
        public string TextID => ID.ToString() + "TEXT";
    }
}
