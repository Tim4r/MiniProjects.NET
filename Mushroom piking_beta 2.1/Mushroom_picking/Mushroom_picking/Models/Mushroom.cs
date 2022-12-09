using System.Collections.Generic;

namespace Mushroom_picking.Models
{
    internal partial class Mushroom : Type
    {
        public int ID { get; set; }
        public string NameMushroom { get; set; }
        public string Edibility { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }

        public IEnumerable<Mushroom> DefaultPeople { get; internal set; }
    }
}
